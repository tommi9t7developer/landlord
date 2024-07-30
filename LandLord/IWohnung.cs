using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord
{
    public interface IWohnung
    {
        public void setMieter(IMieter mieter);
        public IMieter getMieter();

        public void setGeschoss(string geschoss);

        public string getGeschoss();


    }
}
