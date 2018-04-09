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
using MUtilites;
using PatchMnemoLib.ViewModelMElement;
using System.Globalization;

namespace PatchMnemoLib.View
{
    /// <summary>
    /// Логика взаимодействия для ViewarcBalon.xaml
    /// </summary>
    public partial class ViewarcBalon : UserControl
    {
        public ViewarcBalon()
        {
            InitializeComponent();
        }
        ViewModelarcBalon SelectObj;

        public ViewarcBalon(ViewModelarcBalon val):this()
        {
            SelectObj = val;
            root.DataContext = SelectObj;
            uc1.VG = SelectObj;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ColorDialog dlg = new ColorDialog();

            dlg.Color = SelectObj.BackColor;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }

            // Set selected color in drawing canvas
            // and in application settings
            SelectObj.BackColor = dlg.Color;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = SelectObj.FrontColor;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }


            SelectObj.FrontColor = dlg.Color;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = SelectObj.StrokeColor;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }


            SelectObj.StrokeColor = dlg.Color;

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            double left = double.Parse(tbLeft.Text, CultureInfo.CurrentCulture);
            double top = double.Parse(tbTop.Text, CultureInfo.CurrentCulture);
            SelectObj.MoveGraphics(left, top);

        }
    }
}
