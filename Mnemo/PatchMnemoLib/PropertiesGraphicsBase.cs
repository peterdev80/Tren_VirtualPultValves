using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;

namespace PatchMnemoLib
{
    public abstract class PropertiesGraphicsBase
    {
        public abstract VisualBase CreateGraphics();
        public PropertiesGraphicsBase()
        {
        }
        public PropertiesGraphicsBase(VisualBase val)
        {
            Name = val.Name;
            TransX = val.TransX;
            TransY = val.TransY;
            RotateAngle = val.RotateAngle;
            ScaleX = val.ScaleX;
            ScaleY = val.ScaleY;
            CentrX = val.CentrX;
            CentrY = val.CentrY;
            RedrawType = val.ReDrawType;
        }
        public string Name { get; set; }
        public double TransX { get; set; }
        public double TransY { get; set; }
        public double RotateAngle { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }
        public double CentrX { get; set; }
        public double CentrY { get; set; }
        public bool RedrawType { get; set; }
    }
}
