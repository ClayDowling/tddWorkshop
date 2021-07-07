using System;
using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class CoinAccepterTest
    {
        private CoinAccepter _accepter;

        public CoinAccepterTest()
        {
            _accepter = new CoinAccepter();
        }
        
        [Fact]
        public void Setup_byDefault_InitializesCoin1GpioToPin13()
        {
            _accepter.Setup();
            
            _accepter.Coin1.Pin.Should().Be(13);
            _accepter.Coin2.Pin.Should().Be(14);
            _accepter.Coin3.Pin.Should().Be(15);
            _accepter.Coin4.Pin.Should().Be(16);
        }
    }
}