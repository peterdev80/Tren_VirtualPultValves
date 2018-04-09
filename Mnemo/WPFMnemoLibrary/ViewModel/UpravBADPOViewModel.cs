using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace WPFMnemoLibrary.ViewModel
{
    public class UpravBADPOViewModel : MnemoViewModel
    {
        public UpravBADPOViewModel()
        {
            base.VarName = new List<string>();
            base.VarName.Add("__BADPO_1");
            base.VarName.Add("__BADPO_2");
            base.VarName.Add("__BADPO_3");
            base.VarName.Add("__BADPO_4");
            base.VarName.Add("__MNEMO_RES_7");

            base.ListValStateVariable[1].ValState[7].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[8].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[9].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[11].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[13].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[14].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[15].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[16].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[17].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[18].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[19].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[20].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[21].ActivColor = Brushes.Red;
            base.ListValStateVariable[1].ValState[22].ActivColor = Brushes.Red;

            /*  base.ListValStateVariable[0].ActivColor = Brushes.Transparent;
              base.ListValStateVariable[0].PasivColor = Brushes.Transparent;
              base.ListValStateVariable[1].ActivColor = Brushes.Transparent;
              base.ListValStateVariable[1].PasivColor = Brushes.Transparent;
              base.ListValStateVariable[2].ActivColor = Brushes.Transparent;
              base.ListValStateVariable[2].PasivColor = Brushes.Transparent;
              base.ListValStateVariable[3].ActivColor = Brushes.Transparent;
              base.ListValStateVariable[3].PasivColor = Brushes.Transparent;*/



            SolidColorBrush mySolidColorBrushA = new SolidColorBrush();
            mySolidColorBrushA.Color = Color.FromRgb(0, 255, 0);

             SolidColorBrush mySolidColorBrushP = new SolidColorBrush();
            mySolidColorBrushP.Color = Color.FromRgb(184, 220, 124);


            base.ListValStateVariable[4].ActivColor = mySolidColorBrushA;// Brushes.Green;
            base.ListValStateVariable[4].PasivColor = mySolidColorBrushP;///Brushes.YellowGreen;
            for (int i = 15; i < 25; i++)
                base.ListValStateVariable[4].ValState[i].PasivColor = Brushes.Transparent;
            //  base.ListValStateVariable[2].ValState[12].PasivColor = Brushes.Transparent;
            //  base.ListValStateVariable[2].ValState[24].PasivColor = Brushes.Transparent;
            /*   base.ListValStateVariable[0].PasivColor = Brushes.Red;
               base.ListValStateVariable[0].ActivColor = Brushes.Red;

          
           
                  base.ListValStateVariable[1].PasivColor = Brushes.Red;
                  base.ListValStateVariable[1].ActivColor = Brushes.Red;*/

        }
    }
}
