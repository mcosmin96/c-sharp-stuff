using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class MySubscriptionService : ServiceModelEx.SubscriptionManager<IMyEvents>, IMySubscriptionService
    {
    }
}
