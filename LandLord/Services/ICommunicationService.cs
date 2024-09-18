using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord.Services
{
    public interface ICommunicationService
    {
        void setHausName(string hausname);
        string getHausName();

        void setWohnungName(string wohnungname);
        string getWohnungName();
    }
}
