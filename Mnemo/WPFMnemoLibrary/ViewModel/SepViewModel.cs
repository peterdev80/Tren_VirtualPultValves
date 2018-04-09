using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ValueModel.BaseModel;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class SepViewModel : MnemoViewModel
    {
        BitIntVar val1, val2, val3, val4,val5;
        FloatVar _s6, _s7, _s8, _s9, _s10;
       // IntVar _tISA;


        public IntValue mM_asepmn28RV15 { get; private set; }
        public IntValue mM_asepmn28p15 { get; private set; }
        public IntValue mM_asepmk34RV10 { get; private set; }
        public IntValue mM_asepmk34 { get; private set; }
        public IntValue mM_asepmk34p10 { get; private set; }
        public IntValue mM_asepmn24RV5s { get; private set; }
        public IntValue mM_asepmn24 { get; private set; }
        public IntValue mM_asepmn24RV15 { get; private set; }
        public IntValue mM_asepmn24p5 { get; private set; }
        public IntValue mM_asepmn24p15s { get; private set; }
        public IntValue mM_asepmn23RV5 { get; private set; }
        public IntValue mM_asepmn23RV15 { get; private set; }
        public IntValue mM_asepmn23p5 { get; private set; }
        public IntValue mM_asepmn23p15 { get; private set; }
        public IntValue mM_k50a { get; private set; }
        public IntValue mM_apvu1 { get; private set; }
        public IntValue mM_apvu2 { get; private set; }
        public IntValue mM_apvu3 { get; private set; }
        public IntValue mM_t1 { get; private set; }
        public IntValue mM_t2 { get; private set; }
        public IntValue mM_t3 { get; private set; }
        public IntValue mM_t4 { get; private set; }
        public IntValue mM_t5 { get; private set; }
        public IntValue mM_t6 { get; private set; }
        public IntValue mM_t7 { get; private set; }
        public IntValue mM_t8 { get; private set; }
        public IntValue mM_t9 { get; private set; }
        public IntValue mM_t10 { get; private set; }
        public IntValue mM_t11 { get; private set; }
        public IntValue mM_t12 { get; private set; }
        public IntValue mM_tOBOGREV { get; private set; }

        public IntValue mM_S_E { get; private set; }
        public IntValue mM_mE1 { get; private set; }
        public IntValue mM_BB_EI { get; private set; }
        public IntValue mM_BB_mgE1 { get; private set; }
        public IntValue mM_RB_mE1 { get; private set; }
        public IntValue mM_SB1p_E1 { get; private set; }
        public IntValue mM_SB1l_E1 { get; private set; }
        public IntValue mM_SB1p_E_BB { get; private set; }
        public IntValue mM_SB1l_bb { get; private set; }
        public IntValue mM_mSbNabb { get; private set; }


        public IntValue mM_mzarjadBB { get; private set; }
        public IntValue mM_SB22p { get; private set; }
        public IntValue mM_SB21l { get; private set; }
        public IntValue mM_E1_E { get; private set; }
        public IntValue mM_E { get; private set; }
        public IntValue mM_NgrPO { get; private set; }
        public IntValue mM_E_Ce { get; private set; }
        public IntValue mM_Ce_C { get; private set; }
        public IntValue mM_NgSA { get; private set; }



        public IntValue mM_E_NgrBO { get; private set; }
        public IntValue mM_BSA_C { get; private set; }
        public IntValue mM_v1 { get; private set; }
        public IntValue mM_v2 { get; private set; }
        public IntValue mM_asepDP7 { get; private set; }
        public IntValue mM_asepDP9 { get; private set; }
        public IntValue mM_ISA4_SB { get; private set; }
        public IntValue mM_asepDP8 { get; private set; }
        public IntValue mM_mn28_SB { get; private set; }
        public IntValue mM_PODZARJAD { get; private set; }


        public FloatValue S6 { get;private set;}
        public FloatValue S7 { get; private set; }
        public FloatValue S8 { get; private set; }
        public FloatValue S9 { get; private set; }
        public FloatValue S10 { get; private set; }

        public IntValue tISA { get; private set; }


        public IntValue mE_msBB { get; private set; }
        public IntValue mE_ms18 { get; private set; }
        public IntValue mE_ms4 { get; private set; }
        public IntValue mE_ms12 { get; private set; }
        public IntValue mE_ms16 { get; private set; }
        public IntValue mE_ms8 { get; private set; }
        public IntValue mE_ms9 { get; private set; }
        public IntValue mE_ms6 { get; private set; }
        public IntValue mE_ms5 { get; private set; }
        public IntValue mE_msSB1p { get; private set; }
        public IntValue mE_msSB1l { get; private set; }
        public IntValue mE_msSB2p { get; private set; }
        public IntValue mE_msSB2l { get; private set; }
        public IntValue mE_ms2 { get; private set; }
        public IntValue mE_ms1 { get; private set; }
        public IntValue mE_ms3 { get; private set; }
        public IntValue mE_ms19 { get; private set; }
        public IntValue mE_ms7 { get; private set; }
        public IntValue mE_ms10 { get; private set; }
        public IntValue mE_ms11 { get; private set; }
        public IntValue mE_ms13 { get; private set; }
        public IntValue mE_ms14 { get; private set; }
        public IntValue mE_ms15 { get; private set; }
        public IntValue mE_ms16_20 { get; private set; }
        public IntValue mE_ms17 { get; private set; }
        public IntValue mE_msRB { get; private set; }
        public IntValue mE_ms21 { get; private set; }
        public IntValue mE_ms22 { get; private set; }
        public IntValue mE_ms23 { get; private set; }
        public IntValue mE_ms24 { get; private set; }
        public IntValue mE_ms25 { get; private set; }
        public IntValue mE_ms26 { get; private set; }
        public IntValue mE_ms27 { get; private set; }
        public IntValue mE_ms28 { get; private set; }
        public IntValue mE_ms29 { get; private set; }
        public IntValue mE_ms30 { get; private set; }
        public IntValue mE_ms31 { get; private set; }
        public IntValue mE_ms32 { get; private set; }
       



        public SepViewModel()
        {

         
            // Код для доступа к битам переменной
            base.VarName = new List<string>();
            base.VarName.Add("__SEP_1");
            //расписать переменные
            List<int> ls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            val1 = new BitIntVar("Mnemo", ls);
            val1.VarName = "__SEP_2";
            ///SEP_2_AT
            mM_asepmn28RV15 = val1.ValState[0];
            mM_asepmn28p15 = val1.ValState[1];
            mM_asepmk34RV10 = val1.ValState[2];
            mM_asepmk34 = val1.ValState[3];
            mM_asepmk34p10 = val1.ValState[4];
            mM_asepmn24RV5s = val1.ValState[5];
            mM_asepmn24 = val1.ValState[6];
            mM_asepmn24RV15 = val1.ValState[7];
            mM_asepmn24p5 = val1.ValState[8];
            mM_asepmn24p15s = val1.ValState[9];
            mM_asepmn23RV5 = val1.ValState[10];
            mM_asepmn23RV15 = val1.ValState[11];
            mM_asepmn23p5 = val1.ValState[12];
            mM_asepmn23p15 = val1.ValState[13];
            mM_k50a = val1.ValState[14];
            mM_apvu1 = val1.ValState[15];
            mM_apvu2 = val1.ValState[16];
            mM_apvu3 = val1.ValState[17];
            mM_t1 = val1.ValState[18];
            mM_t2 = val1.ValState[19];
            mM_t3 = val1.ValState[20];
            mM_t4 = val1.ValState[21];
            mM_t5 = val1.ValState[22];
            mM_t6 = val1.ValState[23];
            mM_t7 = val1.ValState[24];
            mM_t8 = val1.ValState[25];
            mM_t9 = val1.ValState[26];
            mM_t10 = val1.ValState[27];
            mM_t11 = val1.ValState[28];
            mM_t12 = val1.ValState[29];
            mM_tOBOGREV = val1.ValState[30];

            List<int> ls2 = new List<int> { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
            val2 = new BitIntVar("Mnemo", ls2);
            val2.VarName = "__SEP_3";
           
            mE_msBB= val2.ValState[0];
            mE_ms18= val2.ValState[1];
            mE_ms4 = val2.ValState[2];
            mE_ms12= val2.ValState[3];
            mE_ms16= val2.ValState[4];
            mE_ms8 = val2.ValState[5];
            mE_ms9  = val2.ValState[6];
            mE_ms6  = val2.ValState[7];
            mE_ms5  = val2.ValState[8];
            mE_msSB1p= val2.ValState[9];
                
            


            //SEP_M1
        /*    mM_S_E = val2.ValState[0];
            mM_mE1 = val2.ValState[1];
            mM_BB_EI = val2.ValState[2];
            mM_BB_mgE1 = val2.ValState[3];
            mM_RB_mE1 = val2.ValState[4];
            mM_SB1p_E1 = val2.ValState[5];
            mM_SB1l_E1 = val2.ValState[6];
            mM_SB1p_E_BB = val2.ValState[7];
            mM_SB1l_bb = val2.ValState[8];
            mM_mSbNabb = val2.ValState[9];*/

            val3 = new BitIntVar("Mnemo", ls2);
            val3.VarName = "__SEP_4";


            mE_msSB1l = val3.ValState[0];
            mE_msSB2p = val3.ValState[1];
            mE_msSB2l = val3.ValState[2];
            mE_ms2   = val3.ValState[3];
            mE_ms1   = val3.ValState[4];
            mE_ms3   = val3.ValState[5];
            mE_ms19  = val3.ValState[6];
            mE_ms7   = val3.ValState[7];
            mE_ms10  = val3.ValState[8];
            mE_ms11  = val3.ValState[9];


          /*  mM_mzarjadBB = val3.ValState[0];
            mM_SB22p = val3.ValState[1];
            mM_SB21l = val3.ValState[2];
            mM_E1_E = val3.ValState[3];
            mM_E = val3.ValState[4];
            mM_NgrPO = val3.ValState[5];
            mM_E_Ce = val3.ValState[6];
            mM_Ce_C = val3.ValState[7];
            mM_NgSA = val3.ValState[8];*/

            List<int> ls3 = new List<int> { 3, 3, 3, 3, 3, 3 };
            val4 = new BitIntVar("Mnemo", ls3);
            val4.VarName = "__SEP_5";

             mE_ms13  = val4.ValState[0];
            mE_ms14  = val4.ValState[1];
            mE_ms15  = val4.ValState[2];
            mE_ms16_20 = val4.ValState[3];
            mE_ms17 = val4.ValState[4];
            mE_msRB = val4.ValState[5];


            val5 = new BitIntVar("Mnemo", ls);
            val5.VarName = "__SEP_5";
            
            
            
            
            
            
            
            
            mE_ms21= val5.ValState[30];
            mE_ms22= val5.ValState[19];
            mE_ms23= val5.ValState[20];
            mE_ms24= val5.ValState[21];
            mE_ms25= val5.ValState[22];
            mE_ms26= val5.ValState[23];
            mE_ms27= val5.ValState[24];
            mE_ms28= val5.ValState[25];
            mE_ms29= val5.ValState[26];
            mE_ms30= val5.ValState[27];
            mE_ms31 = val5.ValState[28];
            mE_ms32 = val5.ValState[29];





          /*  mM_E_NgrBO = val4.ValState[0];
            mM_BSA_C = val4.ValState[1];
            mM_v1 = val4.ValState[2];
            mM_v2 = val4.ValState[3];
            mM_asepDP7 = val4.ValState[4];
            mM_asepDP9 = val4.ValState[5];
            mM_ISA4_SB = val4.ValState[6];
            mM_asepDP8 = val4.ValState[7];
            mM_mn28_SB = val4.ValState[8];
            mM_PODZARJAD = val4.ValState[9];*/


            _s6 = new FloatVar("Mnemo");
            _s6.VarName = "__SEP_6";
            S6 = _s6.ValState;

            _s7 = new FloatVar("Mnemo");
            _s7.VarName = "__SEP_7";
            S7 = _s7.ValState;

            _s8 = new FloatVar("Mnemo");
            _s8.VarName = "__SEP_8";
            S8 = _s8.ValState;

            _s9 = new FloatVar("Mnemo");
            _s9.VarName = "__SEP_9";
            S9 = _s9.ValState;

            _s10 = new FloatVar("Mnemo");
            _s10.VarName = "__SEP_10";
            S10 = _s10.ValState;

           
            tISA = new IntValue();
            tISA.ValueState = 1;








        }
    }
}