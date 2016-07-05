using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpcTestModel;
using System.ServiceModel;

namespace IpcTestServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Server : ISubscribeForStateChanges
    {
        private IStateChangeNotification _clientChannel;

        public void SubscribeClient(string appKey)
        {
            //todo verify appKey
            var channel = OperationContext.Current.GetCallbackChannel<IStateChangeNotification>();
            _clientChannel = channel;
            Console.WriteLine("{0} Subscribed [{1}]", appKey, OperationContext.Current.SessionId);
        }

        public void NotifyOfStateChage(string newState)
        {
            if (_clientChannel != null)
            {
                _clientChannel.StateChanged(newState);
            }
        }


    }
}
