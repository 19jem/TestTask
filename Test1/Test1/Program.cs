using System;
using System.ServiceProcess;

namespace Test1 
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
            new TcpServer()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
