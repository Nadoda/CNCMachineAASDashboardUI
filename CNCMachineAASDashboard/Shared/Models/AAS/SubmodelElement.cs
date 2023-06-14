using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMachineAASDashboard.Shared.Models.AAS
{
    public class SubmodelElement
    {
        public string? idShort { get; set; }
        public ModelType? modelType { get; set; }
        public object? value { get; set; }
        public string? valueType { get; set; }
        //public List<ValueItem>? value { get; set; }
    }
}
