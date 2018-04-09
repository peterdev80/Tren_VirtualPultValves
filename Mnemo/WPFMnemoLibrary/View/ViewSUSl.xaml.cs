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

namespace WPFMnemoLibrary.View
{
    /// <summary>
    /// Логика взаимодействия для ViewSUSl.xaml
    /// </summary>
    public partial class ViewSUSl : UserControl
    {
        public ViewSUSl()
        {
            InitializeComponent();
            ViewModelEditor vm = root.DataContext as ViewModelEditor;
            vm.MC.Canva = MC;
        }
    }
}
