using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Windows.Media;

namespace MnemoTools
{
     [Serializable]
    public abstract class MnemoBaseElement : INotifyPropertyChanged
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
        private Pen _penElement;
        private string _name;       
        private Dictionary<string, int> Ststes = new Dictionary<string, int>();
        
        
        public string NameElement
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// текущее состояние элемента в маршруте
        /// </summary>
        [XmlIgnore]
        public int StCur
        {
            get
            {
                bool al = false;
                bool lr = false;
                bool rr = false;
                foreach (int v in Ststes.Values)
                {
                    if (v == 1) al = true;
                    if (v == 2) lr = true;
                    if (v == 3) rr = true;
                }
                if (lr) return 2;
                if (rr) return 3;
                if (al) return 1;

                return 0;


            }

        }
        /// <summary>
        /// Добовляем состояние в словарь состояний
        /// происходит при добавлениее елемента в новый мвршрут
        /// </summary>
        /// <param name="NodeName"></param>
        public void AddNewState(string NodeName)
        {
            Ststes.Add(NodeName, 0);
        }
        /// <summary>
        /// Удаляем состояние изспмсков состояния
        /// </summary>
        /// <param name="nodeName"></param>
        public void RemovNewState(string nodeName)
        {
            Ststes.Remove(nodeName);
        }
        /// <summary>
        /// Устанавливаем состояние элемента из маршрута
        /// </summary>
        /// <param name="node">имя маршрута</param>
        /// <param name="val">состояние</param>
        public void SetState(string node, int val)
        {
            Ststes[node] = val;
        }
        [XmlIgnore]
        public Pen PenElement
        {
            get { return _penElement; }
            set
            {
                _penElement = value;
                SetNewPen(_penElement);
               // Graphics.ObjectPen = _penElement;
            }
        }

        public abstract void SetNewPen(Pen Val);

    }
}
