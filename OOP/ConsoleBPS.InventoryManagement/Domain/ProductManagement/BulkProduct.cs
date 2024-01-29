using ConsoleBPS.InventoryManagement.Domain.General;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    public class BulkProduct(
        int id,
        string name,
        string? description,
        Price price,
        UnitType unitType,
        int maxAmountInStock,
        int amountPerBox)
        : BoxedProduct(id, name, description, price, unitType, maxAmountInStock, amountPerBox)
    {
        public DateTime ExpiryDateTime { get; set; }
        public string? StorageInstructions { get; set; }

        //public void UseFreshBoxedProduct(int items)
        //{
        //    UseBoxProduct(items);
        //}
    }
}
