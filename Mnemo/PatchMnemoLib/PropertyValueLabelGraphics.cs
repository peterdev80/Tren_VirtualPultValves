using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using PatchMnemoLib.Model;

namespace PatchMnemoLib
{
    public class PropertyValueLabelGraphics : PropertiesGraphicsBase
    {
        public Color GPen { get; set; }
        public double GpenSize { get; set; }
        public double Xpos { get; set; }
        public double Ypos { get; set; }
        public string Shrift { get; set; }
        public string Format { get; set; }
        public string ShowMessage { get; set; }
        public int Alignment { get; set; }

        public PropertyValueLabelGraphics()
        {
        }
        public PropertyValueLabelGraphics(ValueLabel vl)
            : base(vl)
        {
          GPen    =        vl.GPen ;
          GpenSize =       vl.GpenSize ;
          Xpos   =         vl.Xpos ;
          Ypos   =         vl.Ypos ;
          Shrift =         vl.Shrift ;
          Format =         vl.Format ;
          ShowMessage =    vl.ShowMessage;
          Alignment = vl.Alignment;


        }


        public override VisualBase CreateGraphics()
        {
            var val = new ValueLabel();
            val.Name = Name;          
            val.TransX = TransX;
            val.TransY = TransY;
            val.RotateAngle = RotateAngle;
            val.ScaleX = ScaleX;
            val.ScaleY = ScaleY;
            val.CentrX = CentrX;
            val.CentrY = CentrY;
            val.GPen = GPen; ;
            val.GpenSize = GpenSize;
            val.Xpos = Xpos;
            val.Ypos = Ypos;
            val.Shrift = Shrift;
            val.Format = Format;
            val.ShowMessage = ShowMessage;
            val.Alignment = Alignment;
            VisualBase b = val;
            return b;
        }
    }
}
