using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_Task1
{
    public class Storage 
    {// Масив не є ефективною колекцією для цього класу. ЇЇ слід було змвнити.
        private Product[] products;
        public Storage()
        {
            products = new Product[0];
        }
        public Storage(Product[] product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }
            Products = product;
        }
// Порушення інкапсуляції. проблема не глибоких копій!!!
        public Product[] Products
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
            var len = products.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (products[j].CompareTo(products[j+1])==-1)
                    {
                        Product temp = (Product)products[j].Clone();
                        products[j] = (Product)products[j+1].Clone();
                        products[j + 1] = (Product)temp.Clone();
                    }
                }
            }
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
                switch (menuCount)
                {
                    case 1:
                        {
                            Console.WriteLine("You chose Meat");
                            Meat newProduct = new Meat();
                            Console.WriteLine("Input name meat");
                            newProduct.Name = Console.ReadLine();

                            Console.WriteLine("Chose valute price");
                            Console.WriteLine("1 ---- Dollar");
                            Console.WriteLine("2 ---- Grn");
                            Console.WriteLine("3 ---- Euro");

                            int tempValute;
                            while (!int.TryParse(Console.ReadLine(), out tempValute) || tempValute < 1 || tempValute > 3)
                            {
                                Console.WriteLine("Input valid categoria");
                            };
                            switch (tempValute)
                            {
                                case 1:
                                    newProduct.ValutePrice = Valute.dollar;
                                    break;
                                case 2:
                                    newProduct.ValutePrice = Valute.grivna;
                                    break;
                                case 3:
                                    newProduct.ValutePrice = Valute.euro;
                                    break;
                                default:
                                    Console.WriteLine("No valid input");
                                    break;
                            }

                            Console.WriteLine("Input price meat");
                            double tempPrice;
                            while (!double.TryParse(Console.ReadLine(), out tempPrice) && tempPrice < 0)
                            {
                                Console.WriteLine("Input valid price");
                            };
                            newProduct.Price = tempPrice;

                            Console.WriteLine("Chose unit weight");
                            Console.WriteLine("1 ---- Kg");
                            Console.WriteLine("2 ---- Gramm");
                            int tempUnit;
                            while (!int.TryParse(Console.ReadLine(), out tempUnit) || tempUnit < 1 || tempUnit > 2)
                            {
                                Console.WriteLine("Input valid categoria");
                            };
                            switch (tempUnit)
                            {
                                case 1:
                                    newProduct.UnitWeight = Unit.kg;
                                    break;
                                case 2:
                                    newProduct.UnitWeight = Unit.gramm;
                                    break;
                                default:
                                    Console.WriteLine("No valid input");
                                    break;
                            }

                            Console.WriteLine("Input weight meat");
                            double tempWeight;
                            while (!double.TryParse(Console.ReadLine(), out tempWeight) && tempWeight < 0)
                            {
                                Console.WriteLine("Input valid weight");
                            };
                            newProduct.Weight = tempWeight;

                            Console.WriteLine("Chose categoria meat");
                            Console.WriteLine("1 ---- First");
                            Console.WriteLine("2 ---- Second");
                            int tempCategoria;
                            while (!int.TryParse(Console.ReadLine(), out tempCategoria) || tempCategoria < 1 || tempCategoria > 2)
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
                            products[i] = newProduct;
                            i++;
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("You chose Dairy product");
                            Dairy_Products newProduct = new Dairy_Products();
                            Console.WriteLine("Input name dairy product");
                            newProduct.Name = Console.ReadLine();

                            Console.WriteLine("Chose valute price");
                            Console.WriteLine("1 ---- Dollar");
                            Console.WriteLine("2 ---- Grn");
                            Console.WriteLine("3 ---- Euro");

                            int tempValute;
                            while (!int.TryParse(Console.ReadLine(), out tempValute) || tempValute < 1 || tempValute > 3)
                            {
                                Console.WriteLine("Input valid categoria");
                            };
                            switch (tempValute)
                            {
                                case 1:
                                    newProduct.ValutePrice = Valute.dollar;
                                    break;
                                case 2:
                                    newProduct.ValutePrice = Valute.grivna;
                                    break;
                                case 3:
                                    newProduct.ValutePrice = Valute.euro;
                                    break;
                                default:
                                    Console.WriteLine("No valid input");
                                    break;
                            }

                            Console.WriteLine("Input price dairy product");
                            double tempPrice;
                            while (!double.TryParse(Console.ReadLine(), out tempPrice) && tempPrice < 0)
                            {
                                Console.WriteLine("Input valid price");
                            };
                            newProduct.Price = tempPrice;



                            Console.WriteLine("Chose unit weight");
                            Console.WriteLine("1 ---- Kg");
                            Console.WriteLine("2 ---- Gramm");
                            int tempUnit;
                            while (!int.TryParse(Console.ReadLine(), out tempUnit) || tempUnit < 1 || tempUnit > 2)
                            {
                                Console.WriteLine("Input valid categoria");
                            };
                            switch (tempUnit)
                            {
                                case 1:
                                    newProduct.UnitWeight = Unit.kg;
                                    break;
                                case 2:
                                    newProduct.UnitWeight = Unit.gramm;
                                    break;
                                default:
                                    Console.WriteLine("No valid input");
                                    break;
                            }

                            Console.WriteLine("Input weight dairy product");
                            double tempWeight;
                            while (!double.TryParse(Console.ReadLine(), out tempWeight) && tempWeight < 0)
                            {
                                Console.WriteLine("Input valid weight");
                            };
                            newProduct.Weight = tempWeight;
                            Console.WriteLine("Input term dairy product");
                            int tempTerm;
                            while (!int.TryParse(Console.ReadLine(), out tempTerm) && tempTerm < 0)
                            {
                                Console.WriteLine("Input valid term");
                            };
                            newProduct.TermInDays = tempTerm;
                            products[i] = newProduct;
                            i++;
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("You chose Other");
                            Dairy_Products newProduct = new Dairy_Products();
                            Console.WriteLine("Input name product");
                            newProduct.Name = Console.ReadLine();

                            Console.WriteLine("Chose valute price");
                            Console.WriteLine("1 ---- Dollar");
                            Console.WriteLine("2 ---- Grn");
                            Console.WriteLine("3 ---- Euro");

                            int tempValute;
                            while (!int.TryParse(Console.ReadLine(), out tempValute) || tempValute < 1 || tempValute > 3)
                            {
                                Console.WriteLine("Input valid categoria");
                            };
                            switch (tempValute)
                            {
                                case 1:
                                    newProduct.ValutePrice = Valute.dollar;
                                    break;
                                case 2:
                                    newProduct.ValutePrice = Valute.grivna;
                                    break;
                                case 3:
                                    newProduct.ValutePrice = Valute.euro;
                                    break;
                                default:
                                    Console.WriteLine("No valid input");
                                    break;
                            }

                            Console.WriteLine("Input price product");
                            double tempPrice;
                            while (!double.TryParse(Console.ReadLine(), out tempPrice) && tempPrice < 0)
                            {
                                Console.WriteLine("Input valid price");
                            };
                            newProduct.Price = tempPrice;


                            Console.WriteLine("Chose unit weight");
                            Console.WriteLine("1 ---- Kg");
                            Console.WriteLine("2 ---- Gramm");
                            int tempUnit;
                            while (!int.TryParse(Console.ReadLine(), out tempUnit) || tempUnit < 1 || tempUnit > 2)
                            {
                                Console.WriteLine("Input valid categoria");
                            };
                            switch (tempUnit)
                            {
                                case 1:
                                    newProduct.UnitWeight = Unit.kg;
                                    break;
                                case 2:
                                    newProduct.UnitWeight = Unit.gramm;
                                    break;
                                default:
                                    Console.WriteLine("No valid input");
                                    break;
                            }


                            Console.WriteLine("Input weight product");
                            double tempWeight;
                            while (!double.TryParse(Console.ReadLine(), out tempWeight) && tempWeight < 0)
                            {
                                Console.WriteLine("Input valid weight");
                            };
                            newProduct.Weight = tempWeight;
                            products[i] = newProduct;
                            i++;
                        }
                        break;
                    case 0: { Console.WriteLine("Exit..."); } return;
                    default:
                        Console.WriteLine("Type number menu!");
                        break;
                }
            }
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
