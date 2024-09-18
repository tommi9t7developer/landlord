using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json.Serialization;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
using LandLord.ViewModels;
using LandLord.Converter;

namespace LandLord.Services
{
    public class HausService : IHausService
    {
        private readonly string _filePath = "haeuser.json";
        private List<IHaus> _haeuser;

        public HausService()
        {
            _haeuser = new List<IHaus>();
            _haeuser = LoadHaeuser();
        }

        public void AddHaus(IHaus haus)
        {
            _haeuser.Add(haus);
            SaveHaeuser();
        }

        public void RemoveHaus(IHaus haus)
        {
            _haeuser.Remove(haus);
        }

        public void addWohnungZuHaus(string hausname, IWohnung wohnung) //
        { // aus _haueser ??
            var haus = getHausByName(hausname);
            if (haus != null)
            {
                haus.addWohnung(wohnung);
                SaveHaeuser();
            }

        }

        public void addPdfToWohnung(string hausname, string wohnung, string pdf)
        {
            // Basisordner für PDFs
            string baseFolder = Path.Combine("PDFs", hausname, wohnung);

            // Überprüfen und Erstellen des Ordners, falls er nicht existiert
            if (!Directory.Exists(baseFolder))
            {
                Directory.CreateDirectory(baseFolder);
            }

            // Dateiname und Zielpfad für die PDF-Datei
            string fileName = Path.GetFileName(pdf);
            string destinationPath = Path.Combine(baseFolder, fileName);

            // Kopieren der PDF-Datei in den Zielordner
            File.Copy(pdf, destinationPath, true);

            string absolutePath = Path.GetFullPath(destinationPath);

            //eventuell das drüber wieder löschen
            var wohnen = getWohnungByNames(hausname, wohnung);
            if (wohnen != null)
            {
                //wohnen.addPdf(pdf);
                wohnen.addPdf(absolutePath); //warum fehlt hier  C:\Users\Thomas\source\repos\LandLord\LandLord\bin\Debug\net8.0-windows ??? PDFs\Schubert\ Dateiname
                SaveHaeuser();
            }
            // Sicher?
            else MessageBox.Show("Wohnung nicht gefunden");








        }

        public List<IWohnung>? getWohnungenByHaus(string hausname)
        {

            foreach (var hausvar in _haeuser)
            {
                if (hausvar.Name == hausname)
                {
                    return hausvar.getWohnungen();
                }
            }

            return null;
        }

        public IWohnung? getWohnungByNames(string hausname, string geschoss)
        {
            foreach (var hausvar in _haeuser)
            {
                if (hausvar.Name == hausname)
                {
                    return hausvar.getWohnungByGeschoss(geschoss);
                }
            }

            return null;
        }

        public List<string>? getPdfsfromWohnung(string hausname, string geschoss)
        {
            var wohnung = getWohnungByNames(hausname, geschoss);
            if (wohnung != null)
            {
                return wohnung.PdfFiles;
            }
            else return null;
        }

        public IHaus? getHausByName(string hausName) //gib Haus aus Liste zurück
        {
            if (_haeuser != null)
            {
                return _haeuser.FirstOrDefault(h => h.Name == hausName);
            }
            else return null;
        }
        public List<IHaus> GetHaeuser()
        {
            return _haeuser;
        }
        public void SaveHaeuser()
        {
            var hausList = _haeuser.OfType<Haus>().ToList();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new IWohnungConverter(), new IMieterConverter() }
            };

            var json = JsonSerializer.Serialize(hausList, options);
            File.WriteAllText(_filePath, json);
        }

        public List<IHaus> LoadHaeuser()
        {
            if (!File.Exists(_filePath))
            {
                return new List<IHaus>();
            }

            var json = File.ReadAllText(_filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new IWohnungConverter(), new IMieterConverter() }
            };

            var haeuser = JsonSerializer.Deserialize<List<Haus>>(json, options) ?? new List<Haus>();
            return haeuser.Cast<IHaus>().ToList();
        }
    }
}
