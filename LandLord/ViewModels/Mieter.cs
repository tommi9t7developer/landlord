using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LandLord.ViewModels
{
    public class Mieter : IMieter
    {
        public string Name { get; set; }
    }
}
