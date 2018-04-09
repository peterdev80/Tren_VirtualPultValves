using MUtilites;
using PatchMnemoLib.Model;
using PatchMnemoLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;

namespace PatchMnemoLib.ViewModelMElement
{
    public class ViewModelAnimKlapan : ViewModelGraphics
    {
        private UpravRotate RotateCentr;
        public ViewModelAnimKlapan() : base()
        {
            _patch = new AnimKlapan();
            RotateCentr = new UpravRotate((AnimKlapan)_patch);
            RotateCentr.BeginAnimation(UpravRotate.AnimRotateProperty, patch.Animation);
        }
        public ViewModelAnimKlapan(ViewModelMnemoCanvas mc)
           : base(mc)
        {

            AnimKlapan gp = new AnimKlapan();
            this._patch = gp;
            _state = new StatesPatch();
            gp.Name = "ak" + N_Name;// + MCanvas.Canva.VisualCount;
            MCanvas.Canva.AddVisual(gp);
            RotateCentr = new UpravRotate(gp);

            RotateCentr.BeginAnimation(UpravRotate.AnimRotateProperty, patch.Animation);
            FrameElement = 1;
        }
        public ViewModelAnimKlapan(ViewModelMnemoCanvas mc, AnimKlapan gp)
            : base(mc, gp)
        {
            RotateCentr = new UpravRotate(gp);
            RotateCentr.BeginAnimation(UpravRotate.AnimRotateProperty, patch.Animation);
        }
        public int FrameElement { get { return patch.FrameElement; } set { patch.FrameElement = value; OnPropertyChanged("FrameElement"); ReDraw(ReDrawType); } }
        public string AnimName { get { return patch.AnimName; } set { patch.AnimName = value; OnPropertyChanged("AnimName"); } }

        public AnimKlapan patch
        {
            get { return (AnimKlapan)base.GetGP(); }
        }
        public ObservableCollection<AnimKlapanItem> GraphicsData
        {
            get { return patch.GDats; }
            set { patch.GDats = value; OnPropertyChanged("GraphicsData"); ReDraw(ReDrawType); }
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
        public override void SetState(int val, string name)
        {

            base.SetState(val, name);



            patch.StateKey = _state.StateG.Situtation; //val;
                                                       /* if (!patch.GetCurFame())
                                                            patch.Animation.FillBehavior = FillBehavior.Stop;*/

            ReDraw(ReDrawType);
        }
        public override void CopyMov(ViewModelGraphics vl)
        {
            base.CopyMov(vl);
            ViewModelAnimKlapan val = (ViewModelAnimKlapan)vl;
            patch.GDats = val.patch.GDats;
            FrameElement = val.FrameElement;



        }
        public void TestVoid()
        {
            ReDraw(ReDrawType);
        }
        public override void MoveGraphics(double x, double y)
        {
            ObservableCollection<AnimKlapanItem> ki = new ObservableCollection<AnimKlapanItem>();
            foreach (AnimKlapanItem kli in GraphicsData)
            {
                AnimKlapanItem klin = new AnimKlapanItem();
                klin.GBrush = kli.GBrush;
                klin.GData = MovCalcDlg.moveCalc(x, y, kli.GData);
                klin.Xrotate = kli.Xrotate + x;
                klin.Yrotate = kli.Yrotate + y;
                klin.IsAnimate = kli.IsAnimate;
                klin.GPen = kli.GPen;
                klin.GpenSize = kli.GpenSize;
                ki.Add(klin);
            }

            GraphicsData = ki;



            TestVoid();
        }
    }


}

