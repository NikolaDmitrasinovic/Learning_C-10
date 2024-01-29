using ConsoleBPS.InventoryManagement.Domain.General;
using System.Text;
using System.Xml.Linq;

namespace ConsoleBPS.InventoryManagement.Domain.ProductManagement
{
    public class BoxedProduct : Product
    {
        private int amountPerBox;

        public int AmountPerBox
        {
            get { return amountPerBox; }
            set { amountPerBox = value; }
        }

        public BoxedProduct(int Id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) 
            : base(Id, name, description, price, unitType, maxAmountInStock)
        {
        }

        public string DisplayBoxProductDetails(string extraDetails)
        {
            StringBuilder sb = new();

            sb.Append($"{Id} {Name} \n{Description}\n{AmountInStock} item(s) in stock");

            sb.Append(extraDetails);

            if (IsBelowStockTreshold)
            {
                sb.Append(("\n!!STOCK Low!!"));
            }

            return sb.ToString();
        }

        public void UseBoxProduct(int items)
        {
            int smallestMultiple = 0;
            int batchSize;

            while (true)
            {
                smallestMultiple++;
                if (smallestMultiple * AmountPerBox > items)
                {
                    batchSize = smallestMultiple * AmountPerBox;
                    break;
                }
            }

            UseProduct(batchSize);
        }
    }
}
