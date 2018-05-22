using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using PatchMnemoLib.Model;
using PatchMnemoLib.View;
using PatchMnemoLib.ViewModelRout;
using PatchMnemoLib.ViewModelMElement;
using ValueModel.BaseModelCommand;

namespace PatchMnemoLib.ViewModel
{
    public class ViewModelEditor : ViewModelBase
    {
        private string _FShema;
        private string _FRout;

        private string _RShema;
        private string _RRout;


        public string FShema { get { return _FShema; } set { _FShema = value; _mc.FNamePatch = _FShema; } }
        //public string FRout { get; set; }
        public string FRout { get { return _FRout; } set { _FRout = value; vmr.FNamePatch = _FRout; } }

        public string RShema { get { return _RShema; } set { _RShema = value; _mc.RNamePatch = _RShema; } }
        public string RRout { get { return _RRout; } set { _RRout = value; vmr.RNamePatch = _RRout; } }
        //  public string RRout { get; set; }

        private ViewModelMnemoCanvas _mc = new ViewModelMnemoCanvas();
        private ViewModelRouted vmr = new ViewModelRouted();



        #region Canva
        /// <summary>
        /// load patch
        /// </summary>
        /// 





        #endregion


        public ViewModelMnemoCanvas MC
        {
            get { return _mc; }
            set
            {
                _mc = value;


            }
        }
        public ViewModelRouted Routed
        {
            get { return vmr; }
        }


        public ViewModelEditor()
        {
            vmr._Canva = _mc;

        }




        #region Command
        private RelayCommand _cmdNewPatch, _cmdEditPatch, _cmdVariableVar, _cmdroutedit, _cmdNewDp, _cmdNewKlapan, _cmdNewValueLabel, _cmdNewarcBalon, _cmdNewLispKlapan;
        private RelayCommand _CopyPacte, _delete, _save;
        private RelayCommand _cmdNewVoltmetr, _cmdNewColorIndicator;
        private RelayCommand _cmdNewAnimKlapan;
        public ICommand cmdSave
        {
            get
            {
                if (_save == null)
                    _save = new RelayCommand(param =>
                    {
                        MC.SaveCanvas(FShema);
                        vmr.SaveResource(FRout);
                    });
                return _save;
            }
        }

        public ICommand cmdDelete
        {
            get
            {
                if (_delete == null)
                    _delete = new RelayCommand(param =>
                    {
                        if (MC.SelectedGraphics != null)
                        {
                            vmr.DeleteElementfromShower(MC.SelectedGraphics.Name);
                            vmr.DeleteElementfromRoute(MC.SelectedGraphics.Name);
                            MC.SelectedViewModelGraphics.DeleteElement();
                            MC.SelectedGraphics = null;
                        }

                    });
                return _delete;
            }
        }
        public ICommand cmdCopyPacte
        {
            get
            {
                if (_CopyPacte == null)
                    _CopyPacte = new RelayCommand(param =>
                    {
                        if (MC.SelectedGraphics != null)
                        {
                            ViewModelGraphics vmp = new ViewModelPatch();
                            ViewModelGraphics vmp1 = new ViewModelPatch();
                            switch (MC.SelectedGraphics.TVisual)
                            {
                                case 1:
                                    {
                                        vmp = (ViewModelPatch)MC.SelectedViewModelGraphics;
                                        vmp1 = new ViewModelPatch(MC);
                                        break;
                                    }
                                case 2:
                                    {
                                        vmp = (ViewModelDP)MC.SelectedViewModelGraphics;
                                        vmp1 = new ViewModelDP(MC);
                                        break;
                                    }
                                case 3:
                                    {
                                        vmp = (ViewModelKlapan)MC.SelectedViewModelGraphics;
                                        vmp1 = new ViewModelKlapan(MC);
                                        break;
                                    }
                                case 4:
                                    {
                                        vmp = (ViewModelValueLabel)MC.SelectedViewModelGraphics;
                                        vmp1 = new ViewModelValueLabel(MC);
                                        break;
                                    }
                                case 5:
                                    {
                                        vmp = (ViewModelarcBalon)MC.SelectedViewModelGraphics;
                                        vmp1 = new ViewModelarcBalon(MC);
                                        break;
                                    }
                                case 7:
                                    {
                                        vmp = (ViewModelColorInd)MC.SelectedViewModelGraphics;
                                        vmp1 = new ViewModelColorInd(MC);
                                        break;
                                    }
                                case 8:
                                    {
                                        vmp = (ViewModelAnimKlapan)MC.SelectedViewModelGraphics;
                                        vmp1 = new ViewModelAnimKlapan(MC);
                                        break;

                                    }
                                case 122:
                                    {
                                        vmp = (ViewModelLispKlapan)MC.SelectedViewModelGraphics;
                                        vmp1 = new ViewModelLispKlapan(MC);
                                        break;
                                    }

                            }
                            vmp1.CopyMov(vmp);


                        }
                    }
  );
                return _CopyPacte;
            }
        }
        public ICommand CmdNewAnimKlapan
        {
            get
            {
                if (_cmdNewAnimKlapan == null)
                    _cmdNewAnimKlapan = new RelayCommand(param =>
                    {
                        ViewModelAnimKlapan vmp = new ViewModelAnimKlapan(MC);
                        Window wnd = new Window();
                        wnd.Height = 470;
                        wnd.Width = 300;
                        wnd.Content = new View.ViewAnimKlapanProperty(vmp);
                        wnd.Show();
                    });
                return _cmdNewAnimKlapan;
            }
        }
        public ICommand CmdNewColInd
        {
            get
            {
                if (_cmdNewColorIndicator == null)
                    _cmdNewColorIndicator = new RelayCommand(param =>
                    {
                        ViewModelColorInd vmp = new ViewModelColorInd(MC);
                    }
);
                return _cmdNewColorIndicator;
            }
        }
        public ICommand cmdNewVoltmetr
        {
            get
            {
                if (_cmdNewVoltmetr == null)
                    _cmdNewVoltmetr = new RelayCommand(param =>
                    {
                        ViewModelProgressVolt vmp = new ViewModelProgressVolt(MC);
                    }
);
                return _cmdNewVoltmetr;
            }
        }

