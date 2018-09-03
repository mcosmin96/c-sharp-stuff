using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PubSubService
{
    [ServiceContract(CallbackContract = typeof(IMyEvents))]
    public interface IMySubscriptionService : ServiceModelEx.ISubscriptionService
    {
    }
}
