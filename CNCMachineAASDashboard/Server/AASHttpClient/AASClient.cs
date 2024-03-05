using BaSyx.AAS.Client.Http;
using Microsoft.AspNetCore.SignalR;
using static System.Net.WebRequestMethods;

namespace CNCMachineAASDashboard.Server.AASHttpClient

{
    
    public class AASClient 
    {
        public  AssetAdministrationShellHttpClient? aasclient { get; private set; }
        public AASClient()
        {
            CreateClientInstance();
          
        }
        private void CreateClientInstance()
        {
           string? ServerEndpoint = Environment.GetEnvironmentVariable("AASServer_Address");

            if (ServerEndpoint == null)
            {
                Console.WriteLine("------------------------------------------------------------------------>");
                Console.WriteLine("UI doesn't have an established connection with an AAS Server!");
                Console.WriteLine("------------------------------------------------------------------------>");
                Console.WriteLine("-----> Methods to establish connection with an AAS Server \r\n");
                Console.WriteLine("***** 1st Method (With Docker) *****");
                Console.WriteLine("->Please create an instance of Docker image by specifying the AAS Server endpont address with which this UI " +
                    "is going to connect, For Ex.:-");
                Console.WriteLine("->docker run -p 8001:80 -e AASServer_Address=\"http://192.168.2.186:5180\" -d  ajaykumarnadoda/cncmachineaasdashboardserver \r\n");
                Console.WriteLine("***** 2nd Method (With CLI (Command Line Interface)) *****");
                Console.WriteLine("->Set the environment variable first and then run the project with \"docker run\" command");
                Console.WriteLine("->The instructions for configuring an environment variable and running a project are provided with quotation marks for both CMD and PowerShell as shown below...\r\n");
                Console.WriteLine("->with cmd, for ex. -----> \"set AASServer_Address=http://127.0.0.1:5180\" and then \"docker run\"");
                Console.WriteLine("->with powershell, for ex.-----> \"$env:AASServer_Address=\"http://127.0.0.1:5180\";dotnet run\"");
                Console.WriteLine("------------------------------------------------------------------------");
            }
            else
            {
                if (ServerEndpoint != null) { aasclient = new AssetAdministrationShellHttpClient(new Uri(ServerEndpoint)); }
                               
            }
        }
        
    }


}
