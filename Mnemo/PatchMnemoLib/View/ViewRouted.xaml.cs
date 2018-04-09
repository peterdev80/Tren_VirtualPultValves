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

using System.Diagnostics;
using PatchMnemoLib.Model;
using PatchMnemoLib.ViewModelMElement;

namespace PatchMnemoLib.View
{
    /// <summary>
    /// Логика взаимодействия для ViewRouted.xaml
    /// </summary>
    public partial class ViewRouted : UserControl
    {
        ViewModelRout.ViewModelRouted _routed;
        int select_index = -1;
        public ViewRouted()
        {
            InitializeComponent();
        }
        public ViewRouted(ViewModelRout.ViewModelRouted routed)
            : this()
        {
            _routed = routed;
            root.DataContext = routed;
            _routed._Canva.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_routed_PropertyChanged);
           // var r = this.FindResource("RoutList") as ViewModel.ViewModelRouted;

            //test
          /*  foreach (var x in _routed.RoutList)
                x.ListPen.CollectionChanged += delegate { Debug.WriteLine("CollectionChanged"); };*/
        }

        void _routed_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedGraphics")
            {
                var el = ((ViewModelMnemoCanvas)sender).SelectedGraphics;
                if (el!=null)
                for (int i=0;i<listView1.Items.Count;i++)
                    if (el.Name == ((ViewModelGraphics)listView1.Items[i]).Name) { listView1.SelectedIndex = i; lw1.SelectedIndex = i; }

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        //добавить маршрут

        private void button4_Click(object sender, RoutedEventArgs e)
        {
         
            _routed.AddRoute(textBox2.Text);
            textBox2.Text = "Name";

        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = "";
            /*listBox3.Items.Clear();
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (i == 0) str = "Пасив.";
                if (i == 1) str = "Актив";
                if (i > 1) str = "Аним." + (i - 1).ToString();
                listBox3.Items.Add(str);

            }*/
            str = "";
            if (listBox2.SelectedIndex != -1)
            {
                if (listBox2.SelectedIndex == 0) str = "состояние по умолчанию.пасивное";
                if (listBox2.SelectedIndex == 1) str = "Активное";

                if (listBox2.SelectedIndex > 1) str = "Аним." + (listBox2.SelectedIndex - 1).ToString(); ;
                label5.Content = str;
                select_index = listBox2.SelectedIndex;
            }
            else
                if (listBox2.Items.Count > select_index)
                    listBox2.SelectedIndex = select_index;



           
        }

      

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var vm = sgrid.DataContext as ViewModelRout.ViewModelRoute;
          
            vm.ReplaceNamePen(select_index, comboBox2.SelectedValue.ToString());

         
           // listBox2.ItemsSource = null;
            //listBox2.ItemsSource=
        }

      

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var vm = sgrid.DataContext as ViewModelRout.ViewModelRoute;
            string str = _routed.AllPen[0].PenName;
            vm.AddPen(str);
            listBox2.SelectedIndex = listBox2.Items.Count - 1;

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var vm = sgrid.DataContext as ViewModelRout.ViewModelRoute;
            vm.DeleteNamePen(select_index);
           /* Debug.WriteLine("-------------------------------------------------");
            
            foreach (var el in vm.ListPen)
                Debug.WriteLine(el);
            for (int i=0;i<listBox2.Items.Count;i++)
                Debug.WriteLine(string.Format("Index {0}={1}",i,listBox2.Items[i]));

            Debug.WriteLine(select_index);*/
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedValue != null)
            {
                string delname = ((ViewModelRout.ViewModelRoute)listBox1.SelectedValue).Name;
                _routed.DeleteRoute(delname);
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {

            var vm = sgrid.DataContext as ViewModelRout.ViewModelRoute;
            if ((vm!=null)&& (label3.Content!=null))
            vm.AddGraphics(label3.Content.ToString());
            

        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            var vm = sgrid.DataContext as ViewModelRout.ViewModelRoute;
            if ((vm != null)&&(label6.Content!=null))
            vm.DeleteGraphics(label6.Content.ToString());

        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            _routed.SaveResource(_routed.FNamePatch);
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            _routed.AddShower(textBox4.Text);

        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            string delname = ((ViewModelRout.ViewModelShower)listBox3.SelectedValue).Name;
            _routed.DeleteShower(delname);

        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            var vm = sgrid2.DataContext as ViewModelRout.ViewModelShower;
            if (label11.Content!=null)
            vm.AddGraphics(label11.Content.ToString());
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {

            var vm = sgrid2.DataContext as ViewModelRout.ViewModelShower;
            vm.DeleteGraphics(label12.Content.ToString());
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            _routed.FindElName = textBox6.Text;
        }

        private void listBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox1.SelectedItem = listBox4.SelectedItem;
            var vm = sgrid.DataContext as ViewModelRout.ViewModelRoute;
            ViewModelRout.ViewModelRoute vr=listBox4.SelectedItem as ViewModelRout.ViewModelRoute;
            listBox1.SelectedValue = vr;
            if (vr!=null)
            for (int i=0;i<listBox1.Items.Count;i++)
                if (((ViewModelRout.ViewModelRoute)listBox1.Items[i]).Name == vr.Name) { listBox1.SelectedIndex = i; }

        }

        private void button18_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {

            _routed.AddVisiblir(textBox8.Text);
            textBox8.Text = "Name";
        }

        private void button19_Click(object sender, RoutedEventArgs e)
        {
            string delname = ((ViewModelRout.ViewModelVisiblir)listBox1.SelectedValue).Name;
            _routed.DeleteVisiblir(delname);
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            var vm = grid2.DataContext as ViewModelRout.ViewModelVisiblir;
            if (vm != null)
                vm.AddGraphics(label_3.Content.ToString());
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            var vm = grid2.DataContext as ViewModelRout.ViewModelVisiblir;
            if (vm != null)
                vm.DeleteGraphics(label_6.Content.ToString());
        }
    }
}
