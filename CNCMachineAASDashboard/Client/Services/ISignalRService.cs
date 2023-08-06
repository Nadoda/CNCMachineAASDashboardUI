using CNCMachineAASDashboard.Shared.Models.AAS;

namespace CNCMachineAASDashboard.Client.Services
{
    public interface ISignalRService
    {
        event Action<AASModel>? OnReceivedAAS;
        event Action<Submodel>? OnReceivedMaintenance;
        event Action<Submodel>? OnReceivedOperational;
        event Action<string>? OnReceivedMessage;
        bool IsConnected { get; }
        Task UpdateServerValue(string address, string value);
        Task StartConnection();
    }
}