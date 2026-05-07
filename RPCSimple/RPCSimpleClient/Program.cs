using CalculatorRpc;
using Grpc.Core;

namespace RPCSimple.RPCSimpleClient;

class Program   
{
    static void Main()
    {
        var channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
        var client = new Calculator.CalculatorClient(channel);
        var reply = client.Add(new AddRequest { X = 5, Y = 3 });
        Console.WriteLine("5 + 3 = " + reply.Result);
        Console.ReadLine();
        channel.ShutdownAsync().Wait();
    }
}