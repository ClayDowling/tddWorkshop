using System;
using System.Collections.Generic;

namespace Katas
{
    public class Roman
    {
        private static List<Token> romanValues = new List<Token>()
        {
            new Token("L", 50),
            new Token("XL", 40),
            new Token("X", 10),
            new Token("IX", 9),
            new Token("V", 5),
            new Token("IV", 4),
            new Token("I", 1),
        };
        
        static void Main(string[] args)
        {
        }

        public static int ToInt(string numeral)
        {
            var result = 0;

            foreach(var token in romanValues) {
                while(numeral.StartsWith(token.Roman)) {
                    result += token.Arabic;
                    numeral = numeral.Substring(token.Roman.Length);
                }
            }

            return result;
        }




        public static string Add(string numeral1, string numeral2)
        {
            int value = ToInt(numeral1) + ToInt(numeral2);
            string roman = "";

            foreach(var token in romanValues) {
                while (token.Arabic <= value) {
                    roman += token.Roman;
                    value -= token.Arabic;
                }
            }

            return roman;
        }
    }

    internal class Token
    {
        public Token(string r, int a) {
            Roman = r;
            Arabic = a;
        }
        public string Roman { get; set; }
        public int Arabic { get; set; }
    }
}
