using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBPS.InventoryManagement.Domain.OrderManagement
{
    internal class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int AmountOrdered { get; set; }

        public override string ToString()
        {
            return $"Product ID: {ProductId} - Name: {ProductName} - Amount ordered: {AmountOrdered}";
        }
    }
}
