using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBPS.InventoryManagement
{
    public class Product
    {
        private int id;
        private string name = string.Empty;
        private string? description;

        private int maxItemsInStock = 0;
        
        private UnitType unitType;
        private int amountInStock = 0;
        private bool isBelowStoctThreshold = false;

        public void UseProduct(int items)
        {
            if (items <= amountInStock)
            {
                amountInStock -= items;

                UpdateLowStock();

                Log($"Amount int stock updated. Now {amountInStock} items in stock.");
            }
            else
            {
                Log(
                    $"Not enough items on stock for {CreateSimpleProductRepresentation()}. {amountInStock} available but {items} requested.");
            }
        }

        public void IncreaseStock()
        {
            amountInStock++;
        }

        private void DecreaseStock(int items, string reason)
        {
            if (items <= amountInStock)
            {
                amountInStock -= items;
            }
            else
            {
                amountInStock = 0;
            }

            UpdateLowStock();

            Log(reason);
        }

        public string DisplayDetailsShrot()
        {
            return $"{id}. {name} \n{amountInStock} item(s) in stock");
        }

        public string DisplayDetailsFull()
        {
            StringBuilder sb = new();

            sb.Append($"{id} {name} \n{description}\n{amountInStock} item(s) in stock");

            if (isBelowStoctThreshold)
            {
                sb.Append(("\n!!STOCK Low!!"));
            }

            return sb.ToString();
        }

        private void UpdateLowStock()
        {
            if (amountInStock < 10)
            {
                isBelowStoctThreshold = true;
            }
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {id} ({name})";
        }
    }
}
