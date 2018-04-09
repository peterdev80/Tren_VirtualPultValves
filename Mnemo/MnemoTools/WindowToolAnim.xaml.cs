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

namespace MnemoTools
{
    /// <summary>
    /// Логика взаимодействия для WindowToolAnim.xaml
    /// </summary>
    public partial class WindowToolAnim : Window
    {
        public WindowToolAnim()
        {
            InitializeComponent();
        }
        private DataSourceResorcePen _rp;
        private MnemoPensColect mpc;
        private string _fname;
        public WindowToolAnim(MnemoPensColect rp, string fname):this()
        {
            _fname = fname;
            mpc = rp;
            _rp = rp.ResourcePen;
            GridAnim.DataContext = _rp.ListAnim;
            GridPen.DataContext = _rp.ListPenProperty;
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {  
            tbName.IsReadOnly = false;
            MnemoAnimation an=new MnemoAnimation(0,0,0,0,_rp.ListAnim.Count.ToString());
            _rp.AddAnim(an);
            listBoxAnim.SelectedItem=an;
            btnSaveAnim.IsEnabled = true;
          
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mpc.SaveResource(_fname);
            tbName.IsReadOnly = true;
            btnSaveAnim.IsEnabled = false;

          

        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            tbPenName.IsReadOnly = false;
            MnemoPen mp = new MnemoPen(Colors.Red, 2, "", _rp.ListPenProperty.Count.ToString(), false);
            _rp.AddPen(mp);
            listBoxPen.SelectedItem = mp;
            btnSavePen.IsEnabled = true;
        }

        private void btnSavePen_Click(object sender, RoutedEventArgs e)
        {
            tbPenName.IsReadOnly = true;
            btnSavePen.IsEnabled = false;


        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mpc.SaveResource(_fname);
        }
    }
}
