using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Windows.Media;
using System.Collections.Generic;

namespace MnemoTools
{
   public class MnemoPathNodes: DependencyObject, INotifyPropertyChanged
    {
 #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {


            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members
        
        private string _NameNodes=string.Empty;
        private string _NodesPenD=string.Empty;
        private string _NodesPenA=string.Empty;
        private string _NodesPenL=string.Empty;
        private string _NodesPenR = string.Empty;

       

        private ObservableCollection<MnemoPatchElement> _nodeElements = new ObservableCollection<MnemoPatchElement>();//колекция элементов маршрута

        public ObservableCollection<MnemoPatchElement> NameElement
        {
            get { return _nodeElements; }
            set
            {
                _nodeElements = value;
            }
        }

       

        public MnemoPathNodes()
        {
           // NameElement.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(NameElement_CollectionChanged);

        }

     /*   void NameElement_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var x = sender as FrameworkElement;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (string np in e.NewItems)
                {

                    MnemoPatchElement be = x.FindResource(np) as MnemoPatchElement;
                    NameElement.Add(be);
                    be.AddNewState(this.NameNodes);
                }
            }*/
            
          /*  if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach(MnemoPatchElement be in e.NewItems)
              
                be.AddNewState(this.NameNodes);
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (MnemoPatchElement be in e.OldItems)
                be.RemovNewState(this.NameNodes);
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (MnemoPatchElement be in e.NewItems)

                    be.AddNewState(this.NameNodes);
                foreach (MnemoPatchElement be in e.OldItems)
                    be.RemovNewState(this.NameNodes);
            }
            
        }  */
       
  

      
        public string NameNodes
        {
            get { return _NameNodes; }
            set { _NameNodes = value; OnPropertyChanged("NameNodes"); }
        }
        public string NodesPenD
        {
            get { return _NodesPenD; }
            set
            {
               // if (value == _NodesPenD) return;
                _NodesPenD = value;             
                OnPropertyChanged("NodesPenD");
                
            }
        }
        public string NodesPenA
        {
            get { return _NodesPenA; }
            set
            {
               // if (value == _NodesPenA) return;
                _NodesPenA = value;              
                OnPropertyChanged("NodesPenA");
            }
        }
        public string NodesPenL
        {
            get { return _NodesPenL; }
            set
            {
               // if (value == _NodesPenL) return;
                _NodesPenL = value;             
                OnPropertyChanged("NodesPenL");
            }
        }
        public string NodesPenR
        {
            get { return _NodesPenR; }
            set
            {
               // if (value == _NodesPenR) return;
                _NodesPenR = value;               
                OnPropertyChanged("NodesPenR");
            }
        }


        public void FinalLoaded()
        {
            OnPropertyChanged("NodesPenD");
            OnPropertyChanged("NodesPenA");
            OnPropertyChanged("NodesPenL");
            OnPropertyChanged("NodesPenR");
            foreach (MnemoPatchElement el in _nodeElements)
            {

                el.SetState(NameNodes, 0);
            }
        }

        [XmlIgnore]
        public static readonly DependencyProperty ValProperty = DependencyProperty.Register(
       "Val", typeof(int), typeof(MnemoPathNodes), new PropertyMetadata(-1, OnValChange));
        [XmlIgnore]
        public int Val
        {
            get { return (int)GetValue(ValProperty); }
            set { SetValue(ValProperty, value); }
        }

        [XmlIgnore]
        public static readonly DependencyProperty PenDProperty = DependencyProperty.Register(
       "PenD", typeof(Pen), typeof(MnemoPathNodes));
        [XmlIgnore]
        public Pen PenD
        {
            get { return (Pen)GetValue(PenDProperty); }
            set { SetValue(PenDProperty, value); }
        }

        [XmlIgnore]
        public static readonly DependencyProperty PenAProperty = DependencyProperty.Register(
       "PenA", typeof(Pen), typeof(MnemoPathNodes));
        [XmlIgnore]
        public Pen PenA
        {
            get { return (Pen)GetValue(PenAProperty); }
            set { SetValue(PenAProperty, value); }
        }

        [XmlIgnore]
        public static readonly DependencyProperty PenLProperty = DependencyProperty.Register(
       "PenL", typeof(Pen), typeof(MnemoPathNodes));
        [XmlIgnore]
        public Pen PenL
        {
            get { return (Pen)GetValue(PenLProperty); }
            set { SetValue(PenLProperty, value); }
        }

        [XmlIgnore]
        public static readonly DependencyProperty PenRProperty = DependencyProperty.Register(
       "PenR", typeof(Pen), typeof(MnemoPathNodes));
        [XmlIgnore]
        public Pen PenR
        {
            get { return (Pen)GetValue(PenRProperty); }
            set { SetValue(PenRProperty, value); }
        }


        public void AddNodeElement(MnemoPatchElement ne)
        {
            ne.AddNewState(this.NameNodes);
            _nodeElements.Add(ne);

        }
        public void RemoveNodeElement(MnemoPatchElement ne)
        {
            ne.RemovNewState(this.NameNodes);
            _nodeElements.Remove(ne);


        }
  

    
     

#region  StaticFunction
         private static void OnValChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MnemoPathNodes con = d as MnemoPathNodes;
             int val=(int)e.NewValue;
             foreach (var mn in con._nodeElements)
             {
                 mn.SetState(con.NameNodes,val);
           
                 if (mn.StCur == 0)
                     mn.PenElement = con.PenD;
                 if (mn.StCur == 1)
                     mn.PenElement = con.PenA;
                 if (mn.StCur == 2)
                 {
                    /* Pen cp = new Pen();

                     cp.Brush = new SolidColorBrush(Colors.Black);
                     cp.Thickness = 2;
                    
                     {
                         var dstyle = DashStyles.Dash;
                        
                       
                             List<double> dlist = new List<double>();
                             dlist.Add(1);
                             dlist.Add(4);
                             dstyle = new DashStyle(dlist, 0);
                             cp.DashStyle = dstyle;
                       //  cp.DashStyle = dstyle.Clone();
                       //  cp.DashStyle.BeginAnimation(DashStyle.OffsetProperty, PenAnimate);
                     }


                     mn.PenElement = cp;*/
                     mn.PenElement = con.PenL;
                 }
                 if (mn.StCur == 3)
                     mn.PenElement = con.PenR;

             }

            
            

        }
#endregion


    }
}
