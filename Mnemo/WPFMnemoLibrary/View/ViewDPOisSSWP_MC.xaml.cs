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
    /// Логика взаимодействия для ViewDPOisSSWP_MC.xaml
    /// </summary>
    public partial class ViewDPOisSSWP_MC : UserControl
    {
        public ViewDPOisSSWP_MC()
        {
            InitializeComponent();
            ViewModelEditor vm = root.DataContext as ViewModelEditor;
            vm.MC.Canva = MC;
        }
    }
}
