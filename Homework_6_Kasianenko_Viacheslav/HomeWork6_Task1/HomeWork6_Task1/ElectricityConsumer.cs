using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_Task1
{
    public class ElectricityConsumer:ICloneable
    {
        private int numberApartment = 0;
        private string adressApartment = "";
        private string ownerApartment = "";
        private double[] checkIndicatorElectricity;
        private DateTime[] datesСheckIndicatorElectricity = new DateTime[3];

        public ElectricityConsumer(int numberApartment, string adressApartment, string ownerApartment, 
                                   double[] checkIndicatorElectricity, 
                                   DateTime[] datesСheckIndicatorElectricity)
        {
            NumberApartment = numberApartment;
            AdressApartment = adressApartment;
            OwnerApartment = ownerApartment;
            CheckIndicatorElectricity = checkIndicatorElectricity;
            DatesСheckIndicatorElectricity = datesСheckIndicatorElectricity;
        }
        public int NumberApartment
        {
            get 
            { 
                return numberApartment; 
            }
            set 
            {
                if (value < 0) throw new ArgumentOutOfRangeException("numberApartment not to be less zero");
                numberApartment = value; 
            }    
        }
        public string AdressApartment
        {
            get
            {
                return adressApartment;
            }
            set
            {
                adressApartment = value; 
            }
        }
        public string OwnerApartment
        {
            get
            {
                return ownerApartment;
            }
            set
            {
                ownerApartment = value;
            }
        }
        public double[] CheckIndicatorElectricity
        {
            get
            {
                return checkIndicatorElectricity;
            }
            set
            {
                checkIndicatorElectricity = value;
            }
        }
        public DateTime[] DatesСheckIndicatorElectricity
        {
            get
            {
                return datesСheckIndicatorElectricity;
            }
            set
            {
                datesСheckIndicatorElectricity = value;
            }
        }
        
        public int GetDaysLastCheckElectricity()
        {
            return DateTime.Now.Subtract(DatesСheckIndicatorElectricity[2]).Days;
        }
        public double GetСost(double pricekWt)
        {
            double temp = (checkIndicatorElectricity[2] - checkIndicatorElectricity[0]);
            return pricekWt * (checkIndicatorElectricity[2] - checkIndicatorElectricity[0]);
        }
        public object Clone()
        {
            return new ElectricityConsumer(numberApartment, adressApartment, ownerApartment, checkIndicatorElectricity, datesСheckIndicatorElectricity);
        }
        public override string? ToString()
        {
            return String.Format("{0,-14} {1,-20} {2,-20} {3,15:dd.MM.yy} {4,20:#.00}  {5,21:dd.MM.yy} {6,21:#.00}  {7,22:dd.MM.yy} {8,22:#.00} ", numberApartment, ownerApartment,AdressApartment, datesСheckIndicatorElectricity[0], checkIndicatorElectricity[0], datesСheckIndicatorElectricity[1], checkIndicatorElectricity[1], datesСheckIndicatorElectricity[2], checkIndicatorElectricity[2]);
        }
        public string? ToStringWithoutAdress()
        {
            return String.Format("{0,-14} {1,-20} {2,15:dd.MM.yy} {3,20:#.00}  {4,21:dd.MM.yy} {5,21:#.00}  {6,22:dd.MM.yy} {7,22:#.00} ", numberApartment, ownerApartment, datesСheckIndicatorElectricity[0], checkIndicatorElectricity[0], datesСheckIndicatorElectricity[1], checkIndicatorElectricity[1], datesСheckIndicatorElectricity[2], checkIndicatorElectricity[2]);
        }
        public string? ToStringWithCostAndDays(double pricekWt)
        {
            return ToStringWithoutAdress() +String.Format("{0,23:#.00} {1,23} ", GetСost(pricekWt), GetDaysLastCheckElectricity());
        }
    }
}
