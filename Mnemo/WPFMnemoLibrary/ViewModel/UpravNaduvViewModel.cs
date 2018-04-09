using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace WPFMnemoLibrary.ViewModel
{
    public class UpravNaduvViewModel : MnemoViewModel
    {
        public UpravNaduvViewModel()
        {
            base.VarName = new List<string>();
            base.VarName.Add("__UNKDU_1");
            base.VarName.Add("__UNKDU_2");
            base.VarName.Add("__UNKDU_3");
            base.VarName.Add("__MNEMO_RES_8");

            base.VarName.Add("__BADPO_4");
            base.VarName.Add("__MNEMO_RES_7");
            base.VarName.Add("__MNEMO_RES_13");
            base.VarName.Add("__BADPO_2");
           
            
            BrushConverter vb = new BrushConverter();

            SolidColorBrush mySolidColorBrushA = new SolidColorBrush();
            mySolidColorBrushA.Color = Color.FromRgb(0, 255, 0);

            SolidColorBrush mySolidColorBrushP = new SolidColorBrush();
            mySolidColorBrushP.Color = Color.FromRgb(180, 210, 176);

            for (int i = 14; i < 27; i++)
            {
                base.ListValStateVariable[3].ValState[i].ActivColor = mySolidColorBrushA;//Brushes.YellowGreen;
                if (i < 20)
                    base.ListValStateVariable[3].ValState[i].PasivColor = (Brush)vb.ConvertFromString("#FFB8DC7C"); //Brushes.Green;
                else
                    base.ListValStateVariable[3].ValState[i].PasivColor = Brushes.Transparent;
            }

            base.ListValStateVariable[5].ActivColor = Brushes.Green;
            base.ListValStateVariable[5].PasivColor = Brushes.Transparent;
            base.ListValStateVariable[3].ValState[23].PasivColor = Brushes.AliceBlue;
            base.ListValStateVariable[3].ValState[24].PasivColor = Brushes.AliceBlue;


         /*   base.ListValStateVariable[3].ValState[19].PasivColor = (Brush)vb.ConvertFromString("#FFB4D2B0");
            base.ListValStateVariable[2].ValState[5].ActivColor = Brushes.GreenYellow;*/



        }
    }
}
