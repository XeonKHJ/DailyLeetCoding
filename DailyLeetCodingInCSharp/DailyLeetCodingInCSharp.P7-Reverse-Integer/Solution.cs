using System;

namespace DailyLeetCodingInCSharp.P7_Reverse_Integer
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
    }
}
