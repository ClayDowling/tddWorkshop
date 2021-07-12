using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using VendingMachine.Product;
using VendingMachine;

namespace VendingMachineTests.Product
{
    public class ProductsTest
    {
        private IAcceptCoins acceptCoins = new AcceptCoin();
        Products products = new Products();
        [Fact]
        public void TestWeHaveAllTheProducts()
        {
          
            products.productsList.Count().Should().Be(3);
        }


        [Fact]
        public void ColaProductIsDispensedFromMachineTest()
        {
            acceptCoins.AcceptCoins(Coins.quarters);
            acceptCoins.AcceptCoins(Coins.quarters);
            acceptCoins.AcceptCoins(Coins.quarters);
            acceptCoins.AcceptCoins(Coins.quarters);

            products.CheckEligibilityOfProductWithCurrentAmount(acceptCoins.currentAmount, "cola").Should().Be(true);



        }
    }
}
