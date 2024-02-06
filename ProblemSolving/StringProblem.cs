using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class StringProblem
    {
        public int Reverse(int x)
        {
            int count = 0;
            int n = 1;
            if (x < 0)
            {
                count = 1;
                x = x * -1;

            }

            long revNum = 0;
            while (x > 0)
            {
                revNum = revNum * 10 + x % 10;

                x = x / 10;

            }
            if (revNum > int.MaxValue)
                return 0;

            if (count > 0)
                revNum = revNum * -1;
            return (int)revNum;

        }

        public int FirstUniqChar(string s)
        {
            if (s.Length == 0)
            {
                return -1;
            }
            if (s.Length == 1)
            {
                return 0;
            }
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                }
                else
                    dict.Add(s[i], 1);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (dict[s[i]] == 1)
                    return i;
            }
            return -1;
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            var charArray1 = s.ToCharArray();
            var charArray2 = t.ToCharArray();

            Array.Sort(charArray1);
            Array.Sort(charArray2);

            for (int i = 0; i < s.Length; i++)
            {
                if (charArray1[i] != charArray2[i])
                    return false;
            }

            return true;
        }
        public bool IsPalindrome(string s)
        {
            if (s.Length == 0)
                return true;
            var fixedString = "";
            foreach (char c in s.ToCharArray())
            {
                if (char.IsDigit(c) || char.IsLetter(c))
                    fixedString += c;

            }
            var result = fixedString.ToLower();
            int f = 0;
            int l = result.Length - 1;
            while (f < l)
            {
                if (result[f] != result[l])
                    return false;
                f++;
                l--;
            }

            return true;
        }

        public int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length)
                return -1;
            int index = 0;
            int length = haystack.Length;

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                int left = 0;
                while (left < needle.Length && needle[left] == haystack[left + i])
                {

                    left++;
                    if (left == needle.Length)
                        return i;

                }

            }
            return -1;
        }

    }
}
