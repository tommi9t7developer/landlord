using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{

    public class CommunicationService
    {

        public CommunicationService() { }

        private string hausName;
        private string wohnungName;

        public void setHausName(string hausname)
        {
            this.hausName = hausname;
        }
        public string getHausName()
        {
            return this.hausName;
        }

        public void setWohnungName(string wohnungname)
        {
            this.wohnungName = wohnungname;
        }
        public string getWohnungName()
        {
            return this.wohnungName;
        }
    }
}
