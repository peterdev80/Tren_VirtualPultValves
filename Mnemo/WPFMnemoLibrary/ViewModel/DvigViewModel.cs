using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseModel;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class DvigViewModel : ViewModelBase
    {
        public IntValue DVIG1 { get; set; }
        private IntVar DVi;
        public DvigViewModel()
        {
            base.DisplayName = "Расположение двигателей";
          DVi = new IntVar("Mnemo");
          DVi.VarName = "__DPO_1";
          DVIG1 = DVi.ValState;
           
        }

    }
}
