using HomeWork9_Task2.Enum;
using HomeWork9_Task2.Interface;
using HomeWork9_Task2.Model;
using HomeWork9_Task2.Service;
using HomeWork9_Task2.Test;
using System;
using System.Text;

namespace HomeWork9_Task2
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

            List<Product> productsList = new List<Product>
            {
                new Product("Яблука Скороспілки",23.23,2,Valute.grivna,Unit.kg),
                new Product("Виноград Кеші",11.23,2,Valute.grivna,Unit.kg),
                new Dairy_Products("Молоко \"Галиччина\"",11.32,1,Valute.grivna,Unit.bottle,15),
                new Dairy_Products("Молоко \"Коровчик\"",11.32,1,Valute.grivna,Unit.bottle,15),
                new Meat("Курячі грудки \"Селянські\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
                new Meat("Курячі грудки \"Наша Ряба\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
                new Product("Макарони \"З лану до столу\"",23.23,2,Valute.grivna,Unit.kg),
                new Product("Яблука Дющ",23.23,2,Valute.grivna,Unit.kg),
                new Product("Виноград Ларі",11.23,2,Valute.grivna,Unit.kg),
                new Dairy_Products("Молоко \"Марина\"",11.32,1,Valute.grivna,Unit.bottle,15),
                new Dairy_Products("Молоко \"Карина\"",11.32,1,Valute.grivna,Unit.bottle,15),
                new Meat("Курячі ніжки \"Машинки\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
                new Meat("Курячі крильця \"Наша Ряба\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
                new Product("Яблука Скороспілки",23.23,2,Valute.grivna,Unit.kg),
                new Product("Виноград Кеші",11.23,2,Valute.grivna,Unit.kg),
                new Dairy_Products("Молоко \"Галиччина\"",11.32,1,Valute.grivna,Unit.bottle,15),
                new Dairy_Products("Молоко \"Коровчик\"",11.32,1,Valute.grivna,Unit.bottle,15),
                new Meat("Курячі грудки \"Селянські\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
                new Meat("Курячі грудки \"Наша Ряба\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
                new Product("Макарони \"З лану до столу\"",23.23,2,Valute.grivna,Unit.kg),
                new Product("Яблука Дющ",23.23,2,Valute.grivna,Unit.kg),
                new Product("Виноград Ларі",11.23,2,Valute.grivna,Unit.kg),
                new Dairy_Products("Молоко \"Марина\"",11.32,1,Valute.grivna,Unit.bottle,15),
                new Dairy_Products("Молоко \"Карина\"",11.32,1,Valute.grivna,Unit.bottle,15),
                new Meat("Курячі ніжки \"Машинки\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
                new Meat("Курячі крильця \"Наша Ряба\"",51.22,3.2,Valute.grivna,Unit.kg,CategoriaMeat.Second,SortMeat.Chicken),
            };

            List<Product> productsListClone = new List<Product>(productsList);


            TimeCount timeCount = new TimeCount();
            timeCount.SetAction(ClassSortProduct.SortProduct);

            timeCount.TestQuickSort(productsListClone, SupportingElement.begin);

            timeCount.TestQuickSort(productsListClone, SupportingElement.end);

            timeCount.TestQuickSort(productsListClone, SupportingElement.random);


        }

    }
}