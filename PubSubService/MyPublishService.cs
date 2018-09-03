using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class MyPublishService : ServiceModelEx.PublishService<IMyEvents>, IMyEvents
    {
        public void OnBroadcast()
        {
            FireEvent();
        }
    }
}
