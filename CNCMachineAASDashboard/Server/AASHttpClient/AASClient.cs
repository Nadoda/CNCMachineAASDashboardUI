using BaSyx.AAS.Client.Http;
using Microsoft.Extensions.Configuration;


namespace CNCMachineAASDashboard.Server.AASHttpClient

{
    
    public class AASClient 
    {
       public readonly AssetAdministrationShellHttpClient aasclient;
       public string? ServerEndpoint { get; set; } 

       private readonly IConfiguration _Configuration;
        public AASClient(IConfiguration Configuration)
        {
           _Configuration = Configuration;
           ServerEndpoint= _Configuration.GetValue<string>("HelloAAS_API");
           aasclient = new AssetAdministrationShellHttpClient(new Uri(ServerEndpoint));
        }


    }


}
