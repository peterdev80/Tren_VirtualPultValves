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
using PatchMnemoLib.Model;

namespace PatchMnemoLib.UtilControl
{
    /// <summary>
    /// Логика взаимодействия для UserControlMaket.xaml
    /// </summary>
    public partial class UserControlMaket : UserControl
    {
        private ViewModelMElement.ViewModelGraphics vmp;
        public UserControlMaket()
        {
            InitializeComponent();
        }

        public ViewModelMElement.ViewModelGraphics VG { get { return vmp; } set { vmp = value; root.DataContext = value; } }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vmp.TransleteX += 1d;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vmp.TransleteX += 1d;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            vmp.TransleteY += 1d;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            vmp.TransleteY -= 1d;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            vmp.ScaleX+= 0.1d;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            vmp.ScaleX -= 0.1d;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            vmp.ScaleY += 0.1d;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            vmp.ScaleY -= 0.1d;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            vmp.RotateAngle += 90d;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            vmp.RotateAngle -= 90d;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
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

        public void PatchCenterChange()
        {
           /* Point pp = vmp.GetPoint(((GraphicsPatch)vmp.GetGP()).GData);
            tbL.Text = pp.X.ToString();
            tbT.Text = pp.Y.ToString();*/
        }


    }
}
