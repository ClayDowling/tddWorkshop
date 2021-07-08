using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace VendingMachine
{
    public class CoinAccepter
    {
        public Gpio Coin1; 
        public Gpio Coin2; 
        public Gpio Coin3; 
        public Gpio Coin4;
        private List<CoinSensor> _coinSensorConfig;

        public void Setup(string denomination)
        {
            Coin1 = new Gpio(13);
            Coin2 = new Gpio(14);
            Coin3 = new Gpio(15);
            Coin4 = new Gpio(16);
            
            using (StreamReader r = new StreamReader($"configuration/{denomination}.json"))
            {
                var json = r.ReadToEnd();
                _coinSensorConfig = JsonConvert.DeserializeObject<List<CoinSensor>>(json);
            }            
        }
        
        public void Loop()
        {
            
        }

        public void DropCoin(double weightGrams, double diameter)
        {
            var sensor = 0;
            foreach (var coinSensor in _coinSensorConfig)
            {
                if (coinSensor.weight_grams - .001 < weightGrams  && weightGrams < coinSensor.weight_grams + .001)
                {
                    sensor = coinSensor.sensor;
                    break;
                }
            }
            switch (sensor)
            {
                case 1:
                    Coin1.State = GpioState.HIGH;
                    break;
                case 2:
                    Coin2.State = GpioState.HIGH;
                    break;
            };
        }
    }
}