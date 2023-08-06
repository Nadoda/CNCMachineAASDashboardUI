using CNCMachineAASDashboard.Server.SignalRHub;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using BaSyx.AAS.Client.Http;
using BaSyx.Models.Extensions;
using BaSyx.Models.Core.AssetAdministrationShell.Generics;
using BaSyx.Utils.ResultHandling;
using System.Text.Json;

using System;


using Newtonsoft.Json;
using System.Collections.ObjectModel;
using BaSyx.Models.Core.Common;


using CNCMachineAASDashboard.Shared.Models.AAS;
using BaSyx.Models.Core.AssetAdministrationShell.Implementations;
using Submodel = CNCMachineAASDashboard.Shared.Models.AAS.Submodel;
using System.Runtime.Serialization.Formatters.Binary;

//using BaSyx.Models.Core.AssetAdministrationShell.Implementations;


namespace CNCMachineAASDashboard.Server.Backgroundservice
{
    public class BackgroundProcess : BackgroundService
    {



        private readonly ILogger<BackgroundProcess> _logger;
        private readonly IHubContext<AAShub> _hubContext;

        private static AssetAdministrationShellHttpClient clientAAS;
        private string? ServerEndpoint = Environment.GetEnvironmentVariable("ASPNETCORE_APIURL");
        public BackgroundProcess(ILogger<BackgroundProcess> logger, IHubContext<AAShub> hubContext)
        {


            _logger = logger;

            _hubContext = hubContext;

            clientAAS = new AssetAdministrationShellHttpClient(new Uri(ServerEndpoint));

        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {

                    IResult<IAssetAdministrationShell> result = clientAAS.RetrieveAssetAdministrationShell();
                    //Console.WriteLine(result.Entity.GetType());
                    if (result == null)
                    {
                        Console.WriteLine("AAS data not received");
                        Console.WriteLine(result?.GetType());
                    }
                    //var a = result.Entity[]
                    else
                    {
                        var AASGetData = result.Entity.ToJson();
                        Console.WriteLine(AASGetData);

                        // Console.WriteLine(AASGetData.Asset.IdShort);
                        // string jsonSerialized = JsonConvert.SerializeObject(AASGetData);
                        //Console.WriteLine(jsonSerialized);

                        var obj = JsonConvert.DeserializeObject<AASModel>(AASGetData);
                        //Console.WriteLine(obj);

                        //   var data = result.Entity.ToJson();
                        // var AASData = System.Text.Json.JsonSerializer.Deserialize<AASModel>(jsonSerialized);



                        await _hubContext.Clients.All.SendAsync("AASdataSend", obj);

                        Console.WriteLine($"CNCMAchineAAS dataSent to hub");
                        //Console.WriteLine(data);
                    };





                    var MaintenanceSM = clientAAS.RetrieveSubmodel("MaintenanceSubmodel");

                    //IElementContainer<ISubmodelElement> SEs = MaintenanceSM.Entity.SubmodelElements;
                    //var MData = JsonConvert.SerializeObject(MaintenanceSM.Entity);

                    //var MData = MaintenanceSM.Entity.ToJson();
                    //var MaintenanceData = System.Text.Json.JsonSerializer.Deserialize<BaSyx.Models.Core.AssetAdministrationShell.Implementations.Submodel>(MData);
                    //var MaintenanceData = JsonConvert.DeserializeObject<BaSyx.Models.Core.AssetAdministrationShell.Implementations.Submodel>(MData);


                    // var se = clientAAS.RetrieveSubmodelElement("MaintenanceSubmodel","Maintenance_1");
                    // var SEd= se.Entity.ToJson();
                    // //var SEd = JsonConvert.SerializeObject(se.Entity);
                    // var ata = JsonConvert.DeserializeObject<SubmodelElementCollection>(SEd);
                    // //var ata = System.Text.Json.JsonSerializer.Deserialize<SubmodelElementCollection>(SEd);



                    if (MaintenanceSM == null)
                    {
                        Console.WriteLine("Maintenance data not received");
                    }

                    else
                    {
                        var Data = MaintenanceSM.Entity.ToJson();
                        Console.WriteLine(Data);
                        var MaintenanceData = System.Text.Json.JsonSerializer.Deserialize<Submodel>(Data);
                        await _hubContext.Clients.All.SendAsync("MaintenancedataSend", MaintenanceData);
                        Console.WriteLine($"{MaintenanceSM.Entity.IdShort} dataSent to hub");
                        //Console.WriteLine(Data);

                        ////// Code to manage MaintenanceHistory Data of Maintenance_3 SE (Useful Logic) //////////

                        //var se3 = MaintenanceData.submodelElements?.Find(n => n.idShort == "Maintenance_3");
                        //var MHsev = se3.value.Find(n => n.idShort == "MaintenanceHistory");
                        //var mr1 = MHsev.value.Find(n => n.idShort == "MaintenanceRecord_1");
                        //Console.WriteLine(mr1.value is JsonElement);
                        //Console.WriteLine(mr1.value.ToString());
                        //var obj = System.Text.Json.JsonSerializer.Deserialize<List<ValueItem2>>(mr1.value.ToString());
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
