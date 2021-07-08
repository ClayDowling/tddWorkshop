using System.Collections.Generic;

namespace VendingMachine
{
    public class CoinAccepter
    {
        private int _value;

        private static List<CoinSpecification> coinSpecs = new List<CoinSpecification>
        {
            new CoinSpecification(5.000, 21.21, 5),
            new CoinSpecification(2.268, 17.91, 10),
            new CoinSpecification(5.670, 24.26, 25),
            new CoinSpecification(8, 30, 100)
        };

        public void DropCoin(double weightGrams, double diameterMm)
        {
            _value += GetValueForCoin(weightGrams, diameterMm);
        }

        private int GetValueForCoin(double weightGrams, double diameterMm)
        {
            foreach (var spec in coinSpecs)
            {
                if (InTolerance(spec, weightGrams, diameterMm))
                {
                    return spec.Value;
                }
            }
            return 0;
        }

        private bool InTolerance(CoinSpecification spec, double weightGrams, double diameterMm)
        {
            if (spec.Weight - 0.001 < weightGrams && weightGrams < spec.Weight + 0.001
                                                  && spec.DiameterMm - 0.001 < diameterMm &&
                                                  diameterMm < spec.DiameterMm + 0.001)
            {
                return true;
            }

            return false;
        }

        public int Value()
        {
            return _value;
        }
    }

    internal class CoinSpecification
    {
        public CoinSpecification(double weight, double diameterMm, int value)
        {
            Weight = weight;
            DiameterMm = diameterMm;
            Value = value;
        }

        public double Weight { get; set; }
        public double DiameterMm { get; set; }
        public int Value { get; set; }
    }
}