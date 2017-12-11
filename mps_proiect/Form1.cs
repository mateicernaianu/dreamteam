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
using System.Diagnostics;
using Outlook = Microsoft.Office.Interop.Outlook;

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
            wplayer.settings.autoStart = false;
            wplayer.URL = @"C:\Users\Amalia\Desktop\mps_proiect2\dreamteam\mps_proiect\bin\Debug\play1.mp3";
        }


        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnDisable.Enabled = false;
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            //start recognize multiple commands
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
                "mona hide image",
                "mona play",
                "mona stop",
                "mona open chrome",
                "mona close chrome",
                "mona open outlook",
                "mona close outlook"
            });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            //recEngine.RecognizeAsync(RecognizeMode.Multiple);
            recEngine.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(
                SpeechRecognizedHandler);
            recEngine.SetInputToDefaultAudioDevice();

            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            
        }

        void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
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

                    /*
                     * An exception of type 'System.IndexOutOfRangeException' occurred in mps_proiect.exe but was not handled in user code
                        PUNE TRY CATCH
                        */
                    if (!procs[0].HasExited)
                    {
                        procs[0].Kill();
                    }
                    break;
                case "mona play":
                    richTextBox1.Text += "\nPlay";
                    wplayer.controls.play();
                    break;
                case "mona stop":
                    richTextBox1.Text += "\nStop";
                    wplayer.controls.pause();
                    break;
                case "mona open chrome":
                    richTextBox1.Text += "\nOpen chrome";
                    Process chromeProcess = new Process();

                    chromeProcess.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                    chromeProcess.StartInfo.Arguments = "google.com" + " --new-window";

                    chromeProcess.Start();
                    break;
                case "mona close chrome":
                    richTextBox1.Text += "\nClose chrome";
                    Process[] chromeInstances = Process.GetProcessesByName("chrome");

                    foreach (Process chromeProc in chromeInstances)
                        chromeProc.Kill();
                    break;
                case "mona open outlook":
                    richTextBox1.Text += "\nOpen outlook";
                    Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\OUTLOOK.EXE");
                    break;
                case "mona close outlook":
                    richTextBox1.Text += "\nClose outlook";
                    if (Process.GetProcessesByName("outlook").Length != 0)
                    {
                        foreach (var outlookProc in Process.GetProcessesByName("outlook"))
                        {
                            outlookProc.Kill();
                        }
                    }
                    break;
            }
        }

        private void testButtonPlay_Click(object sender, EventArgs e)
        {
            wplayer.controls.play();
        }

        private void testButtonStop_Click(object sender, EventArgs e)
        {
            //wplayer.controls.stop();
            wplayer.controls.pause();
        }
    }
}
