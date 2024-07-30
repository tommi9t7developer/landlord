using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LandLord
{
    public class Haus
    {
        [JsonConstructor]
        public Haus(string name, List<IWohnung> wohnungen)
        {
            this.name = name;
            this.wohnungen = wohnungen ?? new List<IWohnung>();
        }
        public Haus(String hausname)
        {
            name = hausname;
            this.wohnungen = new List<IWohnung>();
        }

        // Parameterloser Konstruktor für die Deserialisierung
        private Haus()
        {
            wohnungen = new List<IWohnung>();
        }


        private string name;
        private List<IWohnung> wohnungen;

        [JsonPropertyName("name")]
        public string Name => name;

        [JsonPropertyName("wohnungen")]
        public List<IWohnung> Wohnungen => wohnungen;

        //public string Name { get => name; }

        public override string ToString()
        {
            return Name;
        }

        public void addWohnung(Wohnung wohnung)
        {
            this.wohnungen.Add(wohnung);    
        }
    }
}
