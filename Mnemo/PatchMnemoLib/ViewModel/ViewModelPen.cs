using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;
using System.Collections;
using System.Xml.Serialization;

namespace PatchMnemoLib.ViewModel
{
    public class ViewModelPen : ViewModelBase
    {
       
        private  GraphicsPen g_pen;
        private DoubleAnimation _PenAnimate;
        private Pen _CurPen;

        public ViewModelPen(Color _cp, Double _ps, String _an, string _pn, bool _anim)
        {

            g_pen = new GraphicsPen(_cp, _ps, _an, _pn, _anim);

        }
        public ViewModelPen(GraphicsPen _g_pen)
        {
            g_pen = _g_pen;
            CreatePen("CurPen");

        }
        public GraphicsPen Model
        {
            get { return g_pen; }
        }

        public double LineDas
         {
             get { return g_pen.LineDas; }
             set {g_pen.LineDas=value;
             CreatePen("LineDas");
             OnPropertyChanged("LineDas");
             }
         }
        public double SpaceDash
         {
             get { return g_pen.SpaceDash; }
             set { g_pen.SpaceDash = value; OnPropertyChanged("SpaceDash"); CreatePen("SpaceDash"); }
         }

         public Color ColorPen
         {
             get { return g_pen.ColorPen; }
             set { g_pen.ColorPen = value; OnPropertyChanged("ColorPen"); CreatePen("ColorPen"); }
         }
         public Double PenSize
         {
             get { return g_pen.PenSize; }
             set { g_pen.PenSize = value; OnPropertyChanged("PenSize"); CreatePen("PenSize"); }
         }
         public String AnimateName
         {
             get { return g_pen.AnimateName; }
             set { g_pen.AnimateName = value; OnPropertyChanged("AnimateName"); }
         }
         public string PenName
         {
             get { return g_pen.PenName; }
             set { g_pen.PenName = value; OnPropertyChanged("PenName"); }
         }
         public bool Animate
         {
             get { return g_pen.Animate; }
             set { g_pen.Animate = value; OnPropertyChanged("Animate"); }
         }
         
         public DoubleAnimation PenAnimate
         {
             get { return _PenAnimate; }
             set { _PenAnimate = value; OnPropertyChanged("PenAnimate"); CreatePen("Animate"); }
         }
         public Pen CurPen
         {
             get { return _CurPen; }
             set { _CurPen = value; OnPropertyChanged("CurPen"); }
         }
         private void CreatePen(string propName)
         {
             Pen cp = new Pen();

             cp.Brush = new SolidColorBrush(ColorPen);
             cp.Thickness = PenSize;
             if ((Animate) && (PenAnimate != null))
             {
                 var dstyle = DashStyles.Dash;
                 if ((LineDas >= 0) && (SpaceDash >= 0))
                 {
                     List<double> dlist = new List<double>();
                     dlist.Add(LineDas);
                     dlist.Add(SpaceDash);
                     dstyle = new DashStyle(dlist, 0);
                 }
                 cp.DashStyle = dstyle.Clone();
                 cp.DashStyle.BeginAnimation(DashStyle.OffsetProperty, PenAnimate);
             }

             CurPen= cp;
             OnPropertyChanged(propName);

         }

       



      
    }
}
