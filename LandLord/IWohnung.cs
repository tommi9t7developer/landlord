using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    public interface IWohnung
    {
        IMieter Mieter { get; set; }
        string Geschoss { get; set; }
    }
}
