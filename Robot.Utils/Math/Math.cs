namespace Robot.Utils
{
    public static class Math
    {
        #region Convertors
        public static double DegreeToRadian = System.Math.PI / 180;
        public static double RadianToDegree = 180 / System.Math.PI;
        #endregion

        #region Functions

        /// <summary>
        ///  Returns the sine of specific angle
        /// </summary>
        /// <param name="degree">Angle in Degree(0-360)</param>
        /// <returns>Returns value of specific angle</returns>
        public static double Sin(double degree)
        {
            return System.Math.Sin(DegreeToRadian*degree);
        }

        /// <summary>
        ///  Returns the cosine of specific angle
        /// </summary>
        /// <param name="degree">Angle in Degree(0-360)</param>
        /// <returns>Returns value of specific angle</returns>
        public static double Cos(double degree)
        {
            return System.Math.Cos(DegreeToRadian*degree);
        }

        /// <summary>
        ///  Returns the tangent of specific angle
        /// </summary>
        /// <param name="degree">Angle in Degree(0-360)</param>
        /// <returns>Returns value of specific angle</returns>
        public static double Tan(double degree)
        {
            return System.Math.Tan(DegreeToRadian*degree);
        }

        /// <summary>
        ///  Returns the cotangent of specific angle
        /// </summary>
        /// <param name="degree">Angle in Degree(0-360)</param>
        /// <returns>Returns value of specific angle</returns>
        public static double Cot(double degree)
        {
            if ((degree % 90).CompareTo(0) == 0 || (degree % 270).CompareTo(0) == 0)
            {
                return 0;
            }
            return 1 / System.Math.Tan(DegreeToRadian*degree);
        }

        /// <summary>
        ///  Returns the arc tangent of specific value
        /// </summary>
        /// <param name="value">Gets value</param>
        /// <returns>Returns angle as degree</returns>
        public static double ArcTan(double value)
        {
            return RadianToDegree*(System.Math.Atan(value));
        }

        /// <summary>
        ///  Returns the arc tangent of specific value
        /// </summary>
        /// <param name="value">Gets value</param>
        /// <returns>Returns angle as degree</returns>
        public static double ArcSin(double value)
        {
            return RadianToDegree*(System.Math.Asin(value));
        }

        /// <summary>
        ///  Returns the arc tangent of specific value
        /// </summary>
        /// <param name="value">Gets value</param>
        /// <returns>Returns angle as degree</returns>
        public static double ArcCos(double value)
        {
            return RadianToDegree*(System.Math.Acos(value));
        }

        #endregion
    }
}
