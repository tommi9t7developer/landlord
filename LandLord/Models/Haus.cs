using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace LandLord.ViewModels
{
    public class Haus : IHaus
    {
        [JsonConstructor]
        public Haus(string name, List<IWohnung> wohnungen)
        {
            this.name = name;
            this.wohnungen = wohnungen ?? new List<IWohnung>();
        }
        public Haus(string hausname)
        {
            name = hausname;
            wohnungen = new List<IWohnung>();

        }

        // Parameterloser Konstruktor für die Deserialisierung
        private Haus()
        {
            wohnungen = new List<IWohnung>();
        }


        private string name;
        private List<IWohnung> wohnungen;
        public string pdfOrdnerName { get; }

        [JsonPropertyName("name")]
        public string Name => name;

        [JsonPropertyName("wohnungen")]
        public List<IWohnung> Wohnungen => wohnungen;

        public override string ToString()
        {
            return Name;
        }

        public void addWohnung(IWohnung wohnung)
        {
            if (wohnung != null)
            {
                wohnungen.Add(wohnung);
            }
            else MessageBox.Show("Wohnung NULL");
        }

        public IWohnung getWohnungByGeschoss(string geschoss)
        {
            // Durchlaufe die Liste der Wohnungen und suche nach der Wohnung mit dem angegebenen Geschoss
            foreach (var wohnung in wohnungen)
            {
                if (wohnung.Geschoss == geschoss)
                {
                    return wohnung;
                }
            }

            // Wenn keine passende Wohnung gefunden wurde, gib null zurück oder werfe eine Ausnahme
            return null;
        }

        public List<IWohnung> getWohnungen()
        {
            return wohnungen;
        }
    }
}
