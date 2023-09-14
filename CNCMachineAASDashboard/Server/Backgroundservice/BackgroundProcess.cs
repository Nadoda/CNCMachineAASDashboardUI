using CNCMachineAASDashboard.Server.SignalRHub;
using Microsoft.AspNetCore.SignalR;
using BaSyx.Models.Extensions;
using Newtonsoft.Json;
using CNCMachineAASDashboard.Shared.Models.AAS;
using Submodel = CNCMachineAASDashboard.Shared.Models.AAS.Submodel;
using CNCMachineAASDashboard.Server.AASHttpClient;
using SubmodelElement = CNCMachineAASDashboard.Shared.Models.AAS.SubmodelElement;

namespace CNCMachineAASDashboard.Server.Backgroundservice
{
    public class BackgroundProcess : BackgroundService
    {


        private readonly ILogger<BackgroundProcess> _logger;

        private readonly IHubContext<AAShub> _hubContext;

        private readonly AASClient Client;

        public BackgroundProcess(ILogger<BackgroundProcess> logger, IHubContext<AAShub> hubContext,AASClient client )
        {

            _logger = logger;

            _hubContext = hubContext;

            Client = client;

        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                                
                    var aas = Client.aasclient.RetrieveAssetAdministrationShell();

                    var result = aas.Entity;

                    if (result == null)
                    {
                        Console.WriteLine("AAS data not received");

                    }

                    else
                    {
                        var AASGetData = result.ToJson();
                       
                        
                        var obj = JsonConvert.DeserializeObject<AASModel>(AASGetData);

                        await _hubContext.Clients.All.SendAsync("AASdataSend", obj);

                        Console.WriteLine($"CNCMAchineAAS dataSent to hub");

                    };

                    var MaintenanceSM = Client.aasclient.RetrieveSubmodel("MaintenanceSubmodel");

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

                    };
                    var OperationalSM = Client.aasclient.RetrieveSubmodel("OperationalDataSubmodel");

                    if (OperationalSM == null)
                    {
                        Console.WriteLine("Operational data not received");
                    }

                    else
                    {
                        var Data = OperationalSM.Entity.ToJson();
                        var OperationalData = System.Text.Json.JsonSerializer.Deserialize<Submodel>(Data);
                        await _hubContext.Clients.All.SendAsync("OperationaldataSend", OperationalData);
                        


                    };

                    var OperatingHourSE = Client.aasclient.RetrieveSubmodelElement("MaintenanceSubmodel", "Maintenance_1/MaintenanceDetails/OperatingHours");
                    if (OperatingHourSE == null)
                    {
                        Console.WriteLine("Operating Hours data not received");
                    }

                    else
                    {
                        var Data = OperatingHourSE.Entity.ToJson();
                        var OperatingHourData = System.Text.Json.JsonSerializer.Deserialize<SubmodelElement>(Data);
                        await _hubContext.Clients.All.SendAsync("OperatingHourSESend", OperatingHourData);
                    };

                    var MaintenanceWarningSE = Client.aasclient.RetrieveSubmodelElement("MaintenanceSubmodel", "Maintenance_1/MaintenanceDetails/MaintenanceWarning");
                    if (MaintenanceWarningSE == null)
                    {
                        Console.WriteLine("Maintenance Warning data not received");
                    }

                    else
                    {
                        var Data = MaintenanceWarningSE.Entity.ToJson();
                        var MaintenanceWarningData = System.Text.Json.JsonSerializer.Deserialize<SubmodelElement>(Data);
                        await _hubContext.Clients.All.SendAsync("MaintenanceWarningSESend", MaintenanceWarningData);
                    };

                    var MaintenanceThresholdSE = Client.aasclient.RetrieveSubmodelElement("MaintenanceSubmodel", "Maintenance_1/MaintenanceDetails/MaintenanceThreshold");
                    if (MaintenanceWarningSE == null)
                    {
                        Console.WriteLine("Maintenance Threshold data not received");
                    }

                    else
                    {
                        var Data = MaintenanceThresholdSE.Entity.ToJson();
                        var MaintenanceThresholdData = System.Text.Json.JsonSerializer.Deserialize<SubmodelElement>(Data);
                        await _hubContext.Clients.All.SendAsync("MaintenanceThresholdSESend", MaintenanceThresholdData);
                    };
                    var ActualOrderStatusSE = Client.aasclient.RetrieveSubmodelElement("MaintenanceSubmodel", "Maintenance_1/MaintenanceOrderStatus/ActualOrderStatus");
                    if (MaintenanceWarningSE == null)
                    {
                        Console.WriteLine("Order Status data not received");
                    }

                    else
                    {
                        var Data = ActualOrderStatusSE.Entity.ToJson();
                        var ActualOrderStatusdData = System.Text.Json.JsonSerializer.Deserialize<SubmodelElement>(Data);
                        await _hubContext.Clients.All.SendAsync("ActualOrderStatusSESend", ActualOrderStatusdData);
                    };

                    var MaintenanceWarning2SE = Client.aasclient.RetrieveSubmodelElement("MaintenanceSubmodel", "Maintenance_2/MaintenanceDetails/MaintenanceWarning");
                    var MaintenanceWarning2Data = System.Text.Json.JsonSerializer.Deserialize<SubmodelElement>(MaintenanceWarning2SE.Entity.ToJson());
                    await _hubContext.Clients.All.SendAsync("MaintenanceWarning2SESend", MaintenanceWarning2Data);


                    var MaintenanceThreshold2SE = Client.aasclient.RetrieveSubmodelElement("MaintenanceSubmodel", "Maintenance_2/MaintenanceDetails/MaintenanceThreshold");                                    
                    var MaintenanceThreshold2Data = System.Text.Json.JsonSerializer.Deserialize<SubmodelElement>(MaintenanceThreshold2SE.Entity.ToJson());
                    await _hubContext.Clients.All.SendAsync("MaintenanceThreshold2SESend", MaintenanceThreshold2Data);

                    var MaintenanceWarning3SE = Client.aasclient.RetrieveSubmodelElement("MaintenanceSubmodel", "Maintenance_3/MaintenanceDetails/MaintenanceWarning");
                    var MaintenanceWarning3Data = System.Text.Json.JsonSerializer.Deserialize<SubmodelElement>(MaintenanceWarning3SE.Entity.ToJson());
                    await _hubContext.Clients.All.SendAsync("MaintenanceWarning3SESend", MaintenanceWarning3Data);


                    var MaintenanceThreshold3SE = Client.aasclient.RetrieveSubmodelElement("MaintenanceSubmodel", "Maintenance_3/MaintenanceDetails/MaintenanceThreshold");
                    var MaintenanceThreshold3Data = System.Text.Json.JsonSerializer.Deserialize<SubmodelElement>(MaintenanceThreshold3SE.Entity.ToJson());
                    await _hubContext.Clients.All.SendAsync("MaintenanceThreshold3SESend", MaintenanceThreshold3Data);

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
