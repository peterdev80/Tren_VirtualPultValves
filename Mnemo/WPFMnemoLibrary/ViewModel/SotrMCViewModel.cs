using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseModel;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class SotrMCViewModel : MnemoViewModel
    {
        BitVar val1;
        public BoolValue K1 { get; set; }
        public BoolValue K2 { get; set; }

        public SotrMCViewModel()
        {
            List<int> ls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            val1 = new BitVar("Mnemo");
            val1.VarName = "__MNEMO_RES_5";
            K1 = val1.ValState[0];
            K2 = val1.ValState[1];
            
        }
    }
}
