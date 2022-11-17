using HomeWork3_Task1;

namespace HomeWork7_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage(new List<Product>
            {
                new Product("Tea",23.23,2,Valute.grivna,Unit.gramm),
                new Meat("Leg",32.13,3.2,Valute.dollar,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
                new Dairy_Products("Butter",21.32,11,Valute.euro,Unit.gramm,15),
                new Dairy_Products("Apple",11.32,1,Valute.grivna,Unit.kg,15),
                new Meat("Salo",41.13,5.2,Valute.euro,Unit.gramm,CategoriaMeat.Second,SortMeat.Pork),
                new Meat("Brisket",99.13,10.2,Valute.euro,Unit.gramm,CategoriaMeat.First,SortMeat.Mutton),
            });
            Storage storage1 = new Storage(new List<Product>
            {
                new Product("Koffe",12.1,2,Valute.grivna,Unit.gramm),
                new Meat("Wing",41.1,3.2,Valute.dollar,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
                new Dairy_Products("Butter",21.32,11,Valute.euro,Unit.gramm,15),
                new Dairy_Products("Tomato",4.32,1,Valute.grivna,Unit.kg,15),
                new Dairy_Products("Apple",11.32,1,Valute.grivna,Unit.kg,15),
                new Meat("Leg",32.13,3.2,Valute.dollar,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
            });


            List<Product> resultProductInFirstStorage = storage.ExceptProductInStorage(storage1);
            List<Product> resultProductInSecondStorage = storage1.ExceptProductInStorage(storage);
            List<Product> resultUnionProductInStorages = storage.UnionProductInStorages(storage1);
            List<Product> resultIntersectProductInFirstStorage = storage.IntersectProductInStorages(storage1);

            foreach (Product product in resultProductInFirstStorage)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
            foreach (Product product in resultProductInSecondStorage)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            foreach (Product product in resultUnionProductInStorages)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            foreach (Product product in resultIntersectProductInFirstStorage)
            {
                Console.WriteLine(product);
            }


        }
    }
}