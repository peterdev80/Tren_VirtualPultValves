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

namespace PatchMnemoLib.View
{
    /// <summary>
    /// Логика взаимодействия для ViewVariableM.xaml
    /// </summary>
    public partial class ViewVariableM : UserControl
    {
        public ViewVariableM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            listBox1.ScrollIntoView(listBox1.Items[listBox1.Items.Count-1 ]);
            listBox1.SelectedIndex=(listBox1.Items.Count);
        }
    }
}
