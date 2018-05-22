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
    /// Логика взаимодействия для ViewSKGS_MC.xaml
    /// </summary>
    public partial class ViewSKGS_MC : UserControl
    {
        public ViewSKGS_MC()
        {
            InitializeComponent();
            ViewModelEditor vm_tma = Vb1.DataContext as ViewModelEditor;
            vm_tma.MC.Canva = MC_TMA;
            ViewModelEditor vm_st = Vb2.DataContext as ViewModelEditor;
            vm_st.MC.Canva = MC_ST;
        }
    }
}
