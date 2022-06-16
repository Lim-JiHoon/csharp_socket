using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MySocket2.SocketEx
{
  public abstract class SocketBase
  {
    protected Socket Socket { get; set; }
    protected IPEndPoint Ipep { get; set; }
    protected Action<Socket, byte[]>? Callback { get; set; }

    public SocketBase(string ip = "127.0.0.1", int port = 8080, Action<Socket, byte[]>? callback = null)
    {
      Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      Ipep = new IPEndPoint(IPAddress.Parse(ip), port);
      Callback = callback;
    }
  }
}
