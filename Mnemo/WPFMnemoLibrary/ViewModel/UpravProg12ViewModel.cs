using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace WPFMnemoLibrary.ViewModel
{
    public class UpravProg12ViewModel : MnemoViewModel
    {

        public UpravProg12ViewModel()
        {
            base.VarName = new List<string>();
            base.VarName.Add("__MNEMO_RES_9");
            base.VarName.Add("__MNEMO_RES_10");
            base.VarName.Add("__MNEMO_RES_12");
            BrushConverter vb = new BrushConverter();
            base.ListValStateVariable[1].ValState[16].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[19].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[19].PasivColor = Brushes.Transparent;
            base.ListValStateVariable[1].ValState[15].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[14].ActivColor = Brushes.Red;

          

            base.ListValStateVariable[2].ValState[5].PasivColor = (Brush)vb.ConvertFromString("#FFB8DC7C");
            base.ListValStateVariable[2].ValState[5].ActivColor = Brushes.GreenYellow;
            base.ListValStateVariable[2].ValState[9].PasivColor = (Brush)vb.ConvertFromString("#FFB8DC7C");
            base.ListValStateVariable[2].ValState[9].ActivColor = Brushes.GreenYellow;
            base.ListValStateVariable[2].ValState[10].PasivColor = (Brush)vb.ConvertFromString("#FFB8DC7C");
            base.ListValStateVariable[2].ValState[10].ActivColor = Brushes.GreenYellow;
            base.ListValStateVariable[2].ValState[11].PasivColor = (Brush)vb.ConvertFromString("#FFEDEAA0");
            base.ListValStateVariable[2].ValState[11].ActivColor = (Brush)vb.ConvertFromString("#FFFFF500");
            base.ListValStateVariable[2].ValState[12].PasivColor = (Brush)vb.ConvertFromString("#FFB8DC7C");
            base.ListValStateVariable[2].ValState[12].ActivColor = Brushes.GreenYellow;
            base.ListValStateVariable[2].ValState[13].PasivColor = (Brush)vb.ConvertFromString("#FFB8DC7C");
            base.ListValStateVariable[2].ValState[13].ActivColor = Brushes.GreenYellow;
            base.ListValStateVariable[2].ValState[14].PasivColor = (Brush)vb.ConvertFromString("#FFEDEAA0");
            base.ListValStateVariable[2].ValState[14].ActivColor = (Brush)vb.ConvertFromString("#FFFFF500");

          


            base.ListValStateVariable[2].ValState[6].PasivColor = Brushes.Transparent;
            base.ListValStateVariable[2].ValState[7].PasivColor = Brushes.Transparent;
            base.ListValStateVariable[2].ValState[8].PasivColor = Brushes.Transparent;


            base.ListValStateVariable[2].ValState[15].PasivColor = Brushes.Transparent;
            base.ListValStateVariable[2].ValState[16].PasivColor = Brushes.Transparent;
            base.ListValStateVariable[2].ValState[17].PasivColor = Brushes.Transparent;

            base.ListValStateVariable[2].ValState[30].PasivColor = Brushes.Transparent;
            base.ListValStateVariable[2].ValState[30].ActivColor = Brushes.GreenYellow;


            ///metki apvu
            ///8 c
            base.ListValStateVariable[0].ValState[28].ActivColor = Brushes.Red;
            base.ListValStateVariable[0].ValState[28].PasivColor = Brushes.Transparent;

            base.ListValStateVariable[0].ValState[29].ActivColor = Brushes.Blue;
            base.ListValStateVariable[0].ValState[29].PasivColor = (Brush)vb.ConvertFromString("#FF89381A");

            //10 c
            base.ListValStateVariable[1].ValState[10].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[10].PasivColor = Brushes.Transparent;

            base.ListValStateVariable[1].ValState[31].ActivColor = Brushes.Blue;
            base.ListValStateVariable[1].ValState[31].PasivColor = (Brush)vb.ConvertFromString("#FF89381A");


            //18 c
            base.ListValStateVariable[1].ValState[29].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[29].PasivColor = Brushes.Transparent;

            base.ListValStateVariable[1].ValState[30].ActivColor = Brushes.Blue;
            base.ListValStateVariable[1].ValState[30].PasivColor = (Brush)vb.ConvertFromString("#FF89381A");


            //60 c
            base.ListValStateVariable[2].ValState[24].ActivColor = Brushes.Red;
            base.ListValStateVariable[2].ValState[24].PasivColor = Brushes.Transparent;

            base.ListValStateVariable[2].ValState[25].ActivColor = Brushes.Blue;
            base.ListValStateVariable[2].ValState[25].PasivColor = (Brush)vb.ConvertFromString("#FF89381A");

            //120 c
            base.ListValStateVariable[2].ValState[26].ActivColor = Brushes.Red;
            base.ListValStateVariable[2].ValState[26].PasivColor = Brushes.Transparent;

            base.ListValStateVariable[2].ValState[27].ActivColor = Brushes.Blue;
            base.ListValStateVariable[2].ValState[27].PasivColor = (Brush)vb.ConvertFromString("#FF89381A");


            //12 m
            base.ListValStateVariable[2].ValState[28].ActivColor = Brushes.Red;
            base.ListValStateVariable[2].ValState[28].PasivColor = Brushes.Transparent;

            base.ListValStateVariable[2].ValState[29].ActivColor = Brushes.Blue;
            base.ListValStateVariable[2].ValState[29].PasivColor = (Brush)vb.ConvertFromString("#FF89381A");


        }



    }
}
