using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatchMnemoLib.Model;
using ValueModel.BaseModel;
using System.Windows;

namespace PatchMnemoLib.ViewModel
{
    public class ViewModelVariableM:ViewModelBase
    {
        private VariableM vM;
        public VariableM xVariableM { get { return vM; } }
        public VarClass VarM { get; private set; }
        public string VarID
        {
            get { return vM.VarID; }
            set { vM.VarID = value; OnPropertyChanged("VarID"); }
        }
        public string VarName
        {
            get { return vM.VarName; }
            set { vM.VarName = value; OnPropertyChanged("VarName"); }
        }
        public string Typ
        {
            get { return vM.Typ; }
            set { vM.Typ = value; OnPropertyChanged("Typ"); }
        }
        public List<int> Mask
        {
            get { return vM.Mask; }
            set { vM.Mask = value; OnPropertyChanged("Mask");}
        }
        public string Note
        {
            get { return vM.Remark; }
            set { vM.Remark = value; OnPropertyChanged("Note"); }
        }
        public ViewModelVariableM()
        {
            vM = new VariableM();
        }
        public ViewModelVariableM(VariableM val)
        {
            vM = val;
            CreateVar();
        }
        public ViewModelVariableM(string varId, string varName, string typ, List<int> _mask)
        {
            vM = new VariableM(varId, varName, typ, _mask);
            CreateVar();
        }
        public ViewModelVariableM(string varId, string varName, string typ,int mask)
        {
            vM = new VariableM(varId, varName, typ,mask);
            CreateVar();

        }
        private void CreateVar()
        {
            switch (Typ)
            {
                case "BitStuct": 
                    VarM = new BitIntVar(VarID, Mask); 
                    VarM.VarName = VarName; 
                    break;
                case "BitIntVar":
                    VarM = new BitIntVar(VarID, Mask);
                    VarM.VarName = VarName;
                    break;


                case "Double":
                    VarM = new DoubleVar(VarID);
                    VarM.VarName = VarName;
                    break;
                case "Float":
                    VarM = new FloatVar(VarID);
                    VarM.VarName = VarName;
                    break;
                case "Int":
                    VarM = new IntVar(VarID);
                    VarM.VarName = VarName;
                    break;

                default:
                    throw new Exception("Ошибка в типи переменной обмена MS");
                    break;




            }  
        }
        public void AplyVar()
        {
            //проверка что поля заполненны
            if ((VarID != String.Empty) && (VarName != String.Empty)) CreateVar();
            else
                new Exception("Попытка создание переменной без инициализации");


        }

    }
}
