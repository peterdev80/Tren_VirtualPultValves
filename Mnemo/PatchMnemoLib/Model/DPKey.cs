using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using System.Windows.Media;
using PatchMnemoLib.ViewModel;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace PatchMnemoLib.Model
{
   public class DPKey: VisualBase
    {
       
       
       private int state;
      // private Brush _br = Brushes.Transparent;
     
       
       public double StartPointX { get; set; }
       public double StartPointY { get; set; }
       public double EndPointX { get; set; }
       public double EndPointY { get; set; }
       public double KofSdvigX { get; set; }
       public double KofSdvigY { get; set; }
       public ObservableCollection<StringItem> PenList { get; set; }
       public bool NodePen { get; set; }
       public int KeyTyp { get; set; }
       [XmlIgnore]
       public int StateKey
       {
           get { return state; }
           set { state = value; }
       }

       public DPKey()
       {
           PenList = new ObservableCollection<StringItem>();
           graphicsPen = new Pen(Brushes.Black, 1);
           
       }
       public override int TVisual
       {
           get { return 2; }
       }
       public override void Draw()
       {
           using (DrawingContext dc = this.RenderOpen())
           {

               //var sti = PenList[state];
               foreach (var tr in base.lstTransf)
                   dc.PushTransform(tr); 
               Point StartPoint = new Point(StartPointX, StartPointY);
               Point EndPoint = new Point(EndPointX, EndPointY);
               Vector KofSdvig = new Vector(KofSdvigX, KofSdvigY);

               Point pointResult1 = StartPoint;
               Point pointResult2 = EndPoint;               
               if (NodePen)
                   if (PenList.Count > state) graphicsPen = viewModelMnemoAnimPen.Instance.GetPen(PenList[state].Value);
               if (state != 0)
               {
                   if ((KeyTyp == 1) || (KeyTyp == 0))
                   pointResult1 = Point.Add(StartPoint, KofSdvig);
                   if ((KeyTyp == 2) || (KeyTyp == 0))
                   pointResult2 = Point.Add(EndPoint, KofSdvig);
               }

               dc.DrawLine(graphicsPen, pointResult1, pointResult2);

               foreach (var tr in base.lstTransf)
                   dc.Pop(); 


           }
       }
       public override PropertiesGraphicsBase CreateSerializedObject()
       {
           return new PropertyDPGraphics(this);
       }
    }
}
