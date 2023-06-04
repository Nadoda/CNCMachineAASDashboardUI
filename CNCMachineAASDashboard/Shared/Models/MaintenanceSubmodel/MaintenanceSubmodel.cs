using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMachineAASDashboard.Shared.Models.MaintenanceSubmodel
{
    public class MaintenanceSubmodel
    {
        public string? idShort { get; set; }
        public Identification? identification { get; set; }
        public List<Description>? description { get; set; }
        public SemanticId? semanticId { get; set; }
        public List<Endpoint>? endpoints { get; set; }
        public ModelType? modelType { get; set; }
        public List<SubmodelElement>? submodelElements { get; set; }
    }
    public class SubmodelElement
    {
        public string? idShort { get; set; }
        public ModelType? modelType { get; set; }
        public List<ValueItem1>? value { get; set; }
    }
    public class ValueItem1
    {
        public string? idShort { get; set; }
        public ModelType? modelType { get; set; }


        public List<ValueItem2>? value { get; set; }
        //public object?value { get; set; }
        //public string? valueType { get; set; }
    }
    public class ValueItem2
    {
        public string? idShort { get; set; }
        public ModelType? modelType { get; set; }
        public object? value { get; set; }
        public string? valueType { get; set; }
    }
  
}
