using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Product
{
    public class Products : IProducts
    {
        private SerialBus _serialBus;
        public string SelectedProduct { get; set; }
        public Products(SerialBus serialBus)
        {
            _serialBus = serialBus;
            productsList.Add("cola", 1.00);
            productsList.Add("chips", 0.50);
            productsList.Add("candy", 0.65);
        }
        public Dictionary<string, double> productsList = new Dictionary<string, double>();
        public Products()
        {
            productsList.Add("cola", 1.00);
            productsList.Add("chips", 0.50);
            productsList.Add("candy", 0.65);
        }


        //public bool CheckEligibilityOfProductWithCurrentAmount(double weightOfCoin, double diameterOfCoin, string product)
        //{
        //    bool flag = false;
        //    double currentAmount = _acceptCoin.AcceptCoins(weightOfCoin, diameterOfCoin);
        //    double productPrice = productsList.Where(x => x.Key.Contains(product))
        //        .Select(y => y.Value).FirstOrDefault();
        //    if (productPrice > currentAmount)
        //    {
        //        flag = true;
        //    }
        //    else
        //    {
        //        _serialBus.Send("Insert Coins");
        //    }

        //    return flag;
        //}

        public bool CheckProductExistsInMachine()
        {
            var ifExists = productsList.Where(x => x.Key == _serialBus.Recv().ToString()).Count();
            if (ifExists > 0)
            {
                SelectedProduct = _serialBus.Recv().ToString();
                return true;
            }

            return false;
        }

        public bool CheckEligibility()
        {
            var receivedAmount =  Convert.ToDouble(_serialBus.Recv());

            double productPrice = productsList.Where(x => x.Key.Contains(SelectedProduct))
                .Select(y => y.Value).FirstOrDefault();

            if (receivedAmount >= productPrice)
            {
                _serialBus.Send("Thank You");   
                return true;
            }
            else
            {
                _serialBus.Send($"PRICE ${productPrice}");
            }
            
            return false;
        }
    }
}
