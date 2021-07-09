using System;
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

        private Action ButtonActionForTesting(int button)
        {
            return () => _buttonsPressedForTesting[button] = true;
        }
        
        public MainProcessorTest()
        {
            _mainProcessor = new MainProcessor();
            _buttonsPressedForTesting = new bool[3];
            _mainProcessor.AttachActionForButton(0, ButtonActionForTesting(0));
        }

        private readonly MainProcessor _mainProcessor;
        private readonly bool[] _buttonsPressedForTesting;

    }
}