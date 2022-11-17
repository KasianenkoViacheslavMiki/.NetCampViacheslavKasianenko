using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_Task1
{
    public class Storage 
    {
        private List<Product> products;
        public Storage()
        {
            products = new List<Product>();
        }
        public Storage(List<Product> product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }
            Products = product;
        }

        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }
        //Іndexator for access to product in array products
        public Product this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                if (value is not Product)
                {
                    throw new Exception("Value is not type Product");
                }
                products[index] = value;
            }
        }
        //Method for sort array name on alphabet order
        public void SortStorage()
        {
            products.Sort();
        }

        //Method for change all price products
        public void ChangePriceOnAllProducts(int percentage)
        {
            foreach (Product p in products)
            {
                if (p is Meat meat)
                {
                    meat.ChangePrice(percentage);
                }
                else if (p is Dairy_Products dairy_Products)
                {
                    dairy_Products.ChangePrice(percentage);
                }
                else
                {
                    p.ChangePrice(percentage);
                }
            }
        }
        //Method for print all product in console.
        public void PrintProducts()
        {
            Console.WriteLine(this.ToString());
        }
        public List<Product> ExceptProductInStorage(Storage secondStorage)
        {
            SortedSet<Product> setFirstStorage = this.UnicalProduct();
            SortedSet<Product> setSecondStorage = secondStorage.UnicalProduct();
            return setFirstStorage.Except(setSecondStorage).ToList();
        }
        public List<Product> IntersectProductInStorages(Storage secondStorage)
        {
            SortedSet<Product> setFirstStorage = this.UnicalProduct();
            SortedSet<Product> setSecondStorage = secondStorage.UnicalProduct();
            return setFirstStorage.Intersect(setSecondStorage).ToList();
        }
        public List<Product> UnionProductInStorages(Storage secondStorage)
        {
            SortedSet<Product> setFirstStorage = this.UnicalProduct();
            SortedSet<Product> setSecondStorage = secondStorage.UnicalProduct();
            return setFirstStorage.Union(setSecondStorage).ToList();
        }
        private SortedSet<Product> UnicalProduct()
        {
            SortedSet<Product> mySet = new SortedSet<Product>();
            foreach (Product product in products)
            {
                mySet.Add(product);
            }
            return new SortedSet<Product>(mySet);
        }
        //Method for get array meats.
        public Meat[] GetMeat()
        {
            List<Meat> searchMeat = new List<Meat>();
            foreach (Product product in Products)
            {
                if (product is Meat meat)
                {
                    searchMeat.Add((Meat)meat.Clone());
                }
            }
            return searchMeat.ToArray();
        }
        //Method for get array dairy products.
        public Dairy_Products[] GetDairyProduct()
        {
            List<Dairy_Products> searchDairyProducts=new List<Dairy_Products>();
            foreach (Product product in Products)
            {
                if (product is Dairy_Products dairy_Products)
                {
                    searchDairyProducts.Add((Dairy_Products)dairy_Products.Clone());
                }
            }
            return searchDairyProducts.ToArray();
        }

        public override string ToString()
        {
            string result = "";
            foreach (var product in products)
            {
                if (product is Meat meat)
                {
                    result += meat.ToString();
                }
                else if (product is Dairy_Products dairy_Products)
                {
                    result += dairy_Products.ToString();
                }
                else
                {
                    result += product.ToString();
                }
                result += "\n";
            }
            return result;
        }

    }
}
