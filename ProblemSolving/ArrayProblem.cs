using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class ArrayProblem
    {

        public void Rotate(int[] nums, int k)
        {

            var list = new List<int>();
            foreach (int i in nums)
            {
                list.Add(i);
            }

            for (int i = 0; i < k; i++)
            {
                var x = list[nums.Length - 1];
                list.RemoveAt(nums.Length - 1);
                list.Insert(0, x);
            }

            nums = list.ToArray();
        }

        public void RotateAnotherApproach(int[] nums, int k)
        {
            k = k % nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);

        }

        void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                var temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }

        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var list = new List<int>();
            var list2 = new List<int>();
            foreach (int i in nums1)
            {
                list.Add(i);
            }

            foreach (int i in nums2)
            {
                if (list.Contains(i))
                {
                    list2.Add(i);
                    list.Remove(i);
                }
            }

            int[] num = new int[list2.Count];
            num = list2.ToArray();
            return num;


        }

        public void MoveZeroes(int[] nums)
        {
            if (nums.Length == 1)
            {
                return;
            }

            var list = nums.ToList();

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == 0)
                {
                    var x = list.IndexOf(nums[i]);
                    list.RemoveAt(x);
                    list.Add(0);
                }
            }

            nums = list.ToArray();

        }

        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i <= nums.Length; i++)
            {
                // 
                int x = target - nums[i];
                if (dict.ContainsKey(x))
                {
                    return new int[] { dict[x], i };
                }

                if (!dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] = i;
                }
            }

            // if no solution found
            return new int[0];

        }

        public int[] DistributeShirtsEvenly(int totalShirts, int numBags)
        {
            int[] bags = new int[numBags];
            int shirtsPerBag = totalShirts / numBags;
            int remainder = totalShirts % numBags;

            for (int i = 0; i < numBags; i++)
            {
                bags[i] = shirtsPerBag;
                if (remainder > 0)
                {
                    bags[i]++;
                    remainder--;
                }
            }

            return bags;
        }

        public int[] DistributeShirtsEvenl(int numShirts, int numBags)
        {
            int[] bags = new int[numBags];
            int shirtsPerBag = 0;
            int remainingShirts = numShirts % numBags;
            int x = (numShirts + remainingShirts) / numBags;
            int diff1 = x - (numShirts - (x * (numBags - 1)));

            if (diff1 >= 0)
            {

            }

            if (remainingShirts > numBags / 2)
            {

                shirtsPerBag = (numShirts - remainingShirts) / numBags;
                remainingShirts += (numShirts - remainingShirts) - ((numBags - 1) * shirtsPerBag);
                bags[0] = remainingShirts;
                for (int i = 1; i < numBags; i++)
                {
                    bags[i] = shirtsPerBag;
                }

            }
            else
            {
                shirtsPerBag = numShirts / numBags;
                bags[0] = shirtsPerBag + remainingShirts;
                for (int i = 1; i < numBags; i++)
                {
                    bags[i] = shirtsPerBag;
                }

            }

            foreach (int i in bags)
                Console.WriteLine(i);

            return bags;
        }

        public int[] DistributeShirtsEven(int numShirts, int numBags)
        {
            int[] bags = new int[numBags];
            int remainingShirts = numShirts % numBags;
            int numPerbag = numShirts / numBags;
            numPerbag++;
            if (remainingShirts < 5 || numPerbag * (numBags - 1) >= numShirts)
            {
                numPerbag--;
                var remaining = numShirts - numPerbag * (numBags - 1);
                bags[0] = remaining;
                for (int i = 1; i < numBags; i++)
                {
                    bags[i] = numPerbag;
                }

            }
            else
            {

                bags[0] = remainingShirts;
                for (int i = 1; i < numBags; i++)
                {
                    bags[i] = numPerbag;
                }

            }

            return bags;
        }
        public int RemoveDuplicates(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == nums.Length - 1)
                {

                    nums[count] = nums[i];
                    count++;
                }
                else if (nums[i] != nums[i + 1])
                {

                    nums[count] = nums[i];
                    count++;
                }

            }

            return count;

        }


        public bool ContainsDuplicate(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    return true;
                }
                else
                    dict.Add(num, -1);
            }

            return false;
        }

        public int SingleNumber(int[] nums)
        {

            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict.Remove(num);
                }
                else
                    dict.Add(num, -1);
            }
            var x = dict.First();
            return x.Key;

        }

        public int[] PlusOne(int[] digits)
        {

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }

            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;

        }


        // need to understand 
        public void Rotate(int[][] matrix)
        {
            int length = matrix.Length - 1;

            for (int i = 0; i < (length + 1) / 2; i++)
            {
                for (int j = 0; j < (length + 1) / 2; j++)
                {
                    // bottom left = bottom right
                    var temp = matrix[length - j][i];
                    //bottom left = bottom right
                    matrix[length - j][i] = matrix[length - i][length - j];

                    // bottom right = top right
                    matrix[length - i][length - j] = matrix[j][length - i];

                    matrix[j][length - i] = matrix[i][j];

                    matrix[i][j] = temp;

                }
            }

        }
    }
}
