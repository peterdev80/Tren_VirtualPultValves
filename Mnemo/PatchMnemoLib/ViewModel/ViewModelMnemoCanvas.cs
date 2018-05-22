using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using PatchMnemoLib.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;
using PatchMnemoLib.ViewModelMElement;
using System.Windows;
using System.Diagnostics;
using System.Windows.Media;

namespace PatchMnemoLib.ViewModel
{
    public class ViewModelMnemoCanvas:ViewModelBase
    {


        // словарь имен элементов
        private Dictionary<string, ViewModelGraphics> DPatch = new Dictionary<string, ViewModelGraphics>();
        private void DictonaryUpdate()
        {
            DPatch.Clear();
            foreach (var el in gpatch)
                DPatch.Add(el.Name, el);
        }

        MnemoCanvas _canva;
        private string _fnameel="No";
        private string _rnameel = "No";
      
       
        private List<ViewModelGraphics> gpatch;// {get;set;}

        private VisualBase _SelectedGraphics;
        private bool _InitMC;
        public bool InitMC { get { return _InitMC; } set { _InitMC = value; OnPropertyChanged("InitMC"); } }
        public string FNamePatch { get { return _fnameel; }
            set 
            {
                _rnameel = "No";
                _fnameel = value;
                if (InitMC) LoadCanvas(_fnameel,p => new FileStream(p, FileMode.Open, FileAccess.Read, FileShare.Read));
                OnPropertyChanged("FNamePatch");
            }
        }
        public string RNamePatch
        {
            get { return _rnameel; }
            set
            {
                _fnameel = "No";
                _rnameel = value;
                if (InitMC) LoadCanvas(_rnameel,LoaderClass.LoadFromResource);
                OnPropertyChanged("RNamePatch");
            }
        }

        public void DeSelectLine()
        {
            if ((_SelectedGraphics != null) && (tekPen != null))
            {

                _SelectedGraphics.graphicsPen = tekPen;
                this.OnPropertyChanged("SelectedGraphics");
                tekPen = null;

            }

        }
        public void RedrawPos()
        {
            for (int i = 0; i < AllPatch.Count; i++)
               
                    AllPatch[0].ReDraw();

        }
        Pen tekPen;//для подсвечивания линий
        public VisualBase SelectedGraphics
        {
            get { return _SelectedGraphics; }
            set
            {
                DeSelectLine();
                _SelectedGraphics = value;
                if ((_SelectedGraphics != null)&&(_SelectedGraphics.TVisual==1))
                {
                    tekPen = _SelectedGraphics.graphicsPen;
                    double size = _SelectedGraphics.graphicsPen.Thickness;

                    _SelectedGraphics.graphicsPen = new Pen(Brushes.Red, size);
                   
                }
                this.OnPropertyChanged("SelectedGraphics");
                this.OnPropertyChanged("SelectedViewModelGraphics");
            }
        }
        public ViewModelGraphics SelectedViewModelGraphics
        {
          
            get { if (SelectedGraphics != null) return gpatch.Find(delegate(ViewModelGraphics vmp) { return vmp.Name == SelectedGraphics.Name; }); return null; }
            set {SelectedGraphics = value.GetGP(); this.OnPropertyChanged("SelectedGraphics"); this.OnPropertyChanged("SelectedViewModelGraphics"); }
        }

        //пытаюсь реализовать драг энд дроп
        #region DragAndDrop
        // Variables for dragging graphics.
        private bool _isDrag;
        private bool _SelectAll;
        public bool isDrag
        {
            get { return _isDrag; }
            set { _isDrag = value; OnPropertyChanged("isDrag"); }
        }
        public bool SelectAll
        {
            get { return _SelectAll; }
            set { _SelectAll = value; OnPropertyChanged("SelectAll"); }
        }

        private bool isDragging = false;
       
        private Point Position0;

