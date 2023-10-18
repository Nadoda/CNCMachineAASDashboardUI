using BaSyx.AAS.Client.Http;
using Microsoft.AspNetCore.SignalR;

namespace CNCMachineAASDashboard.Server.AASHttpClient

{
    
    public class AASClient 
    {
        public  AssetAdministrationShellHttpClient? aasclient { get; private set; }
       public string? ServerEndpoint { get; set; } 
        public AASClient()
        {
            CreateClientInstance();
          
        }
        private void CreateClientInstance()
        {
            ServerEndpoint = Environment.GetEnvironmentVariable("AASServer_Address");
            if (ServerEndpoint == "")
            {
                Console.WriteLine("------------------------------------------------------------------------>");
                Console.WriteLine("UI doesn't have an established connection with an AAS Server!");
                Console.WriteLine("------------------------------------------------------------------------>");
                Console.WriteLine("Please create an instance of Docker image by specifying the AAS Server endpont address with which this UI " +
                    "is going to connect, For Ex.:-");
                Console.WriteLine("");
                Console.WriteLine("----> docker run -p 8001:80 -e AASServer_Address=\"http://192.168.2.186:5180\" -d  ajaykumarnadoda/cncmachineaasdashboardserver");
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------------------------------");
            }
            else
            { 
                aasclient = new AssetAdministrationShellHttpClient(new Uri(ServerEndpoint));
               
            }
        }
        
    }


}
