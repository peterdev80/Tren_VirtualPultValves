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
    ///     <MyNamespace:_3StateKey/>
    ///
    /// </summary>
    public class _3StateKey : Control
    {
        static _3StateKey()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(_3StateKey), new FrameworkPropertyMetadata(typeof(_3StateKey)));
        }
        public static readonly DependencyProperty KeyValueProperty = DependencyProperty.Register(
        "KeyValue", typeof(int), typeof(_3StateKey), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender));
        public int KeyValue
        {
            get { return (int)GetValue(KeyValueProperty); }
            set { this.SetValue(KeyValueProperty, value); }
        }

        //цвет активного состояния ключа
        public static readonly DependencyProperty ActivColorProperty =
      DependencyProperty.Register("ActivColor", typeof(Brush), typeof(_3StateKey),
      new PropertyMetadata(Brushes.Black));
        /// <summary>
        /// Свойства кисть для анимации
        /// </summary>
        public Brush ActivColor
        {
            get { return (Brush)GetValue(ActivColorProperty); }
            set { SetValue(ActivColorProperty, value); }
        }

    }
}
