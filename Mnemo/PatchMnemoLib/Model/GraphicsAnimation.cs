using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media.Animation;
using System.Windows;
using System.Xml.Serialization;

namespace PatchMnemoLib.Model
{
    [Serializable]
    public class GraphicsAnimation 
    {
      

        private double _tovalue;
        double _Dooration;
        double _to;
        double _by;
        string _name;
       
      
        
        public GraphicsAnimation()
        {
            

        }
        public GraphicsAnimation(double tovalue, double Dooration, double to, double by, string Nam)
        {

            _tovalue = tovalue;
            _Dooration = Dooration;
            _to = to;
            _by = by;
            _name = Nam;
           

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
               
               
            }
        }
        public double ToValue
        {
            get { return _tovalue; }
            set
            {
                if (value == _tovalue) return;
                _tovalue = value;
               
            }
        }
        public Double Dooration
        {
            get { return _Dooration; }
            set
            {
                if (value == _Dooration) return;
                _Dooration = value;
                
            }
        }
        public double To
        {
            get { return _to; }
            set
            {
                if (value == _to) return;
                _to = value;
               
            }
        }
        public double By
        {
            get { return _by; }
            set
            {
                if (value == _by) return;
                _by = value;
               
            }
        }
        [XmlIgnore]
        public DoubleAnimation AnimationS
        {
            get;
            set;
        }
        #endregion

      
    }
}
