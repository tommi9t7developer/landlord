using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LandLord
{
    public class Wohnung : IWohnung
    {
        public Wohnung() { }

        public Wohnung(IMieter mieter, string geschoss)
        {
            Mieter = mieter;
            Geschoss = geschoss;
        }

        public IMieter Mieter { get; set; }
        public string Geschoss { get; set; }
    }

}
