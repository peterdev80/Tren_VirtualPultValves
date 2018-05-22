using MUtilites;
using PatchMnemoLib.Model;
using PatchMnemoLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PatchMnemoLib.ViewModelMElement
{
   public class ViewModelLispKlapan : ViewModelGraphics
    {

        public ViewModelLispKlapan() : base()
        {
            _patch = new LispKlapan();
        }
        public ViewModelLispKlapan(ViewModelMnemoCanvas mc)
           : base(mc)
        {
          
            LispKlapan gp = new LispKlapan();
            this._patch = gp;
            _state = new StatesPatch();
            gp.Name = "lkl" + N_Name;// + MCanvas.Canva.VisualCount;
            MCanvas.Canva.AddVisual(gp);

        }
        public ViewModelLispKlapan(ViewModelMnemoCanvas mc, LispKlapan gp)
            : base(mc, gp)
        {

        }
        public override void ReplaceMarsrut(int st, System.Windows.Media.Pen val, string name)
        {
            base.ReplaceMarsrut(st, val, name);
            ReDraw(ReDrawType);
        }

        //Удаление пера из маршрута

        public override void deleteMarshrut(string val)
        {
            base.deleteMarshrut(val);

            ReDraw(ReDrawType);

        }
        public override void CopyMov(ViewModelGraphics vl)
        {
            base.CopyMov(vl);
            ViewModelLispKlapan val = (ViewModelLispKlapan)vl;
            patch.GDats = val.patch.GDats;
            



        }

        public ObservableCollection<LispKlapanItem> GraphicsData
        {
            get { return patch.GDats; }
            set { patch.GDats = value; OnPropertyChanged("GraphicsData"); ReDraw(ReDrawType); }
        }
        public LispKlapan patch
        {
            get { return (LispKlapan)base.GetGP(); }
        }
        public double TransformValue { get { return patch.transformValue; } set { patch.transformValue = value; OnPropertyChanged("TransformValue"); ReDraw(ReDrawType); } }


        public override void MoveGraphics(double x, double y)
        {
            ObservableCollection<LispKlapanItem> ki = new ObservableCollection<LispKlapanItem>();
            foreach (LispKlapanItem kli in GraphicsData)
            {
                LispKlapanItem klin = new LispKlapanItem();
                klin.GBrush = kli.GBrush;
                klin.GData = MovCalcDlg.moveCalc(x, y, kli.GData);
                klin.GPen = kli.GPen;
                klin.GpenSize = kli.GpenSize;
                ki.Add(klin);
                
            }

            GraphicsData = ki;



            TestVoid();
        }
        public void TestVoid()
        {
            ReDraw(ReDrawType);
        }
    }
}

