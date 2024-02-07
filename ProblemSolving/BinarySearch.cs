using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    ans = mid;
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
            while (target > nums[end])
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


        public int PeakIndexInMountainArray(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;

            while (start < end)
            {
                int mid = (start + end) / 2;
                if (arr[mid] < arr[mid + 1])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }

            }
            return start;
        }

        public int FindPeakElement(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                //int mid = start + end / 2;
                int mid = start + (end - start) / 2;

                if (nums[mid] < nums[mid + 1])
                {
                    start = mid + 1;
                }
                else { end = mid; }

            }

            return start;
        }

        public int FindInMountainArray(int target, int[] nums)
        {
            int peakIndex = PeakIndexInMountainArray(nums);
            int firstTry = OrderAgnosticBS(nums, target, 0, peakIndex);
            if (firstTry != -1)
                return firstTry;
            return OrderAgnosticBS(nums, target, peakIndex + 1, nums.Length - 1);

        }

        public int OrderAgnosticBS(int[] arr, int target, int start, int end)
        {
            // find whether the array is sorted in ascending or descending
            bool isAsc = arr[start] < arr[end];

            while (start <= end)
            {
                // find the middle element
                //            int mid = (start + end) / 2; // might be possible that (start + end) exceeds the range of int in java
                int mid = start + (end - start) / 2;

                if (arr[mid] == target)
                {
                    return mid;
                }

                if (isAsc)
                {
                    if (target < arr[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if (target > arr[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }
            return -1;
        }

        public int RotatedSearch(int[] nums, int target)
        {
            int pivot = FindPivot(nums);
            if(pivot == -1)
            {
                return binarySearch(nums, target,0,nums.Length-1);
            }

            if (nums[pivot] == target)
                return pivot;
            if(target >= nums[0])
                return binarySearch(nums,target,0,pivot-1);
               
            return binarySearch(nums,target,pivot+1,nums.Length-1); 

        }

        public int FindPivot(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (mid < end && nums[mid] > nums[mid + 1])
                    return mid;
                else if (mid > start && nums[mid] < nums[mid - 1])
                    return mid - 1;
                else if (nums[mid] <= nums[start])
                    end = mid - 1;
                else
                    start = mid + 1;

            }

            return -1;
        }

        public int FindPivotWithDuplicate(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (mid < end && nums[mid] > nums[mid + 1])
                    return mid;
                else if (mid > start && nums[mid] < nums[mid - 1])
                    return mid - 1;
                // if elements at middle, start, end are equal then just skip the duplicates
                if (nums[mid] == nums[start] && nums[mid] == nums[end])
                {
                    // skip the duplicates
                    // NOTE: what if these elements at start and end were the pivot??
                    // check if start is pivot
                    if (start < end && nums[start] > nums[start + 1])
                    {
                        return start;
                    }
                    start++;

                    // check whether end is pivot
                    if (end > start && nums[end] < nums[end - 1])
                    {
                        return end - 1;
                    }
                    end--;
                }
                // left side is sorted, so pivot should be in right
                else if (nums[start] < nums[mid] || (nums[start] == nums[mid] && nums[mid] > nums[end]))
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        public int binarySearch(int[] nums, int target, int start, int end)
        {
            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (target > nums[mid])
                    start = mid + 1;
                else if (target < nums[mid])
                    end = mid - 1;
                else
                    return mid;

            }
            return -1;

        }


        public int SplitArray(int[] nums, int k)
        {
            int start = 0;
            int end = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                start = Math.Max(start, nums[i]); // in the end of the loop this will contain the max item of the array
                end += nums[i];
            }

            // binary search
            while (start < end)
            {
                // try for the middle as potential ans
                int mid = start + (end - start) / 2;

                // calculate how many pieces you can divide this in with this max sum
                int sum = 0;
                int pieces = 1;
                foreach (var num in nums)
                {
                    if (sum + num > mid)
                    {
                        // you cannot add this in this subarray, make new one
                        // say you add this num in new subarray, then sum = num
                        sum = num;
                        pieces++;
                    }
                    else
                    {
                        sum += num;
                    }
                }

                if (pieces > k)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }

            }
            return end; 
        }


    }


}
