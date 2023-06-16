using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CNCMachineAASDashboard.Shared.Models.AAS
{
    public class AASModel
    {
        
        public string? idShort { get; set; }
        public Identification? identification { get; set; }
        public List<Description>? description { get; set; }
        public List<Endpoint>? endpoints { get; set; }
        public ModelType? modelType { get; set; }
        public Asset? asset { get; set; }
        public List<Submodel>? submodels { get; set; }
    }
}
