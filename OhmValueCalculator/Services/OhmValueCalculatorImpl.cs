using OhmValueCalculator.Domain;
using System;
using System.Collections.Generic;

namespace OhmValueCalculator.Services
{
    public class OhmValueCalculatorImpl : IOhmValueCalculator
    {
        Dictionary<string, BandInformation> bandInformationDictionary = new Dictionary<string, BandInformation>();

        public OhmValueCalculatorImpl()
        {
            bandInformationDictionary.Add("pink", new BandInformation
            {
                Color = "pink",
                Multiplier = 0.001
            });

            bandInformationDictionary.Add("silver", new BandInformation
            {
                Color = "silver",
                Multiplier = 0.01,
                Tolerance = 0.1
            });

            bandInformationDictionary.Add("gold", new BandInformation
            {
                Color = "gold",
                Multiplier = 0.1,
                Tolerance = 0.05
            });

            bandInformationDictionary.Add("black", new BandInformation
            {
                Color = "black",
                SignificantFigures = 0,
                Multiplier = 1
            });

            bandInformationDictionary.Add("brown", new BandInformation
            {
                Color = "brown",
                SignificantFigures = 1,
                Multiplier = 10,
                Tolerance = 0.01
            });

            bandInformationDictionary.Add("red", new BandInformation
            {
                Color = "red",
                SignificantFigures = 2,
                Multiplier = 100,
                Tolerance = 0.02
            });

            bandInformationDictionary.Add("orange", new BandInformation
            {
                Color = "orange",
                SignificantFigures = 3,
                Multiplier = 1000
            });

            bandInformationDictionary.Add("yellow", new BandInformation
            {
                Color = "yellow",
                SignificantFigures = 4,
                Multiplier = 10000,
                Tolerance = 0.05
            });

            bandInformationDictionary.Add("green", new BandInformation
            {
                Color = "green",
                SignificantFigures = 5,
                Multiplier = 100000,
                Tolerance = 0.005
            });

            bandInformationDictionary.Add("blue", new BandInformation
            {
                Color = "blue",
                SignificantFigures = 6,
                Multiplier = 1000000,
                Tolerance = 0.0025
            });

            bandInformationDictionary.Add("violet", new BandInformation
            {
                Color = "violet",
                SignificantFigures = 7,
                Multiplier = 10000000,
                Tolerance = 0.001
            });

            bandInformationDictionary.Add("gray", new BandInformation
            {
                Color = "gray",
                SignificantFigures = 8,
                Multiplier = 100000000,
                Tolerance = 0.0005
            });

            bandInformationDictionary.Add("white", new BandInformation
            {
                Color = "white",
                SignificantFigures = 9,
                Multiplier = 1000000000
            });
        }

        public OhmValue CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {
                BandInformation bandA = bandInformationDictionary[bandAColor];
                BandInformation bandB = bandInformationDictionary[bandBColor];
                BandInformation bandC = bandInformationDictionary[bandCColor];
                BandInformation bandD = bandInformationDictionary[bandDColor];

                if (bandA.SignificantFigures == null || bandB.SignificantFigures == null || bandD.Tolerance == null)
                {
                    return null;
                }

                double Resistance = Int32.Parse(bandA.SignificantFigures.ToString() + bandB.SignificantFigures.ToString()) * bandC.Multiplier;
                double Variance = Resistance * (double)bandD.Tolerance;

                OhmValue ohmValue = new OhmValue
                {
                    Resistance = Resistance,
                    Tolerance = (double)bandD.Tolerance,
                    Minimum = Resistance - Variance,
                    Maximum = Resistance + Variance
                };

                return ohmValue;
            } catch (Exception)
            {
                return null;
            }
        }
    }
}
