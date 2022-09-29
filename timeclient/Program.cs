// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using System.Text;

int port = 1303;

Console.Write("Введите ip адрес сервера: ");
var ipStr = Console.ReadLine();
var ip = IPAddress.Parse(ipStr!);

try
{
    IPEndPoint ipPoint = new IPEndPoint(ip, port);
 
    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    // подключаемся к удаленному хосту
    socket.Connect(ipPoint);
 
    // получаем ответ
    var data = new byte[256]; // буфер для ответа
    StringBuilder builder = new StringBuilder();
    int bytes = 0; // количество полученных байт
 
    do
    {
        bytes = socket.Receive(data, data.Length, 0);
        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
    }
    while (socket.Available > 0);
    Console.WriteLine(builder.ToString());
 
    // закрываем сокет
    socket.Shutdown(SocketShutdown.Both);
    socket.Close();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

