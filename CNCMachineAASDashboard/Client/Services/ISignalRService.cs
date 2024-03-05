
using CNCMachineAASDashboard.Shared.Models.AAS;
using Submodel = CNCMachineAASDashboard.Shared.Models.AAS.Submodel;
using SubmodelElement = CNCMachineAASDashboard.Shared.Models.AAS.SubmodelElement;

namespace CNCMachineAASDashboard.Client.Services
{
    public interface ISignalRService
    {
        event Action<AASModel>? OnReceivedAAS;
        event Action<Submodel>? OnReceivedMaintenance;
        event Action<Submodel>? OnReceivedOperational;
        event Action<string>? OnReceivedMessage;
        event Action<SubmodelElement>? OnOperatingHourSE;
        event Action<SubmodelElement>? OnMaintenaceWarningSE;
        event Action<SubmodelElement>? OnMaintenanceThresholdSE;
        event Action<SubmodelElement>? OnOrderStatusSE;
        event Action<SubmodelElement>? OnMaintenaceWarning2SE;
        event Action<SubmodelElement>? OnMaintenanceThreshold2SE;
        event Action<SubmodelElement>? OnMaintenaceWarning3SE;
        event Action<SubmodelElement>? OnMaintenanceThreshold3SE;
        event Action<SubmodelElement>? OnMaintenaceWarning4SE;
        event Action<SubmodelElement>? OnMaintenanceThreshold4SE;
        event Action<SubmodelElement>? OnRetrievedSE;
        event Action<dynamic>? OnAASServer_Address;
        bool IsConnected { get; }
        
        Task UpdateServerValue(string SubmodelId, string SeIdShortPath, string value);
        Task RetrieveSE(string SubmodelId, string SeIdShortPath);
        Task StartConnection();
        Task StopConnection();
    }
}