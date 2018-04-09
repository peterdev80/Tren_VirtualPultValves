using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using ValueModel.BaseType;
using System.Diagnostics;
using System.Globalization;

namespace WPFMnemoLibrary.ControlLibrary
{
    public class MnemoDateVisualer : BasicMnemoKey
    {
        static MnemoDateVisualer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MnemoDateVisualer), new FrameworkPropertyMetadata(typeof(MnemoDateVisualer)));
        }
        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        public static readonly DependencyProperty CaptionProperty =
        DependencyProperty.Register("Caption", typeof(string), typeof(MnemoDateVisualer),
       new PropertyMetadata("Caption", null, new CoerceValueCallback(TextAnalizer)));
        public static object TextAnalizer(DependencyObject d, object value)
        {
            return ((string)value).Replace("^", Environment.NewLine);
        }


        public string CaptionValue
        {
            get { return (string)GetValue(CaptionValueProperty); }
            set { SetValue(CaptionValueProperty, value); }
        }
        public static readonly DependencyProperty CaptionValueProperty =
        DependencyProperty.Register("CaptionValue", typeof(string), typeof(MnemoDateVisualer),
       new PropertyMetadata("0/00", null, ValueAnalizer));
        public static object ValueAnalizer(DependencyObject d, object value)
        {
            double f;
            NumberStyles style;
  CultureInfo culture;

           // if (value!="")
          //  f =(float) value;
             style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
              culture = CultureInfo.CreateSpecificCulture("en-GB");

              if (double.TryParse(value.ToString(), style,culture, out f))
               return f.ToString("f");
               
            return value;
        }
     
        
         public static readonly DependencyProperty AColorProperty =
       DependencyProperty.Register("AColor", typeof(Brush), typeof(MnemoDateVisualer),
       new FrameworkPropertyMetadata(null,OnColorChange));
        
        public Brush AColor
        {
            get { return (Brush)GetValue(AColorProperty); }
            set { SetValue(AColorProperty, value); }
        }
       

        private Brush PColor;
        public override int GetState(BitPosValue value)
        {
            int _state = 0;
            if (PColor == null)
                PColor = this.Background;
            if (value.HasFlag(ObmenPos)) _state = 1;

            if (_state == 1)
            {
              
                this.Background = AColor;
               // Debug.WriteLine((GetValue(AColorProperty).ToString()));
               // Debug.WriteLine("  " + AColor.ToString());
            }
            else
                this.Background = PColor;
            return _state;
        }
        private static void OnColorChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           MnemoDateVisualer cont = d as MnemoDateVisualer;
           BitPosValue _curentState = (BitPosValue)Enum.Parse(typeof(BitPosValue), cont.Value.ToString());
           cont.GetState(_curentState);
         //  Debug.WriteLine(cont.Value + e.NewValue.ToString());
            // MessageBox.Show(e.OldValue.ToString()+"  "+e.NewValue.ToString());
          //  cont.Value
        }




    }
}
