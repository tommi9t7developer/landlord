using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    public interface IHaus
    {
        string Name { get; }
        List<IWohnung> Wohnungen { get; }
        void addWohnung(IWohnung wohnung);
        string ToString();
    }
}

