using Emgu.CV.Structure;

namespace Robot.Environment.Color
{
    public class ColorPicker
    {
        public Hsv Min;
        public Hsv Max;

        public ColorPicker()
        {
            Min.Hue = Min.Satuation = Min.Value = -1;
            Max.Hue = Max.Satuation = Max.Value = -1;
        }
        public ColorPicker(Hsv iMin, Hsv iMax)
        {
            Min = iMin;
            Max = iMax;

        }
     
        public ColorPicker(ColorPicker iColorRange)
        {
            Min = iColorRange.Min;
            Max = iColorRange.Max;
        }

        public bool IsInColorRange(int h, int s, int v)
        {
            return (h >= Min.Hue && h <= Max.Hue) && (s >= Min.Satuation && s <= Max.Satuation) && (v >= Min.Value && v <= Max.Value);
        }
        public bool IsInColorRange(byte h, byte s, byte v)
        {
            return (h >= Min.Hue && h <= Max.Hue) && (s >= Min.Satuation && s <= Max.Satuation) && (v >= Min.Value && v <= Max.Value);
        }
        public bool IsInColorRange(ref Hsv input)
        {
            return (input.Hue >= Min.Hue && input.Hue <= Max.Hue) && (input.Satuation >= Min.Satuation && input.Satuation <= Max.Satuation) && (input.Value >= Min.Value && input.Value <= Max.Value);
        }

    }
}

