using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using PatchMnemoLib.Model;
using PatchMnemoLib.ViewModelMElement;
using PatchMnemoLib.ViewModel;

using System.Windows.Data;
using System.Collections.ObjectModel;
using ValueModel.BaseType;
using ValueModel.BaseModel;

namespace PatchMnemoLib.ViewModelRout
{
   public class ViewModelVisiblir : DependencyObject
    {
       private Route Marshrut;
       private List<ViewModelGraphics> MPatch;
       ViewModelMnemoCanvas _canva;
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
           DependencyProperty.Register("ValueInt", typeof(int), typeof(ViewModelVisiblir), new PropertyMetadata(-1, OnValChange));

       public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(ViewModelVisiblir), new PropertyMetadata("", OnNameChange));
       public static readonly DependencyProperty ValueNameProperty = DependencyProperty.Register("ValueName", typeof(string), typeof(ViewModelVisiblir), new PropertyMetadata("", OnVNameChange));
       public static readonly DependencyProperty ValuePosProperty = DependencyProperty.Register("ValuePos", typeof(int), typeof(ViewModelVisiblir), new PropertyMetadata(-1, OnValuePosChange));


       private static void OnValChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
       {
          var com = d as ViewModelVisiblir;
           int val = (int)e.NewValue;
           if (val==1)
           foreach (var pth in com.MPatch)
           {
               pth.VisiblelGrpaphics=false;

           }
           if (val==0)
           {
               foreach (var pth in com.MPatch)
          
               pth.VisiblelGrpaphics=true;;

         
           }

       }

       private static void OnNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
       {
           var com = d as ViewModelVisiblir;
           com.Marshrut.Name = e.NewValue.ToString();
       }




       private static void OnVNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
       {
           var com = d as ViewModelVisiblir;
           com.Marshrut.ValueName = e.NewValue.ToString();
           com.IsInitValueFlag1 = true;
           if (com.IsInitValueFlag2) com.SetBnd(com.Marshrut.ValueName, com.Marshrut.ValuePos);
       }


       private static void OnValuePosChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
       {
           var com = d as ViewModelVisiblir;
           com.Marshrut.ValuePos = (int)e.NewValue;
           com.IsInitValueFlag2 = true;
           if (com.IsInitValueFlag1) com.SetBnd(com.Marshrut.ValueName, com.Marshrut.ValuePos);
       }

       private void SetBnd(string varName, int pos)
       {

           var val = ViewModelVariableList.Instance.GetVariable(varName);
           IntValue v = ((BitIntVar)val.VarM).ValState[pos];
           BindingOperations.SetBinding(this, ViewModelVisiblir.ValueIntProperty, new Binding { Source = v, Path = new PropertyPath("ValueState") });
       }



       #endregion




       public ViewModelVisiblir(Route Rout, ViewModelMnemoCanvas canva)
        {
          
             
            Marshrut = Rout;
            Marshrut.TypRoute = 3;
            MPatch = new List<ViewModelGraphics>();
            _canva = canva;
          
           setGraphics();
           SetValue(NameProperty, Marshrut.Name);
           SetValue(ValueNameProperty, Marshrut.ValueName);
           SetValue(ValuePosProperty, Marshrut.ValuePos);
         
            
        }


       //перечень элементов в маршруте
       public ObservableCollection<StringItem> ListGraphics
       {
           get { return Marshrut.NameGraphics; }
           set { Marshrut.NameGraphics = value; }
       }
       private void setGraphics()
       {

           
           foreach (var st in Marshrut.NameGraphics)
           {


               //ecnfyjdrf state
               var gp = _canva.GetPatch(st.Value) as ViewModelGraphics;
               if (gp == null) MessageBox.Show(String.Format("Не найден элемент с именем {0}", st.Value));
               else
               {
                 
                   MPatch.Add(gp);
               }

           }
          
       }
       public void AddGraphics(string NameG)
       {
           StringItem Name = new StringItem();
           Name.Value = NameG;

           if (!Marshrut.NameGraphics.Contains<StringItem>(Name))
           {
               Marshrut.NameGraphics.Add(Name);

               var gp = _canva.GetPatch(Name.Value) as ViewModelGraphics;
               
               MPatch.Add(gp);
           }
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

       public Route Marshruts
       {
           get { return Marshrut; }
       }

    }
}
