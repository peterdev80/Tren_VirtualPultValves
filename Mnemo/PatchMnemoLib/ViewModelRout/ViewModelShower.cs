using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using PatchMnemoLib.Model;
using System.Collections.ObjectModel;
using PatchMnemoLib.ViewModel;

using System.Windows.Data;
using PatchMnemoLib.ViewModelMElement;
using ValueModel.BaseType;
using ValueModel.BaseModel;

namespace PatchMnemoLib.ViewModelRout
{
    public class ViewModelShower : DependencyObject
    {

        private Route Marshrut;

        private bool init1, init2;

        private ViewModelMnemoCanvas _canva;

      
        public ViewModelShower(Route Rout, ViewModelMnemoCanvas canva)
        {
            Marshrut = Rout;
            Marshrut.TypRoute = 2;
            _canva = canva;
            
           SetValue(NameProperty, Marshrut.Name);
           SetValue(ValueNameProperty, Marshrut.ValueName);
           SetValue(ValueTypeProperty, Marshrut.ValueType);
           SetValue(ValueRemProperty, Marshrut.ValueRem);
           Refrech();
          

                     
        }


        public static readonly DependencyProperty ValueIntProperty =
           DependencyProperty.Register("ValueInt", typeof(int), typeof(ViewModelShower), new PropertyMetadata(-1, OnValChange));
        public static readonly DependencyProperty ValueDoubleProperty =
          DependencyProperty.Register("ValueDouble", typeof(double), typeof(ViewModelShower), new PropertyMetadata(0d, OnValChange));
        public static readonly DependencyProperty ValueFloatProperty =
         DependencyProperty.Register("ValueFloat", typeof(float), typeof(ViewModelShower), new PropertyMetadata(0f, OnValChange));


        public static readonly DependencyProperty NameProperty =
        DependencyProperty.Register("Name", typeof(string), typeof(ViewModelShower), new PropertyMetadata("", OnNameChange));

        public static readonly DependencyProperty ValueNameProperty =
      DependencyProperty.Register("ValueName", typeof(string), typeof(ViewModelShower), new PropertyMetadata("", OnValueNameChange));



        public static readonly DependencyProperty ValueTypeProperty =
      DependencyProperty.Register("ValueType", typeof(string), typeof(ViewModelShower), new PropertyMetadata("", OnValueTypeChange));

        public static readonly DependencyProperty ValueRemProperty =
         DependencyProperty.Register("ValueRem", typeof(string), typeof(ViewModelShower), new PropertyMetadata("", OnValueRemChange));

        public static readonly DependencyProperty NameGraphicsProperty =
        DependencyProperty.Register("NameGraphics", typeof(string), typeof(ViewModelShower), new PropertyMetadata("", OnNameGraphicsChange));



        public int ValueInt
        {
            get { return (int)GetValue(ValueIntProperty); }
            set { SetValue(ValueIntProperty, value); }
        }

        public double ValueDouble
        {
            get { return (double)GetValue(ValueDoubleProperty); }
            set { SetValue(ValueDoubleProperty, value); }
        }

        public float ValueFloat
        {
            get { return (float)GetValue(ValueFloatProperty); }
            set { SetValue(ValueFloatProperty, value); }
        }




        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public string ValueName
        {
            get { return (string)GetValue(ValueNameProperty); }
            set { SetValue(ValueNameProperty, value); }
        }
        public string ValueType
        {
            get { return (string)GetValue(ValueTypeProperty); }
            set { SetValue(ValueTypeProperty, value); }
        }
        public string ValueRem
        {
            get { return (string)GetValue(ValueRemProperty); }
            set { SetValue(ValueRemProperty, value); }
        }
        public string NameGraphics
        {
            get { return (string)GetValue(NameGraphicsProperty); }
            set { SetValue(NameGraphicsProperty, value); }
        }



