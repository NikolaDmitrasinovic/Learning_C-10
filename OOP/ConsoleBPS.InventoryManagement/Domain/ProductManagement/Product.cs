using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ConsoleBPS.InventoryManagement.Domain.General;
using ConsoleBPS.InventoryManagement.Domain.ProductManagement;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {
        private int id;
        private string name = string.Empty;
        private string? description;

        private int maxItemsInStock = 0;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value.Length > 50 ? value[..50] : value; }
        }

        public string? Description
        {
            get { return description; }
            set {
                if (value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Length > 250 ? value[..250] : value;
                }
            }
        }

        public UnitType UnitType { get; set; }
        public int AmountInStock { get; private set; }
        public bool IsBelowStockTreshold { get; private set; }

        public Price Price { get; set; }

        public Product(int Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }

        public Product(int Id) : this(Id, string.Empty)
        {
        }

        public Product(int Id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock)
        {
            this.Id = Id;
            Name = name;
            Description = description;
            Price = price;
            UnitType = unitType;
            AmountInStock = maxAmountInStock;

            maxItemsInStock = maxAmountInStock;

            this.UpdateLowStock();
        }

        public void UseProduct(int items)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;

                UpdateLowStock();

                Log($"Amount int stock updated. Now {AmountInStock} items in stock.");
            }
            else
            {
                Log(
                    $"Not enough items on stock for {CreateSimpleProductRepresentation()}. {AmountInStock} available but {items} requested.");
            }
        }

        public void IncreaseStock()
        {
            AmountInStock++;
        }

        public void IncreaseStock(int amount)
        {
            int newStock = AmountInStock + amount;

            if (newStock <= maxItemsInStock)
            {
                AmountInStock += amount;
            }
            else
            {
                AmountInStock = maxItemsInStock;
                Log($"{CreateSimpleProductRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordered that couldn't be stored.");
            }

            if (AmountInStock > 10)
            {
                IsBelowStockTreshold = false;
            }
        }

        private void DecreaseStock(int items, string reason)
        {
            if (items <= AmountInStock)
            {
                AmountInStock -= items;
            }
            else
            {
                AmountInStock = 0;
            }

            UpdateLowStock();

            Log(reason);
        }

        public string DisplayDetailsShort()
        {
            return $"{id}. {name}\n{Price} \n{AmountInStock} item(s) in stock";
        }

        public string DisplayDetailsFull()
        {
            StringBuilder sb = new();

            sb.Append($"{id} {name} \n{description}\n{Price}\n{AmountInStock} item(s) in stock");

            if (IsBelowStockTreshold)
            {
                sb.Append(("\n!!STOCK Low!!"));
            }

            return sb.ToString();
        }

        public string DisplayDetailsFull(string extraDetails)
        {
            StringBuilder sb = new();

            sb.Append($"{id} {name} \n{description}\n{AmountInStock} item(s) in stock");

            sb.Append(extraDetails);

            if (IsBelowStockTreshold)
            {
                sb.Append(("\n!!STOCK Low!!"));
            }

            return sb.ToString();
        }
    }
}
