using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CNCMachineAASDashboard.Shared.Models.AAS.AASModel;

namespace CNCMachineAASDashboard.Shared.Models.AAS
{
    public class Asset
    {
        public string? idShort { get; set; }
        public string? kind { get; set; }
        public AssetIdentificationModel? assetIdentificationModel { get; set; }
        public List<object>? embeddedDataSpecifications { get; set; }
        public ModelType? modelType { get; set; }
        public Identification? identification { get; set; }
        public List<Description>? description { get; set; }
    }
}
