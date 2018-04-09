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
using PatchMnemoLib.ViewModelMElement;
using MUtilites;
using PatchMnemoLib.Model;
using System.Collections.ObjectModel;
using System.Globalization;

namespace PatchMnemoLib.View
{
    /// <summary>
    /// Логика взаимодействия для ViewColorIndicatorProperty.xaml
    /// </summary>
    public partial class ViewColorIndicatorProperty : UserControl
    {
        ViewModelColorInd vmp;
        public ViewColorIndicatorProperty()
        {
            InitializeComponent();
        }
        public ViewColorIndicatorProperty(ViewModelColorInd dc)
            : this()
        {
            vmp = dc;
            root.DataContext = dc;
            //ucM.VG = dc;

        }
        private KlapanItem SelectObj
        {
            get
            {
                return ((SegmentInd)sp.DataContext).PatchData ;
            }
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // vmp.GraphicsData.Add(new KlapanItem());
            vmp.GraphicsData.Add(new SegmentInd());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            vmp.GraphicsData.RemoveAt(ListItem.SelectedIndex);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            /* double left = double.Parse(tbLeft.Text, CultureInfo.CurrentCulture);
             double top = double.Parse(tbTop.Text, CultureInfo.CurrentCulture);

             ObservableCollection<KlapanItem> ki = new ObservableCollection<KlapanItem>();
             foreach (KlapanItem kli in vmp.GraphicsData)
             {
                 KlapanItem klin = new KlapanItem();
                 klin.GBrush = kli.GBrush;
                 klin.GData = MovCalcDlg.moveCalc(left, top, kli.GData);
                 klin.GPen = kli.GPen;
                 klin.GpenSize = kli.GpenSize;
                 ki.Add(klin);
             }

             vmp.GraphicsData = ki;
           


             vmp.TestVoid();*/
        }

        private void ListItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //sp.DataContext = ListItem.SelectedItem as KlapanItem;
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            sp.DataContext = vmp.Strelka;

        }

        private void btzs_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = ((SegmentInd)sp.DataContext).SegmentColorBrush;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }

            // Set selected color in drawing canvas
            // and in application settings
            ((SegmentInd)sp.DataContext).SegmentColorBrush = dlg.Color;
            vmp.TestVoid();

        }

        private void btp_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = ((SegmentInd)sp.DataContext).SegmentColorPen;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }

            // Set selected color in drawing canvas
            // and in application settings
            ((SegmentInd)sp.DataContext).SegmentColorPen = dlg.Color;
            vmp.TestVoid();

        }

        private void btt_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = ((SegmentInd)sp.DataContext).SegmentColorText;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }

            // Set selected color in drawing canvas
            // and in application settings
            ((SegmentInd)sp.DataContext).SegmentColorText = dlg.Color;
            vmp.TestVoid();


        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            MovCalcDlg vnd = new MovCalcDlg();
            vnd.DataGeom = vmp.Strelka.PatchData.GData;
            if (vnd.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }
            vmp.Strelka.PatchData.GData = vnd.DataGeom;
            vmp.TestVoid();
        }
    }
}

