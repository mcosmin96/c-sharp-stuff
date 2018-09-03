using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Sub
{
    partial class MySubscriptionServiceProxy : DuplexClientBase<IMySubscriptionService>, IMySubscriptionService
    {
        public static MySubscriptionServiceProxy NewProxy(InstanceContext inputInstance)
        {
            var binding = new NetNamedPipeBinding();
            var remoteAddress = new EndpointAddress("net.pipe://localhost/ClientSubService");

            return new MySubscriptionServiceProxy(inputInstance, binding, remoteAddress);
        }

        public MySubscriptionServiceProxy(InstanceContext inputInstance) : base(inputInstance)
        { }

        public MySubscriptionServiceProxy(InstanceContext inputInstance, string endpointConfigurationName) : base(inputInstance, endpointConfigurationName)
        { }

        public MySubscriptionServiceProxy(InstanceContext inputInstance, string endpointConfigurationName, string remoteAddress) : base(inputInstance, endpointConfigurationName, remoteAddress)
        { }

        public MySubscriptionServiceProxy(InstanceContext inputInstance, string endpointConfigurationName, EndpointAddress remoteAddress) : base(inputInstance, endpointConfigurationName, remoteAddress)
        { }

        public MySubscriptionServiceProxy(InstanceContext inputInstance, Binding binding, EndpointAddress remoteAddress) : base(inputInstance, binding, remoteAddress)
        {
            InnerChannel.OperationTimeout = new TimeSpan(0, 0, 10);
            //Endpoint.Contract = new System.ServiceModel.Description.ContractDescription("Sub.IMyEvents");

            //(Endpoint.Binding as NetNamedPipeBinding).TransactionFlow = true;
        }

        public void Subscribe(string eventOperation)
        {
            Channel.Subscribe(eventOperation);
        }

        public void Unsubscribe(string eventOperation)
        {
            Channel.Unsubscribe(eventOperation);
        }
    }
}
