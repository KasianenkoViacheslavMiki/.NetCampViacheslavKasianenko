using HomeWork3_Task1;

namespace HomeWork5_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {// Ваші бали 90	110	90	85	90
            Storage storage = new Storage(new Product[]
            {
                new Product("Tea",23.23,2,Valute.grivna,Unit.gramm),
                new Meat("Leg",32.13,3.2,Valute.dollar,Unit.kg,categoriaMeat.Second,sortMeat.Chicken),
                new Dairy_Products("Butter",21.32,11,Valute.euro,Unit.gramm,15),
                new Dairy_Products("Apple",11.32,1,Valute.grivna,Unit.kg,15),
                new Meat("Salo",41.13,5.2,Valute.euro,Unit.gramm,categoriaMeat.Second,sortMeat.Pork),
                new Meat("Brisket",99.13,10.2,Valute.euro,Unit.gramm,categoriaMeat.First,sortMeat.Mutton),
            });
            Buy[] arrayBuys = new Buy[]
            {
                new Buy (1,storage[0]),
                new Buy (3,storage[1]),
                new Buy (4,storage[3]),

            };


            Cart cart = new Cart(arrayBuys.ToList(),Valute.dollar);

            cart.AddProductInCart(storage[0], 2);

            Check.Print(cart);
        }
    }
}