        public ICommand cmdNewarcBalon
        {
            get
            {
                if (_cmdNewarcBalon == null)
                    _cmdNewarcBalon = new RelayCommand(param =>
                    {
                        ViewModelarcBalon vmp = new ViewModelarcBalon(MC);
                        Window wnd = new Window();
                        wnd.Height = 470;
                        wnd.Width = 300;
                        wnd.Content = new View.ViewarcBalon(vmp);
                        wnd.Show();

                    }
);
                return _cmdNewarcBalon;
            }

        }
        public ICommand cmdNewValueLabel
        {
            get
            {
                if (_cmdNewValueLabel == null)
                    _cmdNewValueLabel = new RelayCommand(param =>
                    {
                        ViewModelValueLabel vmp = new ViewModelValueLabel(MC);
                        Window wnd = new Window();
                        wnd.Height = 470;
                        wnd.Width = 300;
                        wnd.Content = new View.ViewLabelPropety(vmp);
                        wnd.Show();


                    }
);
                return _cmdNewValueLabel;
            }
        }
        public ICommand cmdNewPatch
        {
            get
            {
                if (_cmdNewPatch == null) _cmdNewPatch = new RelayCommand(param => NewPatch(param));
                return _cmdNewPatch;
            }
        }
        public ICommand cmdNewKlapan
        {
            get
            {
                if (_cmdNewKlapan == null)
                    _cmdNewKlapan = new RelayCommand(param =>
                    {
                        ViewModelKlapan vmp = new ViewModelKlapan(MC);
                        Window wnd = new Window();
                        wnd.Height = 470;
                        wnd.Width = 300;
                        wnd.Content = new View.ViewKlapanProperty(vmp);
                        wnd.Show();
                    }
);
                return _cmdNewKlapan;
            }
        }
        public ICommand cmdNewLispKlapan
        {
            get
            {
                if (_cmdNewLispKlapan == null)
                    _cmdNewLispKlapan = new RelayCommand(param =>
                    {
                        ViewModelLispKlapan vmp = new ViewModelLispKlapan(MC);
                        Window wnd = new Window();
                        wnd.Height = 470;
                        wnd.Width = 300;
                        wnd.Content = new View.ViewLispProperty(vmp);
                        wnd.Show();
                    }
);
                return _cmdNewLispKlapan;
            }
        }
        public ICommand cmdNewDp
        {
            get
            {
                if (_cmdNewDp == null)
                    _cmdNewDp = new RelayCommand(param =>
                    {
                        ViewModelDP vmp = new ViewModelDP(MC);
                        Window wnd = new Window();
                        wnd.Height = 470;
                        wnd.Width = 300;
                        wnd.Content = new View.ViewDPProperty(vmp);

                        wnd.Show();
                    }
);
                return _cmdNewDp;
            }
        }
        public ICommand cmdEditPatch
        {
            get
            {
                if (_cmdEditPatch == null) _cmdEditPatch = new RelayCommand(param => EditPatch(param));
                return _cmdEditPatch;
            }
        }
        public ICommand cmdVariableVar
        {
            get
            {
                if (_cmdVariableVar == null)
                    _cmdVariableVar = new RelayCommand(param => {
                        var vm = ViewModelVariableList.Instance;
                        var cont = new View.ViewVariableM();
                        cont.lauotRoot.DataContext = vm;
                        Window wnd = new Window();
                        wnd.Height = 470;
                        wnd.Width = 300;
                        wnd.Content = cont;
                        wnd.Show();
                    });
                return _cmdVariableVar;
            }
        }

