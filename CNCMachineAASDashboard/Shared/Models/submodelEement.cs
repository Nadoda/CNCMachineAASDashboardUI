using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMachineAASDashboard.Shared.Models
{
    public class submodelEement
    {
        public string? idShort { get; set; }
        public ModelType? modelType { get; set; }
        public List<ValueItem>? value { get; set; }
    }
}
