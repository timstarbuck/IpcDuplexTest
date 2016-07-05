using IpcTestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpcTestClient
{
    public class Client : IStateChangeNotification
    {
        public void StateChanged(string newState)
        {
            Console.WriteLine("New State = {0}", newState);
        }
    }
}
