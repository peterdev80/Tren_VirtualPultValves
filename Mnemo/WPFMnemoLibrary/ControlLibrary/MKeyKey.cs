using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MKeyKey : BasicMnemoKey
    {
        static MKeyKey()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MKeyKey), new FrameworkPropertyMetadata(typeof(MKeyKey)));
        }
    }
}
