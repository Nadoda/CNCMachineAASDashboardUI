using Microsoft.AspNetCore.SignalR;
using BaSyx.Models.Core.AssetAdministrationShell.Implementations;
using CNCMachineAASDashboard.Server.AASHttpClient;
using Microsoft.AspNetCore.SignalR.Client;
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
        public async Task UpdateToServer(string SubmodelId, string SeIdShortPath, string value)  // Use to update the SubmodelElement value from the UI (method gets invoked from the UI)
        {
            await Task.Run(() => { _Client.aasclient.UpdateSubmodelElementValue(SubmodelId, SeIdShortPath, new ElementValue(value)); });


        }
        public async Task RetrieveSE(string SubmodelId, string SeIdShortPath)      // currently not in use
        {
            var result = _Client.aasclient.RetrieveSubmodelElement(SubmodelId, SeIdShortPath);
            var Deserialise = JsonConvert.DeserializeObject<SubmodelElement>(result.Entity.ToJson());
            await Clients.All.SendAsync("RetrieveSESend", Deserialise);
          
        }

        /*
         The code below is currently commented out as the purpose of the defined methods on the hub side is  
         to manage communications (method invocations) from the client to the server in the ASP.NET Core project.

         However, in the current scenario, data is received from the AAS server, and the primary 
         functionality involves pushing this received data from the server project (ASP.NET Core) to the client.

         The following methods, intended for client-to-server communication, are not 
         applicable in this context. The server now solely focuses on receiving data from the AAS server 
         and forwarding it to the client.

         [SendData]
         [SendMaintenanceData]
         [SendOperationalData]
         [SendOperatingHourData]
         [SendMaintenanceWarningData]
         [SendMaintenanceThresholdData]
         [SendMaintenanceWarning2Data]
         [SendMaintenanceThreshold2Data]
         [SendMaintenanceWarning3Data]
         [SendMaintenanceThreshold3Data]
         [SendActualOrderStatusData]
        

         Note: This comment provides an overview of the hub's functionality and clarifies the 
         current purpose of the commented-out methods.
      */



        //public async Task SendData(object data)
        //{
        //    await Clients.All.SendAsync("AASdataSend", data);
        //}
        //public async Task SendMaintenanceData(object data)
        //{
        //    await Clients.All.SendAsync("MaintenancedataSend", data);
        //}
        //public async Task SendOperationalData(object data)
        //{
        //    await Clients.All.SendAsync("OperationaldataSend", data);
        //}
        //public async Task SendOperatingHourData(object data)
        //{
        //    await Clients.All.SendAsync("OperatingHourSESend", data);
        //}
        //public async Task SendMaintenanceWarningData(object data)
        //{
        //    await Clients.All.SendAsync("MaintenanceWarningSESend", data);
        //}
        //public async Task SendMaintenanceThresholdData(object data)
        //{
        //    await Clients.All.SendAsync("MaintenanceThresholdSESend", data);
        //}
        //public async Task SendMaintenanceWarning2Data(object data)
        //{
        //    await Clients.All.SendAsync("MaintenanceWarning2SESend", data);
        //}
        //public async Task SendMaintenanceThreshold2Data(object data)
        //{
        //    await Clients.All.SendAsync("MaintenanceThreshold2SESend", data);
        //}
        //public async Task SendMaintenanceWarning3Data(object data)
        //{
        //    await Clients.All.SendAsync("MaintenanceWarning3SESend", data);
        //}
        //public async Task SendMaintenanceThreshold3Data(object data)
        //{
        //    await Clients.All.SendAsync("MaintenanceThreshold3SESend", data);
        //}
        //public async Task SendActualOrderStatusData(object data)
        //{
        //    await Clients.All.SendAsync("ActualOrderStatusSESend", data);
        //}



    }
}
