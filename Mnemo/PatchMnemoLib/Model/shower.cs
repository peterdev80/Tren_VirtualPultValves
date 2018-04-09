using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace PatchMnemoLib.Model
{
     [Serializable]
   public class Shower
    {
         public Shower()
         {
           //  NameGraphics = new ObservableCollection<StringItem>();
         }
         public string Name { get; set; }
         public string ValueName { get; set; }
         public string ValueType { get; set; }
         public string ValueRem { get; set; }
         public string NameGraphics { get; set; }
    }
}
