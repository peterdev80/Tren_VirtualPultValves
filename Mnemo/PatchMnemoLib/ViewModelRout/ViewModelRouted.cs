using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using PatchMnemoLib.ViewModel;
using PatchMnemoLib.ViewModelMElement;
using System.Windows;
using System.Diagnostics;

namespace PatchMnemoLib.ViewModelRout
{
    public class ViewModelRouted:ViewModelBase
    {
        //при загрузки сохраняем имя файла откуда загрузили схему
        private string Fname;
       // private string Rname;
        private string _rnameel = "No";

        /// <summary>
        /// Все Переменные обмена из файла переменных обмена
        /// </summary>
        public ObservableCollection<ViewModelVariableM> AllVar
        {
            get { return ViewModelVariableList.Instance.ListVariable; }
        }

        public ObservableCollection<ViewModelPen> AllPen
        {
            get { return viewModelMnemoAnimPen.Instance.ListPenProperty; }
        }
        public List<ViewModelGraphics> AllPatch
        {
            get
            {
                if (_MC!=null)
                return _MC.AllPatch;
                return null;
            }
        }
        public List<ViewModelGraphics> AllLabel
        {
            get
            {
                if (_MC != null)
                    return _MC.AllLabel;
                return null;
            }
        }
        private string _fnameel = "No";
        private ViewModelMnemoCanvas _MC;
        public bool InitR { get; set; }

        private List<Route> Routds;


        public ObservableCollection<ViewModelRoute> RoutList { get; set; } //колекция эле5ментов
        public ObservableCollection<ViewModelShower> ShowerList { get; set; } //колекция значений для отображения
        public ObservableCollection<ViewModelVisiblir> VisiblirList { get; set; } //колекция видимости
        public string FNamePatch
        {
            get { return _fnameel; }
            set
            {
                _rnameel = "No";
                _fnameel = value;
                if (InitR) LoadResource(_fnameel,p => new FileStream(p, FileMode.Open, FileAccess.Read, FileShare.Read));
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
                if (InitR) LoadResource(_rnameel,LoaderClass.LoadFromResource);
                OnPropertyChanged("RNamePatch");
            }
        }
        public ViewModelPatch SelectedPatch
        {
          //  get { if (_MC != null) return _Canva.SelectedPatch; return null; }
            get { return null; }
        }
      
        public ViewModelMnemoCanvas _Canva
        {
            get { return _MC; }
            set
            {
               
                _MC = value;
                if (_MC.InitMC) InitR = true;
                _MC.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_MC_PropertyChanged);
            }
        }

