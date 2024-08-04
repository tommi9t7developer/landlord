using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace LandLord
{
    public class Wohnung : IWohnung
    {
        public Wohnung() {
            pdfFiles = new List<string>();
        }

        public Wohnung(IMieter mieter, string geschoss)
        {
            Mieter = mieter;
            Geschoss = geschoss;
            pdfFiles = new List<string>();
        }

        // Liste von Dateipfaden für PDFs
        public List<string> pdfFiles { get; set; }

        // Methode zum Hinzufügen einer PDF
        public void addPdf()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            openFileDialog.Title = "Select a PDF file";

            if (openFileDialog.ShowDialog() == true)
            {
                pdfFiles.Add(openFileDialog.FileName);
                MessageBox.Show("PDF added successfully: " + openFileDialog.FileName, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public IMieter Mieter { get; set; }
        public string Geschoss { get; set; }
    }

}
