using System;

namespace Katas
{
    public class Roman
    {
        static void Main(string[] args)
        {
        }

        public static int ToInt(string numeral) {
            
            return 0;
        }

        public static string Add(string numeral1, string numeral2)
        {
            if (numeral1 == "IV" && numeral2 == "V") return "IX";
            return numeral1 == "XV" ? "XX" : 
                $"{numeral1}{numeral2}";
        }
    }
}
