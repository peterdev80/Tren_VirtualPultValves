using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Windows.Media;
using System.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;

using PatchMnemoLib.ViewModel;
using PatchMnemoLib.ViewModelMElement;
using System.Diagnostics;
using ValueModel.BaseType;
using ValueModel.BaseModel;

namespace PatchMnemoLib.ViewModelRout
{
    public class ViewModelRoute : DependencyObject
    {
       
        private bool IsInitValueFlag1, IsInitValueFlag2;
        #region DependecyProperty

        public int ValueInt
        {
            get { return (int)GetValue(ValueIntProperty); }
            set { SetValue(ValueIntProperty, value); }
        }

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public string ValueName
        {
            get { return (string)GetValue(ValueNameProperty); }
            set { SetValue(ValueNameProperty, value); }
        }
        public int ValuePos
        {
            get { return (int)GetValue(ValuePosProperty); }
            set { SetValue(ValuePosProperty, value); }
        }
        
        
        
        
        public static readonly DependencyProperty ValueIntProperty =
            DependencyProperty.Register("ValueInt", typeof(int), typeof(ViewModelRoute), new PropertyMetadata(-1, OnValChange));

        public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ViewModelRoute), new PropertyMetadata("", OnNameChange));
        public static readonly DependencyProperty ValueNameProperty = DependencyProperty.Register("ValueName", typeof(string), typeof(ViewModelRoute), new PropertyMetadata("", OnVNameChange));
        public static readonly DependencyProperty ValuePosProperty = DependencyProperty.Register("ValuePos", typeof(int), typeof(ViewModelRoute), new PropertyMetadata(-1, OnValuePosChange));
      

        private static void OnValChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelRoute;
            int val = (int)e.NewValue;
            
            foreach (var pth in com.MPatch)
            {
                pth.SetState(val, com.Name);
              
            }

        }       
      
        private static void OnNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelRoute;
            com.Marshrut.Name = e.NewValue.ToString();
        }


        

        private static void OnVNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelRoute;
            com.Marshrut.ValueName = e.NewValue.ToString();
            com.IsInitValueFlag1 = true;
            if (com.IsInitValueFlag2) com.SetBnd(com.Marshrut.ValueName, com.Marshrut.ValuePos);
        } 
       

        private static void OnValuePosChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelRoute;
            com.Marshrut.ValuePos = (int)e.NewValue;
            com.IsInitValueFlag2 = true;
            if (com.IsInitValueFlag1) com.SetBnd(com.Marshrut.ValueName, com.Marshrut.ValuePos);
        }

        private void SetBnd(string varName, int pos)
        {
            try
            {
                var val = ViewModelVariableList.Instance.GetVariable(varName);
                IntValue v = ((BitIntVar)val.VarM).ValState[pos];
            BindingOperations.SetBinding(this, ViewModelRoute.ValueIntProperty, new Binding { Source = v, Path = new PropertyPath("ValueState") });
       
            }
            catch
            { Console.Write(""); }

            }



 #endregion

        //перечинь кистей состояния 0-пасив 1-актив и т.д.
        public ObservableCollection<StringItem> ListPen
        {
            get { return Marshrut.NamePen; }
            set { Marshrut.NamePen = value; }

        }
        //перечень элементов в маршруте
        public ObservableCollection<StringItem> ListGraphics
        {
            get { return Marshrut.NameGraphics; }
            set { Marshrut.NameGraphics = value; }
        }
        private Route Marshrut;
        private List<Pen> MPen;
        private List<ViewModelGraphics> MPatch;
        ViewModelMnemoCanvas _canva;

        public ViewModelRoute(Route Rout, ViewModelMnemoCanvas canva)
        {
           // timerSP.Start(); 
             
            Marshrut = Rout;
            MPen = new List<Pen>();
            MPatch = new List<ViewModelGraphics>();
            _canva = canva;
            setPen();
            setGraphics();
            SetValue(NameProperty, Marshrut.Name);
           SetValue(ValueNameProperty, Marshrut.ValueName);
           SetValue(ValuePosProperty, Marshrut.ValuePos);
          /* timerSP.Stop();
           var timeWork = timerSP.ElapsedMilliseconds;
           Debug.WriteLine("----ViewModelRoute------------------");
           Debug.WriteLine(timeWork);*/
            
        }

       // Stopwatch timerSP = new Stopwatch();
      //  Stopwatch timerSG = new Stopwatch();
        private void setPen()
        {
             
            foreach (var st in Marshrut.NamePen)
            {

              //  string str = st.Value;
//timerSP.Start();  
              //  var val = viewModelMnemoAnimPen.Instance.GetPen(str);

                MPen.Add(viewModelMnemoAnimPen.Instance.GetPen(st.Value));
              
//timerSP.Stop();
               // var timeWork = timerSP.ElapsedMilliseconds;
              //  Debug.WriteLine("----setPen------------------");
              //  Debug.WriteLine(timeWork);
            }
            
        }
        private void setGraphics()
        {

           // timerSG.Start();
            foreach (var st in Marshrut.NameGraphics)
            {


                //ecnfyjdrf state
              var gp = _canva.GetPatch(st.Value) as ViewModelGraphics;
              if (gp == null) MessageBox.Show(String.Format("Не найден элемент с именем {0}", st.Value));
              else
              {
                  for (int i = 0; i < MPen.Count; i++)
                      gp.AddMarshrut(new StatePatch(Marshrut.Name, MPen[i], i));
                  gp.SetState(0, this.Name);
                  MPatch.Add(gp);
              }
                
            }
         //   timerSG.Stop();
          //  var timeWork = timerSG.ElapsedMilliseconds;
          //  Debug.WriteLine("----setGraphics------------------");
         //   Debug.WriteLine(timeWork);

        }

        public void AddPen(string NamePen)
        {
          //  if (!Marshrut.NamePen.Contains<string>(NamePen))
            {

              // Marshrut.NamePen.Add(NamePen);
                StringItem sti = new StringItem();
                sti.Value = NamePen;

                ListPen.Add(sti);
                MPen.Add(viewModelMnemoAnimPen.Instance.GetPen(NamePen));
                 foreach (var mp in MPatch)
                     mp.AddMarshrut(new StatePatch(this.Marshrut.Name,viewModelMnemoAnimPen.Instance.GetPen(NamePen),MPen.Count-1));
            }
        }
        public void ReplaceNamePen(int state,string namePen)
        {
            StringItem sti = new StringItem();
            sti.Value = namePen;
            Marshrut.NamePen[state] = sti;
            MPen[state] = viewModelMnemoAnimPen.Instance.GetPen(namePen);
            foreach (var mp in MPatch)
                mp.ReplaceMarsrut(state, MPen[state], this.Marshrut.Name);



        }
        public void DeleteNamePen(int state)
        {

            Marshrut.NamePen.RemoveAt(state);
                MPen.RemoveAt(state);
                foreach (var mp in MPatch)
                {
                   
                    mp.deleteState();
                    for (int i = 0; i < MPen.Count; i++)
                        mp.AddMarshrut(new StatePatch(Marshrut.Name, MPen[i], i));
 if (mp.TVisual==1)
     ((ViewModelPatch)mp).PPen = ((ViewModelPatch)mp).CurPen; //разобраться
                }

               /* foreach (var mp in MPatch)
                    mp.deleteState(state, Marshrut.Name);*/

        }
        public void AddGraphics(string NameG)
        {
            StringItem Name = new StringItem();
            Name.Value = NameG;

            if (!Marshrut.NameGraphics.Contains<StringItem>(Name))
            {
                Marshrut.NameGraphics.Add(Name);
              
                var gp = _canva.GetPatch(Name.Value) as ViewModelGraphics;
                for (int i = 0; i < MPen.Count; i++)
                    gp.AddMarshrut(new StatePatch(Marshrut.Name, MPen[i], i));
                MPatch.Add(gp);
            }
        }
        public void ReplaceGraphics(string OldNameG, string NewNameG)
        {
            //сейчас не работает нельзя создавать новый si
            StringItem OldName = new StringItem();
            OldName.Value = OldNameG;
            StringItem NewName = new StringItem();
            NewName.Value = NewNameG;

            Marshrut.NameGraphics.Remove(OldName);

            var g = _canva.GetPatch(OldName.Value) as ViewModelGraphics; ;
          
           // for (int i = 0; i < MPen.Count; i++)
               g.deleteMarshrut(Marshrut.Name);
            MPatch.Remove(g);
           
            Marshrut.NameGraphics.Add(NewName);

            var gp = _canva.GetPatch(NewName.Value) as ViewModelGraphics; ;
            for (int i = 0; i < MPen.Count; i++)
                gp.AddMarshrut(new StatePatch(Marshrut.Name, MPen[i], i));
            MPatch.Add(gp);

        }
        public void DeleteGraphics(string OldNameG)
        {
            StringItem OldName = new StringItem();
            OldName.Value = OldNameG;
           
            foreach (StringItem sti in Marshrut.NameGraphics)
            {
                if (sti.Value == OldNameG)
                    OldName = sti;

            }

            Marshrut.NameGraphics.Remove(OldName);
          //  ListGraphics.Remove(OldName);
            var g = _canva.GetPatch(OldName.Value) as ViewModelGraphics; ;
            if (g != null)
            {

                g.deleteMarshrut(Marshrut.Name);
                MPatch.Remove(g);
            }
           

        }

        /// <summary>
        /// 
        /// </summary>
        public void deleteMarshrut()
        {
            List<string> lst = new List<string>();
            foreach (var mp in MPatch)
            {
               lst.Add(mp.Name);
            }
            foreach (var st in lst)
                DeleteGraphics(st);
               

        }




        private void SetState(string st)
        {
            var gp = _canva.GetPatch(st) as ViewModelGraphics; ;
            for (int i = 0; i < MPen.Count; i++)
                gp.AddMarshrut(new StatePatch(Marshrut.Name, MPen[i], i));
            MPatch.Add(gp);
        }

        #region public property
        public Route Marshruts
        {
            get { return Marshrut; }
        }


       
     
       
        #endregion

       

      

    }
}
