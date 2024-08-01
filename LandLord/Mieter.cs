using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LandLord
{
    /*
    public class Mieter : IMieter
    {
        public Mieter(string name)
        {
            Name = name;
        }

        [JsonPropertyName("name")]
        public string Name { get; }
    }
    */

    public class Mieter : IMieter
    {
        public string Name { get; set; }
    }
}
