using PatchMnemoLib.Model;
using PatchMnemoLib.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace PatchMnemoLib.ViewModelMElement
{
    public class ViewModelValueLabel: ViewModelGraphics
    {
        public ViewModelValueLabel():base()
        {
            _patch=new ValueLabel();
        }
          public ViewModelValueLabel(ViewModelMnemoCanvas mc)
           : base(mc)
       {
           
           ValueLabel gp = new ValueLabel();
           this._patch = gp;
           _state = new StatesPatch();
           gp.Name = "vl" + N_Name;// + MCanvas.Canva.VisualCount;
           MCanvas.Canva.AddVisual(gp);
       }
       public ViewModelValueLabel(ViewModelMnemoCanvas mc, ValueLabel gp)
            : base(mc, gp)
        {
         
      
       }

       public ValueLabel patch
       {
           get { return (ValueLabel)base.GetGP(); }
       }



       public Color GPen
       {
           get { return patch.GPen; } 
           set { patch.GPen = value;OnPropertyChanged("GPen");  ReDraw(); }
       }
       public double GpenSize { get { return patch.GpenSize; } set { patch.GpenSize = value; OnPropertyChanged("GpenSize"); ReDraw(); } }
       public double Xpos { get { return patch.Xpos; } set { patch.Xpos = value;  OnPropertyChanged("Xpos");ReDraw(); } }
       public double Ypos { get { return patch.Ypos; } set { patch.Ypos = value; OnPropertyChanged("Ypos"); ReDraw(); } }
       public string Shrift { get { return patch.Shrift; } set { patch.Shrift = value; OnPropertyChanged("Shrift"); ReDraw(); } }
       public string Format { get { return patch.Format; } set { patch.Format = value;  OnPropertyChanged("Format");ReDraw(); } }
       public string ShowMessage { get { return patch.ShowMessage; } set { patch.ShowMessage = value; OnPropertyChanged("ShowMessage"); ReDraw(); } }
       public int Alignment { get { return patch.Alignment; } set { patch.Alignment = value; OnPropertyChanged("Alignment"); ReDraw(); } }
       public override void CopyMov(ViewModelGraphics vl)
       {
           base.CopyMov(vl);
           var val=(ViewModelValueLabel)vl;
           GPen = val.GPen;
           GpenSize = val.GpenSize;
           Xpos = val.Xpos;
           Ypos = val.Ypos;
           Shrift = val.Shrift;
           Format = val.Format;
           ShowMessage = val.ShowMessage;
           Alignment = val.Alignment;
       }
       public override void MoveGraphics(double x, double y)
       {
           this.Xpos += x;
           this.Ypos += y;
           ReDraw();
       }




       //замена кисти в маршруте
       public override void ReplaceMarsrut(int st, Pen val, string name)
       {

           base.ReplaceMarsrut(st, val, name);

           SolidColorBrush scb=(SolidColorBrush)_state.StateG.MPen.Brush;
           GPen = scb.Color;
           ReDraw();

       }


       //Удаление пера из маршрута

       public override void deleteMarshrut(string val)
       {
           base.deleteMarshrut(val);
          
       }
       public override void SetState(int val, string name)
       {

           base.SetState(val, name);
           if (name != "")
            {
                SolidColorBrush scb = (SolidColorBrush)_state.StateG.MPen.Brush;
                GPen = scb.Color;
            }
       }
       


    }
}
