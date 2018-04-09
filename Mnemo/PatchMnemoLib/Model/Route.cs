using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace PatchMnemoLib.Model
{
     [Serializable]
    public class Route
    {
        public Route()
        {
            NamePen = new ObservableCollection<StringItem>();
            NameGraphics = new ObservableCollection<StringItem>();
            ValueType = "BitStruct";
           

        }
        public string Name { get; set; }
        public ObservableCollection<StringItem> NamePen { get; set; }
        public ObservableCollection<StringItem> NameGraphics { get; set; }
        public string ValueName { get; set; }
        public string ValueRem { get; set; }
        public int TypRoute { get; set; }
         //тип реременной
        public string ValueType { get; set; }
        public int ValuePos { get; set; }

    }
}
