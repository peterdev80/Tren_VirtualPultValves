using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Animation;
using System.Windows;
using System.ComponentModel;

namespace MnemoTools
{
    [Serializable]
    public class MnemoAnimation : INotifyPropertyChanged
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
   
        private double _tovalue;
        double _Dooration;
        double _to;
        double _by;
        string _name;
        private DoubleAnimation _AnimationS;
        public MnemoAnimation()
        {
            _AnimationS = new DoubleAnimation();

        }
        public MnemoAnimation(double tovalue, double Dooration, double to, double by, string Nam)
        {

            _tovalue = tovalue;
            _Dooration = Dooration;
            _to = to;
            _by = by;
            _name = Nam;
            CreateAnimation();

        }
        public DoubleAnimation AnimationS
        {
            get { return _AnimationS; }
        }

        #region property
        /// <summary>
        /// Наименование анимации ключевое поле
        /// </summary>
        public String Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged("Name");
                CreateAnimation();
            }
        }
        public double ToValue
        {
            get { return _tovalue; }
            set 
            { 
                if (value == _tovalue) return;
                _tovalue = value;
                CreateAnimation();
            }
        }
        public Double Dooration
        {
            get { return _Dooration; }
            set 
            {
                if (value == _Dooration) return;
                _Dooration = value;
                CreateAnimation();
            }
        }
        public double To
        {
            get { return _to; }
            set 
            {
                if (value == _to) return;
                _to = value;
                CreateAnimation();
            }
        }
        public double By
        {
            get { return _by; }
            set 
            {
                if (value == _by) return;
                _by = value;
                CreateAnimation();
            }
        }
        #endregion
        
        #region private function
        private void CreateAnimation()
        {
            _AnimationS = new DoubleAnimation(To,ToValue, new Duration(TimeSpan.FromSeconds(Dooration)));
            _AnimationS.RepeatBehavior = RepeatBehavior.Forever;
            //_AnimationS.To = To;
            _AnimationS.By = By;
            Timeline.SetDesiredFrameRate(_AnimationS, 30);
            OnPropertyChanged("AnimationS");
        }
        #endregion
    }
}
