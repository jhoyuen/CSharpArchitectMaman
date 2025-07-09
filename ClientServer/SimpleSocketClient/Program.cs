using System.Net.Sockets;
using System.Net;
using System.Text;

const string serverIp = "127.0.0.1";
const int port = 5000;

var clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
clientSocket.Connect(new IPEndPoint(IPAddress.Parse(serverIp), port));

Console.WriteLine("[Client] Connected to server.");
Console.Write("Enter message: ");
string message = Console.ReadLine();

byte[] buffer = Encoding.UTF8.GetBytes(message);
clientSocket.Send(buffer);

byte[] responseBuffer = new byte[1024];
int received = clientSocket.Receive(responseBuffer);
string response = Encoding.UTF8.GetString(responseBuffer, 0, received);

Console.WriteLine($"[Client] Received from server: {response}");

clientSocket.Close();
Console.WriteLine("[Client] Connection closed.");