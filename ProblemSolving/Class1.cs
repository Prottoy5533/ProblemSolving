using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingPractice
{

    internal class Class1
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            else if (x < 10) return true;
            int ans = 0;
            int y = x;
            while (y > 0)
            {
                ans = ans * 10 + y % 10;
                y = y / 10;
            }

            return ans == x;

        }

        public void reverseString(char[] chars)
        {
           
            int left = 0;
            int right = chars.Length - 1;

            while (left < right)
            {
                var temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;
                left++;
                right--;

            }
            Console.WriteLine(chars);
            

        }
        public void findMaxNumofOne(int[] nums, int k)
        {
            int maxLength = 0, left = 0, zeroCnt = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                    zeroCnt++;
                while (zeroCnt > k)
                {
                    if (nums[left] == 0)
                        zeroCnt--;
                    left++;
                }

                maxLength = Math.Max(maxLength, right - left + 1);

            }


            Console.WriteLine(maxLength);
        }
        public void findMaxAvgSubarray(int[] nums, int k)
        {
            double curr = 0;
            double add = 0;
            for (int i = 0; i < k; i++)
            {
                curr += nums[i];


            }
            add = curr;
            curr = curr / k;
            double ans = curr;
            int left = 0;
            for (int i = k; i < nums.Length; i++)
            {
                add -= nums[left];
                left++;
                add += nums[i];
                curr = add / k;
                ans = Math.Max(ans, curr);
            }

            Console.WriteLine(ans);
        }
        public void findBestSubarray(int[] nums, int k)
        {
            int curr = 0;
            for (int i = 0; i < k; i++)
            {
                curr += nums[i];

            }
            int ans = curr;
            int left = 0;
            for (int i = k; i < nums.Length; i++)
            {
                curr -= nums[left];
                left++;
                curr += nums[i];
                ans = Math.Max(ans, curr);
            }

            Console.WriteLine(ans);
        }
        public void numSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1)
            {
                Console.WriteLine(0);
            }
            int left = 0, curr = 1, ans = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                curr *= nums[right];
                while (curr >= k)
                {
                    curr /= nums[left];
                    left++;
                }
                ans += right - left + 1;

            }
            Console.WriteLine(ans);
        }
        public int findLength(string s)
        {
            int left = 0, curr = 0, ans = 0;

            for (int right = 0; right < s.Length; right++)
            {
                if (s.ElementAt(right) == '0')
                    curr++;
                while (curr > 1)
                {
                    if (s.ElementAt(left) == '0')
                        curr--;
                    left++;
                }

                ans = Math.Max(ans, right - left + 1);

            }

            Console.WriteLine(ans);
            return ans;
        }
        public int findLength(int[] nums, int k)
        {
            int left = 0, curr = 0, ans = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                curr += nums[right];

                int x = 0;
                while (curr > k)
                {
                    curr -= nums[left];
                    left++;
                }

                ans = Math.Max(ans, right - left + 1);

            }

            Console.WriteLine(ans);
            return ans;
        }
        public int[] SortedSquares(int[] nums)
        {
            int n = nums.Length;
            int left = 0, right = n - 1;
            int[] res = new int[n];
            int resIndex = n - 1;

            while (left <= right)
            {
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    res[resIndex--] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    res[resIndex--] = nums[right] * nums[right];
                    right--;

                }

            }
            return res;

        }
        public void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            var reverse = "";
            while (left < right)
            {
                var temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;

            }
            Console.WriteLine(s);
        }
        public bool CheckforTarget(string str1, string str2)
        {
            int i = 0;
            int j = 0;
            var ans = "";
            while (j < str2.Length)
            {
                if (str1[i] == str2[j])
                {
                    i++;
                }
                j++;

            }

            return i == str1.Length;
        }

        public int[] TwoSum(int target, int[] arr)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {

                int compliment = target - arr[i];

                if (dict.ContainsValue(compliment))
                {

                    var myKey = dict.FirstOrDefault(x => x.Value == compliment).Key;
                    return new int[] { i, myKey };
                }

                dict.Add(i, arr[i]);

            }

            return new int[] { -1, -1 };
        }

        public string FirstLettertoAppearTwice(string s)
        {
            var dict = new Dictionary<int, char>();

            var charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (dict.ContainsValue(charArray[i]))
                    return charArray[i].ToString();

                dict.Add(i, charArray[i]);

            }

            return "No duplicate element";
        }

        public bool CheckIfPangram(string sentence)
        {
            var dict = new Dictionary<int, char>();

            var charArray = sentence.ToCharArray();
            int count = 0;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (dict.ContainsValue(charArray[i]))
                    continue;

                dict.Add(i, charArray[i]);
                count++;

            }

            if (count == 26)
                return true;
            return false;


        }

        public int MissingNumber(int[] nums)
        {

            Array.Sort(nums);

            if (nums[0] != 0) return 0;
            if (nums[nums.Length - 1] != nums.Length) return nums.Length;

            for (int i = 0; i < nums.Length; i++)
            {
                int x = nums[i];
                int differ = nums[i + 1] - x;
                if (differ > 1)
                    return x + 1;

            }

            return -1;
        }

        public int CountElements(int[] arr)
        {
            var dictionary = new Dictionary<int, int>();
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                dictionary.Add(i, arr[i]);

            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (dictionary.ContainsValue(arr[i] + 1))
                    count++;

            }

            return count;
        }

        public int CountElements2(int[] arr)
        {
            int res = 0;
            if (arr.Length == 0) return res;
            HashSet<int> hs = new HashSet<int>();
            foreach (int n in arr)
                hs.Add(n);
            foreach (int x in arr)
                if (hs.Contains(x + 1))
                    res++;
            return res;
        }

        public int CountElements3(int[] arr)
        {
            var set = arr.ToHashSet();
            return arr.Count(x => set.Contains(x + 1));
        }

        public Dictionary<int, int> CalculateAmount(int[] notes, int amount)
        {
            //Array.Sort(notes);

            var minNotes = new Dictionary<int, int>();
            for (int i = 0; i < notes.Length; i++)
            {
                minNotes.Add(notes[i], 0);
            }
            var remaining = amount;
            for (int i = 0; i < notes.Length; i++)
            {
                var x = remaining / notes[i];

                if (x > 0)
                {
                    minNotes[notes[i]] = x;
                    remaining = remaining - (x * notes[i]);
                }

                if (remaining == 0)
                    break;

            }

            return minNotes;
        }

        public bool areOccurrencesEqual(string s)
        {
            var dict = new Dictionary<char, int>();

            var x = s.ToCharArray();

            for (int i = 0; i < x.Length; i++)
            {
                if (dict.ContainsKey(x[i]))
                {
                    // Key exists, increment the value
                    dict[x[i]]++;
                }
                else
                {
                    // Key doesn't exist, set default value to 1
                    dict[x[i]] = 1;
                }
            }
            var frequencies = new HashSet<int>(dict.Values);

            return frequencies.Count() == 1;

        }
        //int matches = [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            var ans = new List<IList<int>>();

            var losses = new Dictionary<int, int>();
            var winners = new Dictionary<int, int>();

            for (int i = 0; i < matches.Length; i++)
            {
                if (losses.ContainsKey(matches[i][1]))
                    losses[matches[i][1]]++;
                else
                    losses[matches[i][1]] = 1;

                if (winners.ContainsKey(matches[i][0]))
                    winners[matches[i][0]]++;
                else
                    winners[matches[i][0]] = 1;

            }
            winners = winners.Where(kv => !losses.ContainsKey(kv.Key))
                     .ToDictionary(kv => kv.Key, kv => kv.Value);
            IList<int> element1 = new List<int>();
            IList<int> element2 = new List<int>();
            foreach (var item in losses)
            {
                if (item.Value == 1)
                    element1.Add(item.Key);

            }
            foreach (var item in winners)
            {
                element2.Add(item.Key);

            }

            var lossersSort = element1.OrderBy(n => n).ToList();
            var winnersSort = element2.OrderBy(n => n).ToList();

            ans.Add(winnersSort);
            ans.Add(lossersSort);
            return ans;

        }

        public int LargestUniqueNumber(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            foreach (var item in nums)
            {
                if (dict.ContainsKey(item))
                    dict[item]++;
                else
                    dict[item] = 1;

            }


            var x = dict.Where(x => x.Value == 1).ToList();
            IList<int> element1 = new List<int>();
            foreach (var item in x)
            {

                element1.Add(item.Key);

            }

            var y = element1.OrderBy(n => n).ToList().LastOrDefault();
            if (x.Count == 0)
                return -1;
            else
                return y;


        }

        public int MaxNumberOfBalloons(string text)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'b' || text[i] == 'a' || text[i] == 'l' || text[i] == 'o' || text[i] == 'n')
                {
                    if (!letters.TryAdd(text[i], 1))
                    {
                        letters[text[i]]++;
                    }
                }
            }

            if (letters.Count < 5 || letters['l'] < 2 || letters['o'] < 2)
            {
                return 0;
            }

            letters['l'] = letters['l'] / 2;
            letters['o'] = letters['o'] / 2;

            return letters.Values.Min();

        }

        public IList<IList<string>> groupAnagrams(string[] strs)
        {

            var dict = new Dictionary<string, List<string>>();

            foreach (var item in strs)
            {
                var c = item.ToCharArray();
                Array.Sort(c);
                string key = new string(c);

                if (!dict.ContainsKey(key))
                {

                    dict[key] = new List<string>();
                }


                dict[key].Add(item);

            }
            return new List<IList<string>>(dict.Values);
        }

        public int minimumCardPickup(int[] cards)
        {
            var dict = new Dictionary<int, int>();

            int ans = int.MaxValue;

            for (int i = 0; i < cards.Length; i++)
            {
                int num = cards[i];

                if (dict.ContainsKey(num))
                {
                    ans = Math.Min(ans, i - dict[num] + 1);
                }

                dict[num] = i;

            }

            if (ans == int.MaxValue)
            {
                return -1;
            }

            return ans;
        }

        public int MaximumSum(int[] nums)
        {
            var result = -1;

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                var digitSum = 0;
                int currNum = num;
                while (currNum > 0)
                {
                    digitSum += currNum % 10;
                    currNum /= 10;
                }

                if (dict.ContainsKey(digitSum))
                {
                    result = Math.Max(result, dict[digitSum] + num);
                    dict[digitSum] = Math.Max(dict[digitSum], num);
                }
                else
                {
                    dict[digitSum] = num;
                }


            }



            return result;
        }
        public bool CanConstruct(string ransomNote, string magazine)
        {
            var ransomDict = new Dictionary<char, int>();
            var magazineDict = new Dictionary<char, int>();
            var rChar = ransomNote.ToCharArray();
            var mChar = magazine.ToCharArray();
            foreach (var item in rChar)
            {
                if (ransomDict.ContainsKey(item))
                    ransomDict[item]++;
                else
                    ransomDict[item] = 1;

            }

            foreach (var item in mChar)
            {
                if (magazineDict.ContainsKey(item))
                    magazineDict[item]++;
                else
                    magazineDict[item] = 1;

            }

            foreach (var item in ransomDict)
            {
                if (!magazineDict.ContainsKey(item.Key))
                    return false;

                if (ransomDict[item.Key] < magazineDict[item.Key])
                    return false;

            }

            return true;

        }

        public int NumJewelsInStones(string jewels, string stones)
        {
            var stoneDict = new Dictionary<char, int>();
            var charStones = stones.ToCharArray();
            var charJewels = jewels.ToCharArray();

            foreach (var item in charStones)
            {
                if (stoneDict.ContainsKey(item))
                    stoneDict[item]++;
                else
                    stoneDict[item] = 1;

            }
            int ans = 0;

            foreach (var item in charJewels)
            {
                if (stoneDict.ContainsKey(item))
                    ans += stoneDict[item];

            }

            return ans;

        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode MiddleNode(ListNode head)
        {
            var slow = head;
            var fast = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

            }

            return slow;
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            var node = head;

            while (node != null && node.next != null)
            {
                if (node.val == node.next.val)
                {
                    node.next = node.next.next;
                }
                else
                {
                    node = node.next;
                }

            }

            return head;

        }

        public bool validParanthesis(string s)
        {
            var bracketsMap = new Dictionary<char, char>
           {
               {'{','}' },
               {'(',')' },
               {'[',']' },
           };

            var openBrackets = new Stack<char>();

            foreach (char bracket in s)
            {
                if (bracketsMap.ContainsKey(bracket))
                {
                    openBrackets.Push(bracket);
                }
                else
                {
                    if (openBrackets.Count == 0)
                        return false;

                    var x = openBrackets.Pop();
                    if (bracketsMap[x] != bracket)
                        return false;
                }

            }
            return !openBrackets.Any();

        }

        public string RemoveDuplicates(string s)
        {
            Stack<char> st = new();

            foreach (char c in s)
            {
                //st.TryPeek(out char d): This method attempts to peek at the top element of the stack (st) 
                //without removing it. It uses the out parameter to retrieve the value at the top of the stack (if it exists) and assigns it to the variable d
                if (st.TryPeek(out char d) && d == c)
                {
                    st.Pop();
                    continue;
                }

                st.Push(c);
            }
            return string.Concat(st.Reverse());
        }

        public bool backspaceCompare(string s, string t)
        {
            Stack<char> st = new();
            Stack<char> tt = new();

            foreach (char c in s)
            {
                if (c == '#')
                {
                    if (st.Count == 0)
                        continue;
                    st.Pop();
                    continue;
                }

                st.Push(c);

            }

            var newS = string.Concat(st.Reverse());

            foreach (char c in t)
            {
                if (c == '#')
                {
                    if (tt.Count == 0)
                        continue;
                    tt.Pop();
                    continue;
                }


                tt.Push(c);

            }

            var newT = string.Concat(tt.Reverse());

            return newS.Equals(newT);
        }

        public string MakeGood(string s)
        {
            Stack<char> st = new();

            foreach (char c in s)
            {

                if (st.Count > 0 && st.Peek() != c && char.ToLower(st.Peek()) == char.ToLower(c))
                {
                    st.Pop();
                }
                else
                {
                    st.Push(c);
                }

            }

            return string.Concat(st.Reverse());

        }


        

        









    }
}
