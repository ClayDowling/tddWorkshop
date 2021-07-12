using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Product
{
    public class Products : IProducts
    {
        public Dictionary<string, double> productsList = new Dictionary<string, double>();
        public Products()
        {
            productsList.Add("cola",100);
            productsList.Add("chips",50);
            productsList.Add("candy",65);
        }


        public bool CheckEligibilityOfProductWithCurrentAmount(double currentAmount, string product)
        {
            return true; 
        }
    }
}
