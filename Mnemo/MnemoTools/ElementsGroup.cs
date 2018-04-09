using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Windows.Media;

namespace MnemoTools
{
     [Serializable]
    public class ElementsGroup: DependencyObject, INotifyPropertyChanged
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

        private string _NameNodes = string.Empty;
        private string _NodesPenD = string.Empty;
        private string _NodesPenA = string.Empty;
        private string _NodesPenL = string.Empty;
        private string _NodesPenR = string.Empty;

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
                if (value == _NodesPenD) return;
                _NodesPenD = value;
                OnPropertyChanged("NodesPenD");

            }
        }
        public string NodesPenA
        {
            get { return _NodesPenA; }
            set
            {
                if (value == _NodesPenA) return;
                _NodesPenA = value;
                OnPropertyChanged("NodesPenA");
            }
        }
        public string NodesPenL
        {
            get { return _NodesPenL; }
            set
            {
                if (value == _NodesPenL) return;
                _NodesPenL = value;
                OnPropertyChanged("NodesPenL");
            }
        }
        public string NodesPenR
        {
            get { return _NodesPenR; }
            set
            {
                if (value == _NodesPenR) return;
                _NodesPenR = value;
                OnPropertyChanged("NodesPenR");
            }
        }
        /*  [XmlIgnore]
       public static readonly DependencyProperty ValProperty = DependencyProperty.Register(
       "Val", typeof(int), typeof(ElementsGroup), new PropertyMetadata(-1, OnValChange));
        [XmlIgnore]
        public int Val
        {
            get { return (int)GetValue(ValProperty); }
            set { SetValue(ValProperty, value); }
        }*/
        [XmlIgnore]
        public static readonly DependencyProperty PenDProperty = DependencyProperty.Register(
       "PenD", typeof(Pen), typeof(ElementsGroup));
        [XmlIgnore]
        public Pen PenD
        {
            get { return (Pen)GetValue(PenDProperty); }
            set { SetValue(PenDProperty, value); }
        }

        [XmlIgnore]
        public static readonly DependencyProperty PenAProperty = DependencyProperty.Register(
       "PenA", typeof(Pen), typeof(ElementsGroup));
        [XmlIgnore]
        public Pen PenA
        {
            get { return (Pen)GetValue(PenAProperty); }
            set { SetValue(PenAProperty, value); }
        }

        [XmlIgnore]
        public static readonly DependencyProperty PenLProperty = DependencyProperty.Register(
       "PenL", typeof(Pen), typeof(ElementsGroup));
        [XmlIgnore]
        public Pen PenL
        {
            get { return (Pen)GetValue(PenLProperty); }
            set { SetValue(PenLProperty, value); }
        }

        [XmlIgnore]
        public static readonly DependencyProperty PenRProperty = DependencyProperty.Register(
       "PenR", typeof(Pen), typeof(ElementsGroup));
        [XmlIgnore]
        public Pen PenR
        {
            get { return (Pen)GetValue(PenRProperty); }
            set { SetValue(PenRProperty, value); }
        }
    }
}
