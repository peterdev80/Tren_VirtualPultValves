using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseModel;

using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class SOTRViewModel: ViewModelBase
    {


        IntVar host1;
        IntVar _valk;
        IntVar _valk1;
        
        FloatVar _fDTV1;
        FloatVar _fDTV2;
        FloatVar _fGA;
        FloatVar _fDTJ;
        FloatVar _fDD1;
        FloatVar _fDD2;
        FloatVar _fDTJ1;
        FloatVar _fDTG;
        
        
        public IntValue Val1 { get; private set; }
        public IntValue ValK { get; private set; }
        public IntValue ValK1 { get; private set; }
        public FloatValue fDTV1 { get; private set; }
        public FloatValue fDTV2 { get; private set; }
        public FloatValue fGA { get; private set; }
        public FloatValue fDTJ { get; private set; }
        public FloatValue fDD1 { get; private set; }
        public FloatValue fDD2 { get; private set; }
        public FloatValue fDTJ1 { get; private set; }
        public FloatValue fDTG { get; private set; }
        public SOTRViewModel()
        {
            //int var
             host1 = new IntVar("Mnemo");
            host1.VarName = "__MNEMO_RES_4";
            Val1 = host1.ValState;
           _valk = new IntVar("Mnemo");
            _valk.VarName = "__MNEMO_RES_5";
            ValK = _valk.ValState;
             _valk1 = new IntVar("Mnemo");
            _valk1.VarName = "__MNEMO_RES_6";
            ValK1 = _valk1.ValState;
            //float var
            _fDTV1 = new FloatVar("Mnemo");
            _fDTV1.VarName = "__MNEMO_RES_21";
            fDTV1 = _fDTV1.ValState;

            _fDTV2 = new FloatVar("Mnemo");
            _fDTV2.VarName = "__MNEMO_RES_22";
            fDTV2 = _fDTV2.ValState;

            _fGA = new FloatVar("Mnemo");
            _fGA.VarName = "__MNEMO_RES_23";
            fGA = _fGA.ValState;

            _fDTJ = new FloatVar("Mnemo");
            _fDTJ.VarName = "__MNEMO_RES_24";
            fDTJ = _fDTJ.ValState;

            _fDD1 = new FloatVar("Mnemo");
            _fDD1.VarName = "__MNEMO_RES_25";
            fDD1 = _fDD1.ValState;

            _fDD2 = new FloatVar("Mnemo");
            _fDD2.VarName = "__MNEMO_RES_26";
            fDD2 = _fDD2.ValState;

            _fDTJ1 = new FloatVar("Mnemo");
            _fDTJ1.VarName = "__MNEMO_RES_27";
            fDTJ1 = _fDTJ1.ValState;

            _fDTG = new FloatVar("Mnemo");
            _fDTG.VarName = "__MNEMO_RES_28";
            fDTG = _fDTG.ValState;

            
        }
        
    }
}
