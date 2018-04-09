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
    /// Логика взаимодействия для ViewLabelPropety.xaml
    /// </summary>
    public partial class ViewLabelPropety : UserControl
    {
        ViewModelValueLabel SelectObj;
        public ViewLabelPropety()
        {
            InitializeComponent();
        }
        public ViewLabelPropety(ViewModelValueLabel val):this()
        {
             SelectObj = val;
             root.DataContext = SelectObj;
             uc1.VG = SelectObj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ColorDialog dlg = new ColorDialog();

            dlg.Color = SelectObj.GPen;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }

            // Set selected color in drawing canvas
            // and in application settings
            SelectObj.GPen = dlg.Color;
            
        }

        private void uc1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double left = double.Parse(tbLeft.Text, CultureInfo.CurrentCulture);
                double top = double.Parse(tbTop.Text, CultureInfo.CurrentCulture);
                SelectObj.MoveGraphics(left, top);
            }
            catch { MessageBox.Show("Неверные значения сдвига"); }

        }

    }
}
