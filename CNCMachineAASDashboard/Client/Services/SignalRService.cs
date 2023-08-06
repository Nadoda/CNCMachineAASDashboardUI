using CNCMachineAASDashboard.Shared.Models.AAS;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;


namespace CNCMachineAASDashboard.Client.Services
{

    public class SignalRService : ISignalRService
    {
        private static HubConnection hubConnection;
        private readonly NavigationManager NavigationManager;
        public bool IsConnected { get { return hubConnection?.State == HubConnectionState.Connected; } }

        public event Action<AASModel>? OnReceivedAAS;
        public event Action<Submodel>? OnReceivedMaintenance;
        public event Action<Submodel>? OnReceivedOperational;
        public event Action<string>? OnReceivedMessage;

        public SignalRService(NavigationManager navigationManager)
        {
            this.NavigationManager = navigationManager;

            hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/dataSend")).Build();

            hubConnection.On<AASModel>("AASdataSend", data =>
            {

                OnReceivedAAS?.Invoke(data);

            });
            hubConnection.On<Submodel>("MaintenancedataSend", data =>
            {

                OnReceivedMaintenance?.Invoke(data);
            });
            hubConnection.On<Submodel>("OperationaldataSend", data =>
            {
                OnReceivedOperational?.Invoke(data);
            });

            hubConnection.On<string>("Message", data =>
            {

                OnReceivedMessage?.Invoke(data);

            });

        }
        public async Task StartConnection()
        {

            await hubConnection.StartAsync();
        }

        public async Task UpdateServerValue(string address,string value)
        {
            await hubConnection.InvokeAsync("UpdateToServer", address,value);
        }
    }

}
