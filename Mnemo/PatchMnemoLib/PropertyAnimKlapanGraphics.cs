using PatchMnemoLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PatchMnemoLib
{
    public class PropertyAnimKlapanGraphics : PropertiesGraphicsBase
    {
        public PropertyAnimKlapanGraphics()
        {
        }
        public PropertyAnimKlapanGraphics(AnimKlapan val)
            : base(val)
        {
            FrameElement = val.FrameElement;
            GDats = val.GDats;
            AnimName = val.AnimName;

        }
        public string AnimName { get; set; }
        public int FrameElement { get; set; }

        public ObservableCollection<AnimKlapanItem> GDats { get; set; }

        public override VisualBase CreateGraphics()
        {
            var val = new AnimKlapan();
            val.Name = Name;
            val.TransX = TransX;
            val.TransY = TransY;
            val.RotateAngle = RotateAngle;
            val.ScaleX = ScaleX;
            val.ScaleY = ScaleY;
            val.CentrX = CentrX;
            val.CentrY = CentrY;
            val.ReDrawType = RedrawType;
            val.FrameElement = FrameElement;
            val.GDats = GDats;
            val.AnimName = AnimName;

            VisualBase b = val;
            return b;
        }
    }
}
