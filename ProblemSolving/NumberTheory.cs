using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class NumberTheory
    {

        public int SuperPow(int a, int[] b)
        {
            long res = 1;
            a = a % 1337;
            for (int i = 0; i < b.Length; ++i)
            {
                res = Pow(res, 10) * Pow(a, b[i]) % 1337;
            }
            return (int)res;
        }

        private long Pow(long x, int n)
        {
            if (n == 0) return 1;
            long v = Pow(x, n / 2);
            if (n % 2 == 0)
            {
                return v * v % 1337;
            }
            else
            {
                return v * v * x % 1337;
            }
        }

        public void FindPrimes(int limit)
        {
            List<int> primes = new List<int>();
            bool[] marked = new bool[limit + 1];
            marked[0] = marked[1] = true;


            var sq = Math.Sqrt(limit);

            for (int i = 4; i <= limit; i += 2)
                marked[i] = true;

            for(int i = 3; i<=sq; i += 2)
            {
                for (int k = i * i; k <= limit; k += i + i)
                    marked[k] = true;
            }

            for(int i = 1; i < limit; i++)
            {
                if (!marked[i])
                    Console.WriteLine(i);
            }

            
        }

        int mod(int number, long power, int mod)
        {
            if (power == 0) return 1;

            if (power % 2 == 0)
            {
                int x = this.mod(number, power / 2, mod);
                return (x * x) % mod;
            }
            else return (number % mod * this.mod(number, power - 1, mod)) % mod;
        }
    }
}
