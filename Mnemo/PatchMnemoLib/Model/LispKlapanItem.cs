using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatchMnemoLib.Model
{
    public enum TransformT
    {
        Rotate,Move
    };
   public class LispKlapanItem:KlapanItem
    {

        public bool transformBit { get; set; }
        public double Xtransform { get; set; }
        public double Ytransform { get; set; }
        public TransformT TypeTransform { get; set; }
        public LispKlapanItem():base()
        {
            TypeTransform = TransformT.Rotate;

        }
    }
}
