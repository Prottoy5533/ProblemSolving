using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class Office
    {

        public int LastStoneWeight(int[] stones)
        {
            var heap = new PriorityQueue<int,int>();

            foreach (var item in stones)
            {
                heap.Enqueue(item,-1*item);
            }

            while (heap.Count > 1)
            {
                var newStone = heap.Dequeue() - heap.Dequeue();

                if (newStone > 0)
                    heap.Enqueue(newStone, -1 * newStone);

            }

            return heap.Count > 0 ? heap.Dequeue() : 0;


        }

        public int MinStoneSum(int[] piles, int k)
        {
            if (piles.Length == 0 || k == 0)
            {
                return 0;
            }

            var pq = new PriorityQueue<int, int>();


            //this will store the data from large to small. when dequeue the largest will come first.
            foreach (var item in piles)
            {
                pq.Enqueue(item, -1 * item);
            }

            for (int i = 1; i <= k; i++)
            {
                decimal top = pq.Dequeue();
                int newStones =Convert.ToInt32( Math.Ceiling( top / 2));
                pq.Enqueue(newStones, -1*newStones);
            }

            int sum = 0;
            while(pq.Count > 0)
            {
                sum += pq.Dequeue();    

            }

            return sum;

        }

        public int ConnectSticks(int[] sticks)
        {
            if (sticks.Length == 1)
                return 0;

            var minheap = new PriorityQueue<int, int>();

            //this will store the data from small to large. when dequeue the smallest will come first.
            foreach (var item in sticks)
            {
                minheap.Enqueue(item, item);
            }

            var minimumCost = 0;

            while(minheap.Count>1)
            {
                var x = minheap.Dequeue() + minheap.Dequeue();
                minimumCost+= x;
                minheap.Enqueue(x, x);
            }

            return minimumCost;

        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            return nums.GroupBy(num => num)
            .OrderByDescending(num => num.Count())
            .Take(k)
            .Select(c => c.Key)
            .ToArray();
        }

        public int[] TopKFrequent1(int[] nums, int k)
        {

            var dict = new Dictionary<int, int>();
            var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            var res = new int[k];

            foreach (var num in nums)
                if (!dict.TryAdd(num, 1))
                    dict[num]++;

            foreach (var pair in dict)
                pq.Enqueue(pair.Key, pair.Value);

            for (int i = 0; i < k; i++)
                res[i] = pq.Dequeue();

            return res;
        }

        public int FindKthLargest(int[] nums, int k)
        {
            return nums.OrderByDescending(num => num).Skip(k-1).FirstOrDefault();

        }


        public int PartitionArray(int[] nums, int k)
        {

            Array.Sort(nums);
            int ans = 1;
            int x = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - x <= k)
                    continue;
                else
                {
                    ans++;
                    x = nums[i];
                }

            }

            return ans;

        }

        // 3,7,5,5,3,8
        // 5,7,8,3,5,5
        //3,5,7,8,5,3

        //3,3,5,7,7,8
        //
        //5,7,8,7,5,3,3,

        public void CustomSortArray(int[] arr, int k)
        {

            var pq = new PriorityQueue<int, int>();
            var sortItem = new List<int>();

            foreach (var item in arr)
            {
                pq.Enqueue(item, -1 * item);
            }
            var rest = new List<int>(); 
            sortItem.Add(pq.Dequeue());
            for(int i = 1; i<k; )
            {
                int x = pq.Dequeue();
                if (sortItem[i - 1] != x)
                {
                    sortItem.Add(x);
                    i++;
                }
                else
                    rest.Add(x);
            }

            sortItem.Sort();

            foreach (var item in rest)
            {
                pq.Enqueue(item, -1 * item);
            }

            if(pq.Count> 0)
            {
                while (pq.Count > 0)
                {
                    sortItem.Add((int)pq.Dequeue());
                }
            }

            
            
            

            

            foreach (var item in sortItem)
            {
                Console.WriteLine(item);

            }
        }

        static int Comparer(int a, int b)
        {
            return a.CompareTo(b);
        }

        static int ComparerReverse(int a, int b)
        {
            return b.CompareTo(a);
        }

        public int ReverseInt(int num)
        {
            int rev = 0;

            while (num > 0)
            {
                int remainder = num % 10;
                rev = rev * 10 + remainder;
                num = num / 10;


            }

                return rev;
        }
    }
}
