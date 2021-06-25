using System;
using System.Text;


namespace NumeralSystems
{
    public static class Converter
    {
        public static char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };


        /// <summary>
        /// Converts a decimal number to the specified numeral system
        /// </summary>
        /// <param name="number">Decimal number for conversion</param>
        /// <param name="systemBase">Numeral system base of resulting number</param>
        /// <returns>Converted number in string</returns>
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


        /// <summary>
        /// Converts an int number to a string
        /// </summary>
        /// <param name="remainder">Result of X % Y expression</param>
        /// <returns>Equivalent char or corresponding letter</returns>
        private static char GetRemainder(int remainder) 
        {
            //return remainder >= 10 ? letters[remainder % 10] : 
            //       (char)(remainder + '0'); 
            remainder = RemoveSign(remainder);
            return remainder >= 10 ? letters[remainder % 10] :
                   (char)(remainder + '0');
        }


        /// <summary>
        /// Detects the sign of a number
        /// </summary>
        /// <param name="number">Signed or unsigned number</param>
        /// <returns>Minus or empty string</returns>
        private static string GetSign(int number) 
        {
            return number < 0 ? "-" : string.Empty;
        }


        /// <summary>
        /// Removes the number sign
        /// </summary>
        /// <param name="number">Signed or unsigned number</param>
        /// <returns>Unsigned number</returns>
        private static int RemoveSign(int number) 
        {
            return number < 0 ? -number : number;
        }
    }
}
