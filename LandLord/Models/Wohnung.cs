using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace LandLord.ViewModels
{
    public class Wohnung : IWohnung
    {
        public Wohnung()
        {
            PdfFiles = new List<string>();
        }

        public Wohnung(IMieter mieter, string geschoss)
        {
            Mieter = mieter;
            Geschoss = geschoss;
            PdfFiles = new List<string>();
        }

        // Liste von Dateipfaden für PDFs
        public List<string> PdfFiles { get; set; }
        public string pdfOrdnerName { get; }


        // Methode zum Hinzufügen einer PDF
        public void addPdf(string pdf)
        {
            PdfFiles.Add(pdf);
        }

        public IMieter Mieter { get; set; }
        public string Geschoss { get; set; }
    }

}
