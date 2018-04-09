using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseType;
using System.Windows;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MnemoAnimatePribor : BasicMnemoKey
    {
        static MnemoAnimatePribor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MnemoAnimatePribor), new FrameworkPropertyMetadata(typeof(MnemoAnimatePribor)));
        }
        public override int GetState(BitPosValue value)
        {
            int _rval = -1;
            bool _bit1 = false;
            if (value.HasFlag(ObmenPos)) { _rval = 1; _bit1 = true; }
            if (!ObmenPos2bit.Equals(BitPosValue.None))
                if (value.HasFlag(ObmenPos2bit)) _rval = 2;


            if (_bit1)
                if (_rval == 2)
                    _rval = 3;

            KState = -777;
            return _rval;
        }
        public int KState
        {
            get { return (int)GetValue(KStateProperty); }
            set { SetValue(KStateProperty, value); }

        }
        public static readonly DependencyProperty KStateProperty =
         DependencyProperty.Register("KState", typeof(int), typeof(MnemoAnimatePribor),
         new PropertyMetadata(0));
    }
}
