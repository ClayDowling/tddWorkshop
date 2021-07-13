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
        public ProductsTest()
        {
            serialBus = new SerialBus();
            products = new Products(serialBus);
        }
        private SerialBus serialBus;
        private Products products;

        const int Nickle = 5;
        const int Dime = 10;
        const int Quarters = 25;

        const double WeightOfNickle = 5.00;
        const double WeightOfQuater = 5.67;
        const double WeightOfDime = 2.268;

        const double DiameterOfNickle = 21.21;
        const double DiameterofQuater = 24.26;
        const double DiameterofDime = 17.91;


        [Fact]
        public void TestWeHaveAllTheProducts()
        {

            products.productsList.Count().Should().Be(3);
        }

        [Fact]
        public void ColaExistInMachineTest()
        {
            serialBus.Send("cola");
            products.CheckProductExistsInMachine().Should().Be(true);
        }

        [Fact]
        public void PepsiDoesNotExistInMachineTest()
        {
            serialBus.Send("pepsi");
            products.CheckProductExistsInMachine().Should().Be(false);
        }

        [Fact]
        public void ColaProductIsDispensedFromMachineTest()
        {
            serialBus.Send("cola");
            if (products.CheckProductExistsInMachine())
            {
                serialBus.Send("2.00");
                products.CheckEligibility().Should().Be(true);
            }
        }

        [Fact]
        public void ColaProductAmountNotSufficientTest()
        {
            serialBus.Send("cola");
            if (products.CheckProductExistsInMachine())
            {
                serialBus.Send("0.30");
                products.CheckEligibility().Should().Be(false);
            }
        }

        [Fact]
        public void DisplayThankYouMessageTest()
        {
            serialBus.Send("cola");
            if (products.CheckProductExistsInMachine())
            {
                serialBus.Send("2.00");
                products.CheckEligibility().Should().Be(true);
                serialBus.Recv().Should().Be("Thank You");
            }
        }

        [Fact]
        public void DisplayProductPriceIfNotEligibleTest()
        {
            serialBus.Send("cola");
            if (products.CheckProductExistsInMachine())
            {
                serialBus.Send("0.05");
                products.CheckEligibility().Should().Be(false);
                serialBus.Recv().Should().Be("PRICE $1");
            }
        }
    }
}
