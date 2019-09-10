using System;
using System.Collections.Generic;
using DailyLeetCodingInCSharp.CustomizedDataStructure;

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
            var stringLength = s.Length;

            int subStringStartIndex = 0;
            int subStringEndIndex = 0;

            int minSubStringStartIndex = 0;
            int minSubStringEndIndex = 0;

            int longestPalindromeLength = 0;

            while (subStringEndIndex - subStringStartIndex < stringLength / 2)
            {
                ;
            }

            return "";
        }


        private int maxDepth = 0;
        private int currentDepth = 0;
        public int MaxDepth(TreeNode root)
        {
            if (root != null)
            {
                DepthFirstSearch(root);
            }
            return maxDepth;
        }

        private void DepthFirstSearch(TreeNode treeNode)
        {
            ++currentDepth;
            maxDepth = currentDepth > maxDepth ? currentDepth : maxDepth;
            if (treeNode.left != null)
            {
                DepthFirstSearch(treeNode.left);
            }
            if (treeNode.right != null)
            {
                DepthFirstSearch(treeNode.right);
            }
            --currentDepth;
            return;
        }


        /*
        实现 int sqrt(int x) 函数。
        计算并返回 x 的平方根，其中 x 是非负整数。
        由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。 
        */
        public int MySqrt(int x) 
        {
            return (int)Math.Sqrt(x);
        }

        /*
        一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为“Start” ）。
        机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为“Finish”）。
        问总共有多少条不同的路径？ 
        */
        
        private int RouteCounts = 0;
        private Stack<HJPoint> PointStack = new Stack<HJPoint>();
        public int UniquePaths(int m, int n) 
        {
            HJPoint initalPoint = new HJPoint(0, n - 1);
            HJSize map = new HJSize(m, n);
            PointStack.Push(initalPoint);
            
            do
            {
                var curPoint = PointStack.Pop();
                
                if(curPoint.X == map.Width - 1 && curPoint.Y == 0)
                {
                    ++RouteCounts;
                    continue;
                }
                var rightPoint = new HJPoint(curPoint.X + 1, curPoint.Y );
                var belowPoint = new HJPoint(curPoint.X , curPoint.Y - 1);
                if(map.Contains(rightPoint))
                {
                    PointStack.Push(rightPoint);
                }
                if(map.Contains(belowPoint))
                {
                    PointStack.Push(belowPoint);
                }
            } while (PointStack.Count != 0);

            return RouteCounts;
        }
        private struct HJSize
        {
            public HJSize(int width, int height)
            {
                Width = width;
                Height = height;
            }
            public int Width;
            public int Height;

            public bool Contains(HJPoint point)
            {
                if(point.X < Width && point.Y < Height && point.X >= 0 && point.Y >= 0)
                {
                    return true;
                }
                return false;
            }
        }
        private struct HJPoint
        {
            public HJPoint(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X;
            public int Y;
        }
    }
}
