using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace CNCMachineAASDashboard.Client.Services
{
    public class SignalRService : ISignalRService
    {
        public string AASSerializedData { get; private set; }
        private HubConnection hubConnection;
        private readonly NavigationManager _navigationManager;
        public SignalRService(NavigationManager navigationManager) 
        {
            _navigationManager = navigationManager;
            hubConnection = new HubConnectionBuilder().WithUrl(_navigationManager.ToAbsoluteUri("/dataSend")).Build();
            hubConnection.On<string>("AASdataSend", ReceiveData);
        }


        private void ReceiveData(string serializedData)
        {
            AASSerializedData = serializedData;
        }



        public async Task StartConnection()
        {
            await hubConnection.StartAsync();
        }

        public async Task StopConnection()
        {
            await hubConnection.StopAsync();
        }
    }
}
