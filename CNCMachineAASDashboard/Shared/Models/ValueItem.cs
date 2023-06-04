using CNCMachineAASDashboard.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMachineAASDashboard.Shared.Models
{
    public class ValueItem
    {
        public string? idShort { get; set; }
        public ModelType? modelType { get; set; }

        
        public List<Value>? value { get; set; }
        //public object?value { get; set; }
        //public string? valueType { get; set; }
    }
    public class Value
    {
        public string? idShort { get; set; }
        public ModelType? modelType { get; set; }
        public object? value { get; set; }
        public string? valueType { get; set; }
    }
}

