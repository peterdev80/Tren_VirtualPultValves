using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFMnemoLibrary.Model;
using System.Collections.ObjectModel;


namespace WPFMnemoLibrary.ViewModel
{
    public abstract class MnemoViewModel : ViewModelBase
    {
        private ObservableCollection<MnemoValStateVar> _ListValStateVariable;
        protected List<string> VarName { get; set; }
        public ObservableCollection<MnemoValStateVar> ListValStateVariable
        {
            get
            {
                if (_ListValStateVariable == null)
                {
                    List<MnemoValStateVar> ls = new List<MnemoValStateVar>();
                    for (int i = 0; i < VarName.Count; i++)
                    {
                        MnemoValStateVar v = new MnemoValStateVar();
                        v.VarName = VarName[i];
                        ls.Add(v);
                    }
                    _ListValStateVariable = new ObservableCollection<MnemoValStateVar>(ls);

                }
                return _ListValStateVariable;
            }
        }
    }
}
