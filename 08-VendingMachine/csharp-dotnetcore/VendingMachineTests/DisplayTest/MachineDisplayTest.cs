using Xunit;
using NSubstitute;
using VendingMachine;
using FluentAssertions;
using VendingMachine.Display;

namespace VendingMachineTests.DisplayTest
{
    public class MachineDisplayTest
    {
        private IMachineDisplay machineDisplay = new MachineDisplay();
        [Fact]
        public void NoCoinsInserted()
        {
//            machineDisplay.DisplayMessage(null).Should().BeNull();        
        }

        [Fact]
        public void DisplayCurrentAmount()
        {
  //          machineDisplay.DisplayMessage("INSERT COIN").Should().Be("INSERT COIN");
        }
    }
}
