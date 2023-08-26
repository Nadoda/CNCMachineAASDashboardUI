using BaSyx.AAS.Client.Http;


namespace CNCMachineAASDashboard.Server.AASHttpClient

{
    
    public class AASClient 
    {
       public readonly AssetAdministrationShellHttpClient aasclient;
       public string? ServerEndpoint { get; set; } = Environment.GetEnvironmentVariable("ASPNETCORE_APIURL");

        public AASClient()
        {
           
            aasclient = new AssetAdministrationShellHttpClient(new Uri(ServerEndpoint));
        }


    }


}
