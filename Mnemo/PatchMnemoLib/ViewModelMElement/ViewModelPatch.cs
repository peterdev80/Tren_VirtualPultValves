using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Windows.Media;
using System.Windows;
using System.Globalization;
using System.Diagnostics;
using PatchMnemoLib.ViewModel;
using MUtilites;

namespace PatchMnemoLib.ViewModelMElement

{
    public class ViewModelPatch : ViewModelGraphics
    {
      
       
        //Basa state pen
        

     #region Constructor
        public ViewModelPatch():base()
        {
            _patch = new GraphicsPatch();
           
        }
        /// <summary>
        /// Конструктор для создания новой графики
        /// </summary>
        /// <param name="mc">Канва</param>
        public ViewModelPatch(ViewModelMnemoCanvas mc):base(mc)
        {
           
            GraphicsPatch gp = new GraphicsPatch();
            this._patch = gp;
            _state = new StatesPatch();
            gp.Name = "l" + N_Name;//MCanvas.Canva.VisualCount +"_"+ rnd.Next(MCanvas.Canva.VisualCount);
            MCanvas.Canva.AddVisual(gp);
                
        }
      
        /// <summary>
        /// конструктор из уже заданной графики
        /// </summary>
        /// <param name="mc">Канва для рисования</param>
        /// <param name="gp">Графика</param>
        public ViewModelPatch(ViewModelMnemoCanvas mc, GraphicsPatch gp):base(mc,gp)
        {
         
       }
      #endregion
        public GraphicsPatch patch
        {
            get { return (GraphicsPatch)base.GetGP(); }
        }
        #region ViewGraphics
        #region Property
        public Point StartPoint
        {
            get { return GetPoint(((GraphicsPatch)patch).GData); }
        }
   
        public string GraphicsData
        {
            get { return patch.GData; }
            set
            {
                if (patch.GData != value)
                {
                    patch.GData = value;
                    this.OnPropertyChanged("GraphicsData");
                    ReDraw();
                }
            }
        }
        public Color DefPenColor
        {
            get { return patch.DefPenColor; }
            set
            {
                patch.DefPenColor = value;
               
                this.OnPropertyChanged("DefPenColor");
               
            }
        }
        public double DefPenSize
        {
            get { return patch.DefPenSize; }
            set
            {
                patch.DefPenSize = value;
                this.OnPropertyChanged("DefPenSize");
               
               
            }
        }
   
        public Pen PPen
        {
            get { return patch.graphicsPen; }
            set 
            {
                if (patch.graphicsPen != value)
                {
                    patch.graphicsPen = value;
                    this.OnPropertyChanged("PPen");
                    ReDraw();
                }
            }
        }
       


        #endregion

     
      
        #endregion
       
        //замена кисти в маршруте
        public override void ReplaceMarsrut(int st, Pen val,string name)
        {

            base.ReplaceMarsrut(st, val, name);
            PPen = _state.StateG.MPen;
            ReDraw();

        }

       
        //Удаление пера из маршрута

        public override void deleteMarshrut(string val)
        {
            base.deleteMarshrut(val);
            PPen = new Pen(Brushes.Black,2);
        }
        public override void SetState(int val, string name)
        {

            base.SetState(val, name);
            if (_state.StateG!=null)
            PPen = _state.StateG.MPen; else
                MessageBox.Show(String.Format("Нет StateG для имени {0} значения {1}",name,val));
        }
        public Pen CurPen
        {
            get {return _state.StateG.MPen;}
        }

        public override void CopyMov(ViewModelGraphics val)
        {
            base.CopyMov(val);
            patch.GData = ((ViewModelPatch)val).patch.GData;
            patch.DefPenColor = ((ViewModelPatch)val).patch.DefPenColor;
            patch.DefPenSize = ((ViewModelPatch)val).patch.DefPenSize;
            ReDraw();
        }


        public override void MoveGraphics(double x, double y)
        {
            GraphicsData = MovCalcDlg.moveCalc(x, y, GraphicsData);
        }

      

    }
}
