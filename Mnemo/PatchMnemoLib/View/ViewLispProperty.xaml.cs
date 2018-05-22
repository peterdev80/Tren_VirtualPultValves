using MUtilites;
using PatchMnemoLib.Model;
using PatchMnemoLib.ViewModelMElement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace PatchMnemoLib.View
{
    /// <summary>
    /// Логика взаимодействия для ViewLispProperty.xaml
    /// </summary>
    public partial class ViewLispProperty : UserControl
    {
        ViewModelLispKlapan vmp;
        public ViewLispProperty()
        {
            InitializeComponent();
        }
     public ViewLispProperty(ViewModelLispKlapan dc)
            : this()
        {
            vmp = dc;
            root.DataContext = dc;
            ucM.VG = dc;
            vmp.TransformValue = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            ColorDialog dlg = new ColorDialog();

            dlg.Color = SelectObj.GBrush;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }

            // Set selected color in drawing canvas
            // and in application settings
            SelectObj.GBrush = dlg.Color;
            vmp.TestVoid();
        }

        private LispKlapanItem SelectObj
        {
            get
            {
                return sp.DataContext as LispKlapanItem;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
            vmp.TestVoid();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            vmp.TransleteX += 1d;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            vmp.TransleteX -= 1d;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            vmp.TransleteY += 1d;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            vmp.TransleteY -= 1d;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            vmp.GraphicsData.Add(new LispKlapanItem());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            vmp.GraphicsData.RemoveAt(ListItem.SelectedIndex);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MovCalcDlg vnd = new MovCalcDlg();
            vnd.DataGeom = SelectObj.GData;
            if (vnd.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }
            SelectObj.GData = vnd.DataGeom;
            vmp.TestVoid();

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double left = double.Parse(tbLeft.Text, CultureInfo.CurrentCulture);
                double top = double.Parse(tbTop.Text, CultureInfo.CurrentCulture);

                ObservableCollection<LispKlapanItem> ki = new ObservableCollection<LispKlapanItem>();
                foreach (LispKlapanItem kli in vmp.GraphicsData)
                {
                    LispKlapanItem klin = new LispKlapanItem();
                    klin.GBrush = kli.GBrush;
                    klin.GData = MovCalcDlg.moveCalc(left, top, kli.GData);
                    klin.GPen = kli.GPen;
                    klin.GpenSize = kli.GpenSize;
                    ki.Add(klin);
                }

                vmp.GraphicsData = ki;
                /*  for (int i = 0; i < vmp.GraphicsData.Count; i++)
                  {
                      vmp.GraphicsData[i]=
                  }*/


                vmp.TestVoid();
            }
            catch { MessageBox.Show("EROR Button"); }

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            vmp.TransformValue  =double.Parse(txTransform.Text);
            vmp.ReDraw();
        }
    }
}

