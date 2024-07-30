using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    public interface IHausService
    {
        IReadOnlyList<Haus> EchteHauser { get; }
        void AddHaus(Haus haus);
        void RemoveHaus(Haus haus);
        void addWohnungZuHaus(string hausname, Wohnung wohnung);
        Haus? getHausByName(string hausName);
        List<Haus> GetHaeuser();
    }
}
