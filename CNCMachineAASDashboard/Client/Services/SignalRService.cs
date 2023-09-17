using CNCMachineAASDashboard.Shared.Models.AAS;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Submodel = CNCMachineAASDashboard.Shared.Models.AAS.Submodel;
using SubmodelElement = CNCMachineAASDashboard.Shared.Models.AAS.SubmodelElement;

namespace CNCMachineAASDashboard.Client.Services
{

    public class SignalRService : ISignalRService
    {
        private static HubConnection? hubConnection;
        private readonly NavigationManager NavigationManager;
        public bool IsConnected { get { return hubConnection?.State == HubConnectionState.Connected; } }

        public event Action<AASModel>? OnReceivedAAS;
        public event Action<Submodel>? OnReceivedMaintenance;
        public event Action<Submodel>? OnReceivedOperational;
        public event Action<string>? OnReceivedMessage;
        public event Action<SubmodelElement>? OnOperatingHourSE;
        public event Action<SubmodelElement>? OnMaintenaceWarningSE;
        public event Action<SubmodelElement>? OnMaintenanceThresholdSE;
        public event Action<SubmodelElement>? OnMaintenaceWarning2SE;
        public event Action<SubmodelElement>? OnMaintenanceThreshold2SE;
        public event Action<SubmodelElement>? OnMaintenaceWarning3SE;
        public event Action<SubmodelElement>? OnMaintenanceThreshold3SE;
        public event Action<SubmodelElement>? OnOrderStatusSE;
        public event Action<SubmodelElement>? OnRetrievedSE;

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
            hubConnection.On<SubmodelElement>("OperatingHourSESend", data =>
            {
                OnOperatingHourSE?.Invoke(data);
            });
            hubConnection.On<SubmodelElement>("MaintenanceWarningSESend", data =>
            {
                OnMaintenaceWarningSE?.Invoke(data);
            });
            hubConnection.On<SubmodelElement>("MaintenanceThresholdSESend", data =>
            {
                
                OnMaintenanceThresholdSE?.Invoke(data);
            });
            hubConnection.On<SubmodelElement>("MaintenanceWarning2SESend", data =>
            {
                OnMaintenaceWarning2SE?.Invoke(data);
            });
            hubConnection.On<SubmodelElement>("MaintenanceThreshold2SESend", data =>
            {

                OnMaintenanceThreshold2SE?.Invoke(data);
            });
            hubConnection.On<SubmodelElement>("MaintenanceWarning3SESend", data =>
            {
                OnMaintenaceWarning3SE?.Invoke(data);
            });
            hubConnection.On<SubmodelElement>("MaintenanceThreshold3SESend", data =>
            {

                OnMaintenanceThreshold3SE?.Invoke(data);
            });
            hubConnection.On<SubmodelElement>("ActualOrderStatusSESend", data =>
            {
                OnOrderStatusSE?.Invoke(data);
            });

            hubConnection.On<SubmodelElement>("RetrieveSESend", data =>
            {
                OnRetrievedSE?.Invoke(data);

            });

        }
        public async Task StartConnection()
        {

            await hubConnection.StartAsync();
        }
        public async Task StopConnection()
        {

            await hubConnection.StopAsync();
        }
        public async Task UpdateServerValue(string SubmodelId, string SeIdShortPath,string value)
        {
            await hubConnection.InvokeAsync("UpdateToServer", SubmodelId,SeIdShortPath, value);
        }
        public async Task RetrieveSE(string SubmodelId, string SeIdShortPath)
        {
            await hubConnection.InvokeAsync("RetrieveSE", SubmodelId, SeIdShortPath);
            
           
        }
    }

}
