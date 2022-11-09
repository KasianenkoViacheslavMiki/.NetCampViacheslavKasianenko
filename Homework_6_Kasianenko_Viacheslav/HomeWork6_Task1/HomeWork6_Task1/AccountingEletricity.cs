using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6_Task1
{
    public class AccountingEletricity
    {
        private readonly string[,] month = {              { "січень", "лютий","березень" },
                                                          { "квітень", "травень","червень" },
                                                          { "липень", "серпень","вересень" },
                                                          { "жовтень", "листопад","грудень" }};
        private readonly double pricekWt = 6.5;
        private ListElectricityConsumers listElectricity;
        public AccountingEletricity(double pricekWt)
        {
            this.pricekWt = pricekWt;
        }
        public AccountingEletricity()
        {
            this.pricekWt = 6.5;
        }
        public void ReadFile(int numberQuarter,string year)
        {
            if (!File.Exists(numberQuarter.ToString() + "-" + year + ".txt")) 
            {
                throw new Exception("File not exists");
            }
            ListElectricityConsumers listElectricityConsumers = new ListElectricityConsumers();
            using (StreamReader readOnlyStream = File.OpenText(numberQuarter.ToString() + "-" + year + ".txt"))
            {
                int parseNumberQuarter;
                int parseCountApartments;
                List<ElectricityConsumer> list = new List<ElectricityConsumer>();
                string input = null;
                input = readOnlyStream.ReadLine();
                string[] subs = input.Split("|");
                if (subs.Length < 0)
                {
                    throw new Exception("Format file unvalid");
                }
                if (!int.TryParse(subs[0], out parseCountApartments))
                {
                    throw new Exception("Can`t read count apartments");
                }
                if (!int.TryParse(subs[1], out parseNumberQuarter))
                {
                    throw new Exception("Can`t read number quarter");
                }
                if (numberQuarter != parseNumberQuarter)
                {
                    throw new Exception("File quarter not equal search quarter");
                }
                while ((input = readOnlyStream.ReadLine()) != null)
                {
                    int numberApartment = 0;
                    string adressApartment = "";
                    string ownerApartment = "";
                    DateTime[] datesСheckIndicatorElectricity = new DateTime[3];
                    double[] checkIndicatorElectricity = new double[3];
                    subs = input.Split("|");
                    if (!int.TryParse(subs[0], out numberApartment))
                    {
                        throw new Exception("Can`t read number apartment");
                    }
                    if ((adressApartment = subs[1])==null)
                    {
                        throw new Exception("Can`t read adress apartment");
                    }
                    if ((ownerApartment = subs[2]) == null)
                    {
                        throw new Exception("Can`t read owner apartment");
                    }
                    if (!DateTime.TryParse(subs[3], out datesСheckIndicatorElectricity[0]))
                    {
                        throw new Exception("Can`t read first date in quarter");
                    }
                    if (!double.TryParse(subs[4], out checkIndicatorElectricity[0]))
                    {
                        throw new Exception("Can`t read first indicator electricity");
                    }
                    if (!DateTime.TryParse(subs[5], out datesСheckIndicatorElectricity[1]))
                    {
                        throw new Exception("Can`t read second date in quarter");
                    }
                    if (!double.TryParse(subs[6], out checkIndicatorElectricity[1]))
                    {
                        throw new Exception("Can`t read second indicator electricity");
                    }
                    if (!DateTime.TryParse(subs[7], out datesСheckIndicatorElectricity[2]))
                    {
                        throw new Exception("Can`t read third date in quarter");
                    }
                    if (!double.TryParse(subs[8], out checkIndicatorElectricity[2]))
                    {
                        throw new Exception("Can`t read third indicator electricity");
                    }
                    list.Add(new ElectricityConsumer(numberApartment,adressApartment,ownerApartment, checkIndicatorElectricity, datesСheckIndicatorElectricity));
                }
                listElectricity = new ListElectricityConsumers(parseNumberQuarter,year, parseCountApartments, new List<ElectricityConsumer>(list), pricekWt);
            }
        }
        public void WriteFileInfoForUser()
        {
            if (listElectricity == null)
            {
                throw new Exception("listElectricity is null. Can`t write file");
            }
            using (StreamWriter writer = File.CreateText(listElectricity.NumberQuarter + "-" + listElectricity.Year + "-User"+".txt"))
            {
                writer.WriteLine("Рік " + listElectricity.Year + ". Квартал " + listElectricity.NumberQuarter);
                writer.WriteLine(String.Format("{0,-6} {1,-20} {2,-20:dd.MM.yy} {3,-20:#.00} {4,-20:dd.MM.yy} {5,-20:#.00} {6,-20:dd.MM.yy} {7,-20:#.00}", "Номер квартири", "Власник квартири", "Дата зняття за " + month[listElectricity.NumberQuarter, 0], "Показник за " + month[listElectricity.NumberQuarter, 0], "Дата зняття за " + month[listElectricity.NumberQuarter, 1], "Показник за " + month[listElectricity.NumberQuarter, 1], "Дата зняття за " + month[listElectricity.NumberQuarter, 2], "Показник за " + month[listElectricity.NumberQuarter, 2]));
                writer.WriteLine(listElectricity.ToStringWithoutAdress());      
            }
        }
        public void WriteFileAboutOneApartament(int numberApartament)
        {
            ElectricityConsumer findApartament;
            if (listElectricity == null)
            {
                throw new NullReferenceException("listElectricity is null. Can`t write file");
            }
            if ((findApartament = listElectricity.ElectricityConsumers.Find(x => x.NumberApartment == numberApartament))==null)
            {
                throw new Exception("listElectricity have not this apartament");
            }
            using (StreamWriter writer = File.CreateText(listElectricity.NumberQuarter + "-" + listElectricity.Year + "Apartment№"+ findApartament.NumberApartment+ "-User" + ".txt"))
            {
                writer.WriteLine("Рік " + listElectricity.Year + ". Квартал " + listElectricity.NumberQuarter);
                writer.WriteLine(String.Format("{0,-6} {1,-20} {2,-20} {3,-20:dd.MM.yy} {4,-20:#.00} {5,-20:dd.MM.yy} {6,-20:#.00} {7,-20:dd.MM.yy} {8,-20:#.00}", "Номер квартири", "Власник квартири", "Адреса квартири","Дата зняття за " + month[listElectricity.NumberQuarter, 0], "Показник за " + month[listElectricity.NumberQuarter, 0], "Дата зняття за " + month[listElectricity.NumberQuarter, 1], "Показник за " + month[listElectricity.NumberQuarter, 1], "Дата зняття за " + month[listElectricity.NumberQuarter, 2], "Показник за " + month[listElectricity.NumberQuarter, 2]));
                writer.WriteLine(findApartament.ToString());
            }
        }
        public void WriteConsoleAboutOneApartament(int numberApartament)
        {
            ElectricityConsumer findApartament;
            if (listElectricity == null)
            {
                throw new Exception("listElectricity is null. Can`t write file");
            }
            if ((findApartament = listElectricity.ElectricityConsumers.Find(x => x.NumberApartment == numberApartament)) == null)
            {
                throw new Exception("listElectricity have not this apartament");
            }
            Console.WriteLine("Рік " + listElectricity.Year + ". Квартал " + listElectricity.NumberQuarter);
            Console.WriteLine(String.Format("{0,-6} {1,-20} {2,-20} {3,-20:dd.MM.yy} {4,-20:#.00} {5,-20:dd.MM.yy} {6,-20:#.00} {7,-20:dd.MM.yy} {8,-20:#.00}", "Номер квартири", "Власник квартири", "Адреса квартири", "Дата зняття за " + month[listElectricity.NumberQuarter, 0], "Показник за " + month[listElectricity.NumberQuarter, 0], "Дата зняття за " + month[listElectricity.NumberQuarter, 1], "Показник за " + month[listElectricity.NumberQuarter, 1], "Дата зняття за " + month[listElectricity.NumberQuarter, 2], "Показник за " + month[listElectricity.NumberQuarter, 2]));
            Console.WriteLine(findApartament.ToString());
        }
        public void WriteFileAboutAllInfo()
        {
            if (listElectricity == null)
            {
                throw new Exception("listElectricity is null. Can`t write file");
            }
            using (StreamWriter writer = File.CreateText(listElectricity.NumberQuarter + "-" + listElectricity.Year + "-UserAllInfo" + ".txt"))
            {
                writer.WriteLine("Рік " + listElectricity.Year + ". Квартал " + listElectricity.NumberQuarter);
                writer.WriteLine(String.Format("{0,-6} {1,-20} {2,-20:dd.MM.yy} {3,-20:#.00} {4,-20:dd.MM.yy} {5,-20:#.00} {6,-20:dd.MM.yy} {7,-20:#.00} {8,-20:#.00} {9,-20:#.00}", "Номер квартири", "Власник квартири", "Дата зняття за " + month[listElectricity.NumberQuarter, 0], "Показник за " + month[listElectricity.NumberQuarter, 0], "Дата зняття за " + month[listElectricity.NumberQuarter, 1], "Показник за " + month[listElectricity.NumberQuarter, 1], "Дата зняття за " + month[listElectricity.NumberQuarter, 2], "Показник за " + month[listElectricity.NumberQuarter, 2],"Заборгованість до сплати","Днів з останнього зняття показників"));
                writer.WriteLine(listElectricity.ToStringWithCostAndDays());
            }
        }
        public void WriteConsoleAboutAllInfo()
        {
            if (listElectricity == null)
            {
                throw new Exception("listElectricity is null. Can`t write file");
            }
            Console.WriteLine("Рік " + listElectricity.Year + ". Квартал " + listElectricity.NumberQuarter);
            Console.WriteLine(String.Format("{0,-6} {1,-20} {2,-20:dd.MM.yy} {3,-20:#.00} {4,-20:dd.MM.yy} {5,-20:#.00} {6,-20:dd.MM.yy} {7,-20:#.00} {8,-20:#.00} {9,-20:#.00}", "Номер квартири", "Власник квартири", "Дата зняття за " + month[listElectricity.NumberQuarter, 0], "Показник за " + month[listElectricity.NumberQuarter, 0], "Дата зняття за " + month[listElectricity.NumberQuarter, 1], "Показник за " + month[listElectricity.NumberQuarter, 1], "Дата зняття за " + month[listElectricity.NumberQuarter, 2], "Показник за " + month[listElectricity.NumberQuarter, 2], "Заборгованість до сплати", "Днів з останнього зняття показників"));
            Console.WriteLine(listElectricity.ToStringWithCostAndDays());
        }

    }
}
