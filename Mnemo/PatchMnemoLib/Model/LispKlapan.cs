using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Serialization;

namespace PatchMnemoLib.Model
{
    public class LispKlapan: VisualBase
    {
        [XmlIgnore]
        public double transformValue { get; set; }
      
        public override int TVisual
        {
            get { return 122; }
        }
        public ObservableCollection<LispKlapanItem> GDats { get; set; }
        public LispKlapan()
       
        {
            GDats = new ObservableCollection<LispKlapanItem>();
            

    }
        public override void Draw()
        {
            using (DrawingContext dc = this.RenderOpen())
            {
               
                foreach (var tr in base.lstTransf)
                    dc.PushTransform(tr);



               int posStrDr =0;

                
                int posEndStr = GDats.Count;
                //if (posEndStr > GDats.Count) { posEndStr = GDats.Count;posStrDr=GDats.Count-1 }//new Exception("Размер масива и фреймы несопоставимы");
             if (GDats.Count < 1) posEndStr = 0;
            for (int i = posStrDr; i < posEndStr; i++)
                {
                     Transform rt;
                    rt = new RotateTransform();
                    if (GDats[i].transformBit)
                    {
                       
                       
                        switch (GDats[i].TypeTransform)
                        {
                            case TransformT.Rotate: {
                                    rt = new RotateTransform(transformValue, GDats[i].Xtransform, GDats[i].Ytransform);break;
                                }
                        }
                       
                       
                      

                    }
                    dc.PushTransform(rt);

                    SolidColorBrush br = new SolidColorBrush(GDats[i].GBrush);
                    Pen gp = new Pen(new SolidColorBrush(GDats[i].GPen), GDats[i].GpenSize);
                    dc.DrawGeometry(br, gp, Geometry.Parse(GDats[i].GData));
                }
            //рисуем изменение для gdats



                foreach (var tr in base.lstTransf)
                    dc.Pop();

            }
        }
        public override PropertiesGraphicsBase CreateSerializedObject()
        {
            return new PropertyLispKlapanGraphics(this);
        }
    }
}
