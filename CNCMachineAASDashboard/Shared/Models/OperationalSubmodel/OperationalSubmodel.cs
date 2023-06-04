using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMachineAASDashboard.Shared.Models.OperationalSubmodel
{
    public class OperationalSubmodel
    {
        public string idShort { get; set; }
        public SemanticId semanticId { get; set; }
        public List<SubmodelElement> submodelElements { get; set; }
        public ModelType modelType { get; set; }
        public Identification identification { get; set; }
        public List<Description> description { get; set; }
    }
    public class SubmodelElement
    {
        public string idShort { get; set; }
        public ModelType modelType { get; set; }
        public List<Value> value { get; set; }
    }
    public class Value
    {
        public string idShort { get; set; }
        public ModelType modelType { get; set; }
        public string valueType { get; set; }
        public object value { get; set; }
    }
}
