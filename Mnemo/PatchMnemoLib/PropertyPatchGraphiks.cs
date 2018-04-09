using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Windows.Media;

namespace PatchMnemoLib
{
    public class PropertyPatchGraphics : PropertiesGraphicsBase
    {
        public PropertyPatchGraphics()
        {
        }
        public PropertyPatchGraphics(GraphicsPatch val):base(val)
        {
          /*      Name = val.Name;   
            TransX             = val.TransX; 
        TransY             = val.TransY; 
        RotateAngle        = val.RotateAngle; 
         ScaleX             = val.ScaleX ;
         ScaleY             = val.ScaleY ;
        CentrX             = val.CentrX; 
        CentrY             = val.CentrY;*/


        GData = val.GData;
        DefPenColor = val.DefPenColor;
        DefPenSize = val.DefPenSize;

        }
       /* public string Name { get; set; }
        public double TransX { get; set; }
        public double TransY { get; set; }
        public double RotateAngle { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }
        public double CentrX { get; set; }
        public double CentrY { get; set; }*/


        public string GData { get; set; }
         public Color DefPenColor { get ; set ; }
         public double DefPenSize { get; set; }

        public override VisualBase CreateGraphics()
        {
            
            var val= new GraphicsPatch();
               val.Name =Name  ;
             val.TransX = TransX ;
          val.TransY=TransY;
          val.RotateAngle = RotateAngle;
          val.ScaleX = ScaleX;
          val.ScaleY = ScaleY;
          val.CentrX = CentrX;
          val.CentrY = CentrY;
          val.GData = GData;
          val.DefPenSize = DefPenSize;
          val.DefPenColor = DefPenColor;
          VisualBase b = val;
          return b;

           
        }
    }
}
