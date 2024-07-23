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

        public Haus? getHausByName(string hausName) //gib Haus aus Liste zurück
        {
            if (_echteHauser != null)
            {
                return _echteHauser.FirstOrDefault(h => h.Name == hausName);
            }
            else return null;
        }

        public void updateHaus(Haus updatedHaus) //verändert Haus wieder zur Liste hinzufügen
        {
            var index = _echteHauser.FindIndex(h => h.Name == updatedHaus.Name);
            if (index != -1)
            {
                _echteHauser[index] = updatedHaus;
            }
            else
            {
                // Optional: Falls das Haus nicht gefunden wird, können Sie es hinzufügen.
                _echteHauser.Add(updatedHaus);
            }
        }


    }

}
