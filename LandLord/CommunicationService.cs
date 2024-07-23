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

        public void setHausName(string hausname)
        {
            this.hausName = hausname;
        }
        public string getHausName()
        {
            return this.hausName;
        }
    }
}
