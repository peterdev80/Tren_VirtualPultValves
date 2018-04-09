using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Globalization;
using System.Windows;
using System.Xml.Serialization;

namespace PatchMnemoLib.Model
{
    public class ValueLabel : VisualBase
    {

        public Color GPen { get; set; }
        public double GpenSize { get; set; }
        public double Xpos { get; set; }
        public double Ypos { get; set; }
        public string Shrift { get; set; }
        public string Format { get; set; }
        public string ShowMessage { get; set; }
        public int Alignment { get; set; }
        //Left По умолчанию.Текст выравнивается по левому краю. -0
       //Right Текст выравнивается по правому краю. -1
       //Center Текст выравнивается по центру. -2
       //Justify Текст выравнивается по ширине -3

       
        public ValueLabel()
        {
            Shrift = "Verdana";
            GpenSize = 12d;
            ShowMessage = "xHello";
            Format = "";
            GPen = Colors.Black;
            Alignment = 0;

        }

        [XmlIgnore]
        public override int TVisual
        {
            get { return 4; }
        }


        private int _IntValue;
        private double _DoubleValue;
        private float _FloatValue;
       

       [XmlIgnore]
        public int IntValue
        {
            get { return _IntValue; }
            set { _IntValue = value; ShowMessage = _IntValue.ToString(); Draw(); }
        }

        [XmlIgnore]
        public double DoubleValue
        {
            get { return _DoubleValue; }
            set { _DoubleValue = value; ShowMessage = _DoubleValue.ToString(Format); Draw(); }
        }
        [XmlIgnore]
        public float FloatValue
        {
            get { return _FloatValue; }
            set { _FloatValue = value; ShowMessage = _FloatValue.ToString(Format); Draw(); }
        }
        public override void Draw()
        {
            using (DrawingContext dc = this.RenderOpen())
            {
                foreach (var tr in base.lstTransf)
                    dc.PushTransform(tr);
                FormattedText ft = new FormattedText(TextAnalizer(),
         CultureInfo.GetCultureInfo("ru-ru"),
         FlowDirection.LeftToRight,
         new Typeface(Shrift),
         GpenSize,
         new SolidColorBrush(GPen));


                if (Alignment==2)  ft.TextAlignment = System.Windows.TextAlignment.Center;
                if (Alignment == 1) ft.TextAlignment = System.Windows.TextAlignment.Right;
                if (Alignment == 0) ft.TextAlignment = System.Windows.TextAlignment.Left;
                if (Alignment == 3) ft.TextAlignment = System.Windows.TextAlignment.Justify;

                dc.DrawText(ft,
         new System.Windows.Point(Xpos, Ypos));




                foreach (var tr in base.lstTransf)
                    dc.Pop();
            }
        }
        private string TextAnalizer()
        {
            return ShowMessage.Replace("^", Environment.NewLine);

        }
        public override PropertiesGraphicsBase CreateSerializedObject()
        {
            return new PropertyValueLabelGraphics(this);
        }
    }
}
