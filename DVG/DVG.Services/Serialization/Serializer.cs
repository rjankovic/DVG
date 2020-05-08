using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Services.Serialization
{
    public static class Serializer
    {
        public static string Serialize(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T Deserialize<T>(string serialized)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            return JsonConvert.DeserializeObject<T>(serialized, settings);
        }
    }
}
