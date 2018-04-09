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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using PatchMnemoLib.ViewModelMElement;
using System.Collections.ObjectModel;
using MUtilites;
using PatchMnemoLib.Model;

namespace PatchMnemoLib.View
{
    /// <summary>
    /// Логика взаимодействия для ViewPatchProperty.xaml
    /// </summary>
    public partial class ViewPatchProperty : UserControl
    {
        public ViewPatchProperty()
        {
            InitializeComponent();
        }
        private ViewModelPatch vmp;

        
        public ViewPatchProperty(ViewModelPatch dc):this()
        { 
            
            vmp = dc;
            lroot.DataContext = dc;
            mUC.VG = dc;

            comboBox1.DataContext = ViewModel.viewModelMnemoAnimPen.Instance;
           
           

            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            vmp.TransleteX += 1d;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            vmp.TransleteX -=1d;

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            vmp.TransleteY += 1d;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            vmp.TransleteY -=1d;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /*Double left = Double.Parse(tbL.Text, CultureInfo.InstalledUICulture);
            Double Top = Double.Parse(tbT.Text, CultureInfo.InstalledUICulture);
            Double w = Double.Parse(tbW.Text, CultureInfo.InstalledUICulture);
            Double h = Double.Parse(tbH.Text, CultureInfo.InstalledUICulture);
            double cx = left + w / 2;
            double cy = Top + h / 2;
            vmp.CentrX = cx;
            vmp.CentrY = cy;*/
        }

        private void tbData_TextInput(object sender, TextCompositionEventArgs e)
        {
            

        }

        private void tbData_TargetUpdated(object sender, DataTransferEventArgs e)
        {
           

        }

        private void tbData_TextChanged(object sender, TextChangedEventArgs e)
        {
            mUC.PatchCenterChange();
           /* if (vmp.GraphicsData != null)
            {
                tbL.Text = vmp.StartPoint.X.ToString();
                tbT.Text = vmp.StartPoint.Y.ToString();
            }*/

        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            double left = double.Parse(tbLeft.Text, CultureInfo.CurrentCulture);
            double top = double.Parse(tbTop.Text, CultureInfo.CurrentCulture);

               vmp.GraphicsData = MovCalcDlg.moveCalc(left, top, vmp.GraphicsData);
               
            

            
           


            
        }

        private void tbData_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lx = comboBox1.SelectedItem as ViewModel.ViewModelPen;
            if (lx!=null)
            vmp.PPen = lx.CurPen;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
           

            ColorDialog dlg = new ColorDialog();

            dlg.Color = vmp.DefPenColor;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }

            // Set selected color in drawing canvas
            // and in application settings
            vmp.DefPenColor = dlg.Color;
        }
    }
}
