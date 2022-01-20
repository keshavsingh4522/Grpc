using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        public const string Target = "127.0.0.1:60001";
        static async Task Main(string[] args)
        {
            var channel = new Channel(Target, ChannelCredentials.Insecure);
            await channel.ConnectAsync().ContinueWith((task)=> {
                if(task.Status==TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("connected to server successsfully!");
                }
            });

            var client = new DemoService.DemoServiceClient(channel);

            Console.Write("Enter Num1 : ");
            var num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Num2 : ");
            var num2 = Convert.ToInt32(Console.ReadLine());


            var result =client.Demo(new DemoRequest() {
                 Num1=num1,
                 Num2=num2
            });

            Console.WriteLine("result -> "+result);
            Console.ReadKey();
        }
    }
}
