using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    class Wohnung : IWohnung
    {
        public Wohnung() {
           
        }
        public string Name => throw new NotImplementedException();

        private IMieter mieter;
    }
}
