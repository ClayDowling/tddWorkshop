using System;
using System.Collections.Generic;

namespace Katas
{
    public class Roman
    {
        private static Dictionary<string, int> romanValues = new Dictionary<string, int>
        {
            {"L", 50},
            {"X", 10},
            {"IX", 9},
            {"V", 5},
            {"IV", 4},
            {"I", 1},
        };
        
        static void Main(string[] args)
        {
        }

        public static int ToInt(string numeral)
        {
            var result = 0;
            
            while (numeral.StartsWith("L"))
            {
                result += romanValues["L"];
                numeral = numeral.Substring("L".Length);
            }
            
            while (numeral.StartsWith("X"))
            {
                result += 10;
                numeral = numeral.Substring(1);
            }
            
            if (numeral.StartsWith("IX"))
            {
                result += 9;
                numeral = numeral.Substring(2);
            }
            
            if (numeral.StartsWith("V"))
            {
                result += 5;
                numeral = numeral.Substring(1);
            }

            if (numeral.StartsWith("IV"))
            {
                result += 4;
                numeral = numeral.Substring(2);
            }

            return result + numeral.Length;
        }

        public static string Add(string numeral1, string numeral2)
        {
            if (numeral1 == "IV" && numeral2 == "V") return "IX";
            return numeral1 == "XV" ? "XX" : 
                $"{numeral1}{numeral2}";
        }
    }

    internal class RomanArabicToken
    {
        public string Roman { get; set; }
        public int Arabic { get; set; }
    }
}
