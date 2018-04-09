using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using PatchMnemoLib.Model;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Media;
using System.Resources;
using System.Reflection;
using System.Windows.Input;
using PatchMnemoLib.View;
using System.Windows;
using System.Diagnostics;

namespace PatchMnemoLib.ViewModel
{
    public class viewModelMnemoAnimPen:ViewModelBase
    {

        #region singlton
        private static volatile viewModelMnemoAnimPen instance;
        private static object syncRoot = new Object();
        public static viewModelMnemoAnimPen Instance
        {
            get
            {
                //Stopwatch timerSP = new Stopwatch();

                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new viewModelMnemoAnimPen();
                    }
                }
           /*   timerSP.Stop();
                var timeWork = timerSP.ElapsedMilliseconds;
                Debug.WriteLine("----Instance------------------");
                Debug.WriteLine(timeWork);*/
                return instance;
            }
        }
        #endregion

        ObservableCollection<ViewModelAnimation> _ListAnim;//все анимации
        ObservableCollection<ViewModelPen> _ListPen;//все перья
        private string FileName;



        public ObservableCollection<ViewModelAnimation> ListAnim
        {
            get { return _ListAnim; }
            set { _ListAnim = value; }
        }
        public ObservableCollection<ViewModelPen> ListPenProperty
        {
            get
            {
                return _ListPen;
            }
            set
            {
                _ListPen = value;
                DictPenProperty.Clear();
                foreach (var el in _ListPen)
                    DictPenProperty.Add(el.PenName, el);

            }
        }
        private Dictionary<string, ViewModelPen> DictPenProperty = new Dictionary<string, ViewModelPen>();
        
        
        
        public viewModelMnemoAnimPen()
        {
           
            _ListAnim = new ObservableCollection<ViewModelAnimation>();
            _ListPen = new ObservableCollection<ViewModelPen>();
            //загружаем AnimPen из локального ресурса
            LoadResource();
           
           

        }
        public void AddAnim(ViewModelAnimation ma)
        {
            ma.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ma_PropertyChanged);
            ListAnim.Add(ma);
            OnPropertyChanged("ListAnim");
        }

        void ma_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ViewModelAnimation an = sender as ViewModelAnimation;
            if (e.PropertyName == "AnimationS")
            {
                foreach (var ma in ListPenProperty)
                    if (ma.AnimateName == an.Name)
                        ma.PenAnimate = an.AnimationS;

            }
            OnPropertyChanged("ListAnim");

        }
        public void AddPen(ViewModelPen mp)
        {
            mp.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mp_PropertyChanged);          
           SetBindingAP(mp);
            ListPenProperty.Add(mp);
            OnPropertyChanged("ListPenProperty");

        }
        void mp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ViewModelPen pen = sender as ViewModelPen;
            if (e.PropertyName == "AnimateName")
            {
                SetBindingAP(pen);
            }
            if (e.PropertyName == "Animate")
            {
                if (!pen.Animate) pen.PenAnimate = null;
            }
            OnPropertyChanged("ListPenProperty");

        }
        private void SetBindingAP(ViewModelPen pen)
        {
            foreach (var ma in ListAnim)
                if (ma.Name == pen.AnimateName)
                {
                    pen.PenAnimate = ma.AnimationS;                   
                }
        }

       

        //возвращаем пен по имени
        public Pen GetPen(string NamePen)
        {

          /*  Stopwatch timerSP = new Stopwatch();
            ViewModelPen vmp = ListPenProperty.Where(p => p.PenName == NamePen).First < ViewModelPen>();
            timerSP.Stop();
           var timeWork = timerSP.ElapsedMilliseconds;
           Debug.WriteLine("----GetPen------------------");
           Debug.WriteLine(timeWork);
            if (vmp!=null)
            return vmp.CurPen;
            new Exception("вызов возврата пера до загрузки данных или неверное имя пера");*/
            if (DictPenProperty.Count == 0)
            {
                foreach (var el in _ListPen)
                    DictPenProperty.Add(el.PenName, el);
            }
            ViewModelPen vmp =DictPenProperty[NamePen];
            if (vmp!=null)
            return vmp.CurPen;

          return null;
        }



        #region PenAnim
        private AnimPen _ap = new AnimPen();
  
        public void LoadResource()
        {

            if (Properties.Resources.String3 != "No")
            {
                LoaderClass.LoadResource(p => File.OpenRead(p), out  _ap, Properties.Resources.String1);
                FileName = Properties.Resources.String1;
            }
           
            else
            {
                LoaderClass.LoadResource(LoaderClass.LoadFromResource/*p => Application.GetResourceStream(new Uri(p, UriKind.RelativeOrAbsolute)).Stream*/, out  _ap, Properties.Resources.String2);

                FileName = Properties.Resources.String2;
            }
            

            ConvertApToViewModel();


        }
        public void SaveResource(string fileName)
        {

           ConvertViewModelToAp();
           

            XmlSerializer xmlFormat = new XmlSerializer(typeof(AnimPen));
            using (Stream fstream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fstream, _ap);
            }
        }

        private void ConvertApToViewModel()
        {
            _ListAnim.Clear();
            _ListPen.Clear();
            if (_ap.verfityAnimPen())
            {
                foreach (var an in _ap.ListAnimation)
                    AddAnim(new ViewModelAnimation(an));

                foreach (var pn in _ap.ListPen)
                {
                    ViewModelPen vmp = new ViewModelPen(pn);
                    AddPen(vmp);
                }
            }

        }

        private void ConvertViewModelToAp()
        {
            _ap.ListAnimation.Clear();
            _ap.ListPen.Clear();

            foreach (var an in _ListAnim)
                _ap.ListAnimation.Add(an.Model);

            foreach (var pn in _ListPen)
                _ap.ListPen.Add(pn.Model);

            if (!_ap.verfityAnimPen()) new Exception("Не соответствует имя анимации в названии пера");



        }



        #endregion

        private void RebuildPen()
        {
            foreach (var pen in ListPenProperty)
            {

                SetBindingAP(pen);

            }

        }




    }
}
