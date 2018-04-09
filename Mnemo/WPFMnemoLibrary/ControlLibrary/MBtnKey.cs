using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MBtnKey : BasicMnemoKey
    {
        static MBtnKey()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MBtnKey), new FrameworkPropertyMetadata(typeof(MBtnKey)));
        }
    }
}
