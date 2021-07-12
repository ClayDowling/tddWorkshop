using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class ValueOfCoins : IValueOfCoin
    {
        public double ValueOfCoin(Coins coin)
        {
            switch (coin)
            {
                case Coins.dimes: return 0.10;
                case Coins.nickels: return 0.05;
                case Coins.quarters: return 0.25;
                case Coins.pennies: return 0.01;

                default: return 0;
            }
            
        }
    }
}
