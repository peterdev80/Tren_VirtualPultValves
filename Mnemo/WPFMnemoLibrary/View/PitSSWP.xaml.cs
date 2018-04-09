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
	/// Interaction logic for PitSSWP.xaml
	/// </summary>
	public partial class PitSSWP : UserControl
	{
		public PitSSWP()
		{
			this.InitializeComponent();
		}

		private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{

            //H_ms20red H_ms20blue
           MPC1.AddNodes(new List<string>() { "l1","l2","l3" }, "H_ms20red");
            MPC1.AddNodes(new List<string>() { "l4","l10","l102" }, "H_ms20blue");

            MPC1.AddNodes(new List<string>() { "l7", "l9", "l8","l12","l15","l14" }, "H_ms21red");
            MPC1.AddNodes(new List<string>() { "l11","l13","l92","l99","l93","l98" }, "H_ms21blue");

            MPC1.AddNodes(new List<string>() { "l5"}, "H_ms22red");
            MPC1.AddNodes(new List<string>() { "l91","l6","l100" }, "H_ms22blue");

            MPC1.AddNodes(new List<string>() { "l16","l29" }, "H_ms23red");
            MPC1.AddNodes(new List<string>() { "l94","l17", "l97","l95","l30","l96"}, "H_ms23blue");

            MPC1.AddNodes(new List<string>() { "l103","l104" }, "H_ms24red");
            MPC1.AddNodes(new List<string>() { "l105","l106","l107","l71","l47", }, "H_ms24blue");

            MPC1.AddNodes(new List<string>() { "l10","l91","l92","l93","l94","l95" }, "H_ms27");

            MPC1.AddNodes(new List<string>() { "l46_Copy1", "l52", "l51" }, "H_ms27");

            MPC1.AddNodes(new List<string>() { "lv5","l56", "l55","l54","l51","l53","l57","l60","l61" }, "H_V5");

            MPC1.AddNodes(new List<string>() {"l28_Copy1","l38","l39"  }, "H_D9");

            MPC1.AddNodes(new List<string>() { "l28_Copy", "l37", "l39","l41" }, "H_D11");

            MPC1.AddNodes(new List<string>() { "l203","l36","l108","l41","l39", "l59","l58","l60","l61"}, "H_12_60c");

   MPC1.AddNodes(new List<string>() {"l65","l21","l44","l45","l46",  "l108", "l41", "l39","l24","l25" }, "H_AC2");

                     MPC1.AddNodes(new List<string>() {"l28_Copy3","l42","l44","l45","l47"}, "H_D13");

            MPC1.AddNodes(new List<string>() { "l28_Copy2","l43","l45" }, "H_G17");

            MPC1.AddNodes(new List<string>() { "l50","l49","l20"}, "H_12_180c");

            MPC1.AddNodes(new List<string>() {"l27", "l23","l25"}, "H_D15");

            MPC1.AddNodes(new List<string>() { "l28", "l22","l24", "l25" }, "H_D17");

            MPC1.AddNodes(new List<string>() {"ld8","l31","l18","l20"}, "H_D8");

            MPC1.AddNodes(new List<string>() { "l12_6", "l31", "l18", "l20" }, "H_12_12m");

            MPC1.AddNodes(new List<string>() { "ld5", "l31", "l18", "l20" }, "H_D5");

            MPC1.AddNodes(new List<string>() { "l109","l110"}, "H_ms25");

            MPC1.AddNodes(new List<string>() { "lud36", "l56", "l55", "l54", "l51", "l53", "l57", "l60", "l61" }, "H_ms28");




            var sc = LayoutRoot.DataContext as PitSSWPViewModel;

            BindingOperations.SetBinding(MPC1.GetNodes("H_ms20red"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms20, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_ms20blue"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms20, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_ms21red"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms21, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_ms21blue"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms21, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_ms22red"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms22, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_ms22blue"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms22, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_ms23red"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms23, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_ms23blue"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms23, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_ms24red"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms24, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("H_ms24blue"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms24, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_ms27"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms27, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_D7"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D7, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_V5"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_V5, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_D9"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D9, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_D11"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D11, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_12_60c"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_12_60c, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_AC2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_AC2, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_D13"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D13, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_G17"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_G17, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_12_180c"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_12_180c, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_D15"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D15, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_D17"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D17, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_D8"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D8, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_12_12m"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_12_12m, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_D5"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_D5, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_ms25"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms25, Path = new PropertyPath("ValueState") });

            BindingOperations.SetBinding(MPC1.GetNodes("H_ms28"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mH_ms28, Path = new PropertyPath("ValueState") });

      
        }
	}
}