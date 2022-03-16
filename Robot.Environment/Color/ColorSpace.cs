using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Emgu.CV.Structure;

namespace Robot.Environment.Color
{
    public class ColorSpace
    {
        public ColorPicker ColorList;

        public ColorSpace()
        {
            ColorList = new ColorPicker();
        }

        public ColorSpace(string path)
        {
            ColorList = new ColorPicker();
            Load(path);
        }

        public void Add(ColorPicker input)
        {
            ColorList=input;
        }

   
        public void SetColors(ColorPicker input)
        {
            ColorList = input;
        }
        public ColorPicker GetColor()
        {
         
                return ColorList;
            
        }
        public bool IsInColorSpace(Hsv input)
        {

                if (ColorList.IsInColorRange(ref input))
                {
                    return true;
                }
        
            return false;
        }

        public bool IsInColorSpace(byte h, byte s, byte v)
        {

            if (ColorList.IsInColorRange(h, s, v))
                {
                    return true;
                }

            return false;
        }

        public bool IsInColorSpace(int h, int s, int v)
        {

                if (ColorList.IsInColorRange(h, s, v))
                {
                    return true;
                }

            return false;
        }

        public bool IsInColorSpaceOptimized(byte h, byte s, byte v)
        {   try
                {

                if ((h >= ColorList.Min.Hue && h <= ColorList.Max.Hue) && (s >= ColorList.Min.Satuation && s <= ColorList.Max.Satuation) && (v >= ColorList.Min.Value && v <= ColorList.Max.Value))
                    {
                        return true;
                    }
                
  
                }
            catch { }
            return false;
        }

        public void Save(string path)
        {

            var x = new XElement("ColorPicker", new XElement("Min", new XElement("H", ColorList.Min.Hue), new XElement("S", ColorList.Min.Satuation), new XElement("V", ColorList.Min.Value)),
                                   new XElement("Max", new XElement("H", ColorList.Max.Hue), new XElement("S", ColorList.Max.Satuation), new XElement("V", ColorList.Max.Value)));


            var main = new XElement("ColorSpace", x);
            main.Save(path);
        }

        public void Load(string path)
        {

                XDocument repository = XDocument.Load(path);
                var colors = from element in repository.Descendants("ColorPicker")
                             select new
                                        {
                                            Hmin =
                                 Convert.ToInt32(element.Descendants("Min").Descendants("H").Single().Value),
                                            Smin =
                                 Convert.ToInt32(element.Descendants("Min").Descendants("S").Single().Value),
                                            Vmin =
                                 Convert.ToInt32(element.Descendants("Min").Descendants("V").Single().Value),

                                            Hmax =
                                 Convert.ToInt32(element.Descendants("Max").Descendants("H").Single().Value),
                                            Smax =
                                 Convert.ToInt32(element.Descendants("Max").Descendants("S").Single().Value),
                                            Vmax =
                                 Convert.ToInt32(element.Descendants("Max").Descendants("V").Single().Value)

                                        };

                foreach (var colorItem in colors)
                {
                    ColorList=(new ColorPicker(new Hsv(colorItem.Hmin, colorItem.Smin, colorItem.Vmin),
                                                   new Hsv(colorItem.Hmax, colorItem.Smax, colorItem.Vmax)));
                }
            }
        }
    
}
