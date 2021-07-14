using System;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class MainProcessor
    {
        private readonly SerialBus _serialBus;
        private readonly Action[] _actions;
        private int _availableCash;
        private readonly SerialBus _displayBus;
        private long _timeoutEnd = -1;
        
        public MainProcessor(SerialBus serialBus, int costForButton1, int costForButton2, int costForButton3)
        {
            _serialBus = serialBus;
            _displayBus = new SerialBus();
            ProductSelectionPanel = new ProductSelectionPanel();
            _actions = new Action[3];

            AttachActionForButton(0, new ProductSelection( this, costForButton1).Select);
            AttachActionForButton(1, new ProductSelection( this, costForButton2).Select);
            AttachActionForButton(2, new ProductSelection( this, costForButton3).Select);

            _availableCash = 0;
            Start();
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
                {
                    _availableCash = int.Parse(message);
                    SendDisplayMessage();
                }

                if (_timeoutEnd >= 0 && _timeoutEnd < DateTime.Now.Ticks)
                {
                    SendDisplayMessage();
                    _timeoutEnd = -1;
                }

                await Task.Delay(20);
            }
            // ReSharper disable once FunctionNeverReturns
            // This thread should die when the main testing thread stops executing
        }

        private void SendDisplayMessage()
        {
            if(_availableCash > 0)
                _displayBus.Send($"{_availableCash} cents");
            else 
            {
                _displayBus.Send($"Insert Coin");
            }
        }

        public ProductSelectionPanel ProductSelectionPanel { get; }

        private void AttachActionForButton(int i, Action action)
        {
            _actions[i] = action;
        }

        public int AvailableCash()
        {
            return _availableCash;
        }

        public SerialBus DisplayBus()
        {
            return _displayBus;
        }

        public void StartDisplayMessageTimeout()
        {
            _timeoutEnd = DateTime.Now.Ticks + (2500 * TimeSpan.TicksPerMillisecond);
        }

        public void PersistSale(int cost)
        {
            _availableCash -= cost;
            if (_availableCash > 0)
            {
                // TODO: give change
                _availableCash = 0;
            }
            // TODO: do we track sales?
        }
    }
}