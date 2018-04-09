using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using PatchMnemoLib.ViewModel;
using PatchMnemoLib.ViewModelRout;

namespace PatchMnemoLib
{
    public class ShowShemeClass : UIElement
    {
        private string _FShema;
        private string _FRout;

        private string _RShema;
        private string _RRout;

       // MnemoCanvas _MCanva;


        public string FShema { get { return _FShema; } set { _FShema = value; _mc.FNamePatch = _FShema; } }
        public string FRout { get { return _FRout; } set { _FRout = value; vmr.FNamePatch = _FRout; } }

        public string RShema { get { return _RShema; } set { _RShema = value; _mc.RNamePatch = _RShema; } }
        public string RRout { get { return _RRout; } set { _RRout = value; vmr.RNamePatch = _RRout; } }


       private ViewModelMnemoCanvas _mc = new ViewModelMnemoCanvas();
       private ViewModelRouted vmr = new ViewModelRouted();



        public ViewModelMnemoCanvas MC
        {
            get { return _mc; }
            set
            {
                _mc = value;
               
               
            }
        }
        public ViewModelRouted Routed
        {
            get { return vmr; }
        }


        public ShowShemeClass()
        { 
           SetValue(MCanvaProperty,  new MnemoCanvas());
            MC.Canva = MCanva;
            vmr._Canva = _mc;
          
        }

       /* public MnemoCanvas MCanva
        {
            get { return _MCanva; }
        }*/


     public static readonly DependencyProperty MCanvaProperty = DependencyProperty.Register(
    "MCanva",
    typeof(MnemoCanvas),
    typeof(ShowShemeClass),
    new PropertyMetadata(OnValChange)   
  );


        public MnemoCanvas MCanva
        {
            get { return (MnemoCanvas)GetValue(MCanvaProperty); }
            set { SetValue(MCanvaProperty, value); }
        }

        private static void OnValChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ShowShemeClass;
            MnemoCanvas val = (MnemoCanvas)e.NewValue;

           com.MC.Canva=val;

        }   
        
      
    }
}
