using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MySocket2.SocketEx
{
  public class Client : SocketBase
  {

    public Client(string ip = "127.0.0.1", int port = 8080, Action<Socket, byte[]>? callback = null) : base(ip, port, callback) { }

    public void Send(byte[] buffer)
    {
      //using (Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
      //{
      //  client.Connect(Ipep);
      //  //var clientHelper = new ClientHelper(client, Callback);

      //  client.Send(new byte[] { 0 });
      //  client.Send(BitConverter.GetBytes(buffer.Length));
      //  client.Send(new byte[] { 1 });
      //  client.Send(buffer);

      //  buffer = new byte[4096];
      //  client.Receive(buffer);
      //}

      Socket.Connect(Ipep);
      var clientHelper = new ClientHelper(Socket, Callback);
      Manager.Send(Socket, buffer);      

      //buffer = new byte[4096];
      //client.Receive(buffer);

      
    }

    public void Send(string text)
    {
      Socket.Connect(Ipep);
      var clientHelper = new ClientHelper(Socket, Callback);
      Manager.Send(Socket, text);
    }
  }
}
