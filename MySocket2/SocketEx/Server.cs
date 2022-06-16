using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MySocket2.SocketEx
{
  public class Server : SocketBase
  { 
    public Server(string ip = "127.0.0.1", int port = 8080, Action<Socket, byte[]>? callback = null) : base(ip, port, callback)
    { 
      Socket.Bind(Ipep);
      Socket.Listen(10);
      Socket.BeginAccept(Accept, Socket);    
    }

    private void Accept(IAsyncResult asyncResult)
    {
      var client = new ClientHelper(Socket.EndAccept(asyncResult), Callback);
      Socket.BeginAccept(Accept, Socket);
    }
  }
}
