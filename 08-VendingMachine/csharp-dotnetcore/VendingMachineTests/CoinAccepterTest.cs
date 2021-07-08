using System;
using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class CoinAccepterTest
    {
        private CoinAccepter _accepter;
        private int _cashDropped;

        public CoinAccepterTest()
        {
            _accepter = new CoinAccepter();
            _accepter.Setup("UsaCoins");
            _cashDropped = 0;
            _accepter.CoinSensorGpios[0].AttachInterrupt(ProcessNickle, GpioState.HIGH);
            _accepter.CoinSensorGpios[1].AttachInterrupt(ProcessDime, GpioState.HIGH);
            _accepter.CoinSensorGpios[2].AttachInterrupt(ProcessQuarter, GpioState.HIGH);
            _accepter.CoinSensorGpios[3].AttachInterrupt(ProcessHalfDollar, GpioState.HIGH);
        }
        
        [Fact]
        public void Setup_byDefault_InitializesCoinGpiosToPins13to16()
        {
            _accepter.CoinSensorGpios[0].Pin.Should().Be(13);
            _accepter.CoinSensorGpios[1].Pin.Should().Be(14);
            _accepter.CoinSensorGpios[2].Pin.Should().Be(15);
            _accepter.CoinSensorGpios[3].Pin.Should().Be(16);
        }
        
        // TODO: allow for different GPIO wiring

        [Theory]
        [InlineData("Nickel", 5, 21.21, 5)]
        [InlineData("Dime", 2.268, 17.91, 10)]
        [InlineData("Quarter", 5.670, 24.26, 25)]
        [InlineData("Half-Dollar", 11.340, 30.61, 50)]
        public void AcceptsUsaCoins(string name, double weightGrams, double diameterMm, int expectedValue)
        {
            _accepter.DropCoin(weightGrams, diameterMm);
            _cashDropped.Should().Be(expectedValue);            
        }
        
        [Fact]
        public void RejectsPenney()
        {
            _accepter.DropCoin(2.5, 0.750);
            
            _cashDropped.Should().Be(0);
            // TODO: verify coin return triggered?
        }

        [Theory]
        [InlineData("Penny", 2.35, 19.05)]
        [InlineData("Nickle", 3.95, 21.2)]
        [InlineData("Dime", 1.75, 18.03)]
        [InlineData("Quarter", 4.4, 23.88)]
        [InlineData("Half-Dollar", 6.9, 27.13)]
        public void RejectsCanadianCoins(string name, double weightGrams, double diameterMm)
        {
            _accepter.DropCoin(weightGrams, diameterMm);
            _cashDropped.Should().Be(0);
            // TODO: verify coin return triggered?
        }
        
        private void ProcessNickle()
        {
            _cashDropped += 5;
        }

        private void ProcessDime()
        {
            _cashDropped += 10;
        }
        
        private void ProcessQuarter()
        {
            _cashDropped += 25;
        }
        
        private void ProcessHalfDollar()
        {
            _cashDropped += 50;
        }
    }
}