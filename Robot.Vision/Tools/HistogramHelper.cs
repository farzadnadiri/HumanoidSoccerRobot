using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.Util;

namespace Robot.Vision.Tools
{
    public static class HistogramHelper
    {

        public static VectorOfMat GenerateHistograms(IImage image, IImage mask, int numberOfBins)
        {
            Mat[] channels = new Mat[image.NumberOfChannels];
            Type imageType;
            if ((imageType = Toolbox.GetBaseType(image.GetType(), "Image`2")) != null
               || (imageType = Toolbox.GetBaseType(image.GetType(), "Mat")) != null)
            {
                for (int i = 0; i < image.NumberOfChannels; i++)
                {
                    Mat channel = new Mat();
                    CvInvoke.ExtractChannel(image, channel, i);
                    channels[i] = channel;
                }

            }
            else if ((imageType = Toolbox.GetBaseType(image.GetType(), "CudaImage`2")) != null)
            {
                IImage img = imageType.GetMethod("ToImage").Invoke(image, null) as IImage;
                for (int i = 0; i < img.NumberOfChannels; i++)
                {
                    Mat channel = new Mat();
                    CvInvoke.ExtractChannel(img, channel, i);
                    channels[i] = channel;
                }
            }
            else
            {
                throw new ArgumentException(String.Format("The input image type of {0} is not supported", image.GetType().ToString()));
            }

            Type[] genericArguments = imageType.GetGenericArguments();

            Type typeOfDepth;
            if (genericArguments.Length > 0)
            {


                typeOfDepth = imageType.GetGenericArguments()[1];
            }
            else
            {


                if (image is Mat)
                {
                    typeOfDepth = CvInvoke.GetDepthType(((Mat)image).Depth);
                }
                else
                {
                    throw new ArgumentException(String.Format("Unable to get the type of depth from image of type {0}", image.GetType().ToString()));
                }

            }

            float minVal, maxVal;
            #region Get the maximum and minimum color intensity values

            if (typeOfDepth == typeof(Byte))
            {
                minVal = 0.0f;
                maxVal = 256.0f;
            }
            else
            {
                #region obtain the maximum and minimum color value
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                image.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                double min = minValues[0], max = maxValues[0];
                for (int i = 1; i < minValues.Length; i++)
                {
                    if (minValues[i] < min) min = minValues[i];
                    if (maxValues[i] > max) max = maxValues[i];
                }
                #endregion

                minVal = (float)min;
                maxVal = (float)max;
            }
            #endregion
            VectorOfMat vect = new VectorOfMat();
            for (int i = 0; i < channels.Length; i++)
            {

                //using (DenseHistogram hist = new DenseHistogram(numberOfBins, new RangeF(minVal, maxVal)))
                using (Mat hist = new Mat())
                using (VectorOfMat vm = new VectorOfMat())
                {
                    vm.Push(channels[i]);

                    float[] ranges = new float[] { minVal, maxVal };
                    CvInvoke.CalcHist(vm, new int[] { 0 }, mask, hist, new int[] { numberOfBins }, ranges, false);
                    vect.Push(hist);

                }
            }
            return vect;
        }

    }
}
