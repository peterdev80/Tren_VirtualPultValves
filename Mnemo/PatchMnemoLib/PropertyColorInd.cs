using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using PatchMnemoLib.Model;
using System.Windows.Media;

namespace PatchMnemoLib
{
    public class PropertyColorInd : PropertiesGraphicsBase
    {
        public PropertyColorInd()
        {
        }
        public int FrameElement { get; set; }
        public ObservableCollection<SegmentInd> Segments { get; set; }
        public double MaxValue { get; set; }
        public double NulPos { get; set; }
        public double MaxPos { get; set; }
        public SegmentInd Strelka { get; set; }
        public int PosValEl { get; set; }
       
        public Color GPen { get; set; }
        public double GpenSize { get; set; }
        public double Xpos { get; set; }
        public double Ypos { get; set; }
        public string Shrift { get; set; }
        public string Format { get; set; }

        public PropertyColorInd(InpuColorIndicator val)
            : base(val)
        {
            FrameElement = val.FrameElement;
            Segments = val.Segments;
            MaxValue = val.MaxValue;
            NulPos = val.NulPos;
            MaxPos = val.MaxPos;
            Strelka = val.Strelka;
            PosValEl = val.PosValEl;
            GPen = val.GPen;
            GpenSize = val.GpenSize;
            Xpos = val.Xpos;
            Ypos = val.Ypos;
            Shrift = val.Shrift;
            Format = val.Format;

        }
        public override VisualBase CreateGraphics()
        {
            var val = new InpuColorIndicator();
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
            val.Segments = Segments;
            val.FrameElement = FrameElement;
            // val.GDats=GDats;
            val.MaxValue = MaxValue;
            val.NulPos = NulPos;
            val.MaxPos = MaxPos;
            val.Strelka = Strelka;
            val.PosValEl = PosValEl;


            val.GPen = GPen; ;
            val.GpenSize = GpenSize;
            val.Xpos = Xpos;
            val.Ypos = Ypos;
            val.Shrift = Shrift;
            val.Format = Format;
            VisualBase b = val;
            return b;

        }
    }
}

