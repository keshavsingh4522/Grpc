using Grpc.Core;
using System;

namespace Server_02
{
    class Program
    {
        public const int Port = 60001;
        static void Main(string[] args)
        {
            Console.WriteLine("server is litening on the port "+Port);

            var server = new Server()
            {
                Ports = {new ServerPort("localhost",Port,ServerCredentials.Insecure)},
                Services = { DemoService.BindService(new DemoServiceImpl()) }
            };
            server.Start();
            Console.ReadKey();
        }
    }
}
