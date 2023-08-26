
namespace CNCMachineAASDashboard.Client.Services
{
    public class NotificationService
    {
        public event Action? OnReceivedNotification;

        public string? Message { get; set; }

        public void Notify(string message)
        {
            Message= message;   

            OnReceivedNotification?.Invoke();
        }
    }
}
