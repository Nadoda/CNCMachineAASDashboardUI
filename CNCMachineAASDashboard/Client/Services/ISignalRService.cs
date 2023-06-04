namespace CNCMachineAASDashboard.Client.Services
{
    public interface ISignalRService
    {
        string AASSerializedData { get; }
        Task StartConnection();
        Task StopConnection();

    }
}
