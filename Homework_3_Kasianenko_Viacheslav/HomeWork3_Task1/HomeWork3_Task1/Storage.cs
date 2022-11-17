using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_Task1
{
    public class Storage
    {
        private Product[] product;

        public Storage()
        {
            product=new Product[0];
        }
        public Storage(Product[] product)
        {
            if (product == null) 
            { 
                throw new ArgumentNullException(); 
            }
            Product = product;
        }

        public Product[] Product 
        {
            get
            {
               return product;
            }
            set
            { 
                product = value; 
            }
        }
        //indexator for access to product in array products
        public Product this[int index]
        {
            get 
            { 
                return product[index]; 
            }
            set 
            { 
                product[index] = value; 
            }
        }
        //Method for change all price products
        public void ChangePriceOnAllProducts(int percentage)
        {
            foreach (Product p in product)
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
        //Method for get array meats.
        public Meat[] GetMeat()
        {
            Meat[] temp = new Meat[product.Length];
            int count = 0;
            foreach (Product product in Product)
            {
                if (product is Meat meat)
                {
                    temp[count].Name = meat.Name;
                    temp[count].Price = meat.Price;
                    temp[count].Weight = meat.Weight;
                    temp[count].Sort = meat.Sort;
                    temp[count].Categoria = meat.Categoria;
                }
            }
            Meat[] result = new Meat[temp.Length];
            foreach (Meat meat in temp)
            {
                result[count].Name = meat.Name;
                result[count].Price = meat.Price;
                result[count].Weight = meat.Weight;
                result[count].Sort = meat.Sort;
                result[count].Categoria = meat.Categoria;
            }
            return result;
        }
        //Method for get array dairy products.
        public Dairy_Products[] GetDairyProduct()
        {
            Dairy_Products[] temp = new Dairy_Products[product.Length];
            int count = 0;
            foreach (Product product in Product)
            {
                if (product is Dairy_Products dairy_Products)
                {
                    temp[count].Name = dairy_Products.Name;
                    temp[count].Price = dairy_Products.Price;
                    temp[count].Weight = dairy_Products.Weight;
                    temp[count].TermInDays = dairy_Products.TermInDays;
                }
            }
            Dairy_Products[] result = new Dairy_Products[temp.Length];
            foreach (Dairy_Products dairy_Products in temp)
            {
                result[count].Name = dairy_Products.Name;
                result[count].Price = dairy_Products.Price;
                result[count].Weight = dairy_Products.Weight;
                result[count].TermInDays = dairy_Products.TermInDays;
            }
            return result;
        }
        // Прив'язка до консолі в модельному класі!!!
        //Method for manual initialization of array products by console menu.
        public void ManualInitialization()
        {
            Console.WriteLine("Input count products");
            int count;
            do
            { 
                if (int.TryParse(Console.ReadLine(), out count))
                {
                    Console.WriteLine("Type number!");
                }
                else if (count < 0) 
                { 
                    Console.WriteLine("Count not can be less zero!"); 
                }
            } while (count < 0);
            for (int i = 0; i < count;)
            {
                Console.WriteLine("1 ---- Meat");
                Console.WriteLine("2 ---- Dairy product");
                Console.WriteLine("3 ---- Other");
                Console.WriteLine("0 ---- Break");
                int menuCount;
                if (int.TryParse(Console.ReadLine(), out menuCount))
                {
                    Console.WriteLine("Chose number menu!");
                }
                switch (menuCount){
                    case 1:
                        {
                            Console.WriteLine("You chose Meat");
                            Meat newProduct = new Meat();
                            Console.WriteLine("Input name meat");
                            newProduct.Name = Console.ReadLine();
                            Console.WriteLine("Input price meat");
                            double tempPrice;
                            while (!double.TryParse(Console.ReadLine(), out tempPrice)&& tempPrice<0)
                            {
                                Console.WriteLine("Input valid price");
                            };
                            newProduct.Price= tempPrice;

                            Console.WriteLine("Input weight meat");
                            double tempWeight;
                            while (!double.TryParse(Console.ReadLine(), out tempWeight)&& tempWeight<0)
                            {
                                Console.WriteLine("Input valid weight");
                            };
                            newProduct.Weight= tempWeight;

                            Console.WriteLine("Chose categoria meat");
                            Console.WriteLine("1 ---- First");
                            Console.WriteLine("2 ---- Second");
                            int tempCategoria;
                            while (!int.TryParse(Console.ReadLine(), out tempCategoria)||tempCategoria<1||tempCategoria>2)
                            {
                                Console.WriteLine("Input valid categoria");
                            };
                            switch (tempCategoria)
                            {
                                case 1:
                                    newProduct.Categoria = categoriaMeat.First;
                                    break;
                                case 2:
                                    newProduct.Categoria = categoriaMeat.Second;
                                    break;
                                default:
                                    Console.WriteLine("No valid input");
                                    break;
                            }

                            Console.WriteLine("Chose sort meat");
                            Console.WriteLine("1 ---- Mutton");
                            Console.WriteLine("2 ---- Veal");
                            Console.WriteLine("3 ---- Pork");
                            Console.WriteLine("4 ---- Chicken");

                            int tempSort;
                            while (!int.TryParse(Console.ReadLine(), out tempSort) || tempSort < 1 || tempCategoria > 4)
                            {
                                Console.WriteLine("Input valid categoria");
                            };
                            switch (tempCategoria)
                            {
                                case 1:
                                    newProduct.Sort = sortMeat.Mutton;
                                    break;
                                case 2:
                                    newProduct.Sort = sortMeat.Veal;
                                    break;
                                case 3:
                                    newProduct.Sort = sortMeat.Pork;
                                    break;
                                case 4:
                                    newProduct.Sort = sortMeat.Chicken;
                                    break;
                                default:
                                    Console.WriteLine("No valid input");
                                    break;
                            }
                            product[i] = newProduct;
                            i++;
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("You chose Dairy product");
                            Dairy_Products newProduct = new Dairy_Products();
                            Console.WriteLine("Input name dairy product");
                            newProduct.Name = Console.ReadLine();
                            Console.WriteLine("Input price dairy product");
                            double tempPrice;
                            while (!double.TryParse(Console.ReadLine(), out tempPrice)&& tempPrice<0)
                            {
                                Console.WriteLine("Input valid price");
                            };
                            newProduct.Price = tempPrice;

                            Console.WriteLine("Input weight dairy product");
                            double tempWeight;
                            while (!double.TryParse(Console.ReadLine(), out tempWeight)&& tempWeight<0)
                            {
                                Console.WriteLine("Input valid weight");
                            };
                            newProduct.Weight = tempWeight;
                            Console.WriteLine("Input term dairy product");
                            int tempTerm;
                            while (!int.TryParse(Console.ReadLine(), out tempTerm) && tempTerm<0)
                            {
                                Console.WriteLine("Input valid term");
                            };
                            newProduct.TermInDays=tempTerm;
                            product[i] = newProduct;
                            i++;
                        }  
                        break;
                    case 3:
                        {
                            Console.WriteLine("You chose Other");
                            Dairy_Products newProduct = new Dairy_Products();
                            Console.WriteLine("Input name product");
                            newProduct.Name = Console.ReadLine();
                            Console.WriteLine("Input price product");
                            double tempPrice;
                            while (!double.TryParse(Console.ReadLine(), out tempPrice) && tempPrice < 0)
                            {
                                Console.WriteLine("Input valid price");
                            };
                            newProduct.Price = tempPrice;

                            Console.WriteLine("Input weight product");
                            double tempWeight;
                            while (!double.TryParse(Console.ReadLine(), out tempWeight) && tempWeight < 0)
                            {
                                Console.WriteLine("Input valid weight");
                            };
                            newProduct.Weight = tempWeight;
                            product[i] = newProduct;
                            i++;
                        }
                        break;
                    default: 
                        Console.WriteLine("Type number menu!");
                        break;
                }
            }
        }
        
        public override string ToString()
        {
            string result = "";
            foreach (var product in product)
            {
                if (product is Meat meat)
                {
                    result+= meat.ToString();
                }
                else if (product is Dairy_Products dairy_Products)
                {
                    result += dairy_Products.ToString();
                }
                else
                {
                    result +=product.ToString();
                }
                result += "\n";
            }
            return result;
        }
    }
}
