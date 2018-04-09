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
using System.Windows.Media.Animation;
using WPFMnemoLibrary.Model;

namespace WPFMnemoLibrary.View
{
    /// <summary>
    /// Логика взаимодействия для MainUser.xaml
    /// </summary>
    public partial class MainUser : UserControl
    {
        public MainUser()
        {
            InitializeComponent();
            var a= LinkInpu.Instance;           // Убрать Linux
            DataContext = root.DataContext;
          
        }
    }
}
