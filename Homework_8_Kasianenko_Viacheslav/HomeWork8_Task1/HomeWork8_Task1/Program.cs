using HomeWork8_Task1.Enum;
using HomeWork8_Task1.Interface;
using HomeWork8_Task1.Model;
using HomeWork8_Task1.Service;
using System.Text;
using static HomeWork8_Task1.Interface.IOfferProduct;

namespace HomeWork8_Task1
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Storage storage = new Storage(new Dictionary<Product, uint>
            {
                { new Product("Яблука Скороспілки",23.23,2,Valute.grivna,Unit.kg), 50 },
                { new Product("Виноград Кеші",11.23,2,Valute.grivna,Unit.kg),50 },
                { new Dairy_Products("Молоко \"Галиччина\"",11.32,1,Valute.grivna,Unit.bottle,15),50 },
                { new Dairy_Products("Молоко \"Коровчик\"",11.32,1,Valute.grivna,Unit.bottle,15), 50 },
                { new Meat("Курячі грудки \"Селянські\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),50 },
                { new Meat("Курячі грудки \"Наша Ряба\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),50},
                { new Product("Макарони \"З лану до столу\"",23.23,2,Valute.grivna,Unit.kg),50}
            });

            IOfferEvent offerEvent = new OfferEvent();

            IOfferManager offerManager = new OfferManager();

            offerManager.InitialisationOfferManager();

            offerManager.AddEventOffer(offerEvent.OnOfferWriteFileEvent);

            offerManager.RealizationOffer(storage);

        }

    }
}