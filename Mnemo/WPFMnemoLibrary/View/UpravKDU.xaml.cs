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
using MnemoTools;
using WPFMnemoLibrary.ViewModel;

namespace WPFMnemoLibrary.View
{
    /// <summary>
    /// Логика взаимодействия для UpravKDU.xaml
    /// </summary>
    public partial class UpravKDU : UserControl
    {
        private List<string> ValueName; //test variable
        public UpravKDU()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            MPC1.AddNodes(new List<string>() { "p58","p59","p60","p61","l242","l170","l239" }, "Y_SH17");
           MPC1.AddNodes(new List<string>() { "p71", "p70", "p67","p65","p64","p66","p61","p68","l170" }, "Y_ovk16l1");
           MPC1.AddNodes(new List<string>() { "p71", "p70", "p67", "p65", "p63", "p62", "p61", "p68", "l170" }, "Y_ovk16l2");
            MPC1.AddNodes(new List<string>() { "l3", "l2", "p93", "p92", "p89", "p88","l200","l201" }, "Y_RUS3");
            MPC1.AddNodes(new List<string>() {"l196", "p90", "p89", "p88", "l200", "l201" }, "Y_L17");
            MPC1.AddNodes(new List<string>() { "p96", "p95", "p94", "p92", "p89", "p88", "l200", "l201" }, "Y_ovk18");
            MPC1.AddNodes(new List<string>() {"l198", "p76", "p73", "p74", "p75", "l145", "l98" }, "Y_AC1");
            MPC1.AddNodes(new List<string>() { "l197","p78","p75","l145" }, "Y_L18");
            MPC1.AddNodes(new List<string>() { "l172", "l171", "p72", "p73", "p74", "p75", "l145", "p79", "p81", "l202", "l6", "l7", "l8", "l142", "l105", "l104", "l93", "l92", "l46", "l181", "l45", "l37", "l147", "l103", "l100", "l98", "l94", "l151", "l81", "l82", "l168", "l80", "l167", "l79", "l78", "l150", "l77", "p57", "l166", "l165", "l164", "l163", "l162", }, "Y_OK39");
            MPC1.AddNodes(new List<string>() {"l81","l82","l168","l80","l167","l79","l78","l150","l77","p57","l166","l165","l164","l163","l162" }, "Y_OK30");
            MPC1.AddNodes(new List<string>() {"p33","p32","p30","l159"  }, "Y_OK30_66");
            MPC1.AddNodes(new List<string>() { "p1", "p2", "p3", "p4", "p14", "p18", "p19", "p20", "p141", "p21", "p34", "p22", "p24", "p25", "p28", "p27", "l160", "p29", "p30", "l159","l141" }, "Y_OK29_138");
            MPC1.AddNodes(new List<string>() { "p1", "p2", "p3", "p4", "p14", "p15", "p17", "p20", "p141", "p21", "p34", "p22", "p24", "p25", "p28", "p27", "l160", "p29", "p30", "l159", "l141" }, "Y_OK29_66");
            MPC1.AddNodes(new List<string>() {"p35","p37","p38","p41","p48","p50","l191","p49","l183" }, "Y_skd91");
            MPC1.AddNodes(new List<string>() { "p35", "p37","p40","p43","p46","p51","l182" ,"p47","l184" }, "Y_Skd_91");
            MPC1.AddNodes(new List<string>() { "p35", "p37", "p39", "p42", "p45", "p46", "p51", "l182", "p44", "p47", "p38", "p41", "p48", "p50", "l191", "p49", "l183", "l184" }, "Y_SKD91_100");
            MPC1.AddNodes(new List<string>() { "p35", "p37", "p39", "p42", "p45", "p46", "p51", "l182", "p44", "p47", "p40", "p43", "p48", "p50", "l191", "p49", "l183", "l184" }, "Y_SKD_91_100");
            MPC1.AddNodes(new List<string>() { "l83","l188","l113_","l114","l115","l190","l116","l117","l148" }, "Y_SKD1");
            MPC1.AddNodes(new List<string>() { "l276", "l112", "l109", "l106", "l104", "l103", "l100", "l98", "l94", "l151", "l93", "l92", "l46", "l181", "l45", "l37", "l147", "l81", "l82", "l168", "l80", "l167", "l79", "l78", "l150", "l77", "p57", "l166", "l165", "l164", "l163", "l162" }, "Y_SH6_GK");
            MPC1.AddNodes(new List<string>() { "l81", "l82", "l168", "l80", "l167", "l79", "l78", "l150", "l77", "p57", "l166", "l165", "l164", "l163", "l162" ,"l254","l99","l98","l94","l151"}, "Y_SH44");
            MPC1.AddNodes(new List<string>() { "l266", "l111", "l110", "l109", "l106", "l104", "l103", "l100", "l98", "l94", "l151", "l93", "l92", "l46", "l181", "l45", "l37", "l147", "l81", "l82", "l168", "l80", "l167", "l79", "l78", "l150", "l77", "p57", "l166", "l165", "l164", "l163", "l162" }, "Y_GK_AK");
            MPC1.AddNodes(new List<string>() { "l107", "108", "l106", "l104", "l103", "l100", "l98", "l94", "l151", "l93", "l92", "l46", "l181", "l45", "l37", "l147", "l81", "l82", "l168", "l80", "l167", "l79", "l78", "l150", "l77", "p57", "l166", "l165", "l164", "l163", "l162" }, "Y_OVK17");
            MPC1.AddNodes(new List<string>() { "l16","l15","l12","l10","l9","l193"}, "Y_OVK13");
            MPC1.AddNodes(new List<string>() { "l255", "l95", "l189", "l94", "l151", "l81", "l82", "l168", "l80", "l167", "l79", "l78", "l150", "l77", "p57", "l166", "l165", "l164", "l163", "l162" }, "Y_SKD_2");
            MPC1.AddNodes(new List<string>() { "p36","p8","p9","l194","l195" }, "Y_vkLDPOBT");
            MPC1.AddNodes(new List<string>() { "p13", "p12", "p11", "p10", "l194", "l195", "l5", "l53", "l55", "l54", "l57", "l56", "l176", "l175", "l178", "l177", "l174", "l173", "l60", "l284" }, "Y_DPOBT");
            MPC1.AddNodes(new List<string>() { "l278","l41","l40","l39","l38","l37","l147","l42","l43","l180" }, "Y_SH42");
            MPC1.AddNodes(new List<string>() { "l53", "l55", "l54", "l57", "l56", "l176", "l175", "l178", "l177", "l174", "l173","l47","l48","l49","l44","l43","l180","l50","l51","l179","l52" ,"l58","l59o","l158","l60","l284"}, "Y_DPO13_16");
            MPC1.AddNodes(new List<string>() {"l280","l65","l92","l46","l181", "l45","l37","l147" }, "Y_STD2");
            MPC1.AddNodes(new List<string>() {"p69","l146"}, "y_200ms");
            MPC1.AddNodes(new List<string>() { "l210","l11","l10","l9","l193" }, "UD32");
            MPC1.AddNodes(new List<string>() { "p5","p6","p7","p9","l194","l195" }, "Y_vlkDPOBT_UD17");
            MPC1.AddNodes(new List<string>() { "l248","p82","l144" }, "Y_PK_15");
            MPC1.AddNodes(new List<string>() {"l231","p77","p73","p74","p75","l145","p79", "p81","l202" }, "Y_AC2");
            MPC1.AddNodes(new List<string>() {"l230","p80","p81","l202"  }, "Y_AC3");
            MPC1.AddNodes(new List<string>() { "p72", "p73", "p74", "p75","l145" }, "Y_OK39_158");
            MPC1.AddNodes(new List<string>() { "l229","p86","p85","p84","p83","p91","p89","l200" }, "SU6");
            MPC1.AddNodes(new List<string>() {"p87","l228", "p84", "p83", "p91", "p89", "l200" }, "UD4");
            MPC1.AddNodes(new List<string>() { "p88","l201" }, "OK2");
            MPC1.AddNodes(new List<string>() { "l81", "l82", "l168", "l80", "l167", "l79", "l78", "l150", "l77", "p57", "l166", "l165", "l164", "l163", "l162", "l101", "l100", "l98", "l94", "l151" }, "OK2_158");
           ///новые переменные
           MPC1.AddNodes(new List<string>() { "l203","l13","l12","l10","l9","l193" }, "N_SKD2");
           MPC1.AddNodes(new List<string>() {  "l12", "l10", "l9", "l193","l208","l14" }, "N_UD44");
           MPC1.AddNodes(new List<string>() { "l4","p99","p98","p100","p97","l169" }, "N_OVK1");
           MPC1.AddNodes(new List<string>() { "l4", "p99", "p98", "p100" }, "N_OVK1_1");
           MPC1.AddNodes(new List<string>() { "l143","l1" }, "N_02s");
           MPC1.AddNodes(new List<string>() {"p52","p53","p54" }, "N_mP1_R");
           MPC1.AddNodes(new List<string>() {"p55","p56"}, "N_mP1_B");
           MPC1.AddNodes(new List<string>() {"l17","l18","l19"}, "N_mP2_R");
           MPC1.AddNodes(new List<string>() { "l20","l21"}, "N_mP2_B");
           MPC1.AddNodes(new List<string>() {"l22","l23","l24"}, "N_mPD1_R");
           MPC1.AddNodes(new List<string>() { "l223","l25"}, "N_mPD1_B");
           MPC1.AddNodes(new List<string>() { "l30","l29","l26" }, "N_mPD2_R");
           MPC1.AddNodes(new List<string>() { "l28","l27" }, "N_mPD2_B");
           MPC1.AddNodes(new List<string>() { "l31","l32","l34" }, "N_mDRD_R");
           MPC1.AddNodes(new List<string>() {"l33","l35","l36" }, "N_mDRD_B");

           MPC1.AddNodes(new List<string>() { "l67", "l68", "l69", "l70", "l191", "l71" }, "N_Ce1");
           MPC1.AddNodes(new List<string>() { "l72","l185","l73","l74","l187","l149" }, "N_Ce1_1s");
           MPC1.AddNodes(new List<string>() { "l84","l85","l86","l87","l182","l88" }, "N_Ce2");
           MPC1.AddNodes(new List<string>() {"l89","l186","l74","l187","l149"}, "N_Ce2_1s");
           MPC1.AddNodes(new List<string>() { "l192","p23","p24","p25","p28","p27","l160","p29","p30","l159" }, "N_AC5");
           MPC1.AddNodes(new List<string>() {"p26","l161"}, "N_03sek");
           MPC1.AddNodes(new List<string>() { "l206", "p31","p30","l159" }, "N_SP7");


           MPC1.AddNodes(new List<string>() { "a1", "a2", "a3", "a4" }, "A_eK2_1");
           MPC1.AddNodes(new List<string>() {"a6","a11","r5" }, "A_ypd1_1");
           MPC1.AddNodes(new List<string>() { "a10","a11" }, "A_ypd2_1");
           MPC1.AddNodes(new List<string>() {"a7","a8","a9","a11" }, "A_ydrd_1");
           MPC1.AddNodes(new List<string>() { "a12"}, "A_yk6");
           MPC1.AddNodes(new List<string>() { "a13" }, "A_yk5");
           MPC1.AddNodes(new List<string>() { "a100","a101" }, "A_yp1");
           MPC1.AddNodes(new List<string>() { "a14", "a15" }, "A_bk5");



