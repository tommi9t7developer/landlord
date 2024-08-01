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
        void addWohnungZuHaus(string hausname, IWohnung wohnung);
        public IHaus? getHausByName(string hausName);
        public List<IWohnung>? getWohnungenByHaus(string hausname);
        public IWohnung? getWohnungByNames(string hausname, string geschoss);
        List<IHaus> GetHaeuser();

        public void SaveHaeuser();

        public List<IHaus> LoadHaeuser();
    }
}
