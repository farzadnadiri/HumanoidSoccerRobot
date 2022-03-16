using System;

namespace Robot.Utils
{
    public static class Utility
    {
        public static string SerializeItems(int[] input,string seperator)
        {
            String stepPositions = string.Empty;
            for (int k = 0; k < input.Length; k++)
            {
                if (k != input.Length - 1)
                {
                    stepPositions += input[k] + seperator;
                }
                else
                {
                    stepPositions += input[k];
                }
            }
            return stepPositions;
        }
        public static int[] DeserializeItems(string items,char seperator)
        {
            var splited = items.Split(seperator);
            var array = new int[splited.Length];
            for (int i = 0; i < splited.Length; i++)
            {
                array[i] = Convert.ToInt32(splited[i]);
            }
            return array;
        }
    }
}
