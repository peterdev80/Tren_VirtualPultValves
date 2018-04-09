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

using ValueModel.BaseType;

namespace WPFMnemoLibrary.ControlLibrary
{
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFMnemoLibrary.ControlLibrary"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFMnemoLibrary.ControlLibrary;assembly=WPFMnemoLibrary.ControlLibrary"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:BasicMnemoKey/>
    ///
    /// </summary>
    public class BasicMnemoKey : Control
    {
        static BasicMnemoKey()
        {


            //DefaultStyleKeyProperty.OverrideMetadata(typeof(BasicMnemoKey), new FrameworkPropertyMetadata(typeof(BasicMnemoKey)));
        }

      

        public BitPosValue ObmenPos
        {
            get;
            set;
        }
        public BitPosValue ObmenPos2bit
        {
            get;
            set;
        }
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }

        }
        public static readonly DependencyProperty ValueProperty =
         DependencyProperty.Register("Value", typeof(int), typeof(BasicMnemoKey),
         new PropertyMetadata(0, new PropertyChangedCallback(UpdateState)));




        /// <summary>
        /// Состояние ключа
        /// </summary>
        /// <returns></returns>
        public int State
        {
            get { return (int)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }

        }
        public static readonly DependencyProperty StateProperty =
         DependencyProperty.Register("State", typeof(int), typeof(BasicMnemoKey),
         new PropertyMetadata(0));

        /// <summary>
        /// Алгоритм получения текущего состояния из инт, переопределяемый
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual int GetState(BitPosValue value)
        {
            if (value.HasFlag(ObmenPos)) return 1;
            return 0;
        }
        private static void UpdateState(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BasicMnemoKey element = (BasicMnemoKey)d;
            try
            {
                BitPosValue _curentState = (BitPosValue)Enum.Parse(typeof(BitPosValue), element.Value.ToString());
                element.State = element.GetState(_curentState);
                element.SetValue(StateProperty, element.GetState(_curentState)); 

            }
            catch
            {
              //  MessageBox.Show("Значение INT вне диапазона");

            }
        }

        //передергиваем  для обовления
        public void RefreshKey()
        {
        }

    }
}
