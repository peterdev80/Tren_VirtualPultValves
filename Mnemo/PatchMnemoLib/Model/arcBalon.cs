using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Xml.Serialization;

namespace PatchMnemoLib.Model
{
    public class arcBalon : VisualBase
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


        public arcBalon()
        {
            RadiusX = 50;
            RadiusY = 70;
            MaxValue = 1;
            StrokeSize = 1;
            BackColor = Colors.White;
            FrontColor = Colors.Green;
            StrokeColor = Colors.Black;

        }
        [XmlIgnore]
        public override int TVisual
        {
            get { return 5; }
        }
        public override void Draw()
        {
            using (DrawingContext dc = this.RenderOpen())
            {
                foreach (var tr in base.lstTransf)
                    dc.PushTransform(tr);

                var cx = XPos;
                var cy = YPos;
                double ValueProgress = Progress / MaxValue;
                var pr = 1 - (ValueProgress * 2);
                if (pr == -1)
                    pr = -0.999999;

                var a = Math.Asin(pr);

                var x = RadiusX * Math.Cos(a);
                var y = RadiusY * Math.Sin(a);

                var g = new StreamGeometry();
                using (var ct = g.Open())
                {
                    var e1 = new Point(cx - x, cy - y);
                    var e2 = new Point(cx + x, cy - y);

                    ct.BeginFigure(e1, true, true);
                    ct.ArcTo(e2, new Size(RadiusX, RadiusY), 0, ValueProgress > 0.5, SweepDirection.Clockwise, true, false);
                }
                var be = new SolidColorBrush(BackColor);
                var b = new SolidColorBrush(FrontColor);
                var p = new Pen(new SolidColorBrush(StrokeColor), StrokeSize);

                dc.DrawEllipse(be, p, new Point(cx, cy), RadiusX, RadiusY);
                dc.DrawGeometry(b, p, g);

                foreach (var tr in base.lstTransf)
                    dc.Pop(); 
            }

        }
        public override PropertiesGraphicsBase CreateSerializedObject()
        {
            return new PropertyarcBalon(this);
        }
    }
}
