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
    /// Логика взаимодействия для ViewPR12_MC.xaml
    /// </summary>
    public partial class ViewPR12_MC : UserControl
    {
        public ViewPR12_MC()
        {
            InitializeComponent();
            ViewModelEditor vm = root.DataContext as ViewModelEditor;
            vm.MC.Canva = MC;
        }
    }
}
