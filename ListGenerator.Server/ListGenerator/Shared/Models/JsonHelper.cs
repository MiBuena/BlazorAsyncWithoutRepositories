using ListGenerator.Shared.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace ListGenerator.Shared.Models
{
    public class JsonHelper : IJsonHelper
    {
        public string Serialize<T>(T model)
        {
            string json = JsonConvert.SerializeObject(model);
            return json;
        }

        public T Deserialize<T>(string value)
        {
            var deserializedObject = JsonConvert.DeserializeObject<T>(value);
            return deserializedObject;
        }
    }
}
