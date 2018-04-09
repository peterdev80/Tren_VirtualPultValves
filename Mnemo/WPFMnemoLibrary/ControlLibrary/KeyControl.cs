using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace WPFMnemoLibrary.ControlLibrary
{
    public enum KeyButtonType
    {
        Left,
        Reiht,
        Up,
        Down

    }
    public abstract class KeyControl : Control
    {
        public static readonly DependencyProperty KeyStateProperty = DependencyProperty.Register(
           "KeyState", typeof(bool), typeof(KeyControl), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));
        public bool KeyState
        {
            get { return (bool)GetValue(KeyStateProperty); }
            set { this.SetValue(KeyStateProperty, value); }
        }

        public static readonly DependencyProperty KeyTypeProperty = DependencyProperty.Register(
            "KeyType", typeof(KeyButtonType), typeof(KeyControl), new FrameworkPropertyMetadata(KeyButtonType.Left, FrameworkPropertyMetadataOptions.AffectsRender));
        public KeyButtonType KeyType
        {
            get { return (KeyButtonType)GetValue(KeyTypeProperty); }
            set { this.SetValue(KeyTypeProperty, value); }
        }



    }
}
