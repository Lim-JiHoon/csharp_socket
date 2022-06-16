using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MySocket2.SocketEx
{
  public class ClientHelper : HelperBase
  {
    private Socket socket;

    public ClientHelper(Socket socket, Action<Socket, byte[]>? callback)
    {
      this.socket = socket;

      socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, Receive, callback);
    }

    private void Receive(IAsyncResult result)
    {
      if (!socket.Connected) return;
      var callback = result.AsyncState as Action<Socket, byte[]>;

      switch (state)
      {
        case SocketState.Waiting:
          switch (Buffer[0])
          {
            case 0:
              state = SocketState.Size;
              Buffer = new byte[4];

              break;
            case 1:
              state = SocketState.Buffer;
              Buffer = new byte[BufferSize];

              break;
          }

          break;

        case SocketState.Size:
          state = SocketState.Waiting;
          BufferSize = BitConverter.ToInt32(Buffer, 0);
          Buffer = new byte[1];
          break;

        case SocketState.Buffer:
          state = SocketState.Waiting;

          callback?.Invoke(socket, Buffer);
          // 버퍼 전송
          socket.Disconnect(false);
          socket.Close();
          socket.Dispose();
          return;
      }

      socket.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, Receive, callback);
    }
  }

  public class HelperBase
  {
    protected SocketState state = SocketState.Waiting;
    public byte[] Buffer { get; set; } = new byte[1];
    public int BufferSize = 0;
  }
}
