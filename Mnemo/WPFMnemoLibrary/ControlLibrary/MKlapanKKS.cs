using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MKlapanKKS : MKlapanKVD
    {
        static MKlapanKKS()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MKlapanKKS), new FrameworkPropertyMetadata(typeof(MKlapanKKS)));
        }
    }
}
