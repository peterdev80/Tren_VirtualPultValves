using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using PatchMnemoLib.Model;

namespace PatchMnemoLib
{
    public class PropertyarcBalon : PropertiesGraphicsBase
    {
        public double Progress { get; set; }
        public double RadiusX { get; set; }
        public double RadiusY { get; set; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double MaxValue { get; set; }
        public double StrokeSize { get; set; }
        public Color BackColor { get; set; }
        public Color FrontColor { get; set; }
        public Color StrokeColor { get; set; }

         public PropertyarcBalon()
        {
        }
         public PropertyarcBalon(arcBalon val)
            : base(val)
        {
            Progress = val.Progress;
            RadiusX = val.RadiusX;
            RadiusY = val.RadiusY;
            XPos = val.XPos;
            YPos = val.YPos;
            MaxValue = val.MaxValue;
            StrokeSize = val.StrokeSize;
            BackColor = val.BackColor;
            FrontColor = val.FrontColor;
            StrokeColor = val.StrokeColor;

        }



        public override VisualBase CreateGraphics()
        {
            var val = new arcBalon();
            val.Name = Name;
            val.TransX = TransX;
            val.TransY = TransY;
            val.RotateAngle = RotateAngle;
            val.ScaleX = ScaleX;
            val.ScaleY = ScaleY;
            val.CentrX = CentrX;
            val.CentrY = CentrY;
            val.ReDrawType = RedrawType;
            val.Progress = Progress;
            val.RadiusX = RadiusX;
            val.RadiusY=RadiusY;
            val.XPos = XPos;
            val.YPos = YPos;
            val.MaxValue = MaxValue;
            val.StrokeSize = StrokeSize;
            val.BackColor = BackColor;
            val.FrontColor = FrontColor;
            val.StrokeColor = StrokeColor;
           


            VisualBase b = val;
            return b;
        }
    }
}
