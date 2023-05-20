using CNCMachineAASDashboard.Server.SignalRHub;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using BaSyx.AAS.Client.Http;
using BaSyx.Models.Extensions;
using BaSyx.Models.Core.AssetAdministrationShell.Generics;
using BaSyx.Utils.ResultHandling;
using CNCMachineAASDashboard.Shared.Models;
using System.Text.Json;

using System;
//using BaSyx.Models.Core.AssetAdministrationShell.Implementations;

using Newtonsoft.Json;
using System.Collections.ObjectModel;
//using BaSyx.Models.Core.AssetAdministrationShell.Implementations;
//using BaSyx.Models.Core.AssetAdministrationShell.Implementations;


namespace CNCMachineAASDashboard.Server.Backgroundservice
{
    public class BackgroundProcess:BackgroundService
    {
        //  private readonly HttpClient _httpClient;


        private readonly ILogger<BackgroundProcess> _logger;
        private readonly IHubContext<AAShub> _hubContext;
        private readonly string Hostaddress;
        


        public BackgroundProcess(ILogger<BackgroundProcess> logger, IServiceProvider serviceProvider,IHubContext<AAShub> hubContext )
        {
            

            _logger = logger;

            _hubContext = hubContext;

                
        }
        //public static event EventHandler? DataGot;
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                    AASModel _model = new AASModel();
                    AssetAdministrationShellHttpClient clientAAS = new AssetAdministrationShellHttpClient(new Uri(_model.ServerEndpoint));
                    //AssetAdministrationShellHttpClient clientAAS = new AssetAdministrationShellHttpClient(new Uri("  http://192.168.184.206:5180"));

                    
                    IResult<IAssetAdministrationShell> result = clientAAS.RetrieveAssetAdministrationShell();
                    Console.WriteLine(result.Entity.GetType());
                    if (result == null)
                    {   
                        Console.WriteLine("AAS data not received");
                    }
                    //var a = result.Entity[]
                    else 
                    {
                        IAssetAdministrationShell AASGetData = result.Entity;
                        var AASData = AASGetData as object;
                        string jsonSerialized = JsonConvert.SerializeObject(AASGetData);
                        Console.WriteLine(jsonSerialized);
                        //var obj = JsonConvert.DeserializeObject <AssetAdministrationShell>(jsonSerialized);
                        //Console.WriteLine(obj);

                        //var data = result.Entity.ToJson();
                        //var AASData = JsonSerializer.Deserialize<AASModel>(data);

                        await _hubContext.Clients.All.SendAsync("AASdataSend", jsonSerialized);
                        //await _hubContext.Clients.All.SendAsync("dataSend", AASData);
                        Console.WriteLine($"{result.Entity.IdShort} dataSent to hub");
                        //Console.WriteLine(data);
                        
                    };

                    //var Submodels = clientAAS.RetrieveSubmodels();
                    //string jsonSM = JsonConvert.SerializeObject(Submodels.Entity);
                    //var Jsonobj = JsonConvert.DeserializeObject<object>(jsonSM);
                    //var Js = JsonConvert.DeserializeObject<List<Submodel>>(Jsonobj.ToString());
                    //Console.WriteLine(Jsonobj);

                   


                    var MaintenanceSM = clientAAS.RetrieveSubmodel("MaintenanceSubmodel");
                   
               
                    if (MaintenanceSM == null)
                    {
                        Console.WriteLine("Maintenance data not received");
                    }

                    else
                    {
                        var Data = MaintenanceSM.Entity.ToJson();
                        var MaintenanceData = System.Text.Json.JsonSerializer.Deserialize<Submodel>(Data);
                        await _hubContext.Clients.All.SendAsync("MaintenancedataSend", MaintenanceData);
                        Console.WriteLine($"{MaintenanceSM.Entity.IdShort} dataSent to hub");
                        //Console.WriteLine(Data);

                    };
                    var OperationalSM = clientAAS.RetrieveSubmodel("OperationalDataSubmodel");
                    
                    if (OperationalSM == null)
                    {
                        Console.WriteLine("Operational data not received");
                    }

                    else
                    {
                        var Data = OperationalSM.Entity.ToJson(); 
                        var OperationalData = System.Text.Json.JsonSerializer.Deserialize<Submodel>(Data);
                        await _hubContext.Clients.All.SendAsync("OperationaldataSend", OperationalData);
                        Console.WriteLine($"{OperationalSM.Entity.IdShort} dataSent to hub");
                        //Console.WriteLine(Data);

                    };
                    await Task.Delay(1000);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Disconnected");
                    ex.ToString();
                    await Task.Delay(1000);
                }


            }


        }
    }
}
