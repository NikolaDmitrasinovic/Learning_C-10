using ConsoleBPS.InventoryManagement.Domain.Contracts;
using ConsoleBPS.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    public class RegularProduct : Product, ISaveable
    {
        public RegularProduct(int Id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) 
            : base(Id, name, description, price, unitType, maxAmountInStock)
        {
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};4;";
        }

        public override object Clone()
        {
            return new BoxedProduct(0, Name, Description, new Price() { ItemPrice = Price.ItemPrice, Currency = Price.Currency }, UnitType, maxItemsInStock, AmountInStock);
        }
    }
}
