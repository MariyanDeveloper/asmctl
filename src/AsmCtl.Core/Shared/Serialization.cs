using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AsmCtl.Core.Shared;

public static  class Serialization
{
    extension(object obj)
    {
        public string ToJson(
            Formatting formatting = Formatting.Indented,
            JsonSerializerSettings? settings = null
        )
        {
            settings ??= new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Converters =
                [
                    new Newtonsoft.Json.Converters.StringEnumConverter(
                    new CamelCaseNamingStrategy()
                    )
                ]
            };
            
            return JsonConvert.SerializeObject(obj, formatting, settings);
        }
    }

}
