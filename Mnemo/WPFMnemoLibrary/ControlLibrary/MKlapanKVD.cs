using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MKlapanKVD : BasicMnemoKey
    {
        static MKlapanKVD()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MKlapanKVD), new FrameworkPropertyMetadata(typeof(MKlapanKVD)));
        }
        public override int GetState(BitPosValue value)
        {
            int _rval = 0;
            if (value.HasFlag(ObmenPos)) _rval = 1;
            if (!ObmenPos2bit.Equals(BitPosValue.None))
                if (value.HasFlag(ObmenPos2bit)) _rval = 2;



            return _rval;
        }
    }
}
