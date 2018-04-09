using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class VentTypeA : BasicMnemoKey
    {
        static VentTypeA()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VentTypeA), new FrameworkPropertyMetadata(typeof(VentTypeA)));

        }

    }
}
