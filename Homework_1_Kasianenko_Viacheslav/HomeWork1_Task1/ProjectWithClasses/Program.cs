namespace ProjectWithClasses
{
    internal class Program
    {
        static int Main(string[] args)
        {//yes
            //Demonstration instantiation of class Check 
            Check check = new Check();
            //Demonstration instantiation of class Product "bread"
            Product bread = new Product("Bread",14.32,1.34);
            //Demonstration instantiation of class Product "garlic"
            Product garlic = new Product();
            garlic.Name = "Garlic";
            garlic.Price = 1.3;
            garlic.Weight = 0.4;
            //Demonstration instantiation of class Buy "buyBread"
            Buy buyBread = new Buy(12, bread);
            //Demonstration instantiation of class Buy "buyGarlic"
            Buy buyGarlic = new Buy();
            buyGarlic.Quantity = 55;
            buyGarlic.Product = garlic;
            //Print information about classes Products
            check.Print(garlic);
            check.Print(bread);
            //Print information about classes Buy
            check.Print(buyGarlic);
            check.Print(buyBread);

            return 0;
        }
    }
}
