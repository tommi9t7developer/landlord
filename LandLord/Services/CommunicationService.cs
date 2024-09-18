using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord.Services
{

    public class CommunicationService : ICommunicationService
    {

        public CommunicationService() { }

        private string hausName;
        private string wohnungName;

        public void setHausName(string hausname)
        {
            hausName = hausname;
        }
        public string getHausName()
        {
            return hausName;
        }

        public void setWohnungName(string wohnungname)
        {
            wohnungName = wohnungname;
        }
        public string getWohnungName()
        {
            return wohnungName;
        }
    }
}
