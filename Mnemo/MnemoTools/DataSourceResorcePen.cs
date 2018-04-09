using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Media;

namespace MnemoTools
{
     [Serializable]
   public class DataSourceResorcePen
   {
       ObservableCollection<MnemoAnimation> _ListAnim;
       ObservableCollection<MnemoPen> _ListPen;

       public DataSourceResorcePen()
       {
           _ListAnim = new ObservableCollection<MnemoAnimation>();
           _ListPen = new ObservableCollection<MnemoPen>();
          

       }
       public void AddAnim(MnemoAnimation ma)
       {
           ListAnim.Add(ma);
       }
       public void AddPen(MnemoPen mp)
       {
           mp.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mp_PropertyChanged);
           MnemoAnimation sa=new MnemoAnimation();
           SetBindingAP(mp);
           ListPenProperty.Add(mp);
       }

       void mp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
       { 
           MnemoPen pen = sender as MnemoPen;
           if (e.PropertyName == "AnimateName")
           {             
               SetBindingAP(pen);                
           }
           if (e.PropertyName == "Animate")
           {
               if (!pen.Animate) BindingOperations.ClearBinding(pen, MnemoPen.PenAnimateProperty);
           }

       }


       private void SetBindingAP(MnemoPen pen)
       {
           foreach (var ma in ListAnim)
               if (ma.Name == pen.AnimateName)
               {
                   Binding myBinding = new Binding("AnimationS");
                   myBinding.Source = ma;
                   //BindingOperations.ClearBinding(pen, MnemoPen.PenAnimateProperty);
                   BindingOperations.SetBinding(pen, MnemoPen.PenAnimateProperty, myBinding);
               }
       }
       public void ReEventPen()
       {
           foreach (var pen in ListPenProperty)
           {
             // pen.PropertyChanged -= mp_PropertyChanged;
               pen.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mp_PropertyChanged);
           }
       }
       public void RebuildPen()
       {
           foreach (var pen in ListPenProperty)
           {
              
               SetBindingAP(pen);

           }

       }
       public ObservableCollection<MnemoAnimation> ListAnim
       {
           get { return _ListAnim; }
           set { _ListAnim = value; }
       }
       public ObservableCollection<MnemoPen> ListPenProperty
       {
           get
           {
               return _ListPen;
           }
           set
           {
               _ListPen = value;

           }
       }

   }
}
