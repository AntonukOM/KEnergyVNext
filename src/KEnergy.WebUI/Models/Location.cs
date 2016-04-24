using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KEnergy.WebUI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GeoLong { get; set; } // довгота - для карт google
        public double GeoLat { get; set; } // широта - для карт google
    }
}
