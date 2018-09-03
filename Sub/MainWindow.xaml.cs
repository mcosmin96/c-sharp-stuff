using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace Sub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMyEvents
    {
        MySubscriptionServiceProxy Proxy { get; set; }
        int Count { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Proxy = MySubscriptionServiceProxy.NewProxy(new InstanceContext(this));
            Proxy.Subscribe("OnBroadcast");
            Count = 0;
        }

        protected override void OnClosed(EventArgs e)
        {
            Proxy.Close();
            base.OnClosed(e);
        }

        public void OnBroadcast()
        {
            this.FireCount.Text = Count++.ToString();
        }
    }
}
