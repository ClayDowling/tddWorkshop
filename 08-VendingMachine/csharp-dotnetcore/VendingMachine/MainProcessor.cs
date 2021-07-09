using System;
using System.Threading;
using System.Threading.Tasks;
using VendingMachine;

namespace VendingMachineTests
{
    public class MainProcessor
    {
        private readonly Action[] _actions;

        public MainProcessor()
        {
            ProductSelectionPanel = new ProductSelectionPanel();
            _actions = new Action[3];
            _actions[0] = DefaultNoOpAction;
            _actions[1] = DefaultNoOpAction;
            _actions[2] = DefaultNoOpAction;
            Start();
        }

        private void DefaultNoOpAction()
        {
        }

        private async void Start()
        {
            while (true)
            {
                for (var i = 0; i < ProductSelectionPanel.ButtonList.Count; ++i)
                {
                    var button = ProductSelectionPanel.ButtonList[i];
                    if (button.Gpio.State == GpioState.HIGH)
                    {
                        button.Gpio.State = GpioState.LOW;
                        _actions[i]();
                    }
                }
                await Task.Delay(50);
            }
            // ReSharper disable once FunctionNeverReturns
            // This thread should die when the main testing thread stops executing
        }

        public ProductSelectionPanel ProductSelectionPanel { get; }

        public void AttachActionForButton(int i, Action action)
        {
            _actions[i] = action;
        }

        // TODO: need async loop to sniff for button presses
        public void StopProcessorForTesting()
        {
            
        }
    }
}