using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7_Task2
{
    static public class CheckCard
    {
        public static string InfoCheckCard(string _numberCard)
        {
            string numberCard = _numberCard;
            int lengthNumberCard = numberCard.Length;
            if (!IsNumberCardAllNumber(numberCard))
            {
                return "Number:\n" + numberCard;
            }
            if (IsCardAmericanExpress(numberCard, lengthNumberCard))
            {
                if (!AlgoritmLuna(numberCard, lengthNumberCard))
                {
                    return "Number:\n" + numberCard+ "\n"+"INVALID";
                }
                return "Number:\n" + numberCard + "\n"+"American Express";

            }
            if (IsCardMasterCard(numberCard, lengthNumberCard))
            {
                if (!AlgoritmLuna(numberCard, lengthNumberCard))
                {
                    return "Number:\n" + numberCard + "\n" + "INVALID";
                }
                return "Number:\n" + numberCard + "\n" + "MasterCard";
            }
            if (IsCardVisa(numberCard, lengthNumberCard))
            {
                if (!AlgoritmLuna(numberCard, lengthNumberCard))
                {
                    return "Number:\n" + numberCard + "\n" + "INVALID";
                }
                return "Number:\n" + numberCard + "\n" + "Visa";
            }
            return "Number:\n" + numberCard;
        }
        private static bool IsNumberCardAllNumber(string numberCard)
        {
            if (numberCard == null)
            {
                return false;
            }
            if (!long.TryParse(numberCard, out _))
            {
                return false;
            }
            return true;
        }
        private static bool IsCardAmericanExpress(string numberCard,int lengthNumberCard)
        {
            if (!(lengthNumberCard == 15))
            {
                return false;
            }
            string firstNumber = numberCard.Substring(0, 2);
            if (!(firstNumber == "34" || firstNumber == "37"))
            {
                return false;
            }
            return true;
        }
        private static bool IsCardMasterCard(string numberCard, int lengthNumberCard)
        {
            if (!(lengthNumberCard == 16))
            {
                return false;
            }
            string firstNumber = numberCard.Substring(0, 2);
            if (!(firstNumber == "51" || firstNumber == "52" || firstNumber == "53" || firstNumber == "54" || firstNumber == "55"))
            {
                return false;
            }
            return true;
        }
        private static bool IsCardVisa(string numberCard, int lengthNumberCard)
        {
            if (!(lengthNumberCard == 16 || lengthNumberCard == 13))
            {
                return false;
            }
            string firstNumber = numberCard.Substring(0, 1);
            if (!(firstNumber == "4"))
            {
                return false;
            }
            return true;
        }
        private static bool AlgoritmLuna(string numberCard, int lengthNumberCard)
        {
            int suma=0;
            int number, doublingNumber;
            int i= lengthNumberCard - 2;
            for (; i>=0; i-=2)
            {
                number = (int)Char.GetNumericValue(numberCard[i+1]);
                doublingNumber = (int)Char.GetNumericValue(numberCard[i])*2;
                doublingNumber = doublingNumber % 10 + doublingNumber / 10;
                suma += number + doublingNumber;
            }
            if (i == -1)
            {
                number = (int)Char.GetNumericValue(numberCard[0]);
                suma += number;
            }
            return suma%10==0;
        }
    }
}