        private static void OnValChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelShower;
            com.Refrech();

        }
        private static void OnNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelShower;
            com.Marshrut.Name = e.NewValue.ToString();

        }
        private static void OnValueNameChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelShower;
            if (e.NewValue != null)
            {
                com.Marshrut.ValueName = e.NewValue.ToString();
                
                {
                    com.init1 = true;
                    if (com.init1 && com.init2) com.SetBnd(com.Marshrut.ValueName, com.Marshrut.ValueType);
                }
               
            }

        }
        private static void OnValueTypeChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelShower;
            if (e.NewValue != null)
            {
                com.Marshrut.ValueType = e.NewValue.ToString();
                com.init2 = true;
                if (com.init1 && com.init2) com.SetBnd(com.Marshrut.ValueName, com.Marshrut.ValueType);
               
            }

        }
        private static void OnValueRemChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelShower;
            if(e.NewValue!=null)
            com.Marshrut.ValueRem = e.NewValue.ToString();


        }
        private static void OnNameGraphicsChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var com = d as ViewModelShower;
            com.init1 = true;
            if (com.init1 && com.init2  ) com.SetBnd(com.Marshrut.ValueName, com.Marshrut.ValueType);

        }

        //перечень элементов в маршруте
        public ObservableCollection<StringItem> ListGraphics
        {
            get { return Marshrut.NameGraphics; }
            set { Marshrut.NameGraphics = value; }
        }

        public void DeleteGraphics(string OldNameG)
        {
            StringItem OldName = new StringItem();
            OldName.Value = OldNameG;

            foreach (StringItem sti in Marshrut.NameGraphics)
            {
                if (sti.Value == OldNameG)
                    OldName = sti;

            }

            Marshrut.NameGraphics.Remove(OldName);
            


        }
        public void AddGraphics(string NameG)
        {
            StringItem Name = new StringItem();
            Name.Value = NameG;

            if (!Marshrut.NameGraphics.Contains<StringItem>(Name))
            {
                Marshrut.NameGraphics.Add(Name);

               
            }
        }
        #region public property
        public Route Marshruts
        {
            get { return Marshrut; }
        }


        #endregion

        private void SetBnd(string varName, string TypeVal)
        {

            var val = ViewModelVariableList.Instance.GetVariable(varName);
            DependencyProperty dp = ViewModelShower.ValueIntProperty;
            //   Valuer v = new Valuer<bool>();
            object v=new object();
            init1 = false;
            init2 = false;
            switch (TypeVal)
            {
                case "Int":
                    {
                        v = ((IntVar)val.VarM).ValState;
                        dp = ViewModelShower.ValueIntProperty;

                        break;

                    }
                case "Float":
                    {
                        v = ((FloatVar)val.VarM).ValState;
                        dp = ViewModelShower.ValueFloatProperty;
                        break;

                    }
                case "Double":
                    {
                        v = ((DoubleVar)val.VarM).ValState;
                        dp = ViewModelShower.ValueDoubleProperty;
                        break;
                    }
            }



           BindingOperations.SetBinding(this, dp, new Binding { Source = v, Path = new PropertyPath("ValueState") });
        }

        private void Refrech()
        {
            foreach (var st in Marshrut.NameGraphics)
            {
                var gpe = _canva.GetPatch(st.Value) ;
                if (gpe.TVisual == 4)
                {
                    ViewModelValueLabel gp = (ViewModelValueLabel)gpe;
                    if (ValueType == "Int")
                    {
                        gp.patch.IntValue = ValueInt;

                    }
                    if (ValueType == "Double")
                    {
                        gp.patch.DoubleValue = ValueDouble;
                    }

                    if (ValueType == "Float")
                    {
                        gp.patch.FloatValue = ValueFloat;
                    }
                }
                if (gpe.TVisual == 5)
                {
                    ViewModelarcBalon gp = (ViewModelarcBalon)gpe;
                    gp.patch.Progress = ValueInt;
                     if (ValueType == "Int")
                    {
                        gp.Progress = ValueInt;

                    }
                    if (ValueType == "Double")
                    {
                        gp.Progress = ValueDouble;
                    }

                    if (ValueType == "Float")
                    {
                        gp.Progress = ValueFloat;
                    }
                }
                if (gpe.TVisual == 6)
                {
                    ViewModelProgressVolt gp = (ViewModelProgressVolt)gpe;
                    gp.patch.Progress = ValueInt;
                    if (ValueType == "Int")
                    {
                        gp.Progress = ValueInt;

                    }
                    if (ValueType == "Double")
                    {
                        gp.Progress = ValueDouble;
                    }

                    if (ValueType == "Float")
                    {
                        gp.Progress = ValueFloat;
                    }
                }
                if (gpe.TVisual == 7)
                {
                    ViewModelColorInd gp = (ViewModelColorInd)gpe;
                    gp.patch.Progress = ValueInt;
                    if (ValueType == "Int")
                    {
                        gp.Progress = ValueInt;

                    }
                    if (ValueType == "Double")
                    {
                        gp.Progress = ValueDouble;
                    }

                    if (ValueType == "Float")
                    {
                        gp.Progress = ValueFloat;
                    }
                }
            }






        }
    }
}
