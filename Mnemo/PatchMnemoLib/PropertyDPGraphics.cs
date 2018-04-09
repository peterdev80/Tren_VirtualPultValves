using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.KeyAKlapan;
using System.Windows;
using PatchMnemoLib.Model;
using System.Collections.ObjectModel;

namespace PatchMnemoLib
{
    public class PropertyDPGraphics : PropertiesGraphicsBase
    {
        public PropertyDPGraphics()
        {

        }
        public PropertyDPGraphics(DPKey val):base(val)
        {
            StartPointX = val.StartPointX;
            StartPointY = val.StartPointY;
            EndPointX = val.EndPointX;
            EndPointY = val.EndPointY;
            KofSdvigX = val.KofSdvigX;
            KofSdvigY = val.KofSdvigY;
            PenList = val.PenList;
            NodePen = val.NodePen;
            KeyTyp = val.KeyTyp;

        }
        public double StartPointX { get; set; }
        public double StartPointY { get; set; }
        public double EndPointX { get; set; }
        public double EndPointY { get; set; }
        public double KofSdvigX { get; set; }
        public double KofSdvigY { get; set; }
        public bool NodePen { get; set; }
        public int KeyTyp { get; set; }

        public ObservableCollection<StringItem> PenList { get; set; }
        public override VisualBase CreateGraphics()
        {

            var val = new DPKey();
            val.Name = Name;
            val.TransX = TransX;
            val.TransY = TransY;
            val.RotateAngle = RotateAngle;
            val.ScaleX = ScaleX;
            val.ScaleY = ScaleY;
            val.CentrX = CentrX;
            val.CentrY = CentrY;           

            val.StartPointX=  StartPointX;
            val.StartPointY = StartPointY;
            val.EndPointX = EndPointX;
            val.EndPointY = EndPointY;
            val.KofSdvigX = KofSdvigX;
            val.KofSdvigY = KofSdvigY;

            val.NodePen = NodePen;
            val.KeyTyp = KeyTyp;          
            val.PenList = PenList;
            VisualBase b = val;
            return b;


        }
    }
}
