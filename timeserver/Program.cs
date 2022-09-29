// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using System.Text;

const int port = 1303;
var ipPoint = new IPEndPoint(IPAddress.Loopback, port);

var listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
try
{
    // связываем сокет с локальной точкой, по которой будем принимать данные
    listenSocket.Bind(ipPoint);
 
    // начинаем прослушивание
    listenSocket.Listen(10);
 
    Console.WriteLine("Сервер запущен. Ожидание подключений...");
 
    while (true)
    {
        var handler = listenSocket.Accept();
        
        // Генерируем и отправляем сообщение
        var message = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        Console.WriteLine(message);
        var data = Encoding.Unicode.GetBytes(message);
        handler.Send(data);
        
        // закрываем сокет
        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}