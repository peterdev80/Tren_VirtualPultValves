using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseModel;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class OtvodPodvodViewModel: MnemoViewModel
    {
        BitIntVar val1,val2;

        public IntValue mH_AC3 { get; private set; }
        public IntValue mH_AC1 { get; private set; }
        public IntValue mH_podvod { get; private set; }
        public IntValue mH_38 { get; private set; }
        public IntValue m_SYGN187 { get; private set;}
        public IntValue mH_AC2 { get; private set; }
        public IntValue mH_AC5 { get; private set; }
        public XORIntValue mDpo_Otvod17_18 { get; private set; }
        public XORIntValue mDpo_Otvod27_28 { get; private set; }
        public IntValue mHotvod17_18 { get; private set; }
        public IntValue mHotvod27_28 { get; private set; }
        public IntValue mHotvod17_28 { get; private set; }
        public IntValue mHOtvod { get; private set; }
        public IntValue mHovk12 { get; private set; }
        public IntValue mHovk14 { get; private set; }
        public IntValue mOCM_KR_19 { get; private set; }
        public IntValue mRR_KR_19 { get; private set; }
        public IntValue mOCM_KR_148 { get; private set; }
        public IntValue mRR_KR_148 { get; private set; }
        public IntValue mH_12_8 { get; private set; }
        public IntValue mH_12_18 { get; private set; }
        public IntValue mH_12_60 { get; private set; }
        public IntValue mH_12_10 { get; private set; }
        public IntValue mH_12_12m { get; private set; }
        public IntValue mH_D8 { get; private set; }
        public IntValue mH_D5 { get; private set; }
        public IntValue mH_OK51 { get; private set; }
        public IntValue mH_OTVOD { get; private set; }
        public IntValue mHV_OTVOD { get; private set; }
        public IntValue mH_G5 { get; private set; }
        public IntValue mH_G7 { get; private set; }
        public IntValue mH_G15 { get; private set; }
        public IntValue mH_Sch43 { get; private set; }
        public IntValue mSYGN80 { get; private set; }
        public IntValue mSYGN221 { get; private set; }
        public IntValue mSYGN212 { get; private set; }
        public IntValue mSYGN213 { get; private set; }
        public IntValue mH_Sch59 { get; private set; }
        public IntValue m_p37 { get; private set; }
        public IntValue mResv_b82 { get; private set; }
        public IntValue mResv_b83 { get; private set; }
        public IntValue mYZ41 { get; private set; }
        public IntValue mYZ40 { get; private set; }
        public IntValue mSYGN52 { get; private set; }
        public IntValue mQ51 { get; private set; }
        public IntValue kH772 { get; private set; }
        public IntValue kYZ39 { get; private set; }
        public IntValue kSYGN49 { get; private set; }
        public IntValue kK3203 { get; private set; }
        public IntValue mH1049 { get; private set; }
        public IntValue mA80 { get; private set; }
        public IntValue mA79 { get; private set; }
        public IntValue mA47 { get; private set; }
        public IntValue kY_DP_AC2 { get; private set; }
        public IntValue YshDPOB2 { get; private set; }


        public OtvodPodvodViewModel()
        {
            base.DisplayName = "Управление ДПО-Б по командам из ССВП";
            List<int> ls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            val1 = new BitIntVar("Mnemo", ls);
            val1.VarName = "__DPOB_1";

            
            mH_AC1 = val1.ValState[0];
            mH_podvod = val1.ValState[1];
            m_SYGN187 = val1.ValState[2];
            mH_38 = val1.ValState[3];
            mH_AC2 = val1.ValState[4];
            mH_AC3 = val1.ValState[5];
            mH_AC5 = val1.ValState[6];
            mHotvod17_18 = val1.ValState[7];
            mHOtvod = val1.ValState[8];
            mHotvod27_28 = val1.ValState[9];
            mHotvod17_28 = val1.ValState[10];
            mHovk12 = val1.ValState[11];
            mHovk14 = val1.ValState[12];
            mOCM_KR_19 = val1.ValState[13];
            mRR_KR_19= val1.ValState[14];
            mOCM_KR_148 = val1.ValState[15];
            mRR_KR_148 = val1.ValState[16];
            mH_12_8 = val1.ValState[17];
            mH_12_18 = val1.ValState[18];
            mH_12_60 = val1.ValState[19];
            mH_12_10 = val1.ValState[20];
            mH_12_12m = val1.ValState[21];
            mH_D8 = val1.ValState[22];
            mH_D5 = val1.ValState[23];
            mH_OK51 = val1.ValState[24];
            mH_OTVOD = val1.ValState[25];
            mHV_OTVOD = val1.ValState[26];
            mH_G5 = val1.ValState[27];
            mH_G7 = val1.ValState[28];
            mH_G15 = val1.ValState[29];
            mH_Sch43 = val1.ValState[30];


            mDpo_Otvod17_18 = new XORIntValue();
            mDpo_Otvod17_18.AddVal(val1.ValState[7]);
            mDpo_Otvod17_18.AddVal(val1.ValState[10]);
            mDpo_Otvod17_18.AddVal(val1.ValState[25]);


              mDpo_Otvod27_28 = new XORIntValue();
              mDpo_Otvod27_28.AddVal(val1.ValState[9]);
              mDpo_Otvod27_28.AddVal(val1.ValState[10]);
            mDpo_Otvod27_28.AddVal(val1.ValState[26]);

            val2 = new BitIntVar("Mnemo", ls);
            val2.VarName = "__DPOB_2";
            mSYGN80 = val2.ValState[0];
            mSYGN221 = val2.ValState[1];
            mSYGN212 = val2.ValState[2];
            mSYGN213 = val2.ValState[3];
           //4 free
            //5
            //6
            mH_Sch59 = val2.ValState[7];
            m_p37 = val2.ValState[8];
            mResv_b82 = val2.ValState[9];
            mResv_b83 = val2.ValState[10];
            mYZ41 = val2.ValState[11];
            mYZ40 = val2.ValState[12];
            mSYGN52 = val2.ValState[13];
            mQ51 = val2.ValState[14];
            kH772 = val2.ValState[15];
            kYZ39 = val2.ValState[16];
            kSYGN49 = val2.ValState[17];
            kK3203 = val2.ValState[18];
            
            //19
            mH1049 = val2.ValState[20];
            mA80 = val2.ValState[21];
            mA79 = val2.ValState[22];
            mA47 = val2.ValState[23];
            kY_DP_AC2 = val2.ValState[24];
            YshDPOB2 = val2.ValState[25];

           // mDpo_Otvod17_18 = new XORIntValue(val1.ValState[7], val1.ValState[10]);
          //  mDpo_Otvod27_28 = new XORIntValue(val1.ValState[9], val1.ValState[10]);
            
          

        }
    }
}
