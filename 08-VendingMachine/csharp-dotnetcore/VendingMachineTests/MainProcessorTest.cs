using System.Threading;
using FluentAssertions;
using Xunit;

namespace VendingMachineTests
{
    public class MainProcessorTest
    {
        [Fact]
        public void ProcessorHasButtonActions()
        {
            // TODO: weak test
            _mainProcessor.ProductSelectionPanel.Should().NotBeNull();

            _buttonsPressedForTesting[0].Should().BeFalse();
            _buttonsPressedForTesting[1].Should().BeFalse();
            _buttonsPressedForTesting[2].Should().BeFalse();
        }

        [Fact]
        public void SomethingOnButtonPress()
        {
            _mainProcessor.ProductSelectionPanel.ButtonList[0].State = ButtonState.Pressed;
            Thread.Sleep(300);
            _mainProcessor.ProductSelectionPanel.ButtonList[0].State = ButtonState.Released;
            
            _buttonsPressedForTesting[0].Should().BeTrue();
            _buttonsPressedForTesting[1].Should().BeFalse();
            _buttonsPressedForTesting[2].Should().BeFalse();
            
        }

        private void ButtonActionForTesting(int button)
        {
            
        }
        
        private void ButtonZeroActionForTesting()
        {
            _buttonsPressedForTesting[0] = true;
        }
        
        public MainProcessorTest()
        {
            _mainProcessor = new MainProcessor();
            _buttonsPressedForTesting = new bool[3];
            _mainProcessor.AttachActionForButton(0, ButtonZeroActionForTesting);
        }

        private readonly MainProcessor _mainProcessor;
        private bool[] _buttonsPressedForTesting;

    }
}