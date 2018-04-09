using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using System.ComponentModel;
using VirtualPultValves.DataAccess;

namespace VirtualPultValves.ViewModel
{
   public class AllValvesViewModel:ViewModelBase
    {
       public ObservableCollection<ValvesValueViewModel> ValvesList { get; private set; }

       public AllValvesViewModel()
       {
          /* List<ValvesValueViewModel> all =
             (from name in ValvesRepository.GetNames("")
              select new ValvesValueViewModel(name)).ToList();
         

             this.ValvesList = new ObservableCollection<ValvesValueViewModel>(all);*/
       }

       protected override void OnDispose()
       {
           foreach (ValvesValueViewModel valVM in this.ValvesList)
               valVM.Dispose();
           ValvesList.Clear();

       }
      

    }
}
