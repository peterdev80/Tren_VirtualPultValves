using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MKeyEU : BasicMnemoKey
    {
        static MKeyEU()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MKeyEU), new FrameworkPropertyMetadata(typeof(MKeyEU)));
        }
    }
}
