
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Detector_Ofensas.Api.Modules
{
    public class JSON
    {
        public static List<T> ConvertObject<T>(string json)
        {
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public static Dictionary<string, int> ConvertObject(string json)
        {
            return JsonSerializer.Deserialize<Dictionary<string, int>>(json);
        }
    }
}
