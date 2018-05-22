using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using ValueModel.BaseType;
using WPFMnemoLibrary.View;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Threading;
using ValueModel.BaseModel;
using PatchMnemoLib;
using ValueModel.BaseModelCommand;
using PatchMnemoLib.ViewModel;
using System.Windows.Data;
using System.Windows;

namespace WPFMnemoLibrary.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        private string selectModel;

        public string DisplayNam
        {
            get {
                //  string strsel = "СОЮЗ ТМА М   ";
                // if (mnemoSystemSelector.ValueState == 2)
                string strsel = "СОЮЗ МС   ";



                return strsel+selectModel; }
        }
        public IntValue mnemoSelector { get; private set; }
        public IntVar mSelector;

        public IntValue mnemoSystemSelector { get; private set; }
        public IntVar mSystemSelector;

        #region Fields

        ReadOnlyCollection<CommandViewModel> _commands;
        //readonly CustomerRepository _customerRepository;
       // ObservableCollection<ViewModelBase> _workspaces;

        #endregion // Fields

        private UserControl _model=new UserControl();
        public UserControl Model { get {return _model;}
            set
            {
                /**/
                if (_model != value)
                {
                    _model = value;                   
                    foreach(var cmd in Commands)
                    {
                        cmd.StateCommand = false;
                        if (cmd.DisplayName == selectModel) cmd.StateCommand = true;
                    }

                   
                    base.OnPropertyChanged("Model");
                    OnPropertyChanged("DisplayNam");
                    
                  
                }
            }
        }
        #region Constructor
        public MainWindowViewModel()
        {
            //работа с обменном на прямую
           
            {
              var val = ViewModelVariableList.Instance.GetVariable("__select_MFL");
                mnemoSelector = ((IntVar)val.VarM).ValState;
                mnemoSelector.PropertyChanged += mnemoSelector_PropertyChanged;
               

            }
            
          

        


     


    }

        public void AttachToRemoteControl()
        {
          
        }
        void mnemoSystemSelector_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _commands = null;
            OnPropertyChanged("Commands");
            OnPropertyChanged("DisplayNam");
        }

        void mnemoSelector_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var i = mnemoSelector.ValueState;
        

            switch (i)
            {
                case 100: { selectModel = "Управление КДУ"; Model = new View.ViewOK29_MC(); break; }
                case 101: { selectModel = "ПГС КДУ"; Model = new View.ViewFKDU_MC(); break; }
                case 102: { selectModel = "Наддув^ КДУ".Replace("^ ", Environment.NewLine); Model = new View.ViewNaduvMC(); break; }
                case 103: {  selectModel = "Управление ДПО от^  ССВП".Replace("^ ", Environment.NewLine); Model = new View.ViewDPOisSSWP_MC(); break; }
                        case 110: { selectModel = "СЭП   "; Model = new View.ViewSEPMC(); break; }
                case 120: { selectModel = "СОТР   "; Model = new SotrMCView(); break; }
                case 130: { selectModel = "Питание ССВП"; Model = new View.ViewPitSEP_MC(); break; }
                case 131: { selectModel = "Программа12"; Model = new View.ViewPR12_MC(); break; }
                case 150: { selectModel = "Система ^Термо Датчиков".Replace("^ ", Environment.NewLine); Model = new STDView(); break; }
                case 200: { selectModel = "Система Разделения"; Model = new SRView(); break; }
            }







        }

        public MainWindowViewModel(string customerDataFile)
        {
            base.DisplayName ="Main";

           // _customerRepository = new CustomerRepository(customerDataFile);
        }

        #endregion // Constructor

        #region Commands

        /// <summary>
        /// Returns a read-only list of commands 
        /// that the UI can display and execute.
        /// </summary>
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_commands == null)
                {

                   List<CommandViewModel> cmds;
                    //cmds = this.CreateCommands();
                   // if (mnemoSystemSelector.ValueState==2)*/
                    cmds= this.CreateCommandsMC();
                    _commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _commands;
            }
        }

        List<CommandViewModel> CreateCommandsMC()
        {
            return new List<CommandViewModel>
            {
                  new CommandViewModel(
                    "Управление КДУ",
                    new MnemoRelayCommand(param => {selectModel=  "Управление КДУ"; Model=new View.ViewOK29_MC();})),
                   new CommandViewModel(
                    "ПГС КДУ",
                    new MnemoRelayCommand(param => {selectModel=  "ПГС КДУ"; Model=new View.ViewFKDU_MC();})),
                    new CommandViewModel(
                    "Наддув^ КДУ". Replace("^ ", Environment.NewLine),
                    new MnemoRelayCommand(param => {selectModel=  "Наддув^ КДУ". Replace("^ ", Environment.NewLine); Model=new View.ViewNaduvMC();})),

                     new CommandViewModel(
                    "Управление ДПО от^  ССВП". Replace("^ ", Environment.NewLine),
                    new MnemoRelayCommand(param => {selectModel=  "Управление ДПО от^  ССВП". Replace("^ ", Environment.NewLine); Model=new View.ViewDPOisSSWP_MC();})),

              
                   new CommandViewModel(
                    "Питание ССВП",
                    new MnemoRelayCommand(param => {selectModel=  "Питание ССВП"; Model=new View.ViewPitSEP_MC();})),

                     new CommandViewModel(
                    "СОТР   ",
                    new MnemoRelayCommand(param => {selectModel=  "СОТР   "; Model=new SotrMCView();})),

                  new CommandViewModel(
                    "СЭП   ",
                    new MnemoRelayCommand(param => {selectModel=  "СЭП   "; Model=new View.ViewSEPMC();})),


                new CommandViewModel(
                    "Программа12",
                    new MnemoRelayCommand(param => {selectModel=  "Программа12"; Model=new View.ViewPR12_MC();})),

                new CommandViewModel(
                    "Система^ Термо Датчиков". Replace("^ ", Environment.NewLine),
                    new MnemoRelayCommand(param => {selectModel=  "Система ^Термо Датчиков". Replace("^ ", Environment.NewLine); Model=new STDView();})),

                 new CommandViewModel(
                    "Система Разделения",
                    new MnemoRelayCommand(param => {selectModel=  "Система Разделения"; Model=new SRView();})),

                     new CommandViewModel(
                    "СКГС",
                    new MnemoRelayCommand(param => {selectModel=  "СКГС"; Model=new ViewSKGS_MC();}))


            };
            }

           
        List<CommandViewModel> CreateCommands()
        {
           return new List<CommandViewModel>
            {
                  new CommandViewModel(
                    "Функ.схема КДУ",
                    new RelayCommand(param => {selectModel= "Функ.схема КДУ"; Model=new KDUFuncView(); })),

                new CommandViewModel(
                    "БА ДПО  ",
                    new RelayCommand(param => {selectModel= "БА ДПО  "; Model=new BADPOView(); })),

                new CommandViewModel(
                   "Расположение^ двигателей". Replace("^ ", Environment.NewLine),
                    new RelayCommand(param => {selectModel= "Расположение^ двигателей". Replace("^ ", Environment.NewLine); Model=new DvigView();})),

new CommandViewModel(
                    "СОТР   ",
                    new RelayCommand(param => {selectModel=  "СОТР   "; Model=new SOTRView();})),

                new CommandViewModel(
                    "Управление Пр.12",
                    new RelayCommand(param => {selectModel=  "Управление Пр.12"; Model=new Pr12View();})),

                  new CommandViewModel(
                    "Управление^ наддувом КДУ". Replace("^ ", Environment.NewLine),
                    new RelayCommand(param => {selectModel=  "Управление^ наддувом КДУ". Replace("^ ", Environment.NewLine); Model=new NaduvView();})),

                  new CommandViewModel(
                    "СКГС ТК+БО",
                    new RelayCommand(param => {selectModel=  "СКГС ТК+БО"; Model=new SUView();})),

 new CommandViewModel(
                    "СКГС ТК",
                    new RelayCommand(param => {selectModel=  "СКГС ТК"; Model=new SULiteView();})),

                   new CommandViewModel(
                    "СЭП",
                    new RelayCommand(param => {selectModel=  "СЭП"; Model=new ViewSEP();})),

                     new CommandViewModel(
                    "Управление КДУ",
                    new RelayCommand(param => {selectModel=  "Управление КДУ"; Model=new UpravKDU();})),

                    new CommandViewModel(
                    "Циклограмма^ автоматической^ стыковки". Replace("^ ", Environment.NewLine),
                    new RelayCommand(param => {selectModel= "Циклограмма^ автоматической^ стыковки". Replace("^ ", Environment.NewLine); Model=new ViewCiclogramm();})),

                     new CommandViewModel(
                    "Питание ССВП",
                    new RelayCommand(param => {selectModel= "Питание ССВП"; Model=new PitSSWP();})),

                     new CommandViewModel(
                    "Управление ДПО-Б^ по командам из^ ССВП". Replace("^ ", Environment.NewLine),
                    new RelayCommand(param => {selectModel=  "Управление ДПО-Б^ по командам из^ ССВП". Replace("^ ", Environment.NewLine); Model=new ViewOtvodPodvod();})),
                   
                    new CommandViewModel(
                    "Система Разделения",
                    new RelayCommand(param => {selectModel=  "Система Разделения"; Model=new SRView();})),
                    
                     new CommandViewModel(
                    "Система^ Межмодульной Вентиляции". Replace("^ ", Environment.NewLine),
                    new RelayCommand(param => {selectModel=  "Система ^Межмодульной Вентиляции". Replace("^ ", Environment.NewLine); Model=new SMVView();})),
                    
                    new CommandViewModel(
                    "Система^ Термо Датчиков". Replace("^ ", Environment.NewLine),
                    new RelayCommand(param => {selectModel=  "Система ^Термо Датчиков". Replace("^ ", Environment.NewLine); Model=new STDView();})),
                    
                    
                    new CommandViewModel(
                    "Распределение шин^ электропитания (ст.)". Replace("^ ", Environment.NewLine),
                    new RelayCommand(param => {selectModel=  "Распределение шин^ электропитания (ст.)". Replace("^ ", Environment.NewLine); Model=new ViewEP();})),
                   
                    new CommandViewModel(
                    "Сигнализация ССВП(ст.)",
                    new RelayCommand(param => {selectModel=  "Сигнализация ССВП(ст.)"; Model=new ViewSIG();})),

                     new CommandViewModel(
                    "СИОС(ст.)",
                    new RelayCommand(param => {selectModel=  "СИОС(ст.)"; Model=new ViewSios();}))

            };
        }

        #endregion // Commands

    /*    #region Workspaces

        /// <summary>
        /// Returns the collection of available workspaces to display.
        /// A 'workspace' is a ViewModel that can request to be closed.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces
     */

        #region Private Helpers

        void CreateNewCustomer()
        {
           /* Customer newCustomer = Customer.CreateNewCustomer();
            CustomerViewModel workspace = new CustomerViewModel(newCustomer, _customerRepository);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);*/
        }

        void ShowAllCustomers()
        {
           /* AllCustomersViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllCustomersViewModel)
                as AllCustomersViewModel;

            if (workspace == null)
            {
                workspace = new AllCustomersViewModel(_customerRepository);
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);*/
        }

       /* void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }*/

        #endregion // Private Helpers
    }
}
