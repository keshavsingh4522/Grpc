using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static DemoService;

namespace Server_02
{
   public  class DemoServiceImpl: DemoServiceBase
    {
        public override Task<DemoResponse> Demo(DemoRequest request, ServerCallContext context)
        {
            Console.WriteLine("request received from client  "+request);

            var result = request.Num1 + request.Num2;
            return Task.FromResult(new DemoResponse() { Result=result });
        }
    }
}
