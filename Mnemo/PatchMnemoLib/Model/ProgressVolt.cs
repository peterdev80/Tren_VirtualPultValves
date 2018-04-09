using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Media;
using MUtilites;
using PatchMnemoLib.UtilControl;

namespace PatchMnemoLib.Model
{

    public class ProgressVolt : Klapan
    {
        public double MaxValue { get; set; }       
        public double NulPos { get; set; }
        public double MaxPos { get; set; }       
        public KlapanItem Strelka { get; set; }
        public double Progress { get; set; }
        public override int TVisual
        {
            get { return 6; }
        }





        public ProgressVolt():base()
        {
           /* MaxValue = 1000;
            NulPos = 100;
            MaxPos = 10;
            Progress = 0;
            GDats = KlapanItemVoltmetr.KI2();
            Strelka = KlapanItemVoltmetr.SK1();
            FrameElement =6;
            Draw();*/


            MaxValue = 1000;
            NulPos = 100;
            MaxPos = 10;
            Progress = 0;
            GDats = KlapanItemVoltmetr.KI1();
            Strelka = KlapanItemVoltmetr.SK1();
            FrameElement = 7;
            ReDrawType = true;
            Draw();
           
          /* --voltmetr
           MaxValue = 40;
            NulPos = 329;
            MaxPos = 261;
            Progress = 0;
            GDats = KlapanItemVoltmetr.KI();
            Strelka = KlapanItemVoltmetr.SK();
            FrameElement = 3;
            Draw();*/

           /* KlapanItem 

          /*  GDats.Add("M736.792929292929 , 259.868686868687C736.792929292929 , 258.764117369026 , 737.688359793269 , 257.868686868687 , 738.792929292929 , 257.868686868687L765.042929292929 , 257.868686868687C766.147498792592 , 257.868686868687 , 767.042929292929 , 258.764117369026 , 767.042929292929 , 259.868686868687L767.042929292929 , 334.493686868687C767.042929292929 , 335.59825636835 , 766.147498792592 , 336.493686868687 , 765.042929292929 , 336.493686868687L738.792929292929 , 336.493686868687C737.688359793269 , 336.493686868687 , 736.792929292929 , 335.59825636835 , 736.792929292929 , 334.493686868687zM734.917929292929 , 256.493686868687C734.917929292929 , 255.941402118856 , 735.365644543099 , 255.493686868687 , 735.917929292929 , 255.493686868687L768.042929292929 , 255.493686868687C768.595214042762 , 255.493686868687 , 769.042929292929 , 255.941402118856 , 769.042929292929 , 256.493686868687L769.042929292929 , 338.618686868687C769.042929292929 , 339.170971618517 , 768.595214042762 , 339.618686868687 , 768.042929292929 , 339.618686868687L735.917929292929 , 339.618686868687C735.365644543099 , 339.618686868687 , 734.917929292929 , 339.170971618517 , 734.917929292929 , 338.618686868687z
");*/
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
                    SolidColorBrush br = new SolidColorBrush(GDats[i].GBrush);
                    Pen gp = new Pen(new SolidColorBrush(GDats[i].GPen), GDats[i].GpenSize);
                    dc.DrawGeometry(br, gp, Geometry.Parse(GDats[i].GData));
                }
                //расчет стрелки вольтметра
                double ysdvig=0d;
                if (Progress <= MaxValue)
                    ysdvig = Progress * (-NulPos + MaxPos) / MaxValue;
                else ysdvig = (-NulPos + MaxPos);

               

               SolidColorBrush brst = new SolidColorBrush(Strelka.GBrush);
               Pen gpst = new Pen(new SolidColorBrush(Strelka.GPen), Strelka.GpenSize);
               var newpos = MovCalcDlg.moveCalc(ysdvig, Strelka.GData);
               dc.DrawGeometry(brst, gpst, Geometry.Parse(newpos));


                foreach (var tr in base.lstTransf)
                    dc.Pop();

            }
        }
        public override PropertiesGraphicsBase CreateSerializedObject()
        {
            return new PropertyVoltmetr(this);
        }

    }

}
