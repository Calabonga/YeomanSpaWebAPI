using Calabonga.Portal.Config;
using Newtonsoft.Json;

namespace <%= projectName %>.Web.Infrastructure.AppConfig {
    /// <summary>
    /// Custom serializer for CurrentAppSettings
    /// </summary>
    public class JsonConfigSerializer : IConfigSerializer {
        public T DeserializeObject<T>(string value) {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public string SerializeObject<T>(T config) where T : class {
            return JsonConvert.SerializeObject(config);
        }
    }
}
