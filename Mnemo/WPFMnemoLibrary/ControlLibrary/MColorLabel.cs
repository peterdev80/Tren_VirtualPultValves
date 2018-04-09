using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MColorLabel : BasicMnemoKey
    {
        static MColorLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MColorLabel), new FrameworkPropertyMetadata(typeof(MColorLabel)));
        }
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        public static readonly DependencyProperty CaptionProperty =
       DependencyProperty.Register("Caption", typeof(string), typeof(MColorLabel),
       new PropertyMetadata("Caption", null, new CoerceValueCallback(TextAnalizer)));


        public static object TextAnalizer(DependencyObject d, object value)
        {
            return ((string)value).Replace("^", Environment.NewLine);
        }


    
      public Brush AColor
        {
            get { return (Brush)GetValue(AColorProperty); }
            set { SetValue(AColorProperty, value); }
        }

        public static readonly DependencyProperty AColorProperty =
       DependencyProperty.Register("AColor", typeof(Brush), typeof(MColorLabel),
       new FrameworkPropertyMetadata(Brushes.Green, OnColorChange));



       //!! private bool PColorInstall;
        private Brush PColor=Brushes.Transparent;
        public override int GetState(BitPosValue value)
        {
            int _state = 0;
           /* if (!PColorInstall)
            {
                PColor = this.Background;
                PColorInstall = true;
            }*/
            if (!(this.Background == AColor)) PColor = this.Background;
            if (value.HasFlag(ObmenPos)) _state = 1;

            if (_state == 1)
            {

                this.Background = AColor;
                
            }
            else
                this.Background = PColor;
            return _state;
        }
        private static void OnColorChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MColorLabel cont = d as MColorLabel;
            BitPosValue _curentState = (BitPosValue)Enum.Parse(typeof(BitPosValue), cont.Value.ToString());
            cont.GetState(_curentState);
          
        }


    }
}
