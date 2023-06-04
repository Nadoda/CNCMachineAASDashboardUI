using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CNCMachineAASDashboard.Shared.Models.Test
{
    public class test
    {
        
        public string idShort { get; set; }

      
        public SemanticId semanticId { get; set; }

        
        public List<SubmodelElement> submodelElements { get; set; }

        public ModelType modelType { get; set; }

        public Identification identification { get; set; }

        public List<Description> description { get; set; }
    }

    public class Description
    {
       
        public string language { get; set; }

        
        public string text { get; set; }
    }

    public class Identification
    {
        public string id { get; set; }

        public string idType { get; set; }
    }

    public class ModelType
    {
        public string name { get; set; }
    }

    public class SemanticId
    {
        
        public List<Key> keys { get; set; }
    }

    public class Key
    {
        public string type { get; set; }

        public string idType { get; set; }

        public string value { get; set; }

        public bool local { get; set; }
    }

    public class SubmodelElement
    {
       
        public string idShort { get; set; }

        public ModelType modelType { get; set; }

        public List<SubmodelElementValue> value { get; set; }
    }

    public class SubmodelElementValue
    {
        public string idShort { get; set; }

        public ModelType modelType { get; set; }

        public List<PurpleValue> value { get; set; }
    }

    public class PurpleValue
    {   
        public string idShort { get; set; }

        
        public ModelType modelType { get; set; }

        [JsonProperty("valueType", NullValueHandling = NullValueHandling.Ignore)]
        public string? valueType { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public object value { get; set; }
    }

    public class FluffyValue
    {
        public string idShort { get; set; }

        public ModelType modelType { get; set; }

        public string valueType { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public TentacledValue? value { get; set; }
    }
    public  struct TentacledValue
    {
        public DateTimeOffset? DateTime;
        public long? Integer;

        public static implicit operator TentacledValue(DateTimeOffset DateTime) => new TentacledValue { DateTime = DateTime };
        public static implicit operator TentacledValue(long Integer) => new TentacledValue { Integer = Integer };
    }

    public  struct StickyValue
    {
        public List<FluffyValue> FluffyValueArray;
        public long? Integer;
        public string String;

        public static implicit operator StickyValue(List<FluffyValue> FluffyValueArray) => new StickyValue { FluffyValueArray = FluffyValueArray };
        public static implicit operator StickyValue(long Integer) => new StickyValue { Integer = Integer };
        public static implicit operator StickyValue(string String) => new StickyValue { String = String };
    }
}
