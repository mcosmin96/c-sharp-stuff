using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;

namespace PubSubService
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected ServiceHost PublishServiceHost { get; set; }
        protected ServiceHost SubscriptionManagerHost { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            PublishServiceHost = new ServiceHost(typeof(MyPublishService), new Uri("net.pipe://localhost/ClientPubService"));
            PublishServiceHost.Open();

            SubscriptionManagerHost = new ServiceHost(typeof(MySubscriptionService), new Uri("net.pipe://localhost/ClientSubService"));
            SubscriptionManagerHost.Open();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            PublishServiceHost.Close();
            SubscriptionManagerHost.Close();

            base.OnExit(e);
        }
    }
}