        void _MC_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Canva")
            {
                InitR = true;
                Routds = new List<Route>();
                RoutList = new ObservableCollection<ViewModelRoute>();
                ShowerList = new ObservableCollection<ViewModelShower>();
              if (FNamePatch!="No") LoadResource(_fnameel,p => new FileStream(p, FileMode.Open, FileAccess.Read, FileShare.Read));
              if (RNamePatch != "No") LoadResource(_rnameel, LoaderClass.LoadFromResource); 


            }
           
        }

       



        public ViewModelRouted()
        {
           
            Routds = new List<Route>();
            RoutList = new ObservableCollection<ViewModelRoute>();
            ShowerList = new ObservableCollection<ViewModelShower>();
            VisiblirList = new ObservableCollection<ViewModelVisiblir>();
            FindEl = new ObservableCollection<ViewModelRoute>();

           

        }

        public ViewModelRouted(ViewModelMnemoCanvas Canva)
        {
            
           Routds = new List<Route>();
           RoutList = new ObservableCollection<ViewModelRoute>();
           ShowerList = new ObservableCollection<ViewModelShower>();
           VisiblirList = new ObservableCollection<ViewModelVisiblir>();
           _Canva = Canva;
        

        }
        public void AddShower(Route val)
        {
            ShowerList.Add(new ViewModelShower(val, _Canva));

        }
        public void AddRoute(Route val)
        {
            RoutList.Add(new ViewModelRoute(val, _Canva));


        }
        public void AddVisiblir(Route val)
        {
            VisiblirList.Add(new ViewModelVisiblir(val, _Canva));

        }

        public void AddVisiblir(string NameRoute)
        {
            Route val = new Route();
            val.Name = NameRoute;
            val.ValueName = AllVar[0].VarName;
            val.ValuePos = 0;
            val.TypRoute = 3;
          
            VisiblirList.Add(new ViewModelVisiblir(val, _Canva));

        }
        public void AddShower(string NameRoute)
        {
            Route val = new Route();
            val.Name = NameRoute;
           val.ValueName = AllVar[0].VarName;
            val.ValuePos = 0;
            val.TypRoute = 2;
           // ViewModelShower vms = new ViewModelShower(val, _Canva);
            ShowerList.Add(new ViewModelShower(val, _Canva));

        }

        public void AddRoute(string NameRoute)
        {
            Route val = new Route();
            val.Name = NameRoute;
            val.ValueName = AllVar[0].VarName;
            val.ValuePos = 0;
            RoutList.Add(new ViewModelRoute(val, _Canva));
        }

        public void DeleteVisiblir(string val)
        {
            ViewModelVisiblir vmp = VisiblirList.Where(p => p.Name == val).First<ViewModelVisiblir>();
            if (vmp != null)
                VisiblirList.Remove(vmp);
        }
        public void DeleteShower(string val)
        {
            ViewModelShower vmp = ShowerList.Where(p => p.Name == val).First<ViewModelShower>();
            if (vmp != null)
                ShowerList.Remove(vmp);
        }

        public void DeleteRoute(string val)
        {
            ViewModelRoute vmp = RoutList.Where(p => p.Name == val).First<ViewModelRoute>();
            if (vmp!=null)
            {
                
                vmp.deleteMarshrut();
               RoutList.Remove(vmp);
            }
            
        }
        public void DeleteElementfromVisibler(string elName)
        {
            foreach (var el in VisiblirList)
            {
                el.DeleteGraphics(elName);
            }
        }

        public void DeleteElementfromShower(string elName)
        {
            foreach (var el in ShowerList)
            {
                el.DeleteGraphics(elName);
            }
        }


        public void DeleteElementfromRoute(string elName)
        {
            foreach (var el in RoutList)
            {
                el.DeleteGraphics(elName);
            }
        }
        /// <summary>
        /// загружаем из компилированного ресурса
        /// </summary>
        /// <param name="fileName"></param>
       /* public void LoadCompileRecource(string fileName)
        {
            long eltt=0;
            long el2=0;
         //   var timer = Stopwatch.StartNew();
            Uri uri = new Uri(fileName, UriKind.RelativeOrAbsolute);
            Rname = fileName;
            Fname = fileName;
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Route>));
            using (Stream fstram = Application.GetResourceStream(uri).Stream)
            {
                Routds = (List<Route>)xmlFormat.Deserialize(fstram);
            }

         //   timer.Stop();
         //   var timeWork = timer.ElapsedMilliseconds;
         //   Debug.WriteLine("----REZ------------------");
         //   Debug.WriteLine(timeWork);
           
            RoutList.Clear();
            ShowerList.Clear();
            //var timer3 = Stopwatch.StartNew();
            for (int i = 0; i < Routds.Count; i++)
            {
               
                if (Routds[i].TypRoute != 2)
                {
                    var timer2 = Stopwatch.StartNew();
                    var el = new ViewModelRoute(Routds[i], _Canva);

                    RoutList.Add(el);
                    timer2.Stop();
                    eltt = eltt + timer2.ElapsedMilliseconds;
                }
                else
                {
                   var timer2 = Stopwatch.StartNew();
                    var el = new ViewModelShower(Routds[i], _Canva);
                    ShowerList.Add(el);
                    timer2.Stop();
                    el2 = el2 + timer2.ElapsedMilliseconds;
                }
            }
           
         Debug.WriteLine(string.Format("первый тип {0}, two {1}", eltt, el2));
         //   timer3.Stop();
         //   var timeWork3 = timer3.ElapsedMilliseconds;
         //   Debug.WriteLine("----REZ------------------");
         //   Debug.WriteLine(timeWork3);
        }*/
        /// <summary>
        /// Загружаем из файла
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadResource(string fileName, PatchMnemoLib.ViewModel.LoaderClass.LoadData ld)
        {
            Fname = fileName;

            LoaderClass.LoadResource<List<Route>>(ld, out Routds, fileName);
            
            /*  XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Route>));
            using (Stream fstram = File.OpenRead(fileName))
            {
                Routds = (List<Route>)xmlFormat.Deserialize(fstram);
            }*/
            RoutList.Clear();
            ShowerList.Clear();

            for (int i = 0; i < Routds.Count; i++)
            {
                if (Routds[i].TypRoute ==0)
                {
                    var el = new ViewModelRoute(Routds[i], _Canva);
                    RoutList.Add(el);
                }
                else
                    if (Routds[i].TypRoute == 2)
                {
                    var el = new ViewModelShower(Routds[i], _Canva);
                    ShowerList.Add(el);
                }
                    else
                        if (Routds[i].TypRoute == 3)
                        {
                            var el = new ViewModelVisiblir(Routds[i], _Canva);
                            VisiblirList.Add(el);
                        }
            }




        }
        public void SaveResource(string fileName)
        {

            Routds.Clear();
            for (int i = 0; i < RoutList.Count; i++) Routds.Add(RoutList[i].Marshruts);
            for (int i = 0; i < ShowerList.Count; i++) Routds.Add(ShowerList[i].Marshruts);
            for (int i = 0; i < VisiblirList.Count; i++) Routds.Add(VisiblirList[i].Marshruts);

            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Route>));
            using (Stream fstream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fstream, Routds);
            }
        }

        private string el_name;
        public string FindElName
        {
            get { return el_name; }
            set { el_name = value; IncludeNarshruts(); }
    }

        public ObservableCollection<ViewModelRoute> FindEl { get; set; }
         private List<Route> IncludeNarshruts()
        {
           //  List<> l=
StringItem val=new StringItem();
             val.Value=el_name;
            List<Route> lst = Routds.FindAll(delegate(Route sc) { return ((
                sc.NameGraphics.Contains(val)
                ) ); });

            FindEl = new ObservableCollection<ViewModelRoute>();
             //MessageBox.Show(String.Format("Найдено {} маршрутов",lst.Count);
            foreach (var ro in lst)
            {

                if (ro.TypRoute != 2)
                {
                    var el = new ViewModelRoute(ro, _Canva);
                    FindEl.Add(el);
                }
               // else
               
                
                //FindEl.Add(ro);
            }

            this.OnPropertyChanged("FindEl");

            return lst;
        }


    }
}
