using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MySocket2.SocketEx
{
  public class Manager
  {   
    public static void Send(Socket socket, string text)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(text);
      Send(socket, bytes);
    }

    public static void Send(Socket socket, byte[] bytes)
    {
      socket.Send(new byte[] { 0 });
      socket.Send(BitConverter.GetBytes(bytes.Length));
      socket.Send(new byte[] { 1 });
      socket.Send(bytes);
    }

    public static string GetString(byte[] bytes)
    {
      return Encoding.UTF8.GetString(bytes);
    }
  }
}
