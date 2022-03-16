using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Robot.Vision.Detectors
{

    internal static class FieldDetector
    {
        private static int firstErode = 0;
        private static int secondErode = 0;
        private static int firstDilate = 5;
        private static int secondDilate = 0;
        private static int maxContourCount = 100;
        private static int cameraHeight = 480;
        private static int cameraWidth = 640;
        private static int maxDistanceFromButtomOfImage = 200;
        private static int minArea = 10;

        public static VectorOfPoint GetPoints(Image<Gray, byte> frame)
        {

            if (firstErode > 0)
            {
                frame = frame.Erode(firstErode);

            }
            if (firstDilate > 0)
            {
                frame = frame.Dilate(firstDilate);
            }
            if (secondErode > 0)
            {
                frame = frame.Erode(secondErode);
            }
            if (secondDilate > 0)
            {
                frame = frame.Dilate(secondDilate);
            }




            var hierachy = new Mat();
            var contours = new VectorOfVectorOfPoint();



            CvInvoke.FindContours(frame.Clone(), contours, hierachy, RetrType.External,
                ChainApproxMethod.ChainApproxNone);

            var list = new List<VectorOfPoint>();
            for (int i = 0; i < contours.Size; i++)
            {
                list.Add(contours[i]);
            }

            list = list.OrderByDescending(p => CvInvoke.ContourArea(p)).ToList();

            int totalResult = 0;
            var resPoints = new VectorOfPoint();
            for (int i = 0; i < list.Count; i++) // iterate through each contour.
            {
                if (totalResult >= maxContourCount)
                {
                    return null;
                }
                var rec = CvInvoke.BoundingRectangle(contours[i]);
                double area = CvInvoke.ContourArea(contours[i]);


                if (Math.Abs(cameraHeight - rec.Bottom)
                    <= maxDistanceFromButtomOfImage
                    && area >= minArea)
                {
                    var tmpContour = contours[i];
                    var len = CvInvoke.ArcLength(tmpContour, true) * 0.003;
                    CvInvoke.ApproxPolyDP(tmpContour, tmpContour, len, true);

                    for (int pIt = 0; pIt < tmpContour.Size; pIt++)
                    {
                        Point[] p = { tmpContour[pIt] };

                        resPoints.Push(p);
                    }


                }
                totalResult++;
            }

            return resPoints;

        }


        public static bool InsideField(VectorOfPoint fieldPoints, Point point)
        {
            var result = CvInvoke.PointPolygonTest(fieldPoints, point, false);
            return result >= 0;
        }



    }
}

