using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandLord.ViewModels
{
    public interface IWohnung
    {
        IMieter Mieter { get; set; }
        string Geschoss { get; set; }
        public List<string> PdfFiles { get; set; }

        public void addPdf(string pdf);
    }
}
