using IpcTestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IpcTestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "net.pipe://localhost/IPCTest";

            Server instance = new Server();

            ServiceHost serviceHost = new ServiceHost(instance); //new ServiceHost(typeof(Server));
            NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            serviceHost.AddServiceEndpoint(typeof(ISubscribeForStateChanges), binding, address);
            serviceHost.Open();

            Console.WriteLine("ServiceHost running. Press 'X' to Exit. Or type message to send.");
            bool stop = false;
            while (stop == false)
            {
                string line = Console.ReadLine();
                if (line.Equals("X")) {
                    stop = true;
                } else
                {
                    if (serviceHost.SingletonInstance != null)
                    {
                        ((Server)serviceHost.SingletonInstance).NotifyOfStateChage(line);
                    } else
                    {
                        Console.WriteLine("No instance");
                    }
                }
            }

        }
    }
}
