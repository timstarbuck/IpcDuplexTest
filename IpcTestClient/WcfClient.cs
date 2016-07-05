using IpcTestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace IpcTestClient
{
    public class WcfClient : System.ServiceModel.ClientBase<ISubscribeForStateChanges>, ISubscribeForStateChanges
    {
        public WcfClient()
        {
        }

        public WcfClient(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress):
            base(callbackInstance, binding, remoteAddress)
        {

        }

        public void SubscribeClient(string appKey)
        {
            base.Channel.SubscribeClient(appKey);
        }
    }
}
