using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.KeyAKlapan;
using System.Windows;
using PatchMnemoLib.Model;
using System.Windows.Media;
using PatchMnemoLib.ViewModel;
using System.Collections.ObjectModel;

namespace PatchMnemoLib.ViewModelMElement
{
    public class ViewModelDP : ViewModelGraphics
    {
         #region Constructor
        public ViewModelDP():base()
        {
            this._patch = new DPKey(); 
           
        }
        /// <summary>
        /// Конструктор для создания новой графики
        /// </summary>
        /// <param name="mc">Канва</param>
        public ViewModelDP(ViewModelMnemoCanvas mc):base(mc)
        {

            DPKey gp = new DPKey();
            this._patch = gp;
            _state = new StatesPatch();
            gp.Name = "dp" + N_Name;// + MCanvas.Canva.VisualCount;
            MCanvas.Canva.AddVisual(gp);
                
        }
      
        /// <summary>
        /// конструктор из уже заданной графики
        /// </summary>
        /// <param name="mc">Канва для рисования</param>
        /// <param name="gp">Графика</param>
        public ViewModelDP(ViewModelMnemoCanvas mc,  DPKey gp)
            : base(mc, gp)
        {
         
       }
      #endregion
        public DPKey patch
        {
            get { return (DPKey)base.GetGP(); }
        }

        public double StartPointX
        {
            get { return patch.StartPointX; }
            set
            {
                patch.StartPointX = value;
                OnPropertyChanged("StartPointX");
                ReDraw();
            }
        }
        public double StartPointY
        {
            get { return patch.StartPointY; }
            set
            {
                patch.StartPointY = value;
                OnPropertyChanged("StartPointY");
                ReDraw();
            }
        }



        public double EndPointX { get { return patch.EndPointX; } set { patch.EndPointX = value; OnPropertyChanged("EndPointX"); ReDraw(); } }
        public double EndPointY { get { return patch.EndPointY; } set { patch.EndPointY = value; OnPropertyChanged("EndPointY"); ReDraw(); } }
        public double KofSdvigX { get { return patch.KofSdvigX; } set { patch.KofSdvigX = value; ReDraw(); OnPropertyChanged("KofSdvigX"); } }
        public double KofSdvigY { get { return patch.KofSdvigY; } set { patch.KofSdvigY = value; ReDraw(); OnPropertyChanged("KofSdvigY"); } }
        public ObservableCollection<StringItem> PenList { get { return patch.PenList; } set { patch.PenList = value;  OnPropertyChanged("PenList");ReDraw(); } }
        public bool NodePen { get { return patch.NodePen; } set { patch.NodePen = value; ;OnPropertyChanged("NodePen"); ;ReDraw(); } }
        public int KeyTyp { get { return patch.KeyTyp; } set { patch.KeyTyp = value; OnPropertyChanged("KeyTyp"); ReDraw(); } }
        public Pen PPen
        {
            get { return patch.graphicsPen; }
            set
            {
                patch.graphicsPen = value;
                this.OnPropertyChanged("PPen");
                ReDraw();
            }
        }
       
        //замена кисти в маршруте
        public override void ReplaceMarsrut(int st, Pen val, string name)
        {

            base.ReplaceMarsrut(st, val, name);
            PPen = _state.StateG.MPen;
            ReDraw();

        }

        //Удаление пера из маршрута

        public override void deleteMarshrut(string val)
        {
            base.deleteMarshrut(val);           
            PPen = new Pen(Brushes.Black, 2);
            ReDraw();
           
        }
        public override void SetState(int val, string name)
        {

            base.SetState(val, name);
            PPen = _state.StateG.MPen;
            patch.StateKey = val;
            ReDraw();
        }
        public override void CopyMov(ViewModelGraphics vl)
        {
            base.CopyMov(vl);
            var val = (ViewModelDP)vl;
            StartPointX = val.StartPointX;
            StartPointY = val.StartPointY;
            EndPointX = val.EndPointX;
            EndPointY = val.EndPointY;
            KofSdvigX = val.KofSdvigX;
            KofSdvigY = val.KofSdvigY;
            PenList = val.PenList;
            NodePen = val.NodePen;
            KeyTyp = val.KeyTyp;

        }
        public override void MoveGraphics(double x, double y)
        {
            throw new NotImplementedException();
        }

    
    
    
    }
}
