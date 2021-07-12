using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface IAcceptCoins
    {
        double AcceptCoins(Coins coins);

        bool ValidateCoins(Coins coins);

        string DisplayMessage(string message);


    }
}
