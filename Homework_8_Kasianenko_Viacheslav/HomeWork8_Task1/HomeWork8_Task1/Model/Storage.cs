using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Model
{
    public class Storage
    {
        private IDictionary<Product,uint> products;

        public Storage()
        {
            products = new Dictionary<Product, uint>();
        }
        public Storage(IDictionary<Product, uint> product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }
            Products = product;
        }

        public IDictionary<Product, uint> Products
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
                return ToProductsList()[index];
            }
            set
            {
                if (value is not Product)
                {
                    throw new Exception("Value is not type Product");
                }
                ToProductsList()[index] = value;
            }
        }
        public List<Product> ListProduct
        {
            get
            {
                return ToProductsList();
            }
        }
        //Method for sort array name on alphabet order
        public void SortStorage()
        {
            ToProductsList().Sort();
        }

        //Method for change all price products
        public void ChangePriceOnAllProducts(int percentage)
        {
            foreach (Product p in ToProductsList())
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
            Console.WriteLine(ToString());
        }
        public List<Product> ExceptProductInStorage(Storage secondStorage)
        {
            SortedSet<Product> setFirstStorage = UnicalProduct();
            SortedSet<Product> setSecondStorage = secondStorage.UnicalProduct();
            return setFirstStorage.Except(setSecondStorage).ToList();
        }
        public List<Product> IntersectProductInStorages(Storage secondStorage)
        {
            SortedSet<Product> setFirstStorage = UnicalProduct();
            SortedSet<Product> setSecondStorage = secondStorage.UnicalProduct();
            return setFirstStorage.Intersect(setSecondStorage).ToList();
        }
        public List<Product> UnionProductInStorages(Storage secondStorage)
        {
            SortedSet<Product> setFirstStorage = UnicalProduct();
            SortedSet<Product> setSecondStorage = secondStorage.UnicalProduct();
            return setFirstStorage.Union(setSecondStorage).ToList();
        }
        private SortedSet<Product> UnicalProduct()
        {
            SortedSet<Product> mySet = new SortedSet<Product>();
            foreach (Product product in ToProductsList())
            {
                mySet.Add(product);
            }
            return new SortedSet<Product>(mySet);
        }
        public bool HasNameProductInStorage(string name)
        {
            return ToProductsList().Exists(x => x.Name == name);
        }
        public Product FindProductInStorage(string name, out uint quantity)
        {
            var find = products.FirstOrDefault(x => x.Key.Name == name);
            quantity = find.Value;
            return find.Key;
        }
        //Method for get array meats.
        public Meat[] GetMeat()
        {
            List<Meat> searchMeat = new List<Meat>();
            foreach (Product product in ToProductsList())
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
            List<Dairy_Products> searchDairyProducts = new List<Dairy_Products>();
            foreach (Product product in ToProductsList())
            {
                if (product is Dairy_Products dairy_Products)
                {
                    searchDairyProducts.Add((Dairy_Products)dairy_Products.Clone());
                }
            }
            return searchDairyProducts.ToArray();
        }

        private List<Product> ToProductsList()
        {
            return products.Keys.ToList<Product>();
        }

        public override string ToString()
        {
            string result = "";
            foreach (Product product in ToProductsList())
            {
                result += product.ToString();
                result += "\n";
            }
            return result;
        }

    }
}
