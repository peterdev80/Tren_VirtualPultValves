using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Serialization;

namespace PatchMnemoLib.Model
{
   
      [Serializable]
    public class GraphicsPatch : VisualBase
    {

        private Brush _br = Brushes.Transparent; 
       
        #region кисть для сериализации
           private Color _cl=Colors.Black;
          private double _dps=1.0d;
          public Color DefPenColor { get { return _cl; } set { _cl = value; graphicsPen = new Pen(new SolidColorBrush(_cl), DefPenSize);  } }
          public double DefPenSize { get { return _dps; } set { _dps = value; graphicsPen = new Pen(new SolidColorBrush(_cl), DefPenSize); } }
        #endregion


        public string GData { get; set; }
         

               // [XmlIgnore]
      //  public Color br { get { return _cl; } set { _cl = value; _br = new SolidColorBrush(_cl); } }
        
    

        public GraphicsPatch()
        {
            
            graphicsPen = new Pen(Brushes.Black, 1);
           // _br = Colors.Red;
            //br = Brushes.Transparent;
           
           

        }
          [XmlIgnore]
        public override int TVisual
        {
            get { return 1; }
        }
         
        public override void Draw()
        {
           
            
            
            using (DrawingContext dc = this.RenderOpen())
            {
                foreach(var tr in  base.lstTransf)
                    dc.PushTransform(tr); 

                
                dc.DrawGeometry(_br, graphicsPen, Geometry.Parse(GData));

                foreach (var tr in base.lstTransf)
                    dc.Pop(); 

            }
        }

  


        public override PropertiesGraphicsBase CreateSerializedObject()
        {
            return new PropertyPatchGraphics(this);
        } 



    }
}
