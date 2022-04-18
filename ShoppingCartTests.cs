using Moq;
using Xunit;

namespace TDDRealWorld
{
    public class ShoppingCartTests
    {
        private Mock<Calculator> mockCalc;
        private ShoppingCart target;

        public ShoppingCartTests()
        {
            mockCalc = new Mock<Calculator>();
            mockCalc.Setup(_ => _.Add(It.IsAny<double[]>())).Returns(0);
            mockCalc.Setup(_ => _.Multiply(It.IsAny<double[]>())).Returns(0);

            target = new ShoppingCart(mockCalc.Object);
        }

        [Fact]
        public void AddItem_2Items_shouldHave2Items()
        {
            AddTestData();
            Assert.Equal(2, target.Items.Count);
        }

        [Fact]
        public void Total_with2Items_shouldSum2Items()
        {
            AddTestData();
            var result = target.Total;
            mockCalc.Verify(_ => _.Multiply(12, 2));
            mockCalc.Verify(_ => _.Multiply(13, 1));
            mockCalc.Verify(_ => _.Add(0, 0));
        }

        [Fact]
        public void Total_with2Items_shouldCalculateTaxOnApplicableItems()
        {
            AddTestData();
            var result = target.TotalWithTax;
            mockCalc.Verify(_ => _.Multiply(12, 2, 0.078));
            mockCalc.Verify(_ => _.Multiply(13, 1, 1));
            mockCalc.Verify(_ => _.Add(0, 0));
        }

        private void AddTestData()
        {
            var item1 = new ShoppingCartItem() { Price = 12, Quantity = 2, Taxable = true };
            var item2 = new ShoppingCartItem() { Price = 13, Quantity = 1, Taxable = false };
            target.AddItem(item1);
            target.AddItem(item2);
        }
    }
}
