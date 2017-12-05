using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Net;
using System.IO;
using System.Net.Sockets;
using Microsoft.Win32;
using WMPLib;
using System.Diagnostics;

namespace mps_proiect
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        public Form1()
        {
            InitializeComponent();
            synthesizer.SelectVoiceByHints(VoiceGender.Female);
        }


        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnDisable.Enabled = false;
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            //start recognize multiple commands
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btnDisable.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] {
                "mona print my name",
                "mona datetime please",
                "mona ip address",
                "mona internet connection",
                "goodbye mona",
                "mona battery life",
                "mona show image",
                "mona hide image"
            });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            
        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "mona print my name":
                    richTextBox1.Text += "\nAmalia";
                    break;
                case "mona datetime please":
                    //synthesizer.SpeakAsync(richTextBox1.SelectedText);
                    synthesizer.SpeakAsync(DateTime.Now.ToString("yyyy, MM, dd, hh, mm"));
                    break;
                case "mona ip address":
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    string ipAddress = "";
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                             ipAddress = ip.ToString();
                        }
                    }
                    if (ipAddress.Length != 0)
                    {
                        synthesizer.SpeakAsync("The ip address is " + ipAddress);
                    } else
                    {
                        synthesizer.SpeakAsync("No network adapters with an IPv4 address in the system!");
                    }
                    break;
                case "mona internet connection":
                    try
                    {
                        Dns.GetHostEntry("www.google.com"); //using System.Net;
                        synthesizer.SpeakAsync("Yes, you are connected to internet");
                    }
                    catch (SocketException ex)
                    {
                        synthesizer.SpeakAsync("It looks like you have problems with internet connectivity.");
                    }
                    break;
                case "goodbye mona":
                    synthesizer.SpeakAsync("Goodbye Amalia! Have a nice day!");
                    System.Threading.Thread.Sleep(5000);
                    Application.Exit();
                    break;
                case "mona battery life":
                    String batterystatus;

                    PowerStatus pwr = SystemInformation.PowerStatus;
                    batterystatus = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();

                    synthesizer.SpeakAsync("battery charge status is" + batterystatus);
                    break;
                case "mona show image":
                    richTextBox1.Text += "\nShow Image";
                    Process.Start("mspaint", @"""C:\Users\Amalia\Desktop\mps_proiect2\dreamteam\mps_proiect\bin\Debug\9.jpg""");
                    break;
                case "mona hide image":
                    richTextBox1.Text += "\nHide Image";
                    System.Diagnostics.Process[] procs = null;
          
                    procs = Process.GetProcessesByName("mspaint");

                    if (!procs[0].HasExited)
                    {
                        procs[0].Kill();
                    }
                   
                    break;
            }
        }
    }
}
