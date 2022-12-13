using HomeWork8_Task1.Interface;
using HomeWork8_Task1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Service
{
    public class ParseString   
    {
        public IList<OfferProduct> ParseOfferProduct(string[] strings)
        {
            IList<OfferProduct> result = new List<OfferProduct>();

            foreach (string str in strings)
            {
                string[] split = str.Split("|");
                if (split.Length == 0 || split.Length < 3) throw new Exception("Not valid string offer for parse");
                uint tempQuantity;
                if (!uint.TryParse(split[2],out tempQuantity)) throw new Exception("Not valid string for parse in uint");
                result.Add(new OfferProduct(split[0], split[1],tempQuantity));
            }
            return result;
        }

        public IDictionary<string, string[]> ParseRelatedProduct(string[] strings)
        {
            IDictionary<string, string[]> result = new Dictionary<string, string[]>();

            foreach (string str in strings)
            {
                string[] split = str.Split("-");
                if (split.Length !=2) throw new Exception("Not valid string for parse");
                string[] splitRelatedProduct = split[1].Split(",");
                result.Add(split[0],splitRelatedProduct);
            }
            return result;
        }
    }
}
