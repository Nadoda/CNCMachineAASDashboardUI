using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace CNCMachineAASDashboard.Client.Services
{
    public static class NavigationManagerExtensions
    {
        public static async Task NavigationTonewWindow(this NavigationManager navigation,IJSRuntime jSRuntime,string url,String Content)
        {
            await jSRuntime.InvokeAsync<object>("NavigationManagerExtensions.openInNewWindow", url,Content);
        }
    }
}
