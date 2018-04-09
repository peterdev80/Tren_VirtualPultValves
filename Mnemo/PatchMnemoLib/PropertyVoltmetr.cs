using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Collections.ObjectModel;

namespace PatchMnemoLib
{
    public class PropertyVoltmetr : PropertiesGraphicsBase
    {

        public PropertyVoltmetr()
        {
        }

        public int FrameElement { get; set; }
        public ObservableCollection<KlapanItem> GDats { get; set; }
        public double MaxValue { get; set; }
        public double NulPos { get; set; }
        public double MaxPos { get; set; }
        public KlapanItem Strelka { get; set; }

        public PropertyVoltmetr(ProgressVolt val)
            : base(val)
        {
            FrameElement = val.FrameElement;
            GDats = val.GDats;
            MaxValue = val.MaxValue;
            NulPos = val.NulPos;
            MaxPos = val.MaxPos;
            Strelka = val.Strelka;
        }
        public override VisualBase CreateGraphics()
        {
            var val = new ProgressVolt();
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
            val.FrameElement =FrameElement ;
            val.GDats=GDats;
            val.MaxValue = MaxValue;
            val.NulPos = NulPos;
            val.MaxPos = MaxPos;
            val.Strelka = Strelka;
            VisualBase b = val;
            return b;

        }
    }
}
