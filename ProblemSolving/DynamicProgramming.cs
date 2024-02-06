using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class DynamicProgramming
    {

        public void ClimbStairs(int n)
        {
            var x =  climb_stairs(0, n);
            Console.WriteLine(x);

        }

        public int climb_stairs(int i, int n)
        {
            if (i > n)
                return 0;

            if(i==n) return 1;
            return climb_stairs(i+1,n) + climb_stairs(i+2,n);
        }
    }
}
