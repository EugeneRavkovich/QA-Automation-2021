using System;
using System.Text;


namespace NumeralSystems
{
    public static class Converter
    {
        private static char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };


        public static string Convert(int number, int systemBase) 
        {
            if (systemBase < 2 || systemBase > 20) 
            {
                throw new Exception("Numeral system base must belong to [2, 20]");
            }

            if (number == 0) return "0";

            StringBuilder convertedNumber = new StringBuilder();

            string sign = GetSign(number);
            number = RemoveSign(number);
            char remainder;

            while (number != 0) 
            {
                remainder = GetRemainder(number % systemBase);
                number /= systemBase;
                convertedNumber.Insert(0, remainder.ToString());
            }
            
            return convertedNumber.Insert(0, sign).ToString();
        }


        static char GetRemainder(int remainder) 
        {
            return remainder >= 10 ? letters[remainder % 10] : (char)(remainder+'0');
        }


        static string GetSign(int number) 
        {
            return number < 0 ? "-" : string.Empty;
        }


        static int RemoveSign(int number) 
        {
            return number < 0 ? -number : number;
        }
    }
}
