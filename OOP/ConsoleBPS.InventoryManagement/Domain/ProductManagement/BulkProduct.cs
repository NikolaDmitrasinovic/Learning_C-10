using ConsoleBPS.InventoryManagement.Domain.General;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    public class BulkProduct(
        int id,
        string name,
        string? description,
        Price price,
        int maxAmountInStock)
        : Product(id, name, description, price, UnitType.PerKg, maxAmountInStock)
    {
        public DateTime ExpiryDateTime { get; set; }
        public string? StorageInstructions { get; set; }

        //public void UseFreshBoxedProduct(int items)
        //{
        //    UseBoxProduct(items);
        //}

        public override void IncreaseStock()
        {
            AmountInStock++;
        }
    }
}
