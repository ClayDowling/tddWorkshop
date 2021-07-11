using System;
using System.Threading;
using FluentAssertions;
using VendingMachine;
using Xunit;

namespace VendingMachineTests
{
    public class MainProcessorButtonPanelIntegrationTest
    {
        [Fact]
        public void ProcessorButtonActionsNotTriggeredByDefault()
        {
            _buttonsPressedForTesting[0].Should().BeFalse();
            _buttonsPressedForTesting[1].Should().BeFalse();
            _buttonsPressedForTesting[2].Should().BeFalse();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void ProperActionTriggeredOnButtonPress(int button)
        {
            _mainProcessor.ProductSelectionPanel.ButtonList[button].State = ButtonState.Pressed;
            Thread.Sleep(300);
            _mainProcessor.ProductSelectionPanel.ButtonList[button].State = ButtonState.Released;

            for (var i = 0; i < _mainProcessor.ProductSelectionPanel.ButtonList.Count; ++i)
            {
                if (button == i)
                {
                    _buttonsPressedForTesting[i].Should().BeTrue();
                }
                else
                {
                    _buttonsPressedForTesting[i].Should().BeFalse();
                }
            }
        }
        
        private Action ButtonActionForTesting(int button)
        {
            return () => _buttonsPressedForTesting[button] = true;
        }
        
        public MainProcessorButtonPanelIntegrationTest()
        {
            _mainProcessor = new MainProcessor(new SerialBus());
            _buttonsPressedForTesting = new bool[3];
            _mainProcessor.AttachActionForButton(0, ButtonActionForTesting(0));
            _mainProcessor.AttachActionForButton(1, ButtonActionForTesting(1));
            _mainProcessor.AttachActionForButton(2, ButtonActionForTesting(2));
        }

        private readonly MainProcessor _mainProcessor;
        private readonly bool[] _buttonsPressedForTesting;

    }
}