using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Diagnostics;

namespace PatchMnemoLib
{
    public class PathMnemo : GraphicsBase
    {
        private Brush _br = Brushes.Transparent;
        private Pen _pen = new Pen(Brushes.Black, 1);

        private string _data = "";
        private double _ttx = 0d;
        private double _tty = 0d;
       

        public override void DrawGraphics(string data, double ttx, double tty)
        {
            TranslateTransform tt = new TranslateTransform(ttx, tty);
            _data = data;
            _ttx = ttx;
            _tty = tty;
            initDraw = true;
            this.Data = _data;
            X = _ttx;
            Y = _tty;



            using (DrawingContext dc = this.RenderOpen())
            {
                dc.PushTransform(tt);
                dc.DrawGeometry(_br, graphicsPen, Geometry.Parse(Data));
                dc.Pop();

            }
        }
        public override void ReDrawGraphics()
        {
            if (!initDraw) Debug.WriteLine("redraw до инициализации рисования");
            TranslateTransform tt = new TranslateTransform(_ttx, _tty);
            using (DrawingContext dc = this.RenderOpen())
            {
                dc.PushTransform(tt);
                dc.DrawGeometry(_br, graphicsPen, Geometry.Parse(Data));
                dc.Pop();

            }
        }

    }
}
