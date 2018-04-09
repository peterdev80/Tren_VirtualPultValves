using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseModel;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class SUViewModel: ViewModelBase
    {
        private IntVar _Val1;
        private IntVar _Val2;
        private IntVar _ValK;
        private IntVar _ValT;
        private IntVar _ValMA;
        private FloatVar _ValPCA;
        private FloatVar _ValPOB;
        private FloatVar _ValPBO;
        private FloatVar _ValPCY;
        private FloatVar _ValWPBO;

        public IntValue   Val1  {get; private set;}
        public IntValue   Val2  {get; private set;}
        public IntValue   ValK   {get; private set;}
        public IntValue   ValT   { get; private set; }
        public IntValue   ValMA  { get; private set; }
        public FloatValue ValPCA { get; private set; }
        public FloatValue ValPOB { get; private set; }
        public FloatValue ValPBO { get; private set; }
        public FloatValue ValPCY { get; private set; }
        public FloatValue ValWPBO { get; private set; }

        public SUViewModel()
        {
            _Val1 = new IntVar("Mnemo");
            _Val2 = new IntVar("Mnemo");
            _ValK = new IntVar("Mnemo");
            _ValT = new IntVar("Mnemo");
            _ValMA = new IntVar("Mnemo");
            _ValPCA = new FloatVar("Mnemo");
            _ValPOB = new FloatVar("Mnemo");
            _ValPBO = new FloatVar("Mnemo");
            _ValPCY = new FloatVar("Mnemo");
            _ValWPBO = new FloatVar("Mnemo");

            _Val1.VarName = "__SKGS_1";
            _Val2.VarName = "__SKGS_2";
            _ValK.VarName = "__MNEMO_RES_1";
            _ValT.VarName = "__MNEMO_RES_2";
            _ValMA.VarName = "__MNEMO_RES_3";
            _ValPCA.VarName = "__MNEMO_RES_16";
            _ValPOB.VarName = "__MNEMO_RES_17";
            _ValPBO.VarName = "__MNEMO_RES_18";
            _ValPCY.VarName = "__MNEMO_RES_20";
            _ValWPBO.VarName = "__MNEMO_RES_19"; 


            Val1=_Val1.ValState;  
            Val2=_Val2.ValState;   
            ValK=_ValK.ValState;     
            ValT=_ValT.ValState;     
            ValMA=_ValMA.ValState;   
            ValPCA=_ValPCA.ValState;   
            ValPOB=_ValPOB.ValState;   
            ValPBO=_ValPBO.ValState;   
            ValPCY=_ValPCY.ValState;            
            ValWPBO = _ValWPBO.ValState;
            ValWPBO.Round = true;

        }


    }
}
