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
   public class ViewModelColorInd : ViewModelGraphics
   {

       

      public ViewModelColorInd():base()
       {
           _patch = new InpuColorIndicator();
       }
       public ViewModelColorInd(ViewModelMnemoCanvas mc)
           : base(mc)
       {

           InpuColorIndicator gp = new InpuColorIndicator();
           this._patch = gp;
           _state = new StatesPatch();
           gp.Name = "clrInd" + N_Name;// + MCanvas.Canva.VisualCount;
           MCanvas.Canva.AddVisual(gp);
           ReDraw();
       }
       public ViewModelColorInd(ViewModelMnemoCanvas mc, InpuColorIndicator gp)
            : base(mc, gp)
        {
         
       }



       public int FrameElement { get { return patch.FrameElement; } set { patch.FrameElement = value; OnPropertyChanged("FrameElement"); ReDraw(ReDrawType); } }
     
      /* public ObservableCollection<KlapanItem> GraphicsData
       {
           get { return patch.GDats; }
           set { patch.GDats = value; OnPropertyChanged("GraphicsData"); ReDraw(ReDrawType); }
       } */
        
        public ObservableCollection<SegmentInd> GraphicsData
       {
           get { return patch.Segments; }
           set { patch.Segments = value; OnPropertyChanged("GraphicsData"); ReDraw(ReDrawType); }
       }
        
        public InpuColorIndicator patch
       {
           get { return (InpuColorIndicator)base.GetGP(); }
       }





        public double MaxValue { get { return patch.MaxValue; } set { patch.MaxValue = value; OnPropertyChanged("MaxValue"); } }
        public double NulPos { get { return patch.NulPos; } set { patch.NulPos = value; OnPropertyChanged("NulPos"); } }
        public double MaxPos { get { return patch.MaxPos; } set { patch.MaxPos = value; OnPropertyChanged("MaxPos"); } }
        public SegmentInd Strelka { get { return patch.Strelka; } set { patch.Strelka = value; OnPropertyChanged("Strelka"); ReDraw(ReDrawType); } }
        public double Progress { get { return patch.Progress; } set { patch.Progress = value; OnPropertyChanged("Progress"); ReDraw(ReDrawType);  } }

        public double GpenSize { get { return patch.GpenSize; } set { patch.GpenSize = value; OnPropertyChanged("GpenSize"); ReDraw(); } }
        public double Xpos { get { return patch.Xpos; } set { patch.Xpos = value; OnPropertyChanged("Xpos"); ReDraw(); } }
        public double Ypos { get { return patch.Ypos; } set { patch.Ypos = value; OnPropertyChanged("Ypos"); ReDraw(); } }
        public string Shrift { get { return patch.Shrift; } set { patch.Shrift = value; OnPropertyChanged("Shrift"); ReDraw(); } }
        public string Format { get { return patch.Format; } set { patch.Format = value; OnPropertyChanged("Format"); ReDraw(); } }
        public int PosValEl { get { return patch.PosValEl; } set { patch.PosValEl = value; } }//пока не реализован жестко 1

        
        
        
        
        
        
        
        
        
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
           ViewModelColorInd val = (ViewModelColorInd)vl;
          
           patch.Segments = val.patch.Segments;
           FrameElement = val.FrameElement;
           Strelka = val.Strelka;
          MaxValue=val.MaxValue;
         NulPos=val.NulPos;
         MaxPos=val.MaxPos;
       
       
       // public ObservableCollection<SegmentInd> StrelkaColor { get; set; }
         PosValEl = val.PosValEl;

          
           GpenSize = val.GpenSize;
           Xpos = val.Xpos;
           Ypos = val.Ypos;
           Shrift = val.Shrift;
           Format = val.Format;



       }
       public void TestVoid()
       {
           ReDraw(ReDrawType);
       }
       public override void MoveGraphics(double x, double y)
       {
           //ObservableCollection<SegmentInd> ki = new ObservableCollection<SegmentInd>();
           foreach (SegmentInd kli in GraphicsData)
           {
               KlapanItem klin = new KlapanItem();
               klin.GBrush = kli.PatchData.GBrush;
               klin.GData = MovCalcDlg.moveCalc(x, y, kli.PatchData.GData);
               klin.GPen = kli.PatchData.GPen;
               klin.GpenSize = kli.PatchData.GpenSize;
            // SegmentInd sid=new SegmentInd()
           // sid.GData=klin;
           //    sid.HeigVal=kli.HeigVal;
           //    sid.LowVal=kli.LowVal;
               kli.PatchData=klin;
               
               
              // ki.Add(klin);
           }
           this.Xpos += x;
           this.Ypos += y;

          

          // GraphicsData = ki;

           Strelka.PatchData.GData = MovCalcDlg.moveCalc(x, y, Strelka.PatchData.GData);

           TestVoid();
       }
    }
}

