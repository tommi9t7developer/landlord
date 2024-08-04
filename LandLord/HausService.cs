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

        public void addWohnungZuHaus(string hausname, IWohnung wohnung) //
        { // aus _haueser ??
            var haus = getHausByName(hausname);
            if (haus != null)
            {
                haus.addWohnung(wohnung);
                SaveHaeuser();
            }

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

            /*
            var haus = getHausByName(hausname);
            if (haus != null)
            {
                return haus.getWohnungByGeschoss(geschoss);
            }
            else return null; */
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
