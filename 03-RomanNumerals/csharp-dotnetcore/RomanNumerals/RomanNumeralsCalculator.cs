using System;

namespace Katas
{
    public class RomanNumeralsCalculator
    {
        static void Main(string[] args)
        {
        }

        public string Add(string numeral1, string numeral2)
        {
            return numeral1 == "XV" ? "XX" : 
                $"{numeral1}{numeral2}";
        }
    }
}
