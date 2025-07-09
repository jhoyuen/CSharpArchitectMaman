using System.Net;
using System.Net.Sockets;
using System.Text;

const int port = 5000;
var localEndPoint = new IPEndPoint(IPAddress.Any, port);
var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
var keepRunning = true;

// Handle Ctrl+C to trigger graceful shutdown
Console.CancelKeyPress += (sender, args) =>
{
    Console.WriteLine("\n[Server] Ctrl+C pressed. Stopping server...");
    keepRunning = false;
    listener.Close(); // Unblock listener.Accept()
    args.Cancel = true; // Prevent immediate process exit
};

try
{
    listener.Bind(localEndPoint);
    listener.Listen(5);
    Console.WriteLine($"[Server] Listening on port {port}. Press Ctrl+C to stop...");

    while (keepRunning)
    {
        try
        {
            Socket clientSocket = listener.Accept();
            Console.WriteLine("[Server] Client connected.");

            byte[] buffer = new byte[1024];
            int received = clientSocket.Receive(buffer);
            string message = Encoding.UTF8.GetString(buffer, 0, received);

            Console.WriteLine($"[Server] Received: {message}");

            string response = $"Echo: {message}";
            clientSocket.Send(Encoding.UTF8.GetBytes(response));

            clientSocket.Close();
            Console.WriteLine("[Server] Connection closed.");
        }
        catch (SocketException)
        {
            if (!keepRunning)
                break; // Exit loop gracefully when shutdown
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"[Server] Error: {ex.Message}");
}

Console.WriteLine("[Server] Server has been stopped.");