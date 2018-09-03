using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCommon;

namespace WpfCustomControls
{
    public class ItemContainer : ContentControl
    {
        static ItemContainer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ItemContainer), new FrameworkPropertyMetadata(typeof(ItemContainer)));
        }

        public ItemContainer()
        {

        }

        //DependencyProperty
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ItemContainer), new FrameworkPropertyMetadata(String.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        //DependencyPropertyWrapper
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set { SetValue(TextProperty, value);  }
        }

        //DependencyProperty
        public static readonly DependencyProperty ItemPropertyProperty =
            DependencyProperty.Register("ItemProperty", typeof(ItemClass), typeof(ItemContainer), new FrameworkPropertyMetadata(new ItemClass(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        //DependencyPropertyWrapper
        public ItemClass ItemProperty
        {
            get => (ItemClass)GetValue(ItemPropertyProperty);
            set { SetValue(ItemPropertyProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
