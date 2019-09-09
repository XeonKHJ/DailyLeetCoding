using System;
using System.Collections.Generic;

namespace DailyLeetCodingInCSharp.Solutions
{
    public class Solution
    {
        public int Reverse(int x)
        {
            int maxValueWithoutFirstDigit = int.MaxValue / 10;
            int maxFirstBit = int.MaxValue % 10;
            int minValueWithoutFirstDigit = int.MinValue / 10;
            int minFirstBit = int.MinValue % 10;
            int result = 0;
            while (x != 0)
            {
                int remain = x % 10;

                if (x > 0 &&
                    ((result > maxValueWithoutFirstDigit) ||
                     (result == maxValueWithoutFirstDigit && remain > maxFirstBit)))
                {
                    return 0;
                }
                else if (x < 0 &&
                       (result < minValueWithoutFirstDigit ||
                       (result == minValueWithoutFirstDigit && remain < minFirstBit)))
                {
                    return 0;
                }

                result = result * 10 + remain;
                x /= 10;
            }



            return result;
        }

        public int LengthOfLongestSubstring(string s)
        {
            int currentCount = 0;
            int max = 0;

            Queue<char> subStringList = new Queue<char>();

            foreach (var letter in s)
            {
                if (subStringList.Contains(letter))
                {
                    for (char removedChar = Char.MinValue; removedChar != letter; --currentCount)
                    {
                        removedChar = subStringList.Dequeue();
                    }
                }
                subStringList.Enqueue(letter);
                ++currentCount;
                max = currentCount > max ? currentCount : max;
            }

            return max;
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int length1 = nums1.Length;
            int length2 = nums2.Length;
            int totalLength = length1 + length2;
            bool isLengthOdd = (totalLength % 2 != 0);
            totalLength /= 2;
            int index1 = 0;
            int index2 = 0;
            bool isSecondAdd = false;

            Dictionary<bool, int> keyValuePairs = new Dictionary<bool, int>();
            for (int i = 0; i < totalLength; ++i)
            {
                if (index1 < length1 &&
                    ((index2 < length2) && nums1[index1] < nums2[index2] || (index2 >= length2)))
                {
                    keyValuePairs[isSecondAdd] = nums1[index1++];
                }
                else if (index2 < length2)
                {
                    keyValuePairs[isSecondAdd] = nums2[index2++];
                }
                isSecondAdd = !isSecondAdd;
            }

            return isLengthOdd ? keyValuePairs[!isSecondAdd] : ((double)(keyValuePairs[true] + keyValuePairs[false])) / 2;
        }

        public string LongestPalindrome(string s) 
        {
            
        }
    }
}
