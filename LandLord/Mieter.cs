using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    public  class Mieter : IMieter
    {
        
        public Mieter(string name) {
            this._name = name;
        }

        private string _name;

        public string Name { get { return _name; } }
    }
}
