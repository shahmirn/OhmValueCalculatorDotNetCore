using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OhmValueCalculator.Domain
{
    public class OhmValue
    {
        public double Resistance { get; set; }
        public double Tolerance { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
    }
}
