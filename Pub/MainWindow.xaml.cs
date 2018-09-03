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

namespace Pub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyEventsProxy Proxy { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Proxy = MyEventsProxy.NewProxy();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Proxy.OnBroadcast();
        }

        protected override void OnClosed(EventArgs e)
        {
            Proxy.Close();
            base.OnClosed(e);
        }
    }
}
