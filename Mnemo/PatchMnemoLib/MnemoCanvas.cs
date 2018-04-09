using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using PatchMnemoLib.Model;
using System.IO;
using System.Xml.Serialization;
using PatchMnemoLib.ViewModel;

namespace PatchMnemoLib
{
    public class MnemoCanvas : Canvas
    {

        private List<VisualBase> visuals = new List<VisualBase>();

        public MnemoCanvas()
            : base()
        {
            this.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(MnemoCanvas_MouseRightButtonUp);
          


           /* this.MouseLeftButtonDown += (sender, e)=>{
                MessageBox.Show("Property"); };*/
        }

        void MnemoCanvas_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point pointClicked = e.GetPosition(this);
            MessageBox.Show(pointClicked.ToString());
        }
       
        /// <summary>
        /// пытаюсь совместить рисрванные элементы и стандартные
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override Visual GetVisualChild(int index)
        {
        
            if (index<base.VisualChildrenCount) return   

                
                base.GetVisualChild(index);
            return visuals[index - base.VisualChildrenCount];
        
           // return visuals[index];
        }
        protected override int VisualChildrenCount
        {
            get
            {
                var i=base.VisualChildrenCount;
                var j = visuals.Count;
                return i+j;
               // return visuals.Count;
            }
        }
        public int VisualCount
        {
            get
            {
                return visuals.Count;

            }
        }



        public void AddVisual(VisualBase visual)
        {
            visuals.Add(visual);
            //gpatch.Add(new ViewModelPatch(this, visual));

            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
        }
        public void InsertVisual(VisualBase visual, int pos)
        {
            visuals.Insert(pos, visual);
            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);

        }
     

        public void DeleteVisual(VisualBase visual)
        {
            visuals.Remove(visual);
           // var f = gpatch.Find(delegate(ViewModelPatch vmp) { return vmp.Name == visual.Name; });
            //gpatch.Remove(f);
            base.RemoveVisualChild(visual);
            base.RemoveLogicalChild(visual);
            
        }

        
        public void DeleteVisual(string name)
        {
            var x = GetVisual(name) as GraphicsPatch;
            if (x != null)
                DeleteVisual(x);
            else
                new Exception("Удаление несуществущего элемента");

        }


        

        public DrawingVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
          
            
            
            
            return hitResult.VisualHit as DrawingVisual;
        }

        private List<DrawingVisual> hits = new List<DrawingVisual>();
        public List<DrawingVisual> GetVisuals(Geometry region)
        {
            hits.Clear();
            GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
            HitTestResultCallback callback = new HitTestResultCallback(this.HitTestCallback);
            VisualTreeHelper.HitTest(this, null, callback, parameters);
            return hits;
        }

        private HitTestResultBehavior HitTestCallback(HitTestResult result)
        {
            GeometryHitTestResult geometryResult = (GeometryHitTestResult)result;
            DrawingVisual visual = result.VisualHit as DrawingVisual;
            if (visual != null &&
                geometryResult.IntersectionDetail == IntersectionDetail.FullyInside)
            {
                hits.Add(visual);
            }
            return HitTestResultBehavior.Continue;
        }

       /// <summary>
       /// метод возврощает линию сохранен, лутше использовать GetVisuals
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>

        public GraphicsPatch GetVisual(string name)
        {
            foreach (VisualBase gb in visuals)
            {
                if (gb.TVisual==1)
                    if (gb.Name == name) return (GraphicsPatch)gb;
            }
            return null;
        }
        public VisualBase GetVisuals(string name)
        {
            foreach (VisualBase gb in visuals)
            {
                
                    if (gb.Name == name) return gb;
            }
            return null;
        }
       
    }
    
}
