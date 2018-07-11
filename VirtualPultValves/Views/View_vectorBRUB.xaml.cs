﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirtualPultValves.Views
{
    /// <summary>
    /// Логика взаимодействия для View_vectorBRUB.xaml
    /// </summary>
    public partial class View_vectorBRUB : UserControl
    {
        public View_vectorBRUB()
        {
            InitializeComponent();
        }
        private void rc1_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rc1_1.Visibility = Visibility.Hidden;
            rc.Visibility = Visibility.Hidden;
            cl.Visibility = Visibility.Visible;
        }

        private void cl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cl.Visibility = Visibility.Hidden;
            rc1_1.Visibility = Visibility.Visible;
            rc.Visibility = Visibility.Visible;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var obj = sender as CheckBox;
            int cmdParamKey = int.Parse(obj.Content.ToString());
            int step = 0;
            if (!(bool)obj.IsChecked)
            {
                step = 1;
                if (obj.Name == "bL" || obj.Name == "bR") step = 2;
            }
            obj.CommandParameter = cmdParamKey + step;
           /* if (cmdParamKey == 18) //Заглушка к ПВК, необходтмо разобратся с моделью
            {
                cmdParamKey = 19;
                if (step == 1) step = -1;
            }
            vm.Cmd.Execute(cmdParamKey + step);*/
        }
    }
}
