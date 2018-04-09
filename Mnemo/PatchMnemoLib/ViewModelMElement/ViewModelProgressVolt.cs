using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using PatchMnemoLib.ViewModel;
using System.Collections.ObjectModel;
using MUtilites;

namespace PatchMnemoLib.ViewModelMElement
{
    public class ViewModelProgressVolt : ViewModelGraphics
    {
        public ViewModelProgressVolt():base()
       {
           _patch = new ProgressVolt();
       }
       public ViewModelProgressVolt(ViewModelMnemoCanvas mc)
           : base(mc)
       {

           ProgressVolt gp = new ProgressVolt();
           this._patch = gp;
           _state = new StatesPatch();
           gp.Name = "voltmetr" + N_Name;// + MCanvas.Canva.VisualCount;
           MCanvas.Canva.AddVisual(gp);
           ReDraw();
       }
       public ViewModelProgressVolt(ViewModelMnemoCanvas mc, ProgressVolt gp)
            : base(mc, gp)
        {
         
       }



       public int FrameElement { get { return patch.FrameElement; } set { patch.FrameElement = value; OnPropertyChanged("FrameElement"); ReDraw(ReDrawType); } }
     
       public ObservableCollection<KlapanItem> GraphicsData
       {
           get { return patch.GDats; }
           set { patch.GDats = value; OnPropertyChanged("GraphicsData"); ReDraw(ReDrawType); }
       } 
        
        
        
        public ProgressVolt patch
       {
           get { return (ProgressVolt)base.GetGP(); }
       }





        public double MaxValue { get { return patch.MaxValue; } set { patch.MaxValue = value; OnPropertyChanged("MaxValue"); } }
        public double NulPos { get { return patch.NulPos; } set { patch.NulPos = value; OnPropertyChanged("NulPos"); } }
        public double MaxPos { get { return patch.MaxPos; } set { patch.MaxPos = value; OnPropertyChanged("MaxPos"); } }
        public KlapanItem Strelka { get { return patch.Strelka; } set { patch.Strelka = value; OnPropertyChanged("Strelka"); ReDraw(ReDrawType); } }
        public double Progress { get { return patch.Progress; } set { patch.Progress = value; OnPropertyChanged("Progress"); ReDraw(ReDrawType); } }
        
        
        
        
        
        
        
        
        
        
        
        
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
           ReDraw(ReDrawType);
       }
       public override void CopyMov(ViewModelGraphics vl)
       {
           base.CopyMov(vl);
           ViewModelKlapan val = (ViewModelKlapan)vl;
           patch.GDats = val.patch.GDats;
           FrameElement = val.FrameElement;



       }
       public void TestVoid()
       {
           ReDraw(ReDrawType);
       }
       public override void MoveGraphics(double x, double y)
       {
           ObservableCollection<KlapanItem> ki = new ObservableCollection<KlapanItem>();
           foreach (KlapanItem kli in GraphicsData)
           {
               KlapanItem klin = new KlapanItem();
               klin.GBrush = kli.GBrush;
               klin.GData = MovCalcDlg.moveCalc(x, y, kli.GData);
               klin.GPen = kli.GPen;
               klin.GpenSize = kli.GpenSize;
               ki.Add(klin);
           }

          

           GraphicsData = ki;

           Strelka.GData = MovCalcDlg.moveCalc(x, y, Strelka.GData);

           TestVoid();
       }
    }
}
