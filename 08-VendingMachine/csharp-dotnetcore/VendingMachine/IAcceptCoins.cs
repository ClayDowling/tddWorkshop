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

        double AcceptCoins(Coins coins);

        bool ValidateCoins(Coins coins);

    }
}
