using System.Collections.Generic;

namespace VendingMachine
{
    public class CoinAccepter
    {
        private int _value;
        private readonly SerialBus _serialBus;

        public CoinAccepter(SerialBus serialBus)
        {
            _serialBus = serialBus;
        }
        
        private static readonly List<CoinSpecification> CoinSpecs = new List<CoinSpecification>
        {
            new(5.000, 21.21, 5),
            new(2.268, 17.91, 10),
            new(5.670, 24.26, 25),
            new(8, 30, 100)
        };
        
        public void DropCoin(double weightGrams, double diameterMm)
        {
            var coinValue = GetValueForCoin(weightGrams, diameterMm);
            if (coinValue <= 0) return;
            _value += coinValue;
            _serialBus.Send($"{_value}");
        }

        private int GetValueForCoin(double weightGrams, double diameterMm)
        {
            foreach (var spec in CoinSpecs)
            {
                if (InTolerance(spec, weightGrams, diameterMm))
                {
                    return spec.Value;
                }
            }
            return 0;
        }

        private static bool InTolerance(CoinSpecification spec, double weightGrams, double diameterMm)
        {
            return spec.Weight - 0.001 < weightGrams && weightGrams < spec.Weight + 0.001
                                                     && spec.DiameterMm - 0.001 < diameterMm &&
                                                     diameterMm < spec.DiameterMm + 0.001;
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

        public double Weight { get; }
        public double DiameterMm { get; }
        public int Value { get; }
    }
}