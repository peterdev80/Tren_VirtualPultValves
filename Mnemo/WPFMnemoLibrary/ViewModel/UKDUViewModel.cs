using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseModel;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class UKDUViewModel : MnemoViewModel
    {
        BitIntVar val1, val2, val3, valK;
        BitVar valKDU;
        public IntValue mM_Y_SH17 { get; private set; }
        public IntValue mM_Y_ovk16l1 { get; private set; }
        public IntValue mM_Y_ovk16l2 { get; private set; }
        public IntValue mM_Y_RUS3 { get; private set; }
        public IntValue mM_Y_L17 { get; private set; }
        public IntValue mM_Y_ovk18 { get; private set; }
        public IntValue mM_Y_AC1 { get; private set; }
        public IntValue mM_Y_L18 { get; private set; }
        public IntValue mM_Y_OK39 { get; private set; }
        public IntValue mM_Y_OK30_66 { get; private set; }
        public IntValue mM_Y_OK29_138 { get; private set; }
        public IntValue mM_Y_OK29_66 { get; private set; }
        public IntValue mM_Y_skd91 { get; private set; }
        public IntValue mM_Y_Skd_91 { get; private set; }
        public IntValue mM_Y_SKD91_100 { get; private set; }
        public IntValue mM_Y_SKD_91_100 { get; private set; }
        public IntValue mM_Y_SKD1 { get; private set; }
        public IntValue mM_Y_SH6_GK { get; private set; }
        public IntValue mM_Y_SH44 { get; private set; }
        public IntValue mM_Y_GK_AK { get; private set; }
        public IntValue mM_Y_OVK17 { get; private set; }
        public IntValue mM_Y_OVK13 { get; private set; }
        public IntValue mM_Y_SKD_2 { get; private set; }
        public IntValue mM_Y_vkLDPOBT { get; private set; }
        public IntValue mM_Y_DPOBT { get; private set; }
        public IntValue mM_Y_SH42 { get; private set; }
        public IntValue mM_Y_DPO13_16 { get; private set; }
        public IntValue mM_Y_DPO13_15 { get; private set; }
        public IntValue mM_Y_DPO14_16 { get; private set; }
        public IntValue mM_Y_STD2 { get; private set; }
        public IntValue mM_y_200ms { get; private set; }
        public IntValue mM_UD32 { get; private set; }
        public IntValue mM_Y_vlkDPOBT_UD17 { get; private set; }
        public IntValue mM_Y_PK_15 { get; private set; }
        public IntValue mM_Y_AC2 { get; private set; }
        public IntValue mM_K158 { get; private set; }

        public IntValue mM_Y_AC3 { get; private set; }
        public IntValue mM_Y_OK39_158 { get; private set; }
        public IntValue mM_SU6 { get; private set; }
        public IntValue mM_UD4 { get; private set; }
        public IntValue mM_OK2 { get; private set; }
        public IntValue mM_OK2_158 { get; private set; }

        public IntValue mmvK1  { get; private set; }
        public IntValue mmvK2  { get; private set; }
        public IntValue mmvK3  { get; private set; }
        public IntValue mmvK4  { get; private set; }
        public IntValue mmvK5  { get; private set; }
        public IntValue mmvK6  { get; private set; }
        public IntValue mmvK7  { get; private set; }
        public IntValue mmvK8  { get; private set; }
        public IntValue mmvK9  { get; private set; }
        public IntValue mmvK10 { get; private set; }
        public IntValue mmvK11 { get; private set; }
        public IntValue mmvK12 { get; private set; }
        public IntValue mmvK13 { get; private set; }
        public IntValue mmvK14 { get; private set; }
        public IntValue mmvTPC { get; private set; }

        /// <summary>
        /// new variable
        /// </summary>

        public IntValue mM_N_SKD2 { get; private set; }
        public IntValue mM_N_UD44 { get; private set; }
        public IntValue mM_N_OVK1 { get; private set; }
        public IntValue mM_N_02s { get; private set; }
        public IntValue mM_N_mP1_R { get; private set; }
        public IntValue mM_N_mP1_B { get; private set; }       
        public IntValue mM_N_mP2_R { get; private set; }
        public IntValue mM_N_mP2_B { get; private set; }
        public IntValue mM_N_mPD1_R { get; private set; }
        public IntValue mM_N_mPD1_B { get; private set; }
        public IntValue mM_N_mPD2_R { get; private set; }
        public IntValue mM_N_mPD2_B { get; private set; }
        public IntValue mM_N_mDRD_R { get; private set; }
        public IntValue mM_N_mDRD_B { get; private set; }
        public IntValue mM_N_Ce1 { get; private set; }
        public IntValue mM_N_Ce1_1s { get; private set; }
        public IntValue mM_N_Ce2 { get; private set; }
        public IntValue mM_N_Ce2_1s { get; private set; }
        public IntValue mM_N_AC5 { get; private set; }
        public IntValue mM_N_03sek { get; private set; }
        public IntValue mM_N_SP7 { get; private set; }

        public IntValue mM_A_ek2_1 { get; private set; }
        public IntValue mM_A_ypd1_1 { get; private set; }
        public IntValue mM_A_ypd2_1 { get; private set; }
        public IntValue mM_A_ydrd_1 { get; private set; }
        public IntValue mM_A_yk6 { get; private set; }
        public IntValue mM_A_yk5 { get; private set; }
        public IntValue mM_A_yp1 { get; private set; }
        public IntValue mM_A_bk5 { get; private set; }

        public IntValue mM_K_ODR { get; private set; }
        public IntValue mM_K_ROAK { get; private set; }
        public IntValue mM_krus3 { get; private set; }
        public IntValue mM_kovk5 { get; private set; }
        public IntValue mM_kovk7 { get; private set; }
        public IntValue mM_kovk8 { get; private set; }
        public IntValue mM_D3_5 { get; private set; }

        public IntValue mM_mpvQ201 { get; private set; }
        public IntValue mM_mmvQ121 { get; private set; }
        public IntValue mM_kSKDop { get; private set; }
        public IntValue mM_DPOB_naspusk { get; private set; }
        public IntValue mM_1sekKDU { get; private set; }
        public IntValue mM_tSKD { get; private set; }
        public IntValue mM_pitSUDN { get; private set; }
        public IntValue mM_tOK29 { get; private set; }

        public BoolValue mM_SYGN405 { get; private set; }
        public BoolValue mM_SYGN412 { get; private set; }
        public BoolValue mM_SYGN406 { get; private set; }
        public BoolValue mM_SYGN413 { get; private set; }
        public BoolValue mM_YZ28 { get; private set; }
        public BoolValue mM_SYGN411 { get; private set; }
        public BoolValue mM_Y339 { get; private set; }
        public BoolValue mM_Y338 { get; private set; }



        public IntValue mI_SYGN405 { get; private set; }
        public IntValue mI_SYGN412 { get; private set; }
        public IntValue mI_SYGN406 { get; private set; }
        public IntValue mI_SYGN413 { get; private set; }
        public IntValue mI_YZ28    { get; private set; }
        public IntValue mI_SYGN411 { get; private set; }
      

        public UKDUViewModel()
        {
            //расписать переменные
            List<int> ls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            val1 = new BitIntVar("Mnemo", ls);
            val1.VarName = "__UKDU_1";
            val2 = new BitIntVar("Mnemo", ls);
            val2.VarName = "__UKDU_2";
            //tempval
            val3 = new BitIntVar("Mnemo", ls);
            val3.VarName = "__UKDU_7";
            mM_y_200ms = val1.ValState[0];
            mM_Y_SH17 = val1.ValState[1];
            mM_K_ODR = val1.ValState[2];
            mM_K_ROAK = val1.ValState[3];
            mM_N_OVK1 = val1.ValState[4];
            mM_krus3 = val1.ValState[5];
            mM_Y_ovk16l1 = val1.ValState[6];
            mM_Y_ovk16l2 = val1.ValState[7];
            mM_Y_RUS3 = val1.ValState[8];
            mM_Y_L17 = val1.ValState[9];
            mM_Y_ovk18 = val1.ValState[10];
            mM_Y_AC1 = val1.ValState[11];
            mM_Y_L18 = val1.ValState[12];
            mM_Y_OK39 = val1.ValState[13];
            mM_Y_OK29_138 = val1.ValState[14];
            mM_Y_OK29_66 = val1.ValState[15];
            mM_Y_skd91 = val1.ValState[16];
            mM_Y_Skd_91 = val1.ValState[17];
            mM_Y_SKD91_100 = val1.ValState[18];
            mM_Y_SKD_91_100 = val1.ValState[19];
            mM_Y_SKD1 = val1.ValState[20];


            mM_Y_OK30_66 = val2.ValState[0];//21

            mM_Y_SH6_GK = val1.ValState[22];
            mM_Y_SH44 = val1.ValState[23];
            mM_Y_GK_AK = val1.ValState[24];
            mM_Y_OVK17 = val1.ValState[25];
            mM_kovk7 = val1.ValState[26];
            mM_D3_5 = val1.ValState[27];
            mM_DPOB_naspusk = val1.ValState[28];
            mM_1sekKDU = val1.ValState[29];
            mM_tSKD = val1.ValState[30];
            mM_pitSUDN = val1.ValState[31];


            mM_Y_OVK13 = val2.ValState[0];
            mM_Y_SKD_2 = val2.ValState[1];
            mM_Y_vkLDPOBT = val2.ValState[2];
            mM_Y_DPOBT = val2.ValState[3];
            mM_Y_SH42 = val2.ValState[4];
            mM_Y_DPO13_16 = val2.ValState[5];
            mM_Y_STD2 = val2.ValState[6];
            mM_Y_OK39_158 = val2.ValState[0];//7
            mM_mpvQ201 = val2.ValState[8];

            mM_kovk5 = val2.ValState[12];
            mM_N_UD44 = val2.ValState[13];
            mM_N_SKD2 = val2.ValState[14];
            mM_Y_DPO14_16 = val2.ValState[15];
            mM_Y_DPO13_15 = val2.ValState[15];
            mM_kovk8 = val2.ValState[16];
            mM_kSKDop = val2.ValState[17];
            mM_mmvQ121 = val2.ValState[18];
            mM_UD32 = val2.ValState[19];
            mM_Y_vlkDPOBT_UD17 = val2.ValState[20];
            mM_K158 = val2.ValState[21];
            mM_Y_PK_15 = val2.ValState[22];
            mM_Y_AC2 = val2.ValState[23];

            mM_Y_AC3 = val2.ValState[24];
            mM_SU6 = val2.ValState[25];
            mM_UD4 = val2.ValState[26];
            mM_OK2 = val2.ValState[27];
            mM_OK2_158 = val2.ValState[28];

          






            // mM_tOK29 = val1.ValState[14] + val1.ValState[15];


            List<int> ls2 = new List<int> { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            valK = new BitIntVar("Mnemo", ls2);
            valK.VarName = "__UKDU_3";
            mmvK1 = valK.ValState[0];
            mmvK2 = valK.ValState[1];
            mmvK3 = valK.ValState[2];
            mmvK4 = valK.ValState[3];
            mmvK5 = valK.ValState[4];
            mmvK6 = valK.ValState[5];
            mmvK7 = valK.ValState[6];
            mmvK8 = valK.ValState[7];
            mmvK9 = valK.ValState[8];
            mmvK10 = valK.ValState[9];
            mmvK11 = valK.ValState[10];
            mmvK12 = valK.ValState[11];
            mmvK13 = valK.ValState[12];
            mmvK14 = valK.ValState[13];
            mmvTPC = valK.ValState[14];


            valKDU = new BitVar("Mnemo");
            valKDU.VarName = "__KDU_2";
            mM_SYGN405 = valKDU.ValState[17];
            mM_SYGN412 = valKDU.ValState[18];
            mM_SYGN413 = valKDU.ValState[19];
            mM_YZ28 = valKDU.ValState[20];
            mM_SYGN411 = valKDU.ValState[21];
            mM_Y339 = valKDU.ValState[22];
            mM_Y338 = valKDU.ValState[23];
            mM_SYGN406 = valKDU.ValState[24];


            mI_SYGN405 = val2.ValState[17];
            mI_SYGN412 = val2.ValState[18];
            mI_SYGN406 = val2.ValState[24];
            mI_SYGN413 = val2.ValState[19];
            mI_YZ28 = val2.ValState[20];
            mI_SYGN411 = val2.ValState[21];

           



























        }

    }
}
