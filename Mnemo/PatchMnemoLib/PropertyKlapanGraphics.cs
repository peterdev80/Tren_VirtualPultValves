using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Collections.ObjectModel;

namespace PatchMnemoLib
{
    public class PropertyKlapanGraphics : PropertiesGraphicsBase
    {
        public PropertyKlapanGraphics()
        {
        }
        public PropertyKlapanGraphics(Klapan val)
            : base(val)
        {
            FrameElement = val.FrameElement;
            GDats = val.GDats;
           

        }
        public int FrameElement { get; set; }
        public ObservableCollection<KlapanItem> GDats { get; set; }

        public override VisualBase CreateGraphics()
        {
           var val = new Klapan();
           val.Name = Name;
           val.TransX = TransX;
           val.TransY = TransY;
           val.RotateAngle = RotateAngle;
           val.ScaleX = ScaleX;
           val.ScaleY = ScaleY;
           val.CentrX = CentrX;
           val.CentrY = CentrY;
           val.ReDrawType = RedrawType;
           val.FrameElement =FrameElement ;
           val.GDats= GDats  ;
           VisualBase b = val;
           return b;
        }
    }
}
