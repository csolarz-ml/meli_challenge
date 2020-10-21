using System;
using System.Collections.Generic;
using System.Text;

namespace MeLi_Topsecret_split.Domain.Entities
{
    public class Satellites
    {
        public int IdSatellite { get; set; }
        public string SatelliteName { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string Message { get; set; }
    }
}
