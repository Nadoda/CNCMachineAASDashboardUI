using System.Text;

namespace CNCMachineAASDashboard.Server.ClientToAASServer
{
    public interface IClientToAAS_Server
    {
        Task<bool> UpdateValue(string Address, string Value);

    }
    public class AASClient : IClientToAAS_Server
    {
        private readonly HttpClient _httpClient;


        public AASClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<bool> UpdateValue(string Address, string Value)
        {
            var UpdateValue = new StringContent(Value, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(Address, UpdateValue);
            return response.IsSuccessStatusCode;
        }


    }


}
