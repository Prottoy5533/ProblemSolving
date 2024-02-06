using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class Home
    {

        public int fibonacci(int num)
        {
            if (num < 2)
            {
                return num;
            }

            return fibonacci(num - 1)+ fibonacci(num-2);
        }

        public string RemoveDigit(string number, char digit)
        {
            var newstring = "";
            int count = 0;


            for (int i = 0; i < number.Length; i++)
            {
                if (count == 0 && number[i] == digit)
                {
                    count++;
                    continue;

                }

                newstring += number[i];
            }

            return newstring;

        }
    }
}
