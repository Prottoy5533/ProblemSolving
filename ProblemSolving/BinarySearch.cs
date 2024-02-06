using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class BinarySearch
    {

        public int SearchInsertCeil(int[] nums, int target)
        {
            if (target > nums[nums.Length - 1])
            {
                return nums.Length;
            }
            int start = 0;
            int end = nums.Length - 1;
            

            while(start <= end)
            {
                int mid = (start + end) / 2;
                if (target < nums[mid])
                {
                    end= mid-1;
                }
                else if (target > nums[mid]) 
                {
                    start= mid+1;
                }
                else
                {
                    return mid;
                }
            }

            return start;
        }

        public int SearchInsertFloor(int[] nums, int target)
        {
            if (target < nums[0])
            {
                return 0;
            }
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (target < nums[mid])
                {
                    end = mid - 1;
                }
                else if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return end;
        }

        public int[] SearchRange(int[] nums, int target)
        {
            int[] ans = { -1, -1 };

            ans[0] = search(nums, target, true);
            if (ans[0] != -1)
            {
                ans[1] = search(nums, target, false);
            }
            return ans;

        }

        int search(int[] nums, int target, bool findStartIndex)
        {
            int ans = -1;
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (target < nums[mid])
                {
                    end = mid - 1;
                }
                else if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    ans= mid;
                    if (findStartIndex)
                    {
                        end = mid - 1;
                    }
                    else
                        start = mid + 1;
                }
            }

            return ans;

        }

        public int[] SearchRangeAlternate(int[] nums, int target)
        {

            if (nums.Length == 0)
            {
                return new int[] { -1, -1 };
            }

            Dictionary<int, int> range = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                range.Add(i, nums[i]);
            }

            int first = range.FirstOrDefault(x => x.Value == target).Key;
            int last = range.LastOrDefault(x => x.Value == target).Key;

            if (target != nums[first])
            {
                first = -1;
            }

            if (target != nums[last])
            {
                last = -1;
            }

            return new int[] { first, last };

        }

        public int ans(int[] nums, int target)
        {
            int start = 0;
            int end = 1;
            int n = 2;
            while(target > nums[end])
            {
                n = n * 2;
                int temp = end + 1;

                end = end + (end - start + 1);
                //end = end + n;
                start = temp;
            }

            return BinarySearchInfiniteArray(nums, target, start, end);
        }

        public int BinarySearchInfiniteArray(int[] nums, int target, int start, int end)
        {
          
          
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (target < nums[mid])
                {
                    end = mid - 1;
                }
                else if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    Console.WriteLine(mid);
                    return mid;
                }
            }

            

            return end;
        }
    }
}
