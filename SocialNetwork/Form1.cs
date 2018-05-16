using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using SocketChat;




namespace SocialNetwork
{
    public partial class Form1 : Form
    {
        VoiceControl VC = new VoiceControl();


        /* private string knowFileName()
         {

         }*/

        public Form1()
        {
            InitializeComponent();
       
        }
        private string GetLocalIP()
        {
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }
                return localIP;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sck = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.ReuseAddress,true);
            //get user ip
            textLocalIp.Text = GetLocalIP();
            textRemoteIp.Text = GetLocalIP();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            VC.startRecording();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VC.stopRecording();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VC.listenRecording();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



        Socket sck;
        EndPoint epLocal, epRemote;

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                byte[] receivedData = new byte[1500];
                receivedData = (byte[])aResult.AsyncState;
                //converting byte array to string
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string receivedMessage = aEncoding.GetString(receivedData);
                //Adding this meassage into listbox
                listMessage.Items.Add("Friend: " + receivedMessage);

                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //binding socket with local ip
            epLocal = new IPEndPoint(IPAddress.Parse(textLocalIp.Text), Convert.ToInt32(textLocalPort.Text));
            sck.Bind(epLocal);

            //connect to remote IP
            epRemote=new IPEndPoint(IPAddress.Parse(textRemoteIp.Text), Convert.ToInt32(textRemotePort.Text));
            sck.Connect(epRemote);
            //listening specific port
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer,0,buffer.Length,SocketFlags.None,ref epRemote,new AsyncCallback(MessageCallBack),buffer);

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            //convert  string message to byte array
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1500];
            sendingMessage = aEncoding.GetBytes(textMessage.Text);
            //sending the Encoding message
            sck.Send(sendingMessage);
            //addding to the listBox
            listMessage.Items.Add("Me: "+ textMessage.Text);
            textMessage.Text = null;
        }

        byte[] buffer;

    }
}
