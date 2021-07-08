﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace VendingMachine
{
    public class CoinAccepter
    {
        public readonly Gpio[] CoinSensors = new Gpio[4];
        private List<CoinSensor> _coinSensorConfig;

        public void Setup(string denomination)
        {
            CoinSensors[0] = new Gpio(13);
            CoinSensors[1] = new Gpio(14);
            CoinSensors[2] = new Gpio(15);
            CoinSensors[3] = new Gpio(16);

            using var r = new StreamReader($"configuration/{denomination}.json");
            var json = r.ReadToEnd();
            _coinSensorConfig = JsonConvert.DeserializeObject<List<CoinSensor>>(json);
        }
        
        public void Loop()
        {
            
        }

        public void DropCoin(double weightGrams, double diameter)
        {
            var sensor = 0;
            foreach (var coinSensor in _coinSensorConfig)
            {
                if (IsInTolerance(weightGrams, diameter, coinSensor))
                {
                    sensor = coinSensor.sensor;
                    break;
                }
            }

            CoinSensors[sensor-1].State = GpioState.HIGH;
        }

        private static bool IsInTolerance(double weightGrams, double diameter, CoinSensor coinSensor)
        {
            return coinSensor.weight_grams - .001 < weightGrams  && weightGrams < coinSensor.weight_grams + .001
                && coinSensor.diameter_mm - .001 < diameter && diameter < coinSensor.diameter_mm + .001;
        }
    }
}