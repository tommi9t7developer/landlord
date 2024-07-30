using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    public interface IHausService
    {
        void AddHaus(IHaus haus);
        void RemoveHaus(IHaus haus);
        void addWohnungZuHaus(string hausname, Wohnung wohnung);
        IHaus? getHausByName(string hausName);
        List<IHaus> GetHaeuser();
    }
}
