using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PatchMnemoLib.Model
{
  
    
    [Serializable]
    public class VariableM
    {
       
        public string VarID { get; set; }
        public string VarName { get; set; }
        public string Typ { get; set; }
        public List<int> Mask { get; set; }
        public string Remark {get;set;}
        public VariableM()
        {
            VarID = String.Empty;
            VarName = String.Empty;
            Typ = "BitStuct";

            Mask = new List<int>();
        }
        public VariableM(string varId, string varName, string typ, List<int> _mask):this()
        {
            VarID = varId;
            VarName = varName;
            Typ = typ;
            Mask = _mask;
            
        }
        public VariableM(string varId, string varName, string typ, int maskmask)
            : this()
        {
           
            VarID = varId;
            VarName = varName;
            Typ = typ;
            Mask = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; 
          if (maskmask == 2) Mask = new List<int> { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };             
          
           

        }
      

    
        

        
    }
}
