using Microsoft.AspNetCore.SignalR;
using CNCMachineAASDashboard.Shared.Models;
using BaSyx.Models.Core.AssetAdministrationShell.Implementations;
using BaSyx.Models.Core.AssetAdministrationShell.Generics;
using CNCMachineAASDashboard.Server.AASHttpClient;
using BaSyx.AAS.Client.Http;
using Microsoft.AspNetCore.SignalR.Client;
using CNCMachineAASDashboard.Shared.Models.AAS;
using BaSyx.Utils.ResultHandling;
using Newtonsoft.Json;
using BaSyx.Models.Extensions;
using SubmodelElement = CNCMachineAASDashboard.Shared.Models.AAS.SubmodelElement;

namespace CNCMachineAASDashboard.Server.SignalRHub
{
    public class AAShub:Hub
    {

        private readonly AASClient _Client;

        public AAShub(AASClient Client)
        {
            _Client = Client;
        }
        public async Task SendData(object data)
        {
            await Clients.All.SendAsync("AASdataSend", data);
        }
        public async Task SendMaintenanceData(object data)
        {
            await Clients.All.SendAsync("MaintenancedataSend", data);
        }
        public async Task SendOperationalData(object data)
        {
            await Clients.All.SendAsync("OperationaldataSend", data);
        }
        public async Task SendOperatingHourData(object data)
        {
            await Clients.All.SendAsync("OperatingHourSESend", data);
        }
        public async Task SendMaintenanceWarningData(object data)
        {
            await Clients.All.SendAsync("MaintenanceWarningSESend", data);
        }
        public async Task SendMaintenanceThresholdData(object data)
        {
            await Clients.All.SendAsync("MaintenanceThresholdSESend", data);
        }
        public async Task SendMaintenanceWarning2Data(object data)
        {
            await Clients.All.SendAsync("MaintenanceWarning2SESend", data);
        }
        public async Task SendMaintenanceThreshold2Data(object data)
        {
            await Clients.All.SendAsync("MaintenanceThreshold2SESend", data);
        }
        public async Task SendMaintenanceWarning3Data(object data)
        {
            await Clients.All.SendAsync("MaintenanceWarning3SESend", data);
        }
        public async Task SendMaintenanceThreshold3Data(object data)
        {
            await Clients.All.SendAsync("MaintenanceThreshold3SESend", data);
        }
        public async Task SendActualOrderStatusData(object data)
        {
            await Clients.All.SendAsync("ActualOrderStatusSESend", data);
        }
        public async Task UpdateToServer(string SubmodelId, string SeIdShortPath, string value)
        {
            await Task.Run(() => { _Client.aasclient.UpdateSubmodelElementValue(SubmodelId, SeIdShortPath, new ElementValue(value)); });
            
            
        }
        public async Task RetrieveSE(string SubmodelId, string SeIdShortPath)
        {
             var result=_Client.aasclient.RetrieveSubmodelElement(SubmodelId, SeIdShortPath);          
            var Deserialise = JsonConvert.DeserializeObject<SubmodelElement>(result.Entity.ToJson());
             await Clients.All.SendAsync("RetrieveSESend", Deserialise);

        }
        

    }
}
