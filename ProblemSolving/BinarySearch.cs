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
    }
}
