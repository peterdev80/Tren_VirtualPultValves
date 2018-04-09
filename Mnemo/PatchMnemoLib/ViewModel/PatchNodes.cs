using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;

namespace PatchMnemoLib.ViewModel
{
   public class PatchNodes:  DependencyObject
    {
        private ObservableCollection<ViewModelPatch> _nodeElements=new ObservableCollection<ViewModelPatch>();


        public ObservableCollection<ViewModelPatch> NodeElement
        {
            get { return _nodeElements; }
            set
            {
                _nodeElements = value;
            }
        }
   
   
   
   }
    
    
}
