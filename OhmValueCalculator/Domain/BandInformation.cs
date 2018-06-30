using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhmValueCalculator.Domain
{
    public class BandInformation
    {
        public string Color { get; set; }
        public int? SignificantFigures { get; set; }
        public double Multiplier { get; set; }
        public double? Tolerance { get; set; }
    }
}
