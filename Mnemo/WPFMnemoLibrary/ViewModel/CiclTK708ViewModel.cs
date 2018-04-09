using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueModel.BaseModel;
using ValueModel.BaseType;

namespace WPFMnemoLibrary.ViewModel
{
    public class CiclTK708ViewModel : MnemoViewModel
    {
        CicloIntVar civ1, civ2, civ3, civ4, civ5,civ6,civ7,civ8,civ9,civ10,civ11;
        BitIntVar val1,val3;

        public IntValue m_m1 { get; private set; }
        public IntValue m_m2 { get; private set; }
        public IntValue m_m3 { get; private set; }
        public IntValue m_m4 { get; private set; }
        public IntValue m_m5 { get; private set; }
        public IntValue m_m6 { get; private set; }
        public IntValue m_m7 { get; private set; }
        public IntValue m_m8 { get; private set; }
        public IntValue m_m9 { get; private set; }
        public IntValue m_m10 { get; private set; }
        public IntValue m_m11 { get; private set; }

        public IntValue m_SYGN222 { get; private set; }
        public IntValue m_SYGN296 { get; private set; }
        public IntValue m_SYGN49 { get; private set; }
        public IntValue m_SYGN55 { get; private set; }
        public IntValue m_SYGN223 { get; private set; }
        public IntValue m_SYGN224 { get; private set; }
        public IntValue m_SYGN227 { get; private set; }
        public IntValue m_SYGN226 { get; private set; }
        public IntValue m_SYGN225 { get; private set; }
        public IntValue m_SYGN218 { get; private set; }
        public IntValue m_SYGN297 { get; private set; }
        public IntValue m_SYGN58 { get; private set; }
        public IntValue m_H_vklSSWP { get; private set; }
        public IntValue m_H_pitDK1_2 { get; private set; }
        public IntValue m_H_vtSHT { get; private set; }
        public IntValue m_H_vidSHT { get; private set; }
        public IntValue m_H_vtSA { get; private set; }
        public IntValue m_H_sakrKR { get; private set; }
        public IntValue m_HcDZS_20s { get; private set; }
        public IntValue m_H_cDK1 { get; private set; }
        public IntValue m_H_cDZG { get; private set; }
        public IntValue m_H_cDZG_DK2 { get; private set; }
        public IntValue m_H_cDZS { get; private set; }
        public IntValue m_H_vt_SHT1 { get; private set; }
        public IntValue m_H_sakr_KR { get; private set; }
        public IntValue m_H_vt_SA { get; private set; }
        public IntValue m_H_vt_SHT2 { get; private set; }
        public IntValue m_H_vid_SHT { get; private set; }
        public IntValue m_H_PR12_1 { get; private set; }
        public IntValue m_H_PR12_2 { get; private set; }
        public IntValue m_H_PR12_3 { get; private set; }
        public IntValue m_HcPR12_12m { get; private set; }


        public IntValue m_H_SSWP_GT { get; private set; }


        public CiclTK708ViewModel()
        {
            base.DisplayName = "Цикл_ТК_E_708";
            civ1 = new CicloIntVar("Mnemo", 10);
            civ1.VarName = "__CICLO_2";
            m_m1 = civ1.ValState;

            civ2 = new CicloIntVar("Mnemo", 20);
            civ2.VarName = "__CICLO_2";
            m_m2 = civ2.ValState;

            civ3 = new CicloIntVar("Mnemo", 30);
            civ3.VarName = "__CICLO_2";
            m_m3 = civ3.ValState;

            civ4 = new CicloIntVar("Mnemo", 40);
            civ4.VarName = "__CICLO_2";
            m_m4 = civ4.ValState;

            civ5 = new CicloIntVar("Mnemo", 50);
            civ5.VarName = "__CICLO_2";
            m_m5 = civ5.ValState;

            civ6 = new CicloIntVar("Mnemo", 60);
            civ6.VarName = "__CICLO_2";
            m_m6 = civ6.ValState;

            civ7 = new CicloIntVar("Mnemo", 70);
            civ7.VarName = "__CICLO_2";
            m_m7 = civ7.ValState;

            civ8 = new CicloIntVar("Mnemo", 80);
            civ8.VarName = "__CICLO_2";
            m_m8 = civ8.ValState;

            civ9 = new CicloIntVar("Mnemo", 90);
            civ9.VarName = "__CICLO_2";
            m_m9 = civ9.ValState;

            civ10 = new CicloIntVar("Mnemo", 100);
            civ10.VarName = "__CICLO_2";
            m_m10 = civ10.ValState;

            civ11 = new CicloIntVar("Mnemo", 110);
            civ11.VarName = "__CICLO_2";
            m_m11 = civ11.ValState;

              List<int> ls = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            val3 =  new BitIntVar("Mnemo", ls);
            val3.VarName = "__CICLO_3";
            m_H_SSWP_GT= val3.ValState[0];



            val1 = new BitIntVar("Mnemo", ls);
              val1.VarName = "__CICLO_1";
        m_SYGN222         = val1.ValState[0];
        m_SYGN296= val1.ValState[1];
        m_SYGN49 = val1.ValState[2];
        m_SYGN55 = val1.ValState[3];
        m_SYGN223 = val1.ValState[4];
        m_SYGN224 = val1.ValState[5];
        m_SYGN227 = val1.ValState[6];
        m_SYGN226 = val1.ValState[7];
        m_SYGN225 = val1.ValState[8];
        m_SYGN218 = val1.ValState[9];
        m_SYGN297 = val1.ValState[10];
        m_SYGN58 = val1.ValState[11];
        m_H_vklSSWP= val1.ValState[12]; 
        m_H_pitDK1_2= val1.ValState[13];
        m_H_vtSHT = val1.ValState[14];
        m_H_vidSHT = val1.ValState[15];
        m_H_vtSA = val1.ValState[16];
        m_H_sakrKR= val1.ValState[17];
        m_HcDZS_20s= val1.ValState[18]; 
        m_H_cDK1 = val1.ValState[19];
        m_H_cDZG = val1.ValState[20];
        m_H_cDZG_DK2 = val1.ValState[21];
        m_H_cDZS = val1.ValState[22];
        m_H_vt_SHT1 = val1.ValState[23];
        m_H_sakr_KR = val1.ValState[24];
        m_H_vt_SA = val1.ValState[25];
        m_H_vt_SHT2 = val1.ValState[26];
        m_H_vid_SHT = val1.ValState[27];
        m_H_PR12_1 = val1.ValState[28];
        m_H_PR12_2 = val1.ValState[29];
        m_H_PR12_3 = val1.ValState[30];
        m_HcPR12_12m = val1.ValState[31];





















        }
    }
}
