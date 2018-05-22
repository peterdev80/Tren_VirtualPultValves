using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Collections.ObjectModel;

namespace PatchMnemoLib
{
   public class PropertyLispKlapanGraphics : PropertiesGraphicsBase
    {
           public PropertyLispKlapanGraphics() { }
        public PropertyLispKlapanGraphics(LispKlapan val)
             : base(val)
        {
            GDats = val.GDats;

        }

        public ObservableCollection<LispKlapanItem> GDats { get; set; }
        public override VisualBase CreateGraphics()
        {
            var val =new  LispKlapan();
            val.Name = Name;
            val.TransX = TransX;
            val.TransY = TransY;
            val.RotateAngle = RotateAngle;
            val.ScaleX = ScaleX;
            val.ScaleY = ScaleY;
            val.CentrX = CentrX;
            val.CentrY = CentrY;
            val.ReDrawType = RedrawType;            
            val.GDats = GDats;
            VisualBase b = val;
            return b;
        }
    }
}
