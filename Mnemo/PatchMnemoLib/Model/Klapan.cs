using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace PatchMnemoLib.Model
{
   public class Klapan : VisualBase
    {
       private int state;
       [XmlIgnore]
       public int StateKey
       {
           get { return state; }
           set { state = value; }
       }
      
       public int FrameElement { get; set; }
       public Klapan()
       { GDats = new ObservableCollection<KlapanItem>(); }
       /// <summary>
       /// графика для всех элементов клапана
       /// </summary>
       public ObservableCollection<KlapanItem> GDats { get; set; }
      
        public override int TVisual
       {
           get { return 3; }
       }
        public override void Draw()
        {
            using (DrawingContext dc = this.RenderOpen())
            {
                foreach (var tr in base.lstTransf)
                    dc.PushTransform(tr);

               

                int posStrDr = FrameElement * StateKey;
                 if (FrameElement!=0)
                {
                    int kf = GDats.Count / FrameElement;//количество фрэймов
                    if (StateKey >= kf) posStrDr = FrameElement * (kf - 1);

                }

                int posEndStr = posStrDr + FrameElement;
                //if (posEndStr > GDats.Count) { posEndStr = GDats.Count;posStrDr=GDats.Count-1 }//new Exception("Размер масива и фреймы несопоставимы");
                    for (int i = posStrDr; i < posEndStr; i++)
                    {
                        SolidColorBrush br = new SolidColorBrush(GDats[i].GBrush);
                        Pen gp = new Pen(new SolidColorBrush(GDats[i].GPen), GDats[i].GpenSize);
                        dc.DrawGeometry(br, gp, Geometry.Parse(GDats[i].GData));
                    }
               
                
               

                foreach (var tr in base.lstTransf)
                    dc.Pop(); 

            }
        }
        public override PropertiesGraphicsBase CreateSerializedObject()
        {
            return new PropertyKlapanGraphics(this);
        }
    }
}
