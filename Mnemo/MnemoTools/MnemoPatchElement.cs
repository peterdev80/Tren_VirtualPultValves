using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Data;

namespace MnemoTools
{
    public class MnemoPatchElement : DependencyObject
    {
        public MnemoPatchElement()
        {
        }
       
        private Pen _penElement;
        private string _name;
        private Dictionary<string, int> Ststes = new Dictionary<string, int>();

        public bool FillPen { get; set; }
        public string NameElement
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// текущее состояние элемента в маршруте
        /// </summary>
        
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
        public static readonly DependencyProperty GPatchProperty = DependencyProperty.Register(
     "GPatch", typeof(Path), typeof(MnemoPatchElement),new PropertyMetadata(null,OnPathChange));

        public Path GPatch
        {
            get { return (Path)GetValue(GPatchProperty); }
            set { SetValue(GPatchProperty, value); }
        }
       

        private void SetNewPen(Pen Val)
        {
            if (Val != null)
                if (!FillPen)
                {
                    
                    GPatch.Stroke = Val.Brush;
                    GPatch.StrokeDashArray = Val.DashStyle.Dashes;   
              if (Val.DashStyle.Dashes.Count>0)
                    BindingOperations.SetBinding(GPatch, Path.StrokeDashOffsetProperty, new Binding { Source = Val.DashStyle, Path = new PropertyPath(DashStyle.OffsetProperty) });
                   
                }
                else
                    GPatch.Fill = Val.Brush;

        }
        private static void OnPathChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MnemoPatchElement mp = d as MnemoPatchElement;
        }

    }
}
