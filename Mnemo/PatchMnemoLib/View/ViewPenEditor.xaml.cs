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
using PatchMnemoLib.ViewModel;
using PatchMnemoLib.Model;
using System.Diagnostics;
using MUtilites;

namespace PatchMnemoLib.View
{
    /// <summary>
    /// Логика взаимодействия для ViewPenEditor.xaml
    /// </summary>
    public partial class ViewPenEditor : UserControl
    {
        viewModelMnemoAnimPen vm = viewModelMnemoAnimPen.Instance;
        private bool editflag1;
        public ViewPenEditor()
        {
            InitializeComponent();
            vm.LoadResource();
            GridAnim.DataContext = vm.ListAnim;
            GridPen.DataContext = vm.ListPenProperty;
            vm.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(vm_PropertyChanged);
        }

        void vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            editflag1 = true;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            tbName.IsReadOnly = false;
            ViewModelAnimation an = new ViewModelAnimation(new GraphicsAnimation(0, 0, 0, 0,"Anim"+ vm.ListAnim.Count.ToString()));
            vm.AddAnim(an);
            listBoxAnim.SelectedItem = an;
            btnSaveAnim.IsEnabled = true;

        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {


           
            vm.SaveResource(Properties.Resources.String1);
            tbName.IsReadOnly = true;
            btnSaveAnim.IsEnabled = false;
            



        }
        private void btnSavePen_Click(object sender, RoutedEventArgs e)
        {
            
            tbPenName.IsReadOnly = true;
            btnSavePen.IsEnabled = false;


        }
        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
           
            tbPenName.IsReadOnly = false;
            ViewModelPen mp = new ViewModelPen(Colors.Red, 2, "", "p" + vm.ListPenProperty.Count.ToString(), false);
            vm.AddPen(mp);
            listBoxPen.SelectedItem = mp;
            btnSavePen.IsEnabled = true;

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (editflag1)
            if (MessageBox.Show
                ("Были внесены измененния.Сохранить?", "Выход",MessageBoxButton.YesNo,MessageBoxImage.Question)
                ==MessageBoxResult.Yes)                
                 vm.SaveResource(Properties.Resources.String1);
           /* else
            submit = false;
            if (editflag1) MessageBox.Show(

            vm.SaveResource(Properties.Resources.String1);
            Debug.WriteLine("Unload");*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var SelectObj = grid2.DataContext as ViewModelPen;

            ColorDialog dlg = new ColorDialog();

            dlg.Color = SelectObj.ColorPen;
            if (dlg.ShowDialog().GetValueOrDefault() != true)
            {
                return;
            }

            // Set selected color in drawing canvas
            // and in application settings
            SelectObj.ColorPen = dlg.Color;
        }
    }
}
