using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Newtonsoft.Json;
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
            _accepter.CoinSensors[0].AttachInterrupt(ProcessNickle, GpioState.HIGH);
            _accepter.CoinSensors[1].AttachInterrupt(ProcessDime, GpioState.HIGH);
            _accepter.CoinSensors[2].AttachInterrupt(ProcessQuarter, GpioState.HIGH);
            _accepter.CoinSensors[3].AttachInterrupt(ProcessHalfDollar, GpioState.HIGH);
        }
        
        [Fact]
        public void Setup_byDefault_InitializesCoinGpiosToPins13to16()
        {
            _accepter.CoinSensors[0].Pin.Should().Be(13);
            _accepter.CoinSensors[1].Pin.Should().Be(14);
            _accepter.CoinSensors[2].Pin.Should().Be(15);
            _accepter.CoinSensors[3].Pin.Should().Be(16);
        }
        
        // TODO: allow for different GPIO wiring

        [Fact]
        public void DetectsNickle()
        {
            _accepter.DropCoin(5, 21.21);
            
            _cashDropped.Should().Be(5);
        }

        [Fact]
        public void DetectsDime()
        {
            _accepter.DropCoin(2.268, 17.91);
            
            _cashDropped.Should().Be(10);
        }
        
        [Fact]
        public void DetectsQuarter()
        {
            _accepter.DropCoin(5.670, 24.26);
            
            _cashDropped.Should().Be(25);
        }
        
        [Fact]
        public void DetectsHalfDollar()
        {
            _accepter.DropCoin(11.340, 30.61);
            
            _cashDropped.Should().Be(50);
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