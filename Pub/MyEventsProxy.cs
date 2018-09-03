using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Pub
{
    partial class MyEventsProxy : ClientBase<IMyEvents>, IMyEvents
    {
        public static MyEventsProxy NewProxy()
        {
            var binding = new NetNamedPipeBinding();
            var remoteAddress = new EndpointAddress("net.pipe://localhost/ClientPubService");

            return new MyEventsProxy(binding, remoteAddress);
        }

        public MyEventsProxy()
        {
            InnerChannel.OperationTimeout = new TimeSpan(0, 0, 10);
            Endpoint.Binding = new NetNamedPipeBinding();
            Endpoint.Address = new EndpointAddress("net.pipe://localhost/ClientPubService");
            Endpoint.Contract = new System.ServiceModel.Description.ContractDescription("IMyEvents");

            (Endpoint.Binding as NetNamedPipeBinding).TransactionFlow = true;
        }

        public MyEventsProxy(string endpointConfigurationName) : base(endpointConfigurationName)
        { }

        public MyEventsProxy(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
        { }

        public MyEventsProxy(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
        { }

        public MyEventsProxy(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {
            InnerChannel.OperationTimeout = new TimeSpan(0, 0, 10);
            //Endpoint.Contract = new System.ServiceModel.Description.ContractDescription("IMyEvents");

            //(Endpoint.Binding as NetNamedPipeBinding).TransactionFlow = true;
        }

        public void OnBroadcast()
        {
            Channel.OnBroadcast();
        }
    }
}
