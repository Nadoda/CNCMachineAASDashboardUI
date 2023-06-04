using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNCMachineAASDashboard.Shared.Models.MaintenanceSubmodel;

namespace CNCMachineAASDashboard.Shared.Models
{
    public class AASModel
    {
        public string ServerEndpoint = "http://192.168.2.186:5180";

        //public  string ServerEndpoint = "http://141.44.237.178:5180";
        public string? idShort { get; set; }
        public Identification? identification { get; set; }
        public List<Description>? description { get; set; }
        public List<Endpoint>? endpoints { get; set; }
        public ModelType? modelType { get; set; }
        public Asset? asset { get; set; }
        public List<submodel>? submodels { get; set; }
    }
}
