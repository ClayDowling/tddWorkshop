using System;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class MainProcessor
    {
        private readonly SerialBus _serialBus;
        private readonly Action[] _actions;
        private int _availableCash;

        public MainProcessor(SerialBus serialBus)
        {
            _serialBus = serialBus;
            ProductSelectionPanel = new ProductSelectionPanel();
            _actions = new Action[3];
            _actions[0] = DefaultNoOpAction;
            _actions[1] = DefaultNoOpAction;
            _actions[2] = DefaultNoOpAction;
            _availableCash = 0;
            Start();
        }

        private static void DefaultNoOpAction()
        {
        }

        private async void Start()
        {
            while (true)
            {
                for (var i = 0; i < ProductSelectionPanel.ButtonList.Count; ++i)
                {
                    var button = ProductSelectionPanel.ButtonList[i];
                    if (button.Gpio.State == GpioState.High)
                    {
                        button.Gpio.State = GpioState.Low;
                        _actions[i]();
                    }
                }

                var message = _serialBus.Recv();
                if (message != string.Empty)
                    _availableCash = int.Parse(message);
                
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

        public int AvailableCash()
        {
            return _availableCash;
        }
    }
}