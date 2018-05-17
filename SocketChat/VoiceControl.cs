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
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace SocketChat
{
    public class VoiceControl
    {
        public string getFileName()
        {
            string fileName = @"C:\sounds\sound";
            string newFileName = fileName;
            int fileIndex = 1;
            while (File.Exists(newFileName + ".wav"))
            {

                newFileName = fileName + fileIndex.ToString();
                fileIndex++;
            }
            
            return (newFileName + ".wav");
        }

        [DllImport("winmm.dll")]
        public static extern long mciSendString(string command, StringBuilder retstring, int ReturnLenth, IntPtr callback);

        public void startRecording()
        {
            mciSendString("open new Type waveaudio alias recsound", null, 0, IntPtr.Zero);
            mciSendString("record recsound", null, 0, IntPtr.Zero);
        }
        public string stopRecording()
        {
            string fileName = getFileName();
            string command = "save recsound " + fileName;
            mciSendString(command, null, 0, IntPtr.Zero);
            mciSendString("close recsound", null, 0, IntPtr.Zero);
            return (fileName.Remove(0,10));
        }

        public bool listenRecording(string record)
        {
              bool fileExists;
              SoundPlayer waveFile = new SoundPlayer(@"C:\sounds\"+record);
              fileExists = File.Exists(@"C:\sounds\"+ record);
              if (fileExists)
              {
                  waveFile.PlaySync(); // PlaySync means that once sound start then no other activity if form will occur untill sound goes to finish

              }

            return fileExists;

        }
    }
}
