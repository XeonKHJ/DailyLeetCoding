using System;
using DailyLeetCodingInCSharp.Solutions;

namespace DailyLeetCodingInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Solution solution = new Solution();
            Console.WriteLine(solution.LengthOfLongestSubstring("abcdedskfdjaldkfksjldkjlkjlkwjlkerjkjlkjlkjlkjlkjiiqwertyuiop"));

            int[] a = { 1,3,5,7};
            int[] b = { 2,4,6,8,10};
            Console.WriteLine(solution.FindMedianSortedArrays(a, b));
        }
    }
}
