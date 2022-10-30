using HomeWork3_Task1;

namespace HomeWork4_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Check check = new Check();

            int temp = 50;
            Console.WriteLine((double)50/100);
            Storage storage = new Storage(new Product[]
            {
                new Product("Tea",23.23,2),
                new Meat("Leg",32.13,3.2,categoriaMeat.Second,sortMeat.Chicken),
                new Dairy_Products("Butter",21.32,11,15),
                new Dairy_Products("Apple",11.32,1,15),
                new Meat("Salo",41.13,5.2,categoriaMeat.Second,sortMeat.Pork),
                new Meat("Brisket",99.13,10.2,categoriaMeat.First,sortMeat.Mutton),
            });
           
            check.Print(storage);
            storage.SortStorage();
            check.Print(storage);

        }
    }
}