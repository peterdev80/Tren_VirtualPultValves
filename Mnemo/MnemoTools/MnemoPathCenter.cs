using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace MnemoTools
{
    public class MnemoPathCenter : FrameworkElement
    {
        MnemoPensColect _pc;
        private ObservableCollection<MnemoPatchElement> _allElement = new ObservableCollection<MnemoPatchElement>();   
       
    
       
        public ObservableCollection<MnemoPatchElement> AllElement
         {
             get { return _allElement; }
             set { AllElement = value; }
         }

        /// <summary>
        /// Добовляем элементы в путь 
        /// </summary>
        /// <param name="lsname">список имен элементов входящих в ноде</param>
        /// <param name="nodeName">имя узла</param>

         public void AddNodes(List<string> lsname, string nodeName)
         {
             MnemoPathNodes selectNode=new MnemoPathNodes();
             foreach (MnemoPathNodes node in Marshrut.Where(p=>p.NameNodes==nodeName))
             {                
                 selectNode = node;
             }
             selectNode.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(val_PropertyChanged);
             selectNode.FinalLoaded();
                 
             
             for (int i = 0; i < AllElement.Count; i++)
             {
                 foreach (string nam in lsname)
                 {
                     if (nam == AllElement[i].NameElement)
                     {
                         AllElement[i].FillPen = false;
                         selectNode.AddNodeElement(AllElement[i]);

                     }
                 }
             }

         }
         public void AddNodesB(List<string> lsname, string nodeName)
         {
             MnemoPathNodes selectNode = new MnemoPathNodes();
             foreach (MnemoPathNodes node in Marshrut.Where(p => p.NameNodes == nodeName))
             {
                 selectNode = node;
             }
             selectNode.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(val_PropertyChanged);
             selectNode.FinalLoaded();


             for (int i = 0; i < AllElement.Count; i++)
             {
                 foreach (string nam in lsname)
                 {
                     if (nam == AllElement[i].NameElement)
                     {
                         AllElement[i].FillPen = true;
                         selectNode.AddNodeElement((MnemoPatchElement)AllElement[i]);

                     }
                 }
             }

         }


       

         public MnemoPathCenter()
        {
            Marshrut = new ObservableCollection<MnemoPathNodes>();
            _pc = new MnemoPensColect();
         //   AllElement.CollectionChanged += new NotifyCollectionChangedEventHandler(AllElement_CollectionChanged);
          //  Marshrut.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Marshrut_CollectionChanged);
        }



         public MnemoPathNodes GetNodes(string NameNodes)
         {
             var Nodes = Marshrut.Where(p => p.NameNodes == NameNodes);
             if (Nodes.Count<MnemoPathNodes>() > 0) return Nodes.First<MnemoPathNodes>();
             MessageBox.Show(String.Format("Элемент с именем {0} не найден ", NameNodes));
             return null;
         }

         public static readonly DependencyProperty DCanvasProperty = DependencyProperty.Register(
        "DCanvas", typeof(Canvas), typeof(MnemoPathCenter), new PropertyMetadata(null, OnDCanvasChange));

         public Canvas DCanvas
         {
             get { return (Canvas)GetValue(DCanvasProperty); }
             set { SetValue(DCanvasProperty, value); }
         }
        
       
        public ObservableCollection<MnemoPathNodes> Marshrut { get; set; }
        public static readonly DependencyProperty PenPatchProperty = DependencyProperty.Register(
             "PenPatch", typeof(string), typeof(MnemoPathCenter), new PropertyMetadata(string.Empty, OnPenPatchChange));

        public string PenPatch
        {
            get { return (string)GetValue(PenPatchProperty); }
            set { SetValue(PenPatchProperty, value); }
        }
        void val_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            MnemoPathNodes mnodes = (MnemoPathNodes)sender;
            string newvalue = string.Empty;
            DependencyProperty prop = MnemoPathNodes.PenDProperty;
            switch (e.PropertyName)
            {
                case "NodesPenD": prop = MnemoPathNodes.PenDProperty; newvalue = mnodes.NodesPenD; break;
                case "NodesPenA": prop = MnemoPathNodes.PenAProperty; newvalue = mnodes.NodesPenA; break;
                case "NodesPenL": prop = MnemoPathNodes.PenLProperty; newvalue = mnodes.NodesPenL; break;
                case "NodesPenR": prop = MnemoPathNodes.PenRProperty; newvalue = mnodes.NodesPenR; break;
            }
            if (_pc != null)
                foreach (MnemoPen p in _pc.ResourcePen.ListPenProperty)
                {
                    // BindingOperations.ClearBinding(this, prop);
                    if (p.PenName == newvalue)
                        BindingOperations.SetBinding(mnodes, prop, new Binding { Source = p, Path = new PropertyPath(MnemoPen.CurPenProperty) });

                }


        }
        private static void OnDCanvasChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MnemoPathCenter con = d as MnemoPathCenter;
            con.ReadAllElement((Canvas)e.NewValue);


        }
        private void ReadAllElement(Canvas celement)
        {
            foreach (var ob in celement.Children)
            {
                if (ob.GetType() == typeof(Path))
                {

                    MnemoPatchElement ne = new MnemoPatchElement();
                    ne.GPatch = ob as Path;
                    ne.NameElement = ne.GPatch.Name;
                    AllElement.Add(ne);

                }


            }
        }
    
        private static void OnPenPatchChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MnemoPathCenter con = d as MnemoPathCenter;
            con._pc.LoadResource(e.NewValue.ToString());

        }
    }
}