          /* MPC1.AddNodes(new List<string>() { "a2" ,"a3","a4"}, "A_eK2_2");
           MPC1.AddNodes(new List<string>() { "l84", "l85", "l86", "l87", "l182", "l88" }, "N_Ce2");
           MPC1.AddNodes(new List<string>() { "l89", "l186", "l74", "l187", "l149" }, "N_Ce2_1s");
           MPC1.AddNodes(new List<string>() { "l192", "p23", "p24", "p25", "p28", "p27", "l160", "p29", "p30", "l159" }, "N_AC5");
           MPC1.AddNodes(new List<string>() { "p26", "l161" }, "N_03sek");
           MPC1.AddNodes(new List<string>() { "l206", "p31", "p30", "l159" }, "N_SP7");*/


            
            ValueName = new List<string>();
            foreach (MnemoPathNodes node in MPC1.Marshrut)
            {
                ValueName.Add(node.NameNodes);

            }
          /*  foreach (string st in ValueName)
                MPC1.GetNodes(st).Val = 1;*/
         //   MPC1.GetNodes("A_eK2_1").Val = 2;
            // MPC1.GetNodes("Y_SH6_GK").Val = 1;



            #region Binding Value


            var sc = LayoutRoot.DataContext as UKDUViewModel;


            BindingOperations.SetBinding(MPC1.GetNodes("Y_SH17"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_SH17, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_ovk16l1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_ovk16l1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_ovk16l2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_ovk16l2, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_RUS3"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_RUS3, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_L17"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_L17, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_ovk18"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_ovk18, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_AC1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_AC1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_L18"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_L18, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_OK39"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_OK39, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_OK30_66"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_OK30_66, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_OK29_138"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_OK29_138, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_OK29_66"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_OK29_66, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_skd91"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_skd91, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_Skd_91"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_Skd_91, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_SKD91_100"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_SKD91_100, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_SKD1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_SKD1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_SH6_GK"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_SH6_GK, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_SH44"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_SH44, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_GK_AK"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_GK_AK, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_OVK17"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_OVK17, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_OVK13"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_OVK13, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_SKD_2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_SKD_2, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_vkLDPOBT"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_vkLDPOBT, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_DPOBT"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_DPOBT, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_SH42"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_SH42, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_DPO13_16"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_DPO13_16, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_STD2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_STD2, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("y_200ms"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_y_200ms, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("UD32"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_UD32, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_vlkDPOBT_UD17"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_vlkDPOBT_UD17, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_PK_15"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_PK_15, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_AC2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_AC2, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_AC3"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_AC3, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("Y_OK39_158"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_Y_OK39_158, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("SU6"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_SU6, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("UD4"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_UD4, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("OK2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_OK2, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("OK2_158"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_OK2_158, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_SKD2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_SKD2, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_UD44"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_UD44, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_OVK1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_OVK1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_OVK1_1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_K_ODR, Path = new PropertyPath("ValueState") });
         
            BindingOperations.SetBinding(MPC1.GetNodes("N_02s"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_02s, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mP1_R"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN405, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mP1_B"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN405, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mP2_R"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN412, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mP2_B"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN412, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mPD1_R"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN406, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mPD1_B"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN406, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mPD2_R"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN413, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mPD2_B"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN413, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mDRD_R"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN411, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_mDRD_B"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mI_SYGN411, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_Ce1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_Ce1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_Ce1_1s"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_Ce1_1s, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_Ce2"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_Ce2, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_Ce2_1s"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_Ce2_1s, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_AC5"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_AC5, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_03sek"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_03sek, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("N_SP7"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_N_SP7, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("A_eK2_1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_A_ek2_1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("A_ypd1_1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_A_ypd1_1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("A_ypd2_1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_A_ypd2_1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("A_ydrd_1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_A_ydrd_1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("A_yk6"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_A_yk6, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("A_yk5"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_A_yk5, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("A_yp1"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_A_yp1, Path = new PropertyPath("ValueState") });
            BindingOperations.SetBinding(MPC1.GetNodes("A_bk5"), MnemoPathNodes.ValProperty, new Binding { Source = sc.mM_A_bk5, Path = new PropertyPath("ValueState") });
        
            #endregion
        }
        /// <summary>
        /// test void
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      /*  private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValueName=new List<string>();
            foreach (MnemoPathNodes node in MPC1.Marshrut)
            {
                ValueName.Add(node.NameNodes);
                
            }

            cmbCom.ItemsSource = ValueName;
        }
        /// <summary>
        /// test void
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string select_value = cmbCom.SelectedValue.ToString();
            if (ValueName!=null)
            foreach (string st in ValueName)
                MPC1.GetNodes(st).Val = 0;
            if (select_value!=string.Empty)
                MPC1.GetNodes(select_value).Val = 1;

        }
       */
    }
}
