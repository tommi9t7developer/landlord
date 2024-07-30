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
        private List<Haus> _haeuser;

        public HausService()
        {
            _haeuser = new List<Haus>();
            _haeuser = LoadHaeuser();
        }

        public IReadOnlyList<Haus> EchteHauser => _haeuser.AsReadOnly();

        public void AddHaus(Haus haus)
        {
            _haeuser.Add(haus);
            SaveHaeuser();
        }

        public void RemoveHaus(Haus haus)
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

        public Haus? getHausByName(string hausName) //gib Haus aus Liste zurück
        {
            if (_haeuser != null)
            {
                return _haeuser.FirstOrDefault(h => h.Name == hausName);
            }
            else return null;
        }
        public List<Haus> GetHaeuser()
        {
            return _haeuser;
        }

        private void SaveHaeuser()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_haeuser, options);
            File.WriteAllText(_filePath, json);
        }

        private List<Haus> LoadHaeuser()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IncludeFields = true };
                return JsonSerializer.Deserialize<List<Haus>>(json, options) ?? new List<Haus>();
            }
            return new List<Haus>();
        }



    }

}
