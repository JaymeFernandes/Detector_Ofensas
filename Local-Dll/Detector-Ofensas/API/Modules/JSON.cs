using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
    public class JSON
    {
        public static List<T> ConvertObject<T>(string json)
        {
            
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static Dictionary<string, int> ConvertObject(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
        }

        public static string ConvertJson<T>(List<T> values)
        {
            return JsonConvert.SerializeObject(values, Formatting.Indented);
        }
    }
