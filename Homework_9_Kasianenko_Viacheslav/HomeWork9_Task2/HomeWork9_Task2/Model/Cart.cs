using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork9_Task2.Enum;

namespace HomeWork9_Task2.Model
{
    public class Cart : ICloneable
    {
        private List<Buy> cartRows;
        private Valute valuteCart;

        public Cart(List<Buy> cartRows, Valute valute)
        {
            ValuteCart = valute;
            CartRows = new List<Buy>(cartRows);
        }

        public Cart()
        {
            cartRows = new List<Buy>();
        }

        private List<Buy> CartRows
        {
            get
            {
                return new List<Buy>(cartRows);
            }
            set
            {
                if (value is List<Buy>)
                {
                    List<Buy> valueList = new List<Buy>(value);
                    foreach (var item in valueList) item.Product = item.Product.ChangeValute(ValuteCart);
                    cartRows = valueList;
                }
                else throw new Exception("Value not list Buy");
            }
        }

        public Valute ValuteCart { get => valuteCart; set => valuteCart = value; }
        public void ChangeValureCart(Valute valute)
        {
            ValuteCart = valute;
            foreach (Buy item in cartRows)
            {
                item.Product.ChangeValute(ValuteCart);
            }
        }
        public void AddProductInCart(Product product, int countAdd)
        {
            Product productAdd = (Product)product.Clone();
            productAdd.ChangeValute(ValuteCart);
            Buy buyProduct = ThisProductHasInCart(productAdd);
            if (buyProduct != null)
            {
                buyProduct.AddQuantity(countAdd);
            }
            else
            {
                buyProduct = new Buy();
                buyProduct.AddQuantity(countAdd);
                buyProduct.Product = (Product)product.Clone();
                cartRows.Add(buyProduct);
            }
        }
        public void DeleteProductInCart(Product product, int countDelete)
        {
            Buy buyProduct = ThisProductHasInCart(product);
            if (buyProduct != null)
            {
                buyProduct.SubtractQuantity(countDelete);
            }
            else
            {
                throw new Exception("Not have what delete");
            }
        }

        private Buy ThisProductHasInCart(Product product) // Return reference on memory row in cartRows
        {
            Product checkProduct = (Product)product.Clone();
            foreach (var row in cartRows)
            {
                if (row.Product.Equals(checkProduct))
                {
                    return (Buy) row.Clone();
                }
            }
            return null;
        }
        public double GetCartPrice()
        {
            double price = 0;
            foreach (var item in CartRows)
            {
                price += item.GetTotalPrice();
            }
            return price;
        }

        public object Clone()
        {
            return new Cart(CartRows, ValuteCart);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            string result = "";
            foreach (var item in CartRows)
            {
                result += item.ToString() + "\n";
            }
            return result;
        }
    }
}
