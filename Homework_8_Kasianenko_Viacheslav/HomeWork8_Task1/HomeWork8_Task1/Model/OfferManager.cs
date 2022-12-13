using HomeWork8_Task1.Interface;
using HomeWork8_Task1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Model
{
    public class OfferManager 
    {
        public event Action<StreamWriter,StringEventArgs[]> NotCanBeRealizationOffer;


        readonly IReadFile readFile = new ActionFile(); 

        private IDictionary<string, string[]> nameReletedProduct;
        private IList<OfferProduct> offerProducts;
        public IList<OfferProduct> OfferProduct 
        {
            get
            {
                return offerProducts;
            }
            set 
            { 
                offerProducts = value;
            }
        }

        public IDictionary<string, string[]> NameReletedProduct
        {
            get
            {
                return nameReletedProduct;
            }
            set
            {
                nameReletedProduct = value;
            }
        }

        public void InitialisationOfferManager(string pathOffer, string pathReletedProduct)
        {
            try 
            { 
                ReadOffers(pathOffer);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            try
            {
                ReadReletedProduct(pathReletedProduct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void ReadOffers(string path)
        {
            ParseString parseOfferProduct = new ParseString();

            string[] content;
            try
            {
                content = readFile.ReadFile(path);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            try
            {
                offerProducts = parseOfferProduct.ParseOfferProduct(content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void ReadReletedProduct(string path)
        {
            ParseString parseReletedProduct = new ParseString();
            string[] content;
            try
            {
                content = readFile.ReadFile(path);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            try
            {
                nameReletedProduct = parseReletedProduct.ParseRelatedProduct(content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RealizationOffer(Storage storage,string pathResult)
        {
            Product findProduct;
            uint quantity;
            using (StreamWriter streamWriter = new StreamWriter(pathResult))
            {
                foreach (OfferProduct offer in offerProducts)
                {
                    findProduct = storage.FindProductInStorage(offer.NameProduct, out quantity);
                    if (findProduct == null || !(quantity > offer.QuantityProduct))
                    {
                        List<StringEventArgs> stringEventArgs = new List<StringEventArgs>();
                        stringEventArgs.Add(new StringEventArgs("| Не може бути реалізовано заказ: "+offer.ToString()));
                        foreach (string name in nameReletedProduct[offer.NameProduct]) stringEventArgs.Add(new StringEventArgs(name));
                        NotCanBeRealizationOffer?.Invoke(streamWriter, stringEventArgs.ToArray());
                    }
                }
            }
        }
    }
}
