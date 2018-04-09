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
	/// Interaction logic for ViewOtvodPodvod.xaml
	/// </summary>
	public partial class ViewOtvodPodvod : UserControl
	{
		public ViewOtvodPodvod()
		{
			this.InitializeComponent();
		}

		private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            MPC1.AddNodes(new List<string>() { "l255", "l1", "l1_Copy10", "l3", "l2", "l1_Copy3","l1_Copy4","l1_Copy5","l4","l5","l7","l8","l9","l9_Copy","l10","l6" }, "H_AC3");
            MPC1.AddNodes(new List<string>() {"l203","l11","l12","l15","l14","l13" }, "H_AC1");
            MPC1.AddNodes(new List<string>() {"l16","l17","l18","l12","l19","l20","l21","l22","l125" }, "H_podvod");
            MPC1.AddNodes(new List<string>() { "l23" ,"l14"}, "H_38");
            MPC1.AddNodes(new List<string>() {"l203_Copy","l24","l26","l25","l9_Copy","l10" }, "H_AC2");
            MPC1.AddNodes(new List<string>() {"l4", "l5", "l7", "l8", "l9", "l9_Copy", "l10", "l6","l27","l255_Copy" }, "H_AC5");
            MPC1.AddNodes(new List<string>() { "l28","l29","l39","l36","l30",    "l31",    "l32","l35"}, "Hotvod17_18");
            MPC1.AddNodes(new List<string>() { "l28", "l29", "l39", "l36", "l30", "l31","l33","l34"  }, "Hotvod27_28");
            MPC1.AddNodes(new List<string>() { "l28", "l29", "l39", "l36", "l30", "l31", "l33", "l34", "l32", "l35" }, "Hotvod17_28");
            MPC1.AddNodes(new List<string>() { "l40" }, "HOtvod");
            MPC1.AddNodes(new List<string>() { "l4", "l5", "l7", "l8", "l9", "l9_Copy", "l10", "l6", "l37", "l1_Copy5","lp12" }, "Hovk12");
            MPC1.AddNodes(new List<string>() { "l4", "l5", "l7", "l8", "l9", "l9_Copy", "l10", "l6", "l37", "l1_Copy5", "lp14" }, "Hovk14");
            MPC1.AddNodes(new List<string>() { "l1_Copy4", "l1_Copy5", "l4", "l5", "l7", "l8", "l9", "l9_Copy", "l10", "l6", "lp1", "l255_Copy1", "l38", "l41", "l43" }, "OCM_KR_19");
            MPC1.AddNodes(new List<string>() { "l1_Copy4", "l1_Copy5", "l4", "l5", "l7", "l8", "l9", "l9_Copy", "l10", "l6", "lp2", "l255_Copy1", "l38", "l42", "l43" }, "RR_KR_19");
            MPC1.AddNodes(new List<string>() { "l1_Copy4", "l1_Copy5", "l4", "l5", "l7", "l8", "l9", "l9_Copy", "l10", "l6", "lp1", "l255_Copy1", "l38", "l41", "l43" }, "OCM_KR_148");
            MPC1.AddNodes(new List<string>() { "l1_Copy4", "l1_Copy5", "l4", "l5", "l7", "l8", "l9", "l9_Copy", "l10", "l6", "lp2", "l255_Copy1", "l38", "l42", "l43" }, "RR_KR_148");
            MPC1.AddNodes(new List<string>() { "l44","l47","l46" }, "H_12_8");
            MPC1.AddNodes(new List<string>() { "l48", "l51","l50", "l46" }, "H_12_18");
            MPC1.AddNodes(new List<string>() { "l50", "l46", "l53", "l48_Copy", "l49", "l278", "l54", "l9", "l9_Copy", "l10" }, "H_12_60");
            MPC1.AddNodes(new List<string>() { "l57", "l55", "l56","l10" }, "H_12_10");
            MPC1.AddNodes(new List<string>() {"l58","l59","l60","l13","l26","l25" }, "H_12_12m");
            MPC1.AddNodes(new List<string>() { "l61", "l60", "l13", "l26", "l25" }, "H_D8");
            MPC1.AddNodes(new List<string>() { "l62", "l60", "l13", "l26", "l25" }, "H_D5");
            MPC1.AddNodes(new List<string>() {"l63","l52","l53","l50","l46","l8","l9","l9_Copy","l10" }, "H_OK51");
            MPC1.AddNodes(new List<string>() {"l64","l31","l32","l35" }, "H_OTVOD");
            MPC1.AddNodes(new List<string>() { "l64", "l31", "l33", "l34" }, "HV_OTVOD");
            MPC1.AddNodes(new List<string>() { "l206","l65","l66" }, "H_G5");
            MPC1.AddNodes(new List<string>() { "l255_Copy2", "l67", "l68","l69" }, "H_G7");
            MPC1.AddNodes(new List<string>() { "l255_Copy3", "l71","l70","l66", }, "H_G15");
            MPC1.AddNodes(new List<string>() { "l206_Copy", "l72", "l70", "l66", }, "H_Sch43");
            MPC1.AddNodes(new List<string>() {"l80","l81" }, "SYGN212");
            MPC1.AddNodes(new List<string>() { "l82", "l83" }, "SYGN213");
            MPC1.AddNodes(new List<string>() { "l84", "l76","l68","l69" }, "H_Sch59");
            MPC1.AddNodes(new List<string>() { "l85" }, "p37");
            MPC1.AddNodes(new List<string>() { "l57", "l56", "l55", "l74", "l73", "l3", "l1_Copy3", "l1_Copy4", "l1_Copy5","l4","l6","l5", "l7","l8","l9","l9_Copy","l10"}, "H1049");
            MPC1.AddNodes(new List<string>() { "l15" }, "mA80");
            MPC1.AddNodes(new List<string>() { "l3" }, "A79");
            MPC1.AddNodes(new List<string>() { "l79" }, "A47");
            
            
            
            
            
            
            var sc = LayoutRoot.DataContext as OtvodPodvodViewModel;

            BindingOperations.SetBinding(MPC1.GetNodes("H_AC3"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_AC3, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_AC1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_AC1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_podvod"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_podvod, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_38"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_38, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_AC2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_AC2, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_AC5"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_AC5, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Hotvod17_18"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mHotvod17_18, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Hotvod27_28"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mHotvod27_28, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Hotvod17_28"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mHotvod17_28, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Hovk12"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mHovk12, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Hovk14"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mHovk14, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("OCM_KR_19"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mOCM_KR_19, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("RR_KR_19"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mRR_KR_19, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("OCM_KR_148"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mOCM_KR_148, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("RR_KR_148"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mRR_KR_148, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_12_8"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_12_8, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_12_18"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_12_18, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_12_60"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_12_60, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_12_10"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_12_10, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_12_12m"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_12_12m, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_D8"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D8, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_D5"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D5, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_OK51"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_OK51, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_OTVOD"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_OTVOD, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("HV_OTVOD"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mHV_OTVOD, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_G5"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_G5, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_G7"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_G7, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_G15"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_G15, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_Sch43"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_Sch43, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("SYGN212"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mSYGN212, Path = new PropertyPath("ValueState") });
             BindingOperations.SetBinding(MPC1.GetNodes("SYGN213"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mSYGN213, Path = new PropertyPath("ValueState") });
             BindingOperations.SetBinding(MPC1.GetNodes("H_Sch59"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_Sch59, Path = new PropertyPath("ValueState") });
             BindingOperations.SetBinding(MPC1.GetNodes("p37"), MnemoPathNodes.ValProperty, new Binding { Source = sc.m_p37, Path = new PropertyPath("ValueState") });
             BindingOperations.SetBinding(MPC1.GetNodes("H1049"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH1049, Path = new PropertyPath("ValueState") });
             BindingOperations.SetBinding(MPC1.GetNodes("A80"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mA80, Path = new PropertyPath("ValueState") });
             BindingOperations.SetBinding(MPC1.GetNodes("A79"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mA79, Path = new PropertyPath("ValueState") });
             BindingOperations.SetBinding(MPC1.GetNodes("A47"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mA47, Path = new PropertyPath("ValueState") });

		}
	}
}