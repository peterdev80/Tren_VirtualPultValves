using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace PatchMnemoLib.Model
{
    [Serializable]
   public class KlapanItem
    {
        public string GData { get;  set; }
        public Color GBrush { get; set; }
        public Color GPen { get;  set; }
        public double GpenSize { get; set; }

        public  KlapanItem()
        {
            GPen = Colors.Black;
            GBrush = Colors.Transparent;
            GpenSize = 1;
            GData = "";
           
        }
    }
}
