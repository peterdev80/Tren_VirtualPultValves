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
using PatchMnemoLib.Model;

namespace PatchMnemoLib.View
{
    /// <summary>
    /// Логика взаимодействия для ViewDPProperty.xaml
    /// </summary>
    public partial class ViewDPProperty : UserControl
    {
        ViewModelDP vmp;

        public ViewDPProperty()
        {
            InitializeComponent();
            comboBox2.DataContext = ViewModel.viewModelMnemoAnimPen.Instance;
        }
        public ViewDPProperty(ViewModelDP dc)
            : this()
        {

        vmp = dc;
            lroot.DataContext = dc; 
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Double left = Double.Parse(tbL.Text, CultureInfo.InstalledUICulture);
            Double Top = Double.Parse(tbT.Text, CultureInfo.InstalledUICulture);
            Double w = Double.Parse(tbW.Text, CultureInfo.InstalledUICulture);
            Double h = Double.Parse(tbH.Text, CultureInfo.InstalledUICulture);
            double cx = left + w / 2;
            double cy = Top + h / 2;
            vmp.CentrX = cx;
            vmp.CentrY = cy;
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            if (select_index < 0) new Exception("Не верно выбранн select_index");
            else
            {
                var dc = lroot.DataContext as ViewModelDP;
                StringItem sti = new StringItem();
                sti.Value = comboBox2.SelectedValue.ToString();
                dc.PenList[select_index] = sti;
            }


        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            var dc = lroot.DataContext as ViewModelDP;
            string str = ViewModel.viewModelMnemoAnimPen.Instance.ListPenProperty[0].PenName;
               StringItem sti = new StringItem();
                sti.Value = str;
                dc.PenList.Add(sti);
                listBox2.SelectedIndex = listBox2.Items.Count - 1;
        }
        int select_index = 0;

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            select_index = listBox2.SelectedIndex;

        }
    }
}
