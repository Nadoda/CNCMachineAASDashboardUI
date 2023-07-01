using BaSyx.Models.Core.AssetAdministrationShell.Implementations;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.AspNetCore.Http.Connections;
using Newtonsoft.Json;
using System.Text;

namespace CNCMachineAASDashboard.Server.SignalRHub
{
    public class ConnectionAPI: PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var receivedObject = JsonConvert.DeserializeObject<Submodel>(data);

            // Handle the received object and send it back to the client
            
            var responseBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(receivedObject));
            //return Connection.Send(connectionId, receivedObject);
            return Connection.Broadcast(receivedObject);
        }
    }
}
