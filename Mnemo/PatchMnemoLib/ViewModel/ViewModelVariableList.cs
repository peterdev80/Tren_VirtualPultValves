using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using PatchMnemoLib.Model;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows;
using ValueModel.BaseModelCommand;

namespace PatchMnemoLib.ViewModel
{
    /// <summary>
    /// Класс описывает переменные обмена
    /// </summary>
   public class ViewModelVariableList:ViewModelBase
   {


       #region singlton
       private static volatile ViewModelVariableList instance;
       private static object syncRoot = new Object();
       public static ViewModelVariableList Instance
       {
           get
           {
               if (instance == null)
               {
                   lock (syncRoot)
                   {
                       if (instance == null)
                           instance = new ViewModelVariableList();
                   }
               }

               return instance;
           }
       }
       #endregion



       #region Property
       public ObservableCollection<ViewModelVariableM> ListVariable { get; set; }

       #endregion


       public ViewModelVariableList()
       {
           ListVariable = new ObservableCollection<ViewModelVariableM>();
           //Определяем грузить из файла или ресурса

           LoadResource();
        
          
          
         
       }

       #region Method
       /// <summary>
       /// Вернуть переменную по имени
       /// </summary>
       /// <param name="Name"></param>
       /// <returns></returns>
       public ViewModelVariableM GetVariable(string Name)
       {
           return ListVariable.Where(p => p.VarName == Name).First<ViewModelVariableM>();
       }
       
       /// <summary>
       /// Добавить переменную
       /// </summary>
       /// <param name="val"></param>
       public void AddVariable(ViewModelVariableM val)
       {
           ListVariable.Add(val);
       }

       #endregion

       #region ReadWriteData

       //загрузка из ресурса
   
      private void LoadResource()
       {
           List<VariableM> Seriaz;
           if (Properties.Resources.String3 != "No")
           {
               LoaderClass.LoadResource(p => File.OpenRead(p), out  Seriaz, Properties.Resources.String4);

           }
          
           else
           {
               LoaderClass.LoadResource(LoaderClass.LoadFromResource, out  Seriaz, Properties.Resources.String5);


           }
          
           foreach (var el in Seriaz)
               ListVariable.Add(new ViewModelVariableM(el));         

            
       }


       private void SaveResource(string fileName)
       {
           List<VariableM> Seriaz = new List<VariableM>();
           foreach (var el in ListVariable)
           {
               Seriaz.Add(el.xVariableM);

           }
           XmlSerializer xmlFormat = new XmlSerializer(typeof(List<VariableM>));
           using (Stream fstream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
           {
               xmlFormat.Serialize(fstream, Seriaz);
           }
       }


       #endregion
      
       
       



        #region Command
       RelayCommand cmdSave,cmdNew,cmdLoad;

       public ICommand CmdSave
       {
           get
           {
               if (cmdSave == null) cmdSave = new RelayCommand(param => { SaveResource(param.ToString()); });
               return cmdSave;
           }
       }
       public ICommand CmdNew
       {
           get
           {
               if (cmdNew == null) cmdNew = new RelayCommand(NewValue);
            
               return cmdNew;
           }
       }
       public ICommand CmdLoad
       {
           get
           {
               if (cmdLoad == null) cmdLoad = new RelayCommand(param => { LoadResource(); });
               return cmdLoad;
           }
       }
       private void NewValue(object state)
       {
           ViewModelVariableM el = new ViewModelVariableM("Mnemo", "Mnemo_Rez", "BitIntVar", 1);
           ListVariable.Add(el);

       }
        #endregion
    }
}
