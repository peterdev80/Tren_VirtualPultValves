using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using MUtilites;
using System.Collections.ObjectModel;
using PatchMnemoLib.UtilControl;
using System.Globalization;
using System.Windows;

namespace PatchMnemoLib.Model
{
   public class SegmentInd
    {

        public SegmentInd()           

        {
            LowVal = 0;
            HeigVal = 0;
            SegmentColorPen = Colors.Black;
            SegmentColorBrush = Colors.Black;
            SegmentColorText = Colors.Black;

        }
       
        public double LowVal {get;set;}
        public double HeigVal { get; set; }
        public bool InSegment(double val)
        {
            if (val >= LowVal && val < HeigVal) return true;
            return false;
        }
        public Color SegmentColorPen {get; set; }
        public Color SegmentColorBrush { get; set; }
        public Color SegmentColorText { get; set; }
       
        public KlapanItem PatchData {get;set;}
        
        
    }

    public class InpuColorIndicator : Klapan
    {

        //Label
        public Color GPen { get; set; }
        public double GpenSize { get; set; }
        public double Xpos { get; set; }
        public double Ypos { get; set; }
        public string Shrift { get; set; }
        public string Format { get; set; }
        public string ShowMessage { get; set; }

        //


        public double MaxValue { get; set; }
        public double NulPos { get; set; }
        public double MaxPos { get; set; }
        public SegmentInd Strelka { get; set; }
        public double Progress { get; set; }
       // public ObservableCollection<SegmentInd> StrelkaColor { get; set; }
        public int PosValEl { get; set; }
        public override int TVisual
        {
            get { return 7; }
        }
        public ObservableCollection<SegmentInd> Segments { get; set; } //сегменты должны соответствовать GDats
        public InpuColorIndicator():base()
        {
            //Label
            Shrift = "Verdana";
            GpenSize = 11d;
            ShowMessage = "xHello";
            Format = "f0";
            GPen = Colors.Black;
            //

            Segments = new ObservableCollection<SegmentInd>();
            PosValEl = 1;
            MaxValue = 1000;
            NulPos = 100;
            MaxPos = 10;
            Progress = 0;
            GDats = KlapanItemVoltmetr.KI1();
            SegmentInd st = new SegmentInd();
            st.PatchData=KlapanItemVoltmetr.SK1();
            Strelka = st;
            FrameElement = 7;
            ReDrawType = true;
            for (int i = 0; i < GDats.Count; i++)
            {
                SegmentInd sid = new SegmentInd();
                sid.PatchData = GDats[i];
                Segments.Add(sid);
            }
            
            
            
            Draw();
        }
        public override void Draw()
        {
            using (DrawingContext dc = this.RenderOpen())
            {
                foreach (var tr in base.lstTransf)
                    dc.PushTransform(tr);



                int posStrDr = FrameElement * StateKey;
                if (FrameElement != 0)
                {
                    int kf = GDats.Count / FrameElement;//количество фрэймов
                    if (StateKey >= kf) posStrDr = FrameElement * (kf - 1);

                }


                int posEndStr = posStrDr + FrameElement;

                for (int i = posStrDr; i < posEndStr; i++)
                {
                    SolidColorBrush br;
                    Pen gp;

                    br = new SolidColorBrush(Segments[i].PatchData.GBrush);
                    gp = new Pen(new SolidColorBrush(Segments[i].PatchData.GPen), Segments[i].PatchData.GpenSize);
                     if ((PosValEl==i)) //заполняем цветом только квадрат со значением
                     {
                         foreach (var seg in Segments)
                         {
                             if (seg.InSegment(Progress))
                             {
                                 br = new SolidColorBrush(seg.SegmentColorBrush);
                                // gpst = new Pen(new SolidColorBrush(seg.SegmentColorPen), Strelka.PatchData.GpenSize);

                             }
                         }
                        // br = new SolidColorBrush(Segments[i].SegmentColorBrush);
                         //gp = new Pen(new SolidColorBrush(Segments[i].SegmentColorPen), Segments[i].PatchData.GpenSize);
                     }
                     dc.DrawGeometry(br, gp, Geometry.Parse(Segments[i].PatchData.GData));
                }
                //расчет стрелки вольтметра
                double ysdvig = 0d;
                if (Progress <= MaxValue)
                    ysdvig = Progress * (-NulPos + MaxPos) / MaxValue;
                else ysdvig = (-NulPos + MaxPos);

                 
                SolidColorBrush brst = new SolidColorBrush(Strelka.PatchData.GBrush);
                Pen gpst = new Pen(new SolidColorBrush(Strelka.PatchData.GPen), Strelka.PatchData.GpenSize);
                SolidColorBrush txtBrush = new SolidColorBrush(GPen);
                foreach (var seg in Segments)
                {
                    if (seg.InSegment(Progress))
                    {
                        brst = new SolidColorBrush(seg.SegmentColorPen);
                        gpst = new Pen(new SolidColorBrush(seg.SegmentColorPen), Strelka.PatchData.GpenSize);
                        txtBrush = new SolidColorBrush(seg.SegmentColorText);
                    }
                }
                
                var newpos = MovCalcDlg.moveCalc(ysdvig, Strelka.PatchData.GData);

               
                
                dc.DrawGeometry(brst, gpst, Geometry.Parse(newpos));


 FormattedText ft = new FormattedText(Progress.ToString(Format),
        CultureInfo.GetCultureInfo("ru-ru"),
        FlowDirection.LeftToRight,
        new Typeface(Shrift),
        GpenSize,
        txtBrush);

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
            return new PropertyColorInd(this);
        }
    }
}
