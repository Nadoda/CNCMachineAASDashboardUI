using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCMachineAASDashboard.Shared.Models.AAS
{
    public class Key
    {
        public string? type { get; set; }
        public string? idType { get; set; }
        public string? value { get; set; }
        public bool? local { get; set; }
    }
}
