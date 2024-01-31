using ConsoleBPS.InventoryManagement.Domain.General;
using ConsoleBPS.InventoryManagement.Domain.ProductManagement;

namespace TestBPS.InventoryManagement
{
    public class ProductTests
    {
        [Fact]
        public void UseProduct_Reduces_AmountInStock()
        {
            // Arrange
            var product = new RegularProduct(1, "Sugar", "Lorem Ipsum",
                new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);

            // Act
            product.UseProduct(20);

            // Assert
            Assert.Equal(80, product.AmountInStock);
        }

        [Fact]
        public void UseProduct_REduces_AmountInStock_StockBelowThreshold()
        {
            // Arrange
            var product = new RegularProduct(1, "Sugar", "Lorem Ipsum",
                new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);

            var increaseValue = 100;
            product.IncreaseStock(increaseValue);

            // Act
            product.UseProduct(increaseValue -1);

            // Assert
            Assert.True(product.IsBelowStockTreshold);
        }
    }
}