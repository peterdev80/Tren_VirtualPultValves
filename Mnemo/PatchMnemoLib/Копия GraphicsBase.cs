using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace PatchMnemoLib
{
    public abstract class GraphicsBase : DrawingVisual
    {
        private int objectId;
       // private double _graphicsLineWidth;
       // private Color _graphicsObjectColor;
        protected bool initDraw;
        private Pen _graphicsPen;
        private TranslateTransform _sdvig;
        private string _data;

        protected GraphicsBase()
        {
            objectId = this.GetHashCode();
            _sdvig = new TranslateTransform(0d, 0d);
            _graphicsPen = new Pen(Brushes.Black, 1);
        }
        protected GraphicsBase(string _name):this()
        {
            Name = _name;
        }

        public Pen graphicsPen
        {
            get { return _graphicsPen; }
            set { _graphicsPen = value; 
                if (initDraw)
                ReDrawGraphics(); }
        }
        public String Data
        {
            get { return _data; }
            set { _data = value;
            if (initDraw) ReDrawGraphics();
            }
        }
        public double X { get; set; }
        public double Y { get; set; }
        public TranslateTransform Sdvig
        {
            get { return _sdvig; }
            set { _sdvig = value;
            if (initDraw) ReDrawGraphics();
            }
        }
        public string Name { get;set;}

        public abstract void DrawGraphics(string data, double ttx, double tty);
        public abstract void ReDrawGraphics();
        

    }
}
