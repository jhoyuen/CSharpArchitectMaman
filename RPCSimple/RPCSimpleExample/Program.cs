// Program.cs
using Grpc.Core;
using CalculatorRpc;

namespace RPCSimple.RPCSimpleExample;

class Program
{
    const int Port = 50051;
    static void Main()
    {
        var server = new Server
        {
            Services = { Calculator.BindService(new CalculatorService()) },
            Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
        };
        server.Start();
        Console.WriteLine("Server listening on port " + Port);
        Console.ReadKey();
        server.ShutdownAsync().Wait();
    }
}