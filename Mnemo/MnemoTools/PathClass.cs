using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections;

namespace MnemoTools
{
    public class PathClass : ObservableCollection<string> 
    {
        public PathClass():base()
        {
            _ListPatch=new ArrayList();
        }
        //public ObservableCollection<string> OL = new ObservableCollection<string>();
       private ArrayList _ListPatch;
        public ArrayList ListPatch
        {
           // get { return _ListPatch; }
            set {
                _ListPatch = value;
                Clear();
                foreach (string s in _ListPatch)
                {
                    Add(s);
                  
                }
            }
        }

    }
}
