using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseModel;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class SMVViewModel : ViewModelBase
    {
        IntVar val1;
        public IntValue Val1 { get; private set; }

        public SMVViewModel()
        {
            val1 = new IntVar("Mnemo");
            val1.VarName = "__VENT_1";
            Val1 = val1.ValState;
            this.DisplayName = "gggggggg";
        }

    }
}
