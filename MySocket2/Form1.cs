using MySocket2.SocketEx;
using System.Text;

namespace MySocket2
{
  public partial class Form1 : Form
  {
    Client client;
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var server = new Server(callback: (socket,buffer) => {
        Manager.Send(socket, buffer);        
      });
    }

    private void button2_Click(object sender, EventArgs e)
    {
      client = new Client(callback: (socket, buffer) =>
      {
        string text = Manager.GetString(buffer);
      });

      client.Send("æ»≥Á«œººø‰!");
    }

  }
}