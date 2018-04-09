using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MZaglushka : BasicMnemoKey
    {
        static MZaglushka()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MZaglushka), new FrameworkPropertyMetadata(typeof(MZaglushka)));
        }
    }
}
