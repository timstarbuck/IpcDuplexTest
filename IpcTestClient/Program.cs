using IpcTestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IpcTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var testClient = new Client();
            InstanceContext context = new InstanceContext(testClient);

            string address = "net.pipe://localhost/IPCTest";
            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            EndpointAddress ep = new EndpointAddress(address);

            try
            {
                WcfClient client = new WcfClient(context, binding, ep);
                Console.WriteLine("Client Connected");
                client.SubscribeClient("TestAppKey");
            }
            catch (EndpointNotFoundException ex)
            {
                Console.WriteLine("Server doesn't appear to be listening.";
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            Console.ReadLine();

        }
    }
}
