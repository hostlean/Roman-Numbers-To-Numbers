using System;
using System.Collections.Generic;

namespace TestForTest
{
    using System;
    using System.Collections.Generic;

    class MainClass
    {
        public static string StringChallenge(string str) {
            
            return str;
        }

        static void Main() {
            
            //Console.WriteLine(StringChallenge(Console.ReadLine()));

            RomanNumber romanNumber = new RomanNumber();

            Console.WriteLine(romanNumber.RomanToNumber(Console.ReadLine()));
        }
    }

    public class RomanNumber
    {
        private Dictionary<char, int> romanLetters = new Dictionary<char, int>();

        public RomanNumber()
        {
            romanLetters.Add('I', 1);
            romanLetters.Add('V', 5);
            romanLetters.Add('X', 10);
            romanLetters.Add('L', 50);
            romanLetters.Add('C', 100);
            romanLetters.Add('D', 500);
            romanLetters.Add('M', 1000);

        }

        public int RomanToNumber(string str)
        {
            int number = 0;
            int newNumber = 0;
            int oldNumber = 0;
            foreach(var c in str)
            {
                if (romanLetters.ContainsKey(c))
                {
                    newNumber = romanLetters.GetValueOrDefault(c);
                    
                    if (oldNumber >= newNumber || oldNumber == 0)
                    {
                        number += newNumber;
                        oldNumber = newNumber;
                    }
                    else if(oldNumber < newNumber)
                    {
                        var n = newNumber - oldNumber * 2;
                        number += n;
                        oldNumber = newNumber;
                    }
                }

                else
                {
                    throw new ArgumentOutOfRangeException( $"{c} is not a roman number");
                }
            }

            return number;
        }

    }
}
