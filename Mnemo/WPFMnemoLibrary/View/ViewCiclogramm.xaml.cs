using System;
using System.Collections.Generic;
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
using WPFMnemoLibrary.ViewModel;
using MnemoTools;

namespace WPFMnemoLibrary.View
{
	/// <summary>
	/// Interaction logic for ViewCiclogramm.xaml
	/// </summary>
	public partial class ViewCiclogramm : UserControl
	{
		public ViewCiclogramm()
		{
			this.InitializeComponent();
		}

		private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy23", "c1_Copy39", "c1_Copy55", "c1_Copy87" }, "m1");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy23", "c1_Copy39", "c1_Copy55", "c1_Copy112", "c1_Copy", "c1_Copy8", "c1_Copy24", "c1_Copy40", "c1_Copy56","c1_Copy96" }, "m2");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy23", "c1_Copy39", "c1_Copy55", "c1_Copy112", "c1_Copy", "c1_Copy8", "c1_Copy24", "c1_Copy40", "c1_Copy56", "c1_Copy96", "c1_Copy7", "c1_Copy9","c1_Copy10","c1_Copy11","c1_Copy12","c1_Copy13","c1_Copy14" }, "m3");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy23", "c1_Copy39", "c1_Copy55", "c1_Copy112", "c1_Copy", "c1_Copy24", "c1_Copy40", "c1_Copy56", "c1_Copy7", "c1_Copy9", "c1_Copy11", "c1_Copy12", "c1_Copy13",  "c1_Copy113", "c1_Copy1", "c1_Copy17", "c1_Copy25", "c1_Copy41", "c1_Copy57", "c1_Copy105" }, "m4");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy39", "c1_Copy55", "c1_Copy112", "c1_Copy", "c1_Copy40", "c1_Copy56", "c1_Copy7", "c1_Copy9", "c1_Copy12", "c1_Copy13",  "c1_Copy113", "c1_Copy1", "c1_Copy17", "c1_Copy41", "c1_Copy57", "c1_Copy105", "c1_Copy114", "c1_Copy2", "c1_Copy18", "c1_Copy42", "c1_Copy58", "c1_Copy106" }, "m5");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy55", "c1_Copy112", "c1_Copy", "c1_Copy56", "c1_Copy7", "c1_Copy9", "c1_Copy13", "c1_Copy113", "c1_Copy1", "c1_Copy17", "c1_Copy57", "c1_Copy105", "c1_Copy114", "c1_Copy2", "c1_Copy18", "c1_Copy58", "c1_Copy106", "c1_Copy115", "c1_Copy19", "c1_Copy59", "c1_Copy75", "c1_Copy107", "c1_Copy3" }, "m6");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy112", "c1_Copy", "c1_Copy7", "c1_Copy9", "c1_Copy113", "c1_Copy1", "c1_Copy17", "c1_Copy105", "c1_Copy114", "c1_Copy2", "c1_Copy18", "c1_Copy106", "c1_Copy115", "c1_Copy19", "c1_Copy75", "c1_Copy107", "c1_Copy116", "c1_Copy4", "c1_Copy20", "c1_Copy52", "c1_Copy76", "c1_Copy108", "c1_Copy3" }, "m7");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy112", "c1_Copy", "c1_Copy7", "c1_Copy9", "c1_Copy113", "c1_Copy1", "c1_Copy17", "c1_Copy105", "c1_Copy114", "c1_Copy2", "c1_Copy18", "c1_Copy106", "c1_Copy115", "c1_Copy19", "c1_Copy75", "c1_Copy107", "c1_Copy116", "c1_Copy4", "c1_Copy20", "c1_Copy52", "c1_Copy76", "c1_Copy108", "c1_Copy3", "c1_Copy117", "c1_Copy21", "c1_Copy53", "c1_Copy69", "c1_Copy77", "c1_Copy109" }, "m8");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy112", "c1_Copy", "c1_Copy7", "c1_Copy9", "c1_Copy113", "c1_Copy1", "c1_Copy17", "c1_Copy105", "c1_Copy114", "c1_Copy2", "c1_Copy18", "c1_Copy106", "c1_Copy115", "c1_Copy19", "c1_Copy75", "c1_Copy107", "c1_Copy116", "c1_Copy4", "c1_Copy20", "c1_Copy52", "c1_Copy76", "c1_Copy108", "c1_Copy3", "c1_Copy117", "c1_Copy21", "c1_Copy53", "c1_Copy69", "c1_Copy77", "c1_Copy109", "c1_Copy5" }, "m9");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy112", "c1_Copy", "c1_Copy7", "c1_Copy9", "c1_Copy113", "c1_Copy1", "c1_Copy17", "c1_Copy105", "c1_Copy114", "c1_Copy2", "c1_Copy18", "c1_Copy106", "c1_Copy115", "c1_Copy19", "c1_Copy75", "c1_Copy107", "c1_Copy116", "c1_Copy4", "c1_Copy20", "c1_Copy52", "c1_Copy76", "c1_Copy108", "c1_Copy3", "c1_Copy117", "c1_Copy21", "c1_Copy53", "c1_Copy69", "c1_Copy77", "c1_Copy109", "c1_Copy5", "c1_Copy118", "c1_Copy6", "c1_Copy22", "c1_Copy38", "c1_Copy54", "c1_Copy70", "c1_Copy78", "c1_Copy86", "c1_Copy110" }, "m10");
            MPC1.AddNodes(new List<string>() { "c1_Copy111", "c1", "c1_Copy112", "c1_Copy", "c1_Copy7", "c1_Copy9", "c1_Copy113", "c1_Copy1", "c1_Copy17", "c1_Copy105", "c1_Copy114", "c1_Copy2", "c1_Copy18", "c1_Copy106", "c1_Copy115", "c1_Copy19", "c1_Copy75", "c1_Copy107", "c1_Copy116", "c1_Copy4", "c1_Copy20", "c1_Copy52", "c1_Copy76", "c1_Copy108", "c1_Copy3", "c1_Copy117", "c1_Copy21", "c1_Copy53", "c1_Copy69", "c1_Copy77", "c1_Copy109", "c1_Copy5", "c1_Copy118", "c1_Copy6", "c1_Copy22", "c1_Copy38", "c1_Copy54", "c1_Copy70", "c1_Copy78", "c1_Copy86", "c1_Copy110", "c1_Copy15", "c1_Copy16" }, "m11");


            var sc = LayoutRoot.DataContext as CiclTK708ViewModel;
            BindingOperations.SetBinding(MPC1.GetNodes("m1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m2, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m3"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m3, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m4"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m4, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m5"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m5, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m6"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m6, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m7"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m7, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m8"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m8, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m9"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m9, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m10"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m10, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("m11"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_m11, Path = new PropertyPath("ValueState") });
		
        }
	}
}