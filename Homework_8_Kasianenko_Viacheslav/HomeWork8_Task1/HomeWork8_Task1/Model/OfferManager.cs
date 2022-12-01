using HomeWork8_Task1.Interface;
using HomeWork8_Task1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Model
{
    public class OfferManager : IOfferManager
    {
        readonly string pathOffer = "ProductOffers.txt";
        readonly string pathReletedProduct = "ProductRelated.txt";
        readonly IReadFile readFile = new ActionFile(); 

        private IDictionary<string, string[]> nameReletedProduct;
        private IList<IOfferProduct> offerProducts;
        public IList<IOfferProduct> OfferProduct 
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

        public void InitialisationOfferManager()
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
            IParseOfferProduct parseOfferProduct = new ParseString();

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
                offerProducts = parseOfferProduct.IParseOfferProduct(content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void ReadReletedProduct(string path)
        {
            IParseRelatedProduct parseReletedProduct = new ParseString();
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
                nameReletedProduct = parseReletedProduct.IParseRelatedProduct(content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RealizationOffer(Storage storage)
        {
            Product findProduct;
            uint quantity;
            bool beginWriteFile=true;
            foreach (IOfferProduct offer in offerProducts)
            {
                findProduct = storage.FindProductInStorage(offer.NameProduct, out quantity);
                if (findProduct == null || !(quantity > offer.QuantityProduct))
                {
                    offer.InvokeEventNotCanBeRealizationOffer(nameReletedProduct[offer.NameProduct],beginWriteFile);
                    beginWriteFile = false;
                }
            }
        }

        public void AddEventOffer(IOfferEvent.OfferHandler any)
        {
            foreach (IOfferProduct offer in offerProducts)
            {
                offer.NotCanBeRealizationOffer+= any;
            }
        }

        public void RemoveEventOffer(IOfferEvent.OfferHandler any)
        {
            foreach (IOfferProduct offer in offerProducts)
            {
                offer.NotCanBeRealizationOffer -= any;
            }
        }
    }
}
