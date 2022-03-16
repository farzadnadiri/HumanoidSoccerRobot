using System;

namespace Robot.Utils
{
    public class Range<T> where T : IComparable
    {

        public T Min { get; set; }
        public T Max { get; set; }

        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public bool IsInRange(T value)
        {
            return ((value.CompareTo(Min) > 0) && (value.CompareTo(Max) < 0));
        }

        public T Validate(T value)
        {
            if (value.CompareTo(Max) > 0)
            {
                return Max;
            }
            if (value.CompareTo(Min) < 0)
            {
                return Min;
            }
            return value;
        }
        public static T Validate(T input, T min, T max)
        {
            if (input.CompareTo(max) > 0)
            {
                return max;
            }
            if (input.CompareTo(min) < 0)
            {
                return min;
            }
            return input;
        }
    }
}
