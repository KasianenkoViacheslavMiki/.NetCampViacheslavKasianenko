using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_Task1
{
    public class ListElectricityConsumers:ICloneable
    {
        private int countsApartments=0;
        private string year = "";
        private int numberQuarter=0;
        private List<ElectricityConsumer> electricityConsumers;
        private readonly double pricekWt = 0;

        public ListElectricityConsumers()
        {
            pricekWt = 0;
            Year = "";
            NumberQuarter = 0;
            CountsApartments = 0;
            ElectricityConsumers = new List<ElectricityConsumer>();
        }
        public ListElectricityConsumers(int numberQuarter, string year, int countsApartments, List<ElectricityConsumer> electricityConsumers,double pricekWt)
        { 
            this.pricekWt=pricekWt;
            this.Year = year;
            NumberQuarter = numberQuarter;
            CountsApartments = countsApartments;
            ElectricityConsumers = new List<ElectricityConsumer> (electricityConsumers);
        }

        public int NumberQuarter 
        {
            get
            {
                return numberQuarter;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("numberQuarter not to be less zero");
                if (value >4) throw new ArgumentOutOfRangeException("numberQuarter not to be more fourth");
                numberQuarter = value;
            }
        }
        private int CountsApartments 
        {
            get
            {
                return countsApartments;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("countsApartments not to be less zero");
                countsApartments = value;
            }
        }
        public List<ElectricityConsumer> ElectricityConsumers
        {
            get
            {
                return electricityConsumers;
            }
            set
            {
                if (value == null) throw new Exception("electricityConsumers not to be equels null");
                CountsApartments = value.Count;
                electricityConsumers = new List<ElectricityConsumer>(value);
            }
        }
        public string Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public string? BiggestDebt()
        {
            if (electricityConsumers == null)
            {
                throw new NullReferenceException("electricityConsumers is null");
            }
            ElectricityConsumer[] arrayConsumers= electricityConsumers.ToArray();
            string findSurname = arrayConsumers[0].OwnerApartment;
            double findDebt = arrayConsumers[0].GetСost(pricekWt);
            for (int i=1; i < countsApartments; i++)
            {
                if (findDebt < arrayConsumers[i].GetСost(pricekWt))
                {
                    findSurname = arrayConsumers[i].OwnerApartment;
                }
            }
            return findSurname;
        }
        public int? NotUserElectricity()
        {
            return electricityConsumers.Find(x => x.GetСost(pricekWt) == 0).NumberApartment;
        }
        public int GetCountsApartments() { return countsApartments; }
        public object Clone()
        {
            return new ListElectricityConsumers( numberQuarter, year,  countsApartments, electricityConsumers,pricekWt);
        }
        public override string? ToString()
        {
            string result = "";
            foreach (ElectricityConsumer consumer in ElectricityConsumers)
            {
                result +=consumer.ToString()+"\n";
            }
            return result;
        }
        public string? ToStringWithCostAndDays()
        {
            string result = "";
            foreach (ElectricityConsumer consumer in ElectricityConsumers)
            {
                result += consumer.ToStringWithCostAndDays(pricekWt) + "\n";
            }
            return result;
        }
        public string? ToStringWithoutAdress()
        {
            string result = "";
            foreach (ElectricityConsumer consumer in ElectricityConsumers)
            {
                result += consumer.ToStringWithoutAdress() + "\n";
            }
            return result;
        }

    }
}
