using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    public class Haus
    {
        public Haus(String hausname)
        {
            name = hausname;
            this.wohnungen = new List<IWohnung>();
        }

        private string name;
        private List<IWohnung> wohnungen;

        public string Name { get => name; }

        public override string ToString()
        {
            return Name;
        }
    }
}
