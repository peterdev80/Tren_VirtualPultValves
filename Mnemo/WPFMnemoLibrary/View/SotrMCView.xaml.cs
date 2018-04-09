using PatchMnemoLib.ViewModel;
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

namespace WPFMnemoLibrary.View
{
    /// <summary>
    /// Логика взаимодействия для SotrMCView.xaml
    /// </summary>
    public partial class SotrMCView : UserControl
    {
        public SotrMCView()
        {
            InitializeComponent();
            ViewModelEditor vm0 = r0.DataContext as ViewModelEditor;
            vm0.MC.Canva = MC0;
            ViewModelEditor vm = r1.DataContext as ViewModelEditor;
            vm.MC.Canva = MC;
           ViewModelEditor vm2 = r2.DataContext as ViewModelEditor;
            vm2.MC.Canva = MC2;
            ViewModelEditor vm3 = r3.DataContext as ViewModelEditor;
            vm3.MC.Canva = MC3;
            ViewModelEditor vm4 = r4.DataContext as ViewModelEditor;
            vm4.MC.Canva = MC4;

        }

       

        private void cb1_Checked(object sender, RoutedEventArgs e)
        {
          

        }

        private void cb1_Click(object sender, RoutedEventArgs e)
        {
            if (cb1.IsChecked == true) { r0.Visibility = Visibility.Visible; r2.Visibility = Visibility.Visible; }
            else
            {
                r2.Visibility = Visibility.Hidden;
                if (cb2.IsChecked == false) r0.Visibility = Visibility.Hidden;
            }

        }

        private void cb2_Click(object sender, RoutedEventArgs e)
        {
            if (cb2.IsChecked == true) { r0.Visibility = Visibility.Visible; r4.Visibility = Visibility.Visible; }
            else
            {
                r4.Visibility = Visibility.Hidden;
                if (cb1.IsChecked == false) r0.Visibility = Visibility.Hidden;
            }

        }

        private void cb3_Click(object sender, RoutedEventArgs e)
        {
            if (cb3.IsChecked == true) { r1.Visibility = Visibility.Visible; }
            else
            {
                r1.Visibility = Visibility.Hidden;
               
            }

        }

        private void cb4_Click(object sender, RoutedEventArgs e)
        {
            if (cb4.IsChecked == true) { r3.Visibility = Visibility.Visible; }
            else
            {
                r3.Visibility = Visibility.Hidden;

            }

        }
    }
}
