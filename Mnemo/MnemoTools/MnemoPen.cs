using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Xml.Serialization;
using System.Windows.Media.Animation;
using System.Windows;

namespace MnemoTools
{
    [Serializable]
    public class MnemoPen : DependencyObject,INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {


            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members

        private Color _ColorPen;
        private Double _PenSize;
        private String _AnimateName;
        private string _PenName;
        private bool _Animate;
        private double _LineDush=-1d;
        private double _SpaseDush=-1d;
      //  DoubleAnimation _penAnimat;
       // private Pen _curPen;


        public MnemoPen()
        {

        }
        public MnemoPen(Color _cp, Double _ps, String _an, string _pn, bool _anim)
        {
            ColorPen = _cp;
            PenSize = _ps;
            AnimateName = _an;
            PenName = _pn;
            Animate = _anim;

        }
       //свойства DashStyle
        public double LineDas
        {
            get { return _LineDush; }
            set { _LineDush = value; CreatePen("LineDas"); }
        }
        public double SpaceDash
        {
            get { return _SpaseDush; }
            set { _SpaseDush = value; CreatePen("SpaceDash"); }
        }
      
        public Color ColorPen
        {
            get { return _ColorPen; }
            set { _ColorPen = value; CreatePen("ColorPen"); }
        }
        public Double PenSize
        {
            get { return _PenSize; }
            set { _PenSize = value; CreatePen("PenSize"); }
        }
        public String AnimateName
        {
            get { return _AnimateName; }
            set { _AnimateName = value; OnPropertyChanged("AnimateName"); }
        }
        public string PenName
        {
            get { return _PenName; }
            set { _PenName = value; OnPropertyChanged("PenName"); }
        }
        public bool Animate
        {
            get { return _Animate; }
            set { _Animate = value; OnPropertyChanged("Animate"); }
        }

        [XmlIgnore]
        public static readonly DependencyProperty PenAnimateProperty = DependencyProperty.Register(
       "PenAnimate", typeof(DoubleAnimation), typeof(MnemoPen), new PropertyMetadata(new DoubleAnimation(),  OnPenAnimateChange));
       [XmlIgnore]
        public DoubleAnimation PenAnimate
        {
            get {return (DoubleAnimation)GetValue(PenAnimateProperty); }
            set { SetValue(PenAnimateProperty, value); }
        }

       [XmlIgnore]
       public static readonly DependencyProperty CurPenProperty = DependencyProperty.Register(
      "CurPen", typeof(Pen), typeof(MnemoPen),new PropertyMetadata(new Pen(new SolidColorBrush(Colors.Green),3)));
       [XmlIgnore]
       public Pen CurPen
       {
           get { return (Pen)GetValue(CurPenProperty); }
           set { SetValue(CurPenProperty, value); }
       }
        private static void OnPenAnimateChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MnemoPen con = d as MnemoPen;
            con.CreatePen("Animate");

        }

        private void CreatePen(string propName)
        {
            Pen cp = new Pen();

            cp.Brush = new SolidColorBrush(_ColorPen);
            cp.Thickness = _PenSize;
            if ((_Animate) && (PenAnimate != null))
            {
                var dstyle=DashStyles.Dash;
                if ((_LineDush >= 0) && (_SpaseDush >= 0))
                {
                    List<double> dlist = new List<double>();
                    dlist.Add(_LineDush);
                    dlist.Add(_SpaseDush);
                    dstyle = new DashStyle(dlist, 0);
                }
                cp.DashStyle = dstyle.Clone();
                cp.DashStyle.BeginAnimation(DashStyle.OffsetProperty, PenAnimate);
            }
        
            SetValue(CurPenProperty, cp);
            OnPropertyChanged(propName);

        }
    }
}


