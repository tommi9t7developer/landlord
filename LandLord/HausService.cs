using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LandLord
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

        public void addWohnungZuHaus(string hausname, Wohnung wohnung) //
        {
            var haus = getHausByName(hausname);
            if (haus != null)
            {
                haus.addWohnung(wohnung);
            }

        }

        public void getWohnungByNames(string hausname, string geschoss)
        {

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

        private void SaveHaeuser()
        {
            /*
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_haeuser, options);
            File.WriteAllText(_filePath, json);
            */

            // Sicherstellen, dass die Liste von Haus-Objekten korrekt konvertiert wird
            var hausList = _haeuser.OfType<Haus>().ToList();

            // Optionen für die JSON-Serialisierung
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,  // Schöner formatierter JSON-Output
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Optional: camelCase-Namenskonvention
            };

            // Serialisieren der Liste von Haus-Objekten in eine JSON-Zeichenkette
            var json = JsonSerializer.Serialize(hausList, options);

            // Schreiben der JSON-Zeichenkette in die Datei
            File.WriteAllText(_filePath, json);
        }
        /*
        private List<IHaus> LoadHaeuser()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IncludeFields = true };
                return JsonSerializer.Deserialize<List<Haus>>(json, options) ?? new List<Haus>();
            }
            // Wenn du eine Liste von IHaus benötigst, konvertiere sie
            return haeuser.Cast<IHaus>().ToList();
        }
        */
        public List<IHaus> LoadHaeuser()
        {
            var json = File.ReadAllText(_filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                // Weitere Optionen hinzufügen, falls nötig
            };

            // Deserialisiere JSON zu einer Liste von Haus-Objekten
            var haeuser = JsonSerializer.Deserialize<List<Haus>>(json, options) ?? new List<Haus>();

            // Konvertiere die Liste von Haus zu IList<IHaus>
            return haeuser.Cast<IHaus>().ToList();
        }



    }

}
