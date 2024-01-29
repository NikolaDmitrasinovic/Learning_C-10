using ConsoleBPS.InventoryManagement.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    public class BulkProduct : BoxedProduct
    {
        public DateTime ExpiryDateTime { get; set; }
        public string? StorageInstructions { get; set; }

        public BulkProduct(int Id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) 
            : base(Id, name, description, price, unitType, maxAmountInStock)
        {
        }

        public void UseFreshBoxedProduct(int items)
        {
            UseBoxProduct(3);
        }
    }
}
