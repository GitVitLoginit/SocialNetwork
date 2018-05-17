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
using System.Drawing.Imaging;




namespace SocialNetwork
{
    public partial class Form1 : Form
    {
        VoiceControl VC = new VoiceControl();
   
    /*    private void im()
        {
            System.Drawing.Image tempImage = MyProject.Properties.Resources.myImage;
            Clipboard.SetDataObject(tempImage);
            DataFormats.Format image = DataFormats.GetFormat(DataFormats.Bitmap);
            richTextBox1.Paste(image);
        }*/


        public Form1()
        {
            InitializeComponent();
       
        }
        private void sendMessage(bool voiceRecord, string recordName="")
        {
            
            //convert  string message to byte array
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendingMessage = new byte[1500];
            listMessage.Items.Add(DateTime.Now.ToLongTimeString()+":");
            if (!voiceRecord)
            {
             
                sendingMessage = aEncoding.GetBytes(textMessage.Text);
          
                //sending the Encoding message
                sck.Send(sendingMessage);
                //addding to the listBox
                listMessage.Items.Add("Me: " + textMessage.Text);

                textMessage.Text = null;
            }
            else
            {
                sendingMessage = aEncoding.GetBytes(recordName);
                //sending the Encoding message
                sck.Send(sendingMessage);
                //addding to the listBox
                listMessage.Items.Add("Me: " + recordName );
                textMessage.Text = null;
            }
          

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
            textRemotePort.Text = 80.ToString();
            textLocalPort.Text = 81.ToString();
            //  richMessage.LoadFile(@"C:\sounds\sound4.wav");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            VC.startRecording();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string recordName;
            button1.Enabled = true;
            button2.Enabled = false;

            recordName= VC.stopRecording();
            sendMessage(true, recordName);
        }

   



        Socket sck;
        EndPoint epLocal, epRemote;
        byte[] buffer;

        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                byte[] receivedData = new byte[1500];
                receivedData = (byte[])aResult.AsyncState;
                //converting byte array to string
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string receivedMessage = aEncoding.GetString(receivedData).Trim();
                //Adding this meassage into listbox

        
                listMessage.Items.Add(DateTime.Now.ToLongTimeString() + ":");
      
                listMessage.Items.Add("Friend: " +  receivedMessage);
               



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
            if (textMessage.Text.IndexOf(".wav") == -1)
                sendMessage(false);
            else
                MessageBox.Show("Don't use .wav extension in ypur messages!");
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listMessage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
 
        }

        private void listMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMessage.SelectedIndex != -1)
            {
                string choosedElem;
                choosedElem = listMessage.SelectedItem.ToString();
               
                if (choosedElem.IndexOf(".wav") != -1)//record
                {
                    choosedElem = choosedElem.Substring(choosedElem.IndexOf("sound"), choosedElem.IndexOf(".wav")- choosedElem.IndexOf("sound")+4);
                    // MessageBox.Show(choosedElem.Length.ToString());
                    //    VoiceControl VC1 = new VoiceControl();
                    VC.listenRecording(choosedElem);
                       
                }
            }
        }

      

    }
}
