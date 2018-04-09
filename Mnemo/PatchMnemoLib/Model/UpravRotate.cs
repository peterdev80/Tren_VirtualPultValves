using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace PatchMnemoLib.Model
{
    class UpravRotate : UIElement
    {

        public AnimKlapan Kl { get; set; }

        public static readonly DependencyProperty AnimRotateProperty = DependencyProperty.Register(
    " AnimRotate", typeof(Double), typeof(UpravRotate), new PropertyMetadata(0.0d, OnAnimRotate));


        private static void OnAnimRotate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as UpravRotate;
            if (com.Kl.rotate != (Double)e.NewValue)
            {
                if (com.Kl.GetAnimInFame())
                {
                    com.Kl.rotate = (Double)e.NewValue;
                    Debug.WriteLine(com.Kl.Name+" ="+com.Kl.rotate+com.Kl.AnimName);
                    com.Kl.Draw();
                }
            }
        }
        public Double AnimRotate
        {
            get { return (Double)GetValue(AnimRotateProperty); }
            set { SetValue(AnimRotateProperty, value); }
        }

        public UpravRotate()
        {

        }
        public UpravRotate(AnimKlapan ak)
        {
            Kl = ak;

        }

    }
}