        private void MC_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }
        private void MC_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && isDrag)
            {

                if (!SelectAll) Mov(SelectedViewModelGraphics, e.GetPosition(_canva));
                List<string> lst = new List<string>();
                foreach (var el in gpatch)
                    lst.Add(el.Name);

                if (SelectAll)
                {
                    
                 
                  foreach (string vg in lst)
                    Mov2(GetPatch(vg), e.GetPosition(_canva));
                }


            }
        }
        private void Mov(ViewModelGraphics swmg,Point gposition)
        {
            bool flag = false;
            Point pointDragged2 = gposition; ;
            Point pointDragged = gposition;// - Position0;
            if (swmg.ScaleX != 0 & swmg.ScaleY != 0)
            {
                
                        pointDragged2.X = swmg.ScaleX*(pointDragged.X - Position0.X);
                        pointDragged2.Y = swmg.ScaleY * (pointDragged.Y - Position0.Y);
                        flag = true;
             

            }
            
            if ((swmg.RotateAngle == 90))
            {

                //pointDragged2.Y = -pointDragged.X + Position0.X;
                pointDragged2.Y = -pointDragged.X + Position0.X;
                pointDragged2.X = pointDragged.Y -Position0.Y;

            }
            else
                if (swmg.RotateAngle == 180)
                {

                    pointDragged2.X = -pointDragged.X + Position0.X;
                    pointDragged2.Y = -pointDragged.Y + Position0.Y;

                }
                else
                    if ((swmg.RotateAngle == 270))
                    {

                        pointDragged2.Y = pointDragged.X - Position0.X;
                        pointDragged2.X = -pointDragged.Y + Position0.Y;

                    }
                    else
                        if (!flag)
                    {


                        pointDragged2.X = pointDragged.X - Position0.X;
                        pointDragged2.Y = pointDragged.Y - Position0.Y;

                    }
            swmg.MoveGraphics(pointDragged2.X, pointDragged2.Y);
            Position0.X = pointDragged.X; //- Position0.X;
            Position0.Y = pointDragged.Y;
        }
        private void Mov2(ViewModelGraphics swmg, Point gposition)
        {
            double xs = 10d;
            double ys =1;
            xs = gposition.X - Position0.X;
            ys = gposition.Y - Position0.Y;
            double xv = xs;
            double yv = ys;

            if (swmg.ScaleX != -0 & swmg.ScaleY != 0)
            {
                xv = xs * swmg.ScaleX;
                yv = ys * swmg.ScaleY;

            }

            if ((swmg.RotateAngle == 90) )
            {
                xv = ys;
                yv = -xs;
            }
            if ((swmg.RotateAngle == 180) )
            {
                xv = -xs;
                yv = -ys;
            }
            if ((swmg.RotateAngle == 270) || (swmg.RotateAngle == -90))
            {
                xv = -ys;
                yv = xs;
            }

           swmg.MoveGraphics(xv, yv);
         
        }


        #endregion

        private void MC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var p = e.GetPosition(this.Canva);
            var x = Canva.GetVisual(p) as VisualBase;
            if (x != null)
            {
                this.SelectedGraphics = x;
                Position0 = p;
                isDragging = true;
            }
            else
            {

                this.SelectedGraphics = null;
                
                isDragging = false;
            }


        }
        protected override void OnDispose()
        {
            base.OnDispose();
            Canva.MouseLeftButtonDown -= MC_MouseLeftButtonDown;
        }
        public MnemoCanvas Canva 
        
        { 
            get 
            {
                return _canva;
            }
            set {
                if (_canva== value) return;
                _canva = value;
                _canva.MouseLeftButtonDown += MC_MouseLeftButtonDown;

                _canva.MouseLeftButtonUp += MC_MouseLeftButtonUp;
                _canva.MouseMove += MC_MouseMove;

                InitMC = true;
                if (FNamePatch!="No")
                LoadCanvas(_fnameel,p=> new FileStream(p,FileMode.Open, FileAccess.Read, FileShare.Read));
                if (RNamePatch != "No")
                    LoadCanvas(_rnameel,LoaderClass.LoadFromResource);
               
            }
        }
        public ViewModelMnemoCanvas()
        {
            gpatch=  new List<ViewModelGraphics>();
            _canva = new MnemoCanvas();
           
        }

        public void SaveCanvas(string fname)
        {


         
         try
            {
                SerializationHelper helper = new SerializationHelper(gpatch);

                XmlSerializer xml = new XmlSerializer(typeof(SerializationHelper));

                using (Stream stream = new FileStream(fname,
                    FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xml.Serialize(stream, helper);
                   

                }
            }
         catch (IOException e)
            {
                throw new Exception(e.Message, e);
            }
            catch (InvalidOperationException e)
            {
                throw  new Exception(e.Message, e);
            }
        


        }
        /// <summary>
        /// загружаем и создаем визуальные элементы
        /// </summary>
        /// <param name="fname"></param>
        /// <param name="ld"></param>
        private void LoadCanvas(string fname, PatchMnemoLib.ViewModel.LoaderClass.LoadData ld)
        {
            var timer = Stopwatch.StartNew();
            gpatch.Clear();
            List<VisualBase> visual;
          
             SerializationHelper helper;
            LoaderClass.LoadResource<SerializationHelper>(ld, out helper,fname);
            if (helper.Graphics == null)
                {
                    throw new Exception("Ошибка загрузки файла схемы");
                }
            /* try
            {
               

                XmlSerializer xml = new XmlSerializer(typeof(SerializationHelper));

                using (Stream stream = ld(fname))
                {
                    helper = (SerializationHelper)xml.Deserialize(stream);
                }

                if (helper.Graphics == null)
                {
                    throw new Exception("Ошибка загрузки файла схемы");
                }*/

                visual = new List<VisualBase>();
               
                
             
                foreach (PropertiesGraphicsBase g in helper.Graphics)
                {

                    var el = g.CreateGraphics();
                   
                    switch (el.TVisual)
                    {
                        case 1: new ViewModelPatch(this, (GraphicsPatch)el); break;
                        case 2: new ViewModelDP(this, (DPKey)el); break;
                        case 3:
                            new ViewModelKlapan(this,(Klapan)el); break;
                        case 4: 
                            new ViewModelValueLabel(this, (ValueLabel)el); break;
                        case 5:
                            new ViewModelarcBalon(this, (arcBalon)el); break;
                        case 6:
                            new ViewModelProgressVolt(this, (ProgressVolt)el);break;
                        case 7:
                            new ViewModelColorInd(this, (InpuColorIndicator)el); break;
                       
                case 8: new ViewModelAnimKlapan(this, (AnimKlapan)el); break;
                    case 122:
                        new ViewModelLispKlapan(this, (LispKlapan)el); break;


                }


                }
               /* timer.Stop();
                var timeWork = timer.ElapsedMilliseconds;
                Debug.WriteLine("----DW------------------");
                Debug.WriteLine(timeWork);*/



           /* }
            catch (IOException e)
            {
                throw new Exception(e.Message);
            }*/
         OnPropertyChanged("Canva");
          // OnPropertyChanged("AllPatch");

            timer.Stop();
            var timeWork = timer.ElapsedMilliseconds;
            Debug.WriteLine("----DW------------------");
            Debug.WriteLine(timeWork);
        }

      
        public void Load(string fname)
        {
        }

        public void AddVisual(ViewModelGraphics vmp)
        {
            vmp.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(vmp_PropertyChanged);
            gpatch.Add(vmp);
            DPatch.Add(vmp.Name, vmp);
            Canva.AddVisual(vmp.GetGP());
            OnPropertyChanged("AllPatch");
           

        }
        public void InsertVisual(ViewModelGraphics vmp,int pos)
        {
            vmp.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(vmp_PropertyChanged);
            gpatch.Insert(pos, vmp);
           
            Canva.InsertVisual(vmp.GetGP(),pos);
            DictonaryUpdate();
            OnPropertyChanged("AllPatch");

        }

        void vmp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == "DefPenColor") || ((e.PropertyName == "DefPenSize")))
            {
                ViewModelGraphics vmg = sender as ViewModelGraphics;            

                vmg.ReDraw(true);
                
              
            }
        }
        public void SendToBack()
        {
            var vmg = SelectedViewModelGraphics;
            vmg.ReDraw();
            for (int i = 0; i < AllPatch.Count; i++)
                if (AllPatch[0].Name != vmg.Name)
                    AllPatch[0].ReDraw();

        }
        public void DeleteVisual( ViewModelGraphics vmp)
        {
            vmp.PropertyChanged -= vmp_PropertyChanged;
            gpatch.Remove(vmp);
            DPatch.Remove(vmp.Name);
            Canva.DeleteVisual(vmp.GetGP());
            OnPropertyChanged("AllPatch");

        }
        public ViewModelGraphics GetPatch(string name)
        {
           // return gpatch.Find(delegate(ViewModelGraphics vmp) { return vmp.Name == name; });

            if (DPatch.Count == 0) DictonaryUpdate();
            

            return DPatch[name];

        }
        public void SetPatch(List<ViewModelGraphics> val)
        {
            gpatch = val;
            DictonaryUpdate();
            OnPropertyChanged("AllPatch");

        }
        public List<ViewModelGraphics> GetAllPatch()
        {
            return gpatch;
        }
        public List<ViewModelGraphics> AllPatch
        {
            get 
            {
                return gpatch;
                
            }
        }
        public List<ViewModelGraphics> AllLabel
        {
            get
            {
                List<ViewModelGraphics> _AllLabel = new List<ViewModelGraphics>();
                foreach (var el in gpatch)
                {
                    if (el.TVisual == 4) _AllLabel.Add(el);
                    if (el.TVisual == 5) _AllLabel.Add(el);
                    if (el.TVisual == 6) _AllLabel.Add(el);
                    if (el.TVisual == 7) _AllLabel.Add(el);
                    if (el.TVisual == 122) _AllLabel.Add(el);
                }
                return _AllLabel;

            }
        }

      

    }
}
