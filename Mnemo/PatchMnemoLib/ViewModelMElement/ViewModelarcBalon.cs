using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using PatchMnemoLib.ViewModel;
using System.Windows.Media;

namespace PatchMnemoLib.ViewModelMElement
{
    public class ViewModelarcBalon : ViewModelGraphics
    {
        public ViewModelarcBalon()
            : base()
        {
            this._patch = new arcBalon();
        }
        /// <summary>
        /// Конструктор для создания новой графики
        /// </summary>
        /// <param name="mc">Канва</param>
        public ViewModelarcBalon(ViewModelMnemoCanvas mc):base(mc)
        {

            arcBalon gp = new arcBalon();
            this._patch = gp;
            _state = new StatesPatch();
            gp.Name = "ab" + N_Name;// MCanvas.Canva.VisualCount;
            MCanvas.Canva.AddVisual(gp);
            ReDrawType = true;
                
        }
      
        /// <summary>
        /// конструктор из уже заданной графики
        /// </summary>
        /// <param name="mc">Канва для рисования</param>
        /// <param name="gp">Графика</param>
        public ViewModelarcBalon(ViewModelMnemoCanvas mc, arcBalon gp)
            : base(mc, gp)
        {
         
       }


        public arcBalon patch
        {
            get { return (arcBalon)base.GetGP(); }
        }


        public double Progress { get { return patch.Progress; } set { patch.Progress = value; OnPropertyChanged("Progress"); ReDraw(ReDrawType); } }
        public double RadiusX { get { return patch.RadiusX; } set { patch.RadiusX = value; OnPropertyChanged("RadiusX"); ReDraw(ReDrawType); } }
        public double RadiusY { get { return patch.RadiusY; } set { patch.RadiusY = value; OnPropertyChanged("RadiusY"); ReDraw(ReDrawType); } }
        public double XPos { get { return patch.XPos; } set { patch.XPos = value; OnPropertyChanged("XPos"); ReDraw(ReDrawType); } }
        public double YPos { get { return patch.YPos; } set { patch.YPos = value; OnPropertyChanged("YPos"); ReDraw(ReDrawType); } }
        public double MaxValue { get { return patch.MaxValue; } set { patch.MaxValue = value; OnPropertyChanged("MaxValue"); ReDraw(ReDrawType); } }
        public double StrokeSize { get { return patch.StrokeSize; } set { patch.StrokeSize = value; OnPropertyChanged("StrokeSize"); ReDraw(ReDrawType); } }
        public Color BackColor { get { return patch.BackColor; } set { patch.BackColor = value; OnPropertyChanged("BackColor"); ReDraw(ReDrawType); } }
        public Color FrontColor { get { return patch.FrontColor; } set { patch.FrontColor = value; OnPropertyChanged("FrontColor"); ReDraw(ReDrawType); } }
        public Color StrokeColor { get { return patch.StrokeColor; } set { patch.StrokeColor = value; OnPropertyChanged("StrokeColor"); ReDraw(ReDrawType); } }




        public override void CopyMov(ViewModelGraphics vl)
        {
            base.CopyMov(vl);
            var val = (ViewModelarcBalon)vl;
            /*
            Progress 
             RadiusX
             RadiusY 
             XPos 
             YPos
             MaxValue 
             StrokeSize 
            BackColor 
            FrontColor 
            StrokeColor
             * */
            Progress =val.Progress; 
             RadiusX=val.  RadiusX;
             RadiusY =val. RadiusY ;
             XPos =val.    XPos; 
             YPos=val.     YPos;
             MaxValue =val. MaxValue; 
             StrokeSize =val.StrokeSize;
            BackColor =val.BackColor;
            FrontColor =val.FrontColor;
            StrokeColor = val.StrokeColor;

           
        }
        public override void MoveGraphics(double x, double y)
        {
            this.XPos += x;
            this.YPos += y;
            ReDraw(ReDrawType);
        }
    
    }
}
