using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IAcceptCoins
    {
        double currentAmount { get; set; }

        double AcceptCoins(double weightOfCoin, double diameterOfCoin);

        int ValidateCoins(double weightOfCoin, double diameterOfCoin);

    }
}
