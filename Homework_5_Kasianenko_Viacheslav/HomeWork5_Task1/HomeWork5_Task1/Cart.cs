using HomeWork3_Task1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5_Task1
{
    public class Cart : ICloneable
    {
        private List<Buy> cartRows;
        private Valute valuteCart;

        public Cart(List<Buy> cartRows,Valute valute)
        {
            ValuteCart= valute;
            CartRows = cartRows;
        }

        public Cart()
        {
            cartRows = new List<Buy>(); 
        }

        private List<Buy> CartRows
        {
            get
            {
                return cartRows;
            }
            set
            {
                if (value is List<Buy>)
                {
                    List<Buy> valueList = new List<Buy>(value);
                    foreach (var item in valueList) item.Product = item.Product.ChangeValute(ValuteCart);
                    cartRows = value;
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
            Product productAdd = (Product) product.Clone();
            productAdd.ChangeValute(ValuteCart);
            Buy buyProduct = ThisProductHasInCart(productAdd);
            if (buyProduct!=null)
            {
                buyProduct.Quantity += countAdd;
            }
            else
            {
                buyProduct = new Buy();
                buyProduct.Quantity = countAdd;
                buyProduct.Product = (Product) product.Clone();
                cartRows.Add(buyProduct);
            }
        }
        public void DeleteProductInCart(Product product, int countDelete)
        {
            Buy buyProduct = ThisProductHasInCart(product);
            if (buyProduct != null)
            {
                buyProduct.Quantity -= countDelete;
            }
            else
            {
                throw new Exception("Not have what delete");
            }
        }
        
        public Buy ThisProductHasInCart(Product product) // Return reference on memory row in cartRows
        {
            Product checkProduct = (Product)product.Clone();
            foreach (var row in cartRows)
            {
                Product tempProduct = (Product)row.Product.Clone();
                if (tempProduct is Meat && (tempProduct as Meat).Equals(checkProduct)){
                    return row;
                }
                else if (tempProduct is Dairy_Products && (tempProduct as Dairy_Products).Equals(checkProduct))
                {
                    return row;
                }
                else if (tempProduct is Product && tempProduct.Equals(checkProduct))
                {
                    return row;
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
            return new Cart(CartRows,ValuteCart);
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
                result += item.ToString()+"\n";
            }
            return result;
        }
    }
}
