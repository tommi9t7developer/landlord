using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    public class Wohnung : IWohnung
    {
        public Wohnung() {
           
        }
        //public string Geschoss => throw new NotImplementedException();

        private IMieter mieter;

        private string geschoss;

        public void setMieter(IMieter mieter)
        {
            this.mieter = mieter;
        }

        public IMieter getMieter()
        {
            return this.mieter;
        }
        public void setGeschoss(string geschoss)
        {
            this.geschoss = geschoss;
        }
        public string getGeschoss()
        {
            return geschoss;
        }

    }
}
