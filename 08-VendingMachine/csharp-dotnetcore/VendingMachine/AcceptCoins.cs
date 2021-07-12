using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Display;

namespace VendingMachine
{
    public class AcceptCoin : IAcceptCoins
    {
        private IValueOfCoin valueOfCoin = new ValueOfCoins();
        private IMachineDisplay machineDisplay = new MachineDisplay();
        private SerialBus _serialBus;

       public double currentAmount { get; set; }

       public AcceptCoin(SerialBus serialBus)
        {
            _serialBus = serialBus;
            _serialBus.Send("Insert Coins");
        }
       public double AcceptCoins(double weightOfCoin, double diameterOfCoin)
        {
            
            int denomianitaion = ValidateCoins(weightOfCoin, diameterOfCoin);
            currentAmount += denomianitaion;

            return currentAmount;

            
        }

        public int ValidateCoins(double weightOfCoin, double diameterOfCoin)
        {
            int valueOfInsertedCoin=0;

            if (weightOfCoin == 5.00 && diameterOfCoin == 21.21)
                valueOfInsertedCoin = 5;
            else if (weightOfCoin == 2.268 && diameterOfCoin == 17.91)
                valueOfInsertedCoin = 10;
            else if (weightOfCoin == 5.67 && diameterOfCoin == 24.26)
                valueOfInsertedCoin = 25;


            return valueOfInsertedCoin;
        }

    }
}