        RelayCommand cmdOrder;
       
        public ICommand CmdOrder
        {
            get
            {
                if (cmdOrder == null)
                    cmdOrder = new RelayCommand(param =>
                    {

                        if (_mc.SelectedGraphics != null)
                        {
                            _mc.DeSelectLine();
                            _mc.SendToBack();
                        }
                        List<ViewModelGraphics> lst = new List<ViewModelGraphics>();
                        lst.Add(_mc.SelectedViewModelGraphics);
                        for (int i = 0; i < _mc.AllPatch.Count; i++)
                        {
                            if (_mc.AllPatch[i].Name != _mc.SelectedViewModelGraphics.Name)
                                lst.Add(_mc.SelectedViewModelGraphics);


                        }
                    }
);
                return cmdOrder;
            }
        }

        RelayCommand cmdedit;
        public ICommand CmdEditPen
        {
            get
            {
                if (cmdedit == null)
                    cmdedit = new RelayCommand(param =>
                    {
                        var cont = new ViewPenEditor();
                        Window wnd = new Window();
                        wnd.Height = 350;
                        wnd.Width = 600;
                        wnd.Content = cont;
                        wnd.ShowDialog();


                    }
 );
                return cmdedit;
            }
        }
        public ICommand CmdEditRout
        {
            get
            {
                if (_cmdroutedit == null)
                    _cmdroutedit = new RelayCommand(param =>
                    {
                        var cont = new View.ViewRouted(this.Routed);
                        Window wnd = new Window();
                        wnd.Height = 600;
                        wnd.Width = 550;
                        wnd.Content = cont;
                        wnd.Show();

                    }
);
                return _cmdroutedit;
            }
        }


        private void EditPatch(object sender)
        {
            if (MC.SelectedGraphics != null)
            {
                Window wnd = new Window();
              
                switch (MC.SelectedGraphics.TVisual)
                {
                    case 1:
                        {
                            ViewModelPatch vmp = (ViewModelPatch)MC.SelectedViewModelGraphics;
                            wnd.Content = new View.ViewPatchProperty(vmp); break;
                        }
                    case 2:
                        {
                            ViewModelDP dp = (ViewModelDP)MC.SelectedViewModelGraphics;
                            wnd.Content = new View.ViewDPProperty(dp); break;
                        }
                    case 3:
                        {
                            ViewModelKlapan dp = (ViewModelKlapan)MC.SelectedViewModelGraphics;
                            wnd.Content = new View.ViewKlapanProperty(dp); break;
                        }
                    case 4:
                        {
                            ViewModelValueLabel dp = (ViewModelValueLabel)MC.SelectedViewModelGraphics;
                            wnd.Content = new View.ViewLabelPropety(dp); break;
                        }
                    case 5:
                        {
                            ViewModelarcBalon dp = (ViewModelarcBalon)MC.SelectedViewModelGraphics;
                            wnd.Content = new View.ViewarcBalon(dp); break;
                        }
                    case 7:
                        {
                            ViewModelColorInd dp = (ViewModelColorInd)MC.SelectedViewModelGraphics;
                            wnd.Content = new View.ViewColorIndicatorProperty(dp); break;

                        }
                    case 8:
                        {
                            ViewModelAnimKlapan dp = (ViewModelAnimKlapan)MC.SelectedViewModelGraphics;
                            wnd.Content = new View.ViewAnimKlapanProperty(dp);
                            break;
                        }
                    case 122:
                        {
                            ViewModelLispKlapan dp = (ViewModelLispKlapan)MC.SelectedViewModelGraphics;
                            wnd.Content = new View.ViewLispProperty(dp); break;

                        }


                }
                /*  ViewModelPatch vmp = new ViewModelPatch(MC, (GraphicsPatch)MC.SelectedGraphics);
                //  vmp.EditPatch(SelectedGraphics, MC);
                  Window wnd = new Window();
                  wnd.Content = new View.ViewPatchProperty(vmp);*/

                wnd.Show();

            }

        }

        private void NewPatch(Object sender)
        {
            ViewModelPatch vmp = new ViewModelPatch(MC);
            // vmp.AddNewPatch(MC);       


            Window wnd = new Window();
            wnd.Content = new View.ViewPatchProperty(vmp);


            wnd.Show();

        }


        #endregion
    }

}



