using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_Task1
{
    public class Buy: ICloneable
    {
        //Field
        private int quantity;
        private Product product;
        //Constructor
        public Buy()
        {
            this.quantity = 0;
            this.product = new Product();
        }
        public Buy(int quantity, Product product)
        {
            Quantity = quantity;
            Product = (Product)product.Clone();
        }
        //Property
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity not to have less than zero");
                }
                else quantity = value;
            }
        }
        public double GetTotalPrice()
        {
            return Quantity * Product.Price;
        }
        public double GetTotalWeight()
        {
            return Quantity * Product.Weight;
        }
        public Product Product
        {
            get
            {
                return (Product)product.Clone();
            }
            set
            {
                product = (Product)(value as Product).Clone();
            }
        }

        public override string ToString()
        {
            string result = "";
            if (product is Meat meat)
            {
                result += meat.ToString() + " Quantity: " + Quantity + "| Total Weight: " + GetTotalWeight().ToString("0.00") + "| Total Price: " + GetTotalPrice().ToString("0.00") + "|";
            }
            else if (product is Dairy_Products dairy_Products)
            {
                result += dairy_Products.ToString() + " Quantity: " + Quantity + "| Total Weight: " + GetTotalWeight().ToString("0.00") + "| Total Price: " + GetTotalPrice().ToString("0.00") + "|";
            }
            else
            {
                result += product.ToString() + " Quantity: " + Quantity + "| Total Weight: " + GetTotalWeight().ToString("0.00") + "| Total Price: " + GetTotalPrice().ToString("0.00") + "|";
            }
            return result;
        }

        public object Clone()
        {
            return new Buy(Quantity, Product);
        }
    }
}
