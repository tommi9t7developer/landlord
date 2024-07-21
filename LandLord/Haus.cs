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
        }

        private string name;

        public string Name { get => name; }

        public override string ToString()
        {
            return Name;
        }
    }
}
