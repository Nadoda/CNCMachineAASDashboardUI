using Microsoft.AspNetCore.SignalR;
using CNCMachineAASDashboard.Shared.Models;
using BaSyx.Models.Core.AssetAdministrationShell.Implementations;
using BaSyx.Models.Core.AssetAdministrationShell.Generics;
using BaSyx.Utils.ResultHandling;

namespace CNCMachineAASDashboard.Server.SignalRHub
{
    public class AAShub:Hub
    {
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
    }
}
