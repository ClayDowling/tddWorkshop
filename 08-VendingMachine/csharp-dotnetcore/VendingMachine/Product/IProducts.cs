using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Product
{
    public interface IProducts
    {
        bool CheckProductExistsInMachine();
        bool CheckEligibility();
       // bool CheckEligibilityOfProductWithCurrentAmount(double weightOfCoin, double diameterOfCoin, string product);
    }
}
