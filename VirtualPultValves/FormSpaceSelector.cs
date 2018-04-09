using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualPultValves.ViewModel;
using VirtualPultValves.Views;

namespace VirtualPultValves
{

    class FormSpaceSelector
    {
       /* public static FormspaceViewModel ClassСreator(string cname,InPUWin32View val)
        {
            switch (cname)
            {
                case "ИнПУ-1": return new Inpu1ViewModel();
                


            }

            return null;




        }*/
        /// <summary>
        /// создает экземпляр вьюмодел
        /// </summary>
        /// <param name="cname">имя вьюмодел</param>
        /// <returns></returns>
        public static FormspaceViewModel ClassСreator(string cname, InPUWin32View val)
        {
            switch (cname)
            {
                case "ИнПУ-1": return new Inpu1ViewModel(val);
                case "ИнПУ-2": return new Inpu2ViewModel(val, "Нептун Прав п");
                case "ЕПК-ПСА": return new EPKPSAViewModel();
                case "РПВ-1,2": return new RPVViewModel();
                case "ЕПК-РД": return new EPKRDViewModel();
                case "ЕПК-П": return new EPKP_ViewModel();
                case "КР-3": return new KR3_ViewModel();
                case "БРУС": return new BRUS_ViewModel();
                case "ЗДВ": return new ZDV_ViewModel();
                case "ДСД": return new DSD_ViewModel();
                case "Нептун Прав": return new NeptunPravPult_ViewModel();
                case "ХСА СА": return new XSASA_ViewModel();
                case "Люк СА БО": return new Lyk_ViewModel();
                case "БР1": return new BR1_ViewModel();
                case "РАП-10": return new RAP10_ViewModel();
                case "РАП-7": return new RAP7_ViewModel();
                case "КСД-БО": return new KSDBO_ViewModel();
                case "КВД-БО": return new KVDBO_ViewModel();
                case "БРУБ": return new BRUB_ViewModel();
                case "Мановак.": return new Manov_ViewModel();
                case "КР1": return new KR1_ViewModel();
                case "БАПД": return new BAPD_ViewModel();
                case "Згл.КСД-СУ": return new ZGLKSDSU_ViewModel();
                case "ВСЕ": return new All_ViewModel();
                case "РУС": return new RUS_ViewModel();

            } 

            return null;




        }
    }
}
