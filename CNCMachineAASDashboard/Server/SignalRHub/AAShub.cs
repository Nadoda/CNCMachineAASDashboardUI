using Microsoft.AspNetCore.SignalR;
using CNCMachineAASDashboard.Shared.Models;
using BaSyx.Models.Core.AssetAdministrationShell.Implementations;
using BaSyx.Models.Core.AssetAdministrationShell.Generics;
using CNCMachineAASDashboard.Server.ClientToAASServer;

namespace CNCMachineAASDashboard.Server.SignalRHub
{
    public class AAShub:Hub
    {
        private readonly IClientToAAS_Server clientToAAS_Server;

        public AAShub(IClientToAAS_Server clientToAAS_Server)
        {
            this.clientToAAS_Server = clientToAAS_Server;
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
        public async Task UpdateToServer(string address, string value)
        {
            await clientToAAS_Server.UpdateValue(address, value);
            //await Clients.All.SendAsync("Message", address, value);
        }
    }
}
