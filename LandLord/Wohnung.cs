using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LandLord
{
    /*
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
    public class Wohnung : IWohnung
    {
        // Parameterless constructor for deserialization
        public Wohnung() { }

        public Wohnung(IMieter mieter, string geschoss)
    {
        Mieter = mieter;
        Geschoss = geschoss;
    }

        // Private fields for the properties
        private IMieter mieter;
        private string geschoss;

        [JsonPropertyName("mieter")]
        public IMieter Mieter { get; set; }

        [JsonPropertyName("geschoss")]
        public string Geschoss { get; set; }

        // Implementing interface methods
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
    } */

    public class Wohnung : IWohnung
    {
        public Wohnung() { }

        public Wohnung(IMieter mieter, string geschoss)
        {
            Mieter = mieter;
            Geschoss = geschoss;
        }

        public IMieter Mieter { get; set; }
        public string Geschoss { get; set; }
    }

}
