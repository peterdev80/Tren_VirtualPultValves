using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Media;
using PatchMnemoLib.Model;

namespace PatchMnemoLib.ViewModel
{
   /* public class _MnemoPen:ViewModelBase
    {
        private Route Marshrut;
        private List<Pen> MPen;
        public _MnemoPen(Route val)
        {
            Marshrut = val;
        }
        public ObservableCollection<StringItem> ListPen
        {
            get { return Marshrut.NamePen; }
            set { Marshrut.NamePen = value; }

        }
        private void setPen()
        {
            foreach (var st in Marshrut.NamePen)
            {



                MPen.Add(viewModelMnemoAnimPen.Instance.GetPen(st.Value));

            }
        }
        public void AddPen(string NamePen)
        {
            //  if (!Marshrut.NamePen.Contains<string>(NamePen))
            {

                // Marshrut.NamePen.Add(NamePen);
                StringItem sti = new StringItem();
                sti.Value = NamePen;

                ListPen.Add(sti);
                MPen.Add(viewModelMnemoAnimPen.Instance.GetPen(NamePen));
               
            }
        }

    }*/
}
