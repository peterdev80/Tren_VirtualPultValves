using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MUtilites
{
    /// <summary>
    /// Логика взаимодействия для MovCalcDlg.xaml
    /// </summary>
    public partial class MovCalcDlg : Window
    {
        public MovCalcDlg()
        {
            InitializeComponent();
        }
        private string _DataGeom;
        public string DataGeom { get { return _DataGeom; } set { _DataGeom = value; tbData.Text = _DataGeom; } }







        public static string moveCalc(double mx, double my,string geometry)
        {
            string separators = @"(?=[MZLHVCSQTAmzlhvcsqta])";
            var tokens = Regex.Split(geometry, separators).Where(t => !string.IsNullOrEmpty(t));
            string newparch = "";
            foreach (string remainingargs in tokens)
            {

                var fndBK = Regex.Split(remainingargs, @"[\d\s ,.-]").Where(t => !string.IsNullOrEmpty(t));
                int pr = 0;
                string Litera = "";
                foreach (string bk in fndBK)
                {
                    pr++;
                    Litera = bk;

                }
                if (pr > 1)
                    new Exception("строка не верно разобранна");
                string argSeparators = @"[\s," + Litera + "]"; // discard whitespace and comma but keep the -


                var splitArgs = Regex
                   .Split(remainingargs, argSeparators)
                   .Where(t => !string.IsNullOrEmpty(t));

                List<string> st = splitArgs.ToList<string>();
                newparch = newparch + Litera;
                for (int n = 0; n < st.Count; n++)
                {
                    double sum = 0d;
                    if (n % 2 == 0) sum = mx; else sum = my;
                    st[n] = (double.Parse(st[n], CultureInfo.InvariantCulture) + sum).ToString(CultureInfo.InvariantCulture);
                    newparch = newparch + st[n];
                    if (n != st.Count - 1) newparch = newparch + " , ";
                }
                
                
                
           
            }
            return newparch;
        }

        public static string moveCalc(double my, string geometry)
        {
            string separators = @"(?=[MZLHVCSQTAmzlhvcsqta])";
            var tokens = Regex.Split(geometry, separators).Where(t => !string.IsNullOrEmpty(t));
            string newparch = "";
            foreach (string remainingargs in tokens)
            {

                var fndBK = Regex.Split(remainingargs, @"[\d\s ,.-]").Where(t => !string.IsNullOrEmpty(t));
                int pr = 0;
                string Litera = "";
                foreach (string bk in fndBK)
                {
                    pr++;
                    Litera = bk;

                }
                if (pr > 1) new Exception("строка не верно разобранна");
                string argSeparators = @"[\s," + Litera + "]"; // discard whitespace and comma but keep the -


                var splitArgs = Regex
                   .Split(remainingargs, argSeparators)
                   .Where(t => !string.IsNullOrEmpty(t));

                List<string> st = splitArgs.ToList<string>();
                newparch = newparch + Litera;
                for (int n = 0; n < st.Count; n++)
                {
                    double sum = 0d;
                    if (n % 2 == 0) sum = 0d; else sum = my;
                    st[n] = (double.Parse(st[n], CultureInfo.InvariantCulture) + sum).ToString(CultureInfo.InvariantCulture);
                    newparch = newparch + st[n];
                    if (n != st.Count - 1) newparch = newparch + " , ";
                }




            }
            return newparch;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(vX.Text, CultureInfo.CurrentCulture);
                double y = double.Parse(vY.Text, CultureInfo.CurrentCulture);
                tbData.Text = moveCalc(x, y, _DataGeom);
            }
            catch
            {
                MessageBox.Show("НЕ КОРЕКТЕН ВВОД");
            }
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DataGeom = tbData.Text;
            this.DialogResult = true;
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            tbData.Text = DataGeom;

        }
    }
}
