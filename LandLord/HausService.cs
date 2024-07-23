using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    public class HausService
    {
        private List<Haus> _echteHauser;

        public HausService()
        {
            _echteHauser = new List<Haus>();
        }

        public IReadOnlyList<Haus> EchteHauser => _echteHauser.AsReadOnly();

        public void AddHaus(Haus haus)
        {
            _echteHauser.Add(haus);
        }

        public void RemoveHaus(Haus haus)
        {
            _echteHauser.Remove(haus);
        }

       
        // Weitere Methoden, um mit der Liste zu arbeiten
    }

}
