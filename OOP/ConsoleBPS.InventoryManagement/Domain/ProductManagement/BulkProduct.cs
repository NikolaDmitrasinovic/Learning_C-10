using ConsoleBPS.InventoryManagement.Domain.Contracts;
using ConsoleBPS.InventoryManagement.Domain.General;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    public class BulkProduct(
        int id,
        string name,
        string? description,
        Price price,
        int maxAmountInStock)
        : Product(id, name, description, price, UnitType.PerKg, maxAmountInStock), ISaveable
    {
        public DateTime ExpiryDateTime { get; set; }
        public string? StorageInstructions { get; set; }

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};3;";
        }

        //public void UseFreshBoxedProduct(int items)
        //{
        //    UseBoxProduct(items);
        //}

        public override void IncreaseStock()
        {
            AmountInStock++;
        }

        public override object Clone()
        {
            return new BoxedProduct(0, Name, Description, new Price() { ItemPrice = Price.ItemPrice, Currency = Price.Currency }, UnitType, maxItemsInStock, AmountInStock);
        }
    }
}
