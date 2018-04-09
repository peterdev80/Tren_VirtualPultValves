using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseModel;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class PitSSWPViewModel : MnemoViewModel
    {
        BitIntVar val1;
        public IntValue mH_ms20 { get; private set; }
        public IntValue mH_ms21 { get; private set; }
        public IntValue mH_ms22 { get; private set; }
        public IntValue mH_ms23 { get; private set; }
        public IntValue mH_ms24 { get; private set; }
        public IntValue mH_ms27 { get; private set; }


        public IntValue mH_D7 { get; private set; }
        public IntValue mH_V5 { get; private set; }
        public IntValue mH_D9 { get; private set; }
        public IntValue mH_D11 { get; private set; }
        public IntValue mH_12_60c { get; private set; }
        public IntValue mH_AC2 { get; private set; }
        public IntValue mH_D13 { get; private set; }
        public IntValue mH_G17 { get; private set; }
        public IntValue mH_12_180c { get; private set; }
        public IntValue mH_D15 { get; private set; }
        public IntValue mH_D17 { get; private set; }
        public IntValue mH_D8 { get; private set; }
        public IntValue mH_12_12m { get; private set; }
        public IntValue mH_D5 { get; private set; }
        public IntValue mH_ms25 { get; private set; }
        public IntValue mH_ms28 { get; private set; }

        public PitSSWPViewModel()
        {
            base.DisplayName = "Питание SSWP";
            List<int> ls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            val1 = new BitIntVar("Mnemo", ls);
            val1.VarName = "__PITSSVP";

            mH_ms20 = val1.ValState[0];
            mH_ms21 = val1.ValState[1];
            mH_ms22 = val1.ValState[2];
            mH_ms23 = val1.ValState[3];
            mH_ms24 = val1.ValState[4];
            //5
            mH_ms27 = val1.ValState[6];
            mH_D7 = val1.ValState[7];
            mH_V5 = val1.ValState[8];
            mH_D9 = val1.ValState[9];
            mH_D11 = val1.ValState[10];
            mH_12_60c = val1.ValState[11];
            mH_AC2 = val1.ValState[12];
            mH_D13 = val1.ValState[13];
            mH_G17 = val1.ValState[14];
            mH_12_180c = val1.ValState[15];
            mH_D15 = val1.ValState[16];
            mH_D17 = val1.ValState[17];
            mH_D8 = val1.ValState[18];
            mH_12_12m = val1.ValState[19];
            mH_D5 = val1.ValState[20];
            mH_ms25 = val1.ValState[21];
            mH_ms28 = val1.ValState[21];


        }
    }
}
