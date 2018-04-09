using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Windows.Media;
using System.Windows;
using System.Globalization;
using PatchMnemoLib.ViewModel;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace PatchMnemoLib.ViewModelMElement
{
    public abstract class ViewModelGraphics : ViewModelBase
    {
       
        protected VisualBase _patch;
        protected StatesPatch _state;
        protected string N_Name;
        private ViewModelMnemoCanvas _mc;
        #region Constructor
        public ViewModelGraphics()
        {
            _mc = new ViewModelMnemoCanvas();
          //  _patch = new VisualBase();
            _state = new StatesPatch();
           
        }
        /// <summary>
        /// Конструктор для создания новой графики
        /// </summary>
        /// <param name="mc">Канва</param>
        public ViewModelGraphics(ViewModelMnemoCanvas mc)
        {
             Random rnd = new Random();
            _mc = mc;
            N_Name = MCanvas.Canva.VisualCount + "_" + rnd.Next(MCanvas.Canva.VisualCount);
           /* GraphicsPatch gp = new GraphicsPatch();
            this._patch = gp;
            _state = new StatesPatch();
            gp.Name = "l" + MCanvas.Canva.VisualCount;
            MCanvas.Canva.AddVisual(gp);*/
          
                
        }
          /// <summary>
        /// конструктор из уже заданной графики
        /// </summary>
        /// <param name="mc">Канва для рисования</param>
        /// <param name="gp">Графика</param>
        public ViewModelGraphics(ViewModelMnemoCanvas mc, VisualBase gp)
        {
            _patch = gp;
            _mc = mc;
            _state = new StatesPatch();

            ReDraw(ReDrawType);
        }
        #endregion

         public ViewModelMnemoCanvas MCanvas
        {
            get { return _mc; }
            set
            { _mc = value;

            this.OnPropertyChanged("MCanvas");
              
            }
        }
         public string Name
         {
             get { return _patch.Name; }
             set { _patch.Name = value; this.OnPropertyChanged("Name"); }
         }
         public double TransleteX
         {
             get { return _patch.TransX; }
             set
             {
                 _patch.TransX = value;
                 // _tt = new TranslateTransform(_patch.TransX, _patch.TransY);

                 this.OnPropertyChanged("TransleteX");
                 ReDraw(ReDrawType);
             }
         }
         public double TransleteY
         {
             get { return _patch.TransY; }
             set
             {
                 _patch.TransY = value;
                 //  _tt = new TranslateTransform(_patch.TransX, _patch.TransY);

                 this.OnPropertyChanged("TransleteY");
                 ReDraw(ReDrawType);
             }
         }

         public double ScaleX
         {
             get { return _patch.ScaleX; }
             set
             {
                 _patch.ScaleX = value;
                 // _st = new ScaleTransform(_patch.ScaleX, _patch.ScaleY, _patch.CentrX, _patch.CentrY);


                 this.OnPropertyChanged("ScaleX");
                 ReDraw(ReDrawType);

             }
         }
         public double ScaleY
         {
             get { return _patch.ScaleY; }
             set
             {
                 _patch.ScaleY = value;
                 // _st = new ScaleTransform(_patch.ScaleX, _patch.ScaleY, _patch.CentrX, _patch.CentrY);

                 this.OnPropertyChanged("ScaleY");
                 ReDraw(ReDrawType);

             }
         }
         public double RotateAngle
         {
             get { return _patch.RotateAngle; }
             set
             {
                 _patch.RotateAngle = value;
                 // _rt = new RotateTransform(_patch.RotateAngle, _patch.CentrX, _patch.CentrY);
                 this.OnPropertyChanged("RotateAngle");
                 ReDraw(ReDrawType);
             }
         }
         public double CentrX
         {
             get { return _patch.CentrX; }
             set
             {
                 _patch.CentrX = value;
                 this.OnPropertyChanged("CentrX");
                 RotateAngle = _patch.RotateAngle;
                 ScaleY = _patch.ScaleY;
             }
         }
         public double CentrY
         {
             get { return _patch.CentrY; }
             set
             {
                 _patch.CentrY = value;
                 this.OnPropertyChanged("CentrY");
                 RotateAngle = _patch.RotateAngle;
                 ScaleY = _patch.ScaleY;
             }
         }

         private bool _visg=true;
        /// <summary>
        /// Свойства для скрытия элемента
        /// 
        /// </summary>
         public bool VisiblelGrpaphics
         {
             get { return _visg; }
             set
             {
                 _visg = value;
                 OnPropertyChanged("VisiblelGrpaphics");
                 ReDraw(ReDrawType);
             }

         }


         public bool ReDrawType
         {
             get { return _patch.ReDrawType; }
             set { _patch.ReDrawType = value; this.OnPropertyChanged("ReDrawType"); }
         }
         public void ReDraw()
         {
           //  if (this.Name == "l222_69") Debug.WriteLine("*********************************************");
            MCanvas.DeleteVisual(this);
            if (VisiblelGrpaphics)
            {
                _patch.Draw();
                MCanvas.AddVisual(this);
            }





         }
         public void ReDraw(bool val)
         {
             if (val)
             {
                 int indexpos = 0;
                 for (int i = 0; i < MCanvas.AllPatch.Count; i++)
                 {
                     if (MCanvas.AllPatch[i].Name == this.Name) indexpos = i;
                 }


                 MCanvas.DeleteVisual(this);
                 if (VisiblelGrpaphics)
                 {
                     _patch.Draw();
                     MCanvas.InsertVisual(this, indexpos);
                 }
             }
             else ReDraw();

         }
         public void DeleteElement()
         {
             MCanvas.DeleteVisual(this);

         }
         public VisualBase GetGP()
         {
             return _patch;
         }
         public int TVisual
         {
             get { return _patch.TVisual; }
         }
        
        /// <summary>
        /// Замена кисти в маршруте
        /// </summary>
        /// <param name="st"></param>
        /// <param name="val"></param>
        /// <param name="name"></param>
         public virtual void ReplaceMarsrut(int st, Pen val, string name)
         {
             _state.ReplaceStatePen(name, st, val);
            /* PPen = _state.StateG.MPen;
             ReDraw();*/

         }
        
         public void AddMarshrut(StatePatch val)
         {
             _state.AddState(val);

         }
         //Удаление пера из маршрута
         public void deleteState()
         {

             _state = new StatesPatch();


         }
         public virtual void deleteMarshrut(string val)
         {
             _state.RemoveState(val);
            // PPen = new Pen(Brushes.Black, 2);
         }
         public virtual void SetState(int val, string name)
         {

             _state.SetState(val, name);
           //  PPen = _state.StateG.MPen;
         }
         public virtual void CopyMov(ViewModelGraphics val)
         {
             this.ScaleX = val.ScaleX;
             this.ScaleY = val.ScaleY;
             this.CentrX = val.CentrX;
             this.CentrY = val.CentrY;
             this.RotateAngle = val.RotateAngle;
             this.TransleteX = val.TransleteX;
             this.TransleteY = val.TransleteY;
             this.ReDrawType = val.ReDrawType;
             
         }

         /// <summary>
         /// возможно необходимо вынести в уневерсальные функции
         /// </summary>
         /// <returns></returns>
         public Point GetPoint(string data)
         {
             var tokens = Regex.Split(data, @"(?=[MZLHVCSQTAmzlhvcsqta])").Where(t => !string.IsNullOrEmpty(t));

             foreach (string remainingargs in tokens)
            {
                var fndBK = Regex.Split(remainingargs, @"[\d\s ,.-]").Where(t => !string.IsNullOrEmpty(t));
                int pr = 0;
                string Litera = "";
                foreach (string bk in fndBK)
                {
                    pr++;
                    Litera = bk;

                }
                if (pr > 1) new Exception("строка не верно разобранна");
                string argSeparators = @"[\s," + Litera + "]"; // discard whitespace and comma but keep the -


                var splitArgs = Regex
                   .Split(remainingargs, argSeparators)
                   .Where(t => !string.IsNullOrEmpty(t));
                List<string> st = splitArgs.ToList<string>();
                double sss = double.Parse(st[0], CultureInfo.InvariantCulture);
                double sss2 = double.Parse(st[1], CultureInfo.InvariantCulture);

                return new Point(sss, sss2);

             /* for (int i = 0; i < str.Length; i++)
              {
                  if ((str[i].StartsWith("M") || (str[i].StartsWith("m"))))
                  {
                      string[] item = str[i].Split(',');
                      double sss = double.Parse(item[0].Substring(1), CultureInfo.InvariantCulture);
                      string ss2 = item[1];
                      return new Point(sss, double.Parse(item[1], CultureInfo.InvariantCulture));
                  }
              }*/
             }
            /* data = data.Replace("M ", " M").Replace("C ", " C").Replace("L", " L");
             string[] str = data.Split(' ');
             for (int i = 0; i < str.Length; i++)
             {
                 if ((str[i].StartsWith("M") || (str[i].StartsWith("m"))))
                 {
                     string[] item = str[i].Split(',');
                     double sss = double.Parse(item[0].Substring(1), CultureInfo.InvariantCulture);
                     string ss2 = item[1];
                     return new Point(sss, double.Parse(item[1], CultureInfo.InvariantCulture));
                 }
             }*/
             return new Point(0, 0);


         }
         public abstract void MoveGraphics(double x, double y);

    }
}
