using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMachineAASDashboard.Shared.Models
{
    public class Submodel
    {
        public string? idShort { get; set; }
        public Identification? identification { get; set; }
        public List<Description>? description { get; set; }
        public SemanticId? semanticId { get; set; }
        public List<Endpoint>? endpoints { get; set; }
        public ModelType? modelType { get; set; }
        public List<SubmodelElement>? submodelElements { get; set; }
    }
}
