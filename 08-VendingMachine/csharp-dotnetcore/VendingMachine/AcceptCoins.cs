using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class AcceptCoin : IAcceptCoins
    {
        private IValueOfCoin valueOfCoin = new ValueOfCoins();
        //public AcceptCoin (IValueOfCoin valueOfCoin)
        //{
        //    this.valueOfCoin = valueOfCoin;
        //}

       public double currentAmount { get; set; }
       public double AcceptCoins(Coins coins)
        {
            if(ValidateCoins(coins))
            {
                currentAmount += valueOfCoin.ValueOfCoin(coins);
                DisplayMessage(currentAmount.ToString());
            }

            return currentAmount;
            
        }

        public  bool ValidateCoins(Coins coins)
        {
            bool validate = false;
            if (coins == Coins.quarters || coins == Coins.nickels || coins == Coins.dimes)
                validate = true;
            else if (coins == Coins.pennies)
                validate = false;
            return validate;
        }

        public string DisplayMessage(string message)
        {
            return message;
        }
    }
}
