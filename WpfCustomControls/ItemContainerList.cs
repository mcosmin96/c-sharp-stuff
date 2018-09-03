using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public delegate void DependencyPropertyChangedHandler(DependencyPropertyChangedEventArgs e);
    public class ItemContainerList : Control
    {
        public static DependencyPropertyChangedHandler DependencyPropertyChanged { get; set; }

        private const string ContentPanelPart = "PART_ContentPanel";

        static ItemContainerList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ItemContainerList), new FrameworkPropertyMetadata(typeof(ItemContainerList)));
        }

        public ItemContainerList()
        {
            //ItemsSource = new ObservableCollection<ItemClass>();
        }

        //DependencyProperty
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IList), typeof(ItemContainerList), new FrameworkPropertyMetadata(new ObservableCollection<ItemClass>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnItemsSourceChanged)));
        //DependencyPropertyWrapper
        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set { SetValue(ItemsSourceProperty, value); }
        }
        //DependecyPropertyChangedCallback
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DependencyPropertyChanged?.Invoke(e);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var ContentPanel = GetTemplateChild(ContentPanelPart) as StackPanel;

            DependencyPropertyChanged += OnDependecyPropertyChanged;
        }

        private void OnDependecyPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name.Equals("ItemsSource") && ((ObservableCollection<ItemClass>)e.NewValue).Count > 0)
            {
                var ContentPanel = GetTemplateChild(ContentPanelPart) as StackPanel;
                foreach (var item in (ObservableCollection<ItemClass>)e.NewValue)
                {
                    var container = new TextBlock();
                    var binding = new Binding("ItemsSource");
                    binding.RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent);
                    container.SetBinding(TextBlock.TextProperty, binding);
                    ContentPanel.Children.Add(container);
                }
            }
        }
    }
}
