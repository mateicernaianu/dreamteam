using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YoutubeSearch;

namespace mps_proiect
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        Choices commands = new Choices();
        List<string> listOfCommands;
        string demoUsername = "demo > ";
        string monaUsername = "mona < ";

        public Form1()
        {
            InitializeComponent();
            synthesizer.SelectVoiceByHints(VoiceGender.Female);
            wplayer.settings.autoStart = false;
            wplayer.URL = @"C:\Users\Amalia\Desktop\mps_proiect2\dreamteam\mps_proiect\bin\Debug\play1.mp3";
        }


       /* private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
           // btnDisable.Enabled = false;
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            //start recognize multiple commands
           // btnDisable.Enabled = true;
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            listOfCommands = new List<string> {
                "mona datetime please",
                "mona ip address",
                "mona internet connection",
                "goodbye mona",
                "mona battery life",
                "mona show image",
                "mona hide image",
                "mona play music",
                "mona stop music",
                "mona open chrome",
                "mona close chrome",
                "mona open outlook",
                "mona close outlook",
                "mona exchange",
                "mona exchange euro",
                "mona exchange dollar",
                "mona exchange pounds",
                "mona exchange ron to euro",
                "mona exchange ron to dollar",
                "mona exchange ron to pounds",
                "mona exchange euro to dollar",
                "mona exchange dollar to euro",
                "mona exchange euro to pounds",
                "mona exchange dollar to pounds",
                "mona exchange pounds to euro",
                "mona exchange pounds to dollar",
                "mona play jazz",
                "mona play latino",
                "mona play rock",
                "mona stop youtube",
                "mona tell local weather",
                "mona tell new york weather",
                "mona tell chicago weather",
                "mona tell paris weather",
                "mona where I am",
                "mona where is new york",
                "mona where is paris",
                "mona where is chicago"
            };

            commands.Add(new string[] {
                "mona datetime please",
                "mona ip address",
                "mona internet connection",
                "goodbye mona",
                "mona battery life",
                "mona show image",
                "mona hide image",
                "mona play music",
                "mona stop music",
                "mona open chrome",
                "mona close chrome",
                "mona open outlook",
                "mona close outlook",
                "mona exchange",
                "mona exchange euro",
                "mona exchange dollar",
                "mona exchange pounds",
                "mona exchange ron to euro",
                "mona exchange ron to dollar",
                "mona exchange ron to pounds",
                "mona exchange euro to dollar",
                "mona exchange dollar to euro",
                "mona exchange euro to pounds",
                "mona exchange dollar to pounds",
                "mona exchange pounds to euro",
                "mona exchange pounds to dollar",
                "mona play jazz",
                "mona play latino",
                "mona play rock",
                "mona stop youtube",
                "mona tell local weather",
                "mona tell new york weather",
                "mona tell chicago weather",
                "mona tell paris weather",
                "mona where I am",
                "mona where is new york",
                "mona where is paris",
                "mona where is chicago"
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
            richTextBox1.Text += this.demoUsername + e.Result.Text + "\n";
            switch (e.Result.Text)
            {
                case "mona datetime please":
                    richTextBox1.Text += this.monaUsername + DateTime.Now.ToString("yyyy, MM, dd, hh, mm") + "\n";
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
                        richTextBox1.Text += this.monaUsername + "The ip address is " + ipAddress + "\n";
                        synthesizer.SpeakAsync("The ip address is " + ipAddress);
                    } else
                    {
                        richTextBox1.Text += this.monaUsername + "No network adapters with an IPv4 address in the system!\n";
                        synthesizer.SpeakAsync("No network adapters with an IPv4 address in the system!");
                    }
                    break;
                case "mona internet connection":
                    try
                    {
                        Dns.GetHostEntry("www.google.com");
                        richTextBox1.Text += this.monaUsername + "Yes, you are connected to internet.\n";
                        synthesizer.SpeakAsync("Yes, you are connected to internet");
                    }
                    catch (SocketException ex)
                    {
                        richTextBox1.Text += this.monaUsername + "It looks like you have problems with internet connectivity.\n";
                        synthesizer.SpeakAsync("It looks like you have problems with internet connectivity.");
                    }
                    break;
                case "goodbye mona":
                    richTextBox1.Text += this.monaUsername + "Goodbye Amalia! Have a nice day!\n";
                    synthesizer.SpeakAsync("Goodbye Amalia! Have a nice day!");
                    recEngine.RecognizeAsyncStop();
                    System.Threading.Thread.Sleep(5000);
                    Application.Exit();
                    break;
                case "mona battery life":
                    String batterystatus;

                    PowerStatus pwr = SystemInformation.PowerStatus;
                    batterystatus = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();
                    richTextBox1.Text += this.monaUsername + "battery charge status is" + batterystatus + "\n";
                    synthesizer.SpeakAsync("battery charge status is" + batterystatus);
                    break;
                case "mona show image":
                    richTextBox1.Text += this.monaUsername + "Show image\n";
                    Process.Start("mspaint", @"""C:\Users\Amalia\Desktop\mps_proiect2\dreamteam\mps_proiect\bin\Debug\9.jpg""");
                    break;
                case "mona hide image":
                    richTextBox1.Text += richTextBox1.Text += this.monaUsername + "Hide image\n";
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
                case "mona play music":
                    richTextBox1.Text += richTextBox1.Text += this.monaUsername + "Play\n";
                    wplayer.controls.play();
                    break;
                case "mona stop music":
                    richTextBox1.Text += richTextBox1.Text += this.monaUsername + "Stop\n";
                    wplayer.controls.pause();
                    break;
                case "mona open chrome":
                    richTextBox1.Text += richTextBox1.Text += this.monaUsername + "Open chrome\n";
                    Process chromeProcess = new Process();

                    chromeProcess.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                    chromeProcess.StartInfo.Arguments = "google.com" + " --new-window";

                    chromeProcess.Start();
                    break;
                case "mona close chrome":
                    richTextBox1.Text += richTextBox1.Text += this.monaUsername + "Close chrome\n";
                    this.closeChrome(richTextBox1, "chrome");
                    break;
                case "mona open outlook":
                    richTextBox1.Text += richTextBox1.Text += this.monaUsername + "Open outlook\n";
                    Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\OUTLOOK.EXE");
                    break;
                case "mona close outlook":
                    richTextBox1.Text += richTextBox1.Text += this.monaUsername + "Close outlook\n";
                    if (Process.GetProcessesByName("outlook").Length != 0)
                    {
                        foreach (var outlookProc in Process.GetProcessesByName("outlook"))
                        {
                            outlookProc.Kill();
                        }
                    }
                    break;
                case "mona exchange euro":
                    richTextBox1.Text += this.monaUsername + "One euro is " + ConvertCurrency("EUR", "RON") + " ron\n";
                    synthesizer.SpeakAsync("One euro is " + ConvertCurrency("EUR","RON") + " ron");
                    break;
                case "mona exchange dollar":
                    richTextBox1.Text += this.monaUsername + "One dollar is " + ConvertCurrency("USD", "RON") + " ron\n";
                    synthesizer.SpeakAsync("One dollar is " + ConvertCurrency("USD", "RON") + " ron");
                    break;
                case "mona exchange pounds":
                    richTextBox1.Text += this.monaUsername + "One pound is " + ConvertCurrency("GBP", "RON") + " ron\n";
                    synthesizer.SpeakAsync("One pound is " + ConvertCurrency("GBP", "RON") + " ron");
                    break;
                case "mona exchange ron to euro":
                    richTextBox1.Text += this.monaUsername + "One ron is " + ConvertCurrency("RON", "EUR") + " euro\n";
                    synthesizer.SpeakAsync("One ron is " + ConvertCurrency("RON", "EUR") + " euro");
                    break;
                case "mona exchange ron to dollar":
                    richTextBox1.Text += this.monaUsername + "One ron is " + ConvertCurrency("RON", "USD") + " usd\n";
                    synthesizer.SpeakAsync("One ron is " + ConvertCurrency("RON", "USD") + " usd");
                    break;
                case "mona exchange ron to pounds":
                    richTextBox1.Text += this.monaUsername + "One ron is " + ConvertCurrency("RON", "GBP") + " pounds\n";
                    synthesizer.SpeakAsync("One ron is " + ConvertCurrency("RON", "GBP") + " pounds");
                    break;
                case "mona exchange euro to dollar":
                    richTextBox1.Text += this.monaUsername + "One euro is " + ConvertCurrency("EUR", "USD") + " usd\n";
                    synthesizer.SpeakAsync("One euro is " + ConvertCurrency("EUR", "USD") + " usd");
                    break;
                case "mona exchange dollar to euro":
                    richTextBox1.Text += this.monaUsername + "One usd is " + ConvertCurrency("USD", "EUR") + " euro\n";
                    synthesizer.SpeakAsync("One usd is " + ConvertCurrency("USD", "EUR") + " euro");
                    break;
                case "mona exchange euro to pounds":
                    richTextBox1.Text += this.monaUsername + "One euro is " + ConvertCurrency("EUR", "GBP") + " pounds\n";
                    synthesizer.SpeakAsync("One euro is " + ConvertCurrency("EUR", "GBP") + " pounds");
                    break;
                case "mona exchange dollar to pounds":
                    richTextBox1.Text += this.monaUsername + "One usd is " + ConvertCurrency("USD", "GBP") + " pounds\n";
                    synthesizer.SpeakAsync("One usd is " + ConvertCurrency("USD", "GBP") + " pounds");
                    break;
                case "mona exchange pounds to euro":
                    richTextBox1.Text += this.monaUsername + "One pound is " + ConvertCurrency("GBP", "EUR") + " euro\n";
                    synthesizer.SpeakAsync("One pound is " + ConvertCurrency("GBP", "EUR") + " euro");
                    break;
                case "mona exchange pounds to dollar":
                    richTextBox1.Text += this.monaUsername + "One pound is " + ConvertCurrency("GBP", "USD") + " usd\n";
                    synthesizer.SpeakAsync("One pound is " + ConvertCurrency("GBP", "USD") + " usd");
                    break;
                case "mona play jazz":
                    richTextBox1.Text += this.monaUsername + "Enjoy the jazz music!\n";
                    synthesizer.SpeakAsync("Enjoy the jazz music!");                   
                    playOnYoutube("jazz", richTextBox1);
                    break;
                case "mona play latino":
                    richTextBox1.Text += this.monaUsername + "Enjoy the latino music!\n";
                    synthesizer.SpeakAsync("Enjoy the latino music!");
                    playOnYoutube("latino", richTextBox1);
                    break;
                case "mona play rock":
                    richTextBox1.Text += this.monaUsername + "Enjoy the rock music!\n";
                    synthesizer.SpeakAsync("Enjoy the rock music!");
                    playOnYoutube("rock", richTextBox1);
                    break;
                case "mona stop youtube":
                    richTextBox1.Text += this.monaUsername + "Stop youtube\n";
                    this.closeChrome(richTextBox1, "youtube");
                    break;
                case "mona tell local weather":
                    richTextBox1.Text += this.monaUsername + "Bucharest: " + getWeather("Bucharest") + "\n";
                    synthesizer.SpeakAsync(getWeather("Bucharest"));
                    break;
                case "mona tell new york weather":
                    richTextBox1.Text += this.monaUsername + "New York: " + getWeather("New York") + "\n";
                    synthesizer.SpeakAsync(getWeather("New York"));
                    break;
                case "mona tell paris weather":
                    richTextBox1.Text += this.monaUsername + "Paris: " + getWeather("Paris") + "\n";
                    synthesizer.SpeakAsync(getWeather("Paris"));
                    break;
                case "mona tell chicago weather":
                    richTextBox1.Text += this.monaUsername + "Chicago: " + getWeather("Chicago") + "\n";
                    synthesizer.SpeakAsync(getWeather("Chicago"));
                    break;
                case "mona where I am":
                    richTextBox1.Text += this.monaUsername + "You are in Buchares. Here is the map for you.\n";
                    openMaps("Bucharest");
                    synthesizer.SpeakAsync("You are in Buchares. Here is the map for you.");
                    break;
                case "mona where is new york":
                    richTextBox1.Text += this.monaUsername + "Here is the map for you.\n";
                    openMaps("New+York");
                    synthesizer.SpeakAsync("Here is the map for you.");
                    break;
                case "mona where is paris":
                    richTextBox1.Text += this.monaUsername + "Here is the map for you.\n";
                    openMaps("Paris");
                    synthesizer.SpeakAsync("Here is the map for you.");
                    break;
                case "mona where is chicago":
                    richTextBox1.Text += this.monaUsername + "Here is the map for you.\n";
                    openMaps("Chicago");
                    synthesizer.SpeakAsync("Here is the map for you.");
                    break;
            }
        }

        /* private void testButtonPlay_Click(object sender, EventArgs e)
         {
             wplayer.controls.play();
         }

         private void testButtonStop_Click(object sender, EventArgs e)
         {
             //wplayer.controls.stop();
             wplayer.controls.pause();
         }*/
        public static void openMaps(string location)
        {
            Process chromeProcess = new Process();

            chromeProcess.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            chromeProcess.StartInfo.Arguments = "https://www.google.ro/maps/place/" + location + " --new-window";

            chromeProcess.Start();
        }


        public static String ConvertCurrency(string fromCurrency, string toCurrency)
        {
            string URL = String.Format("http://api.fixer.io/latest?symbols={0}&base={1}", toCurrency, fromCurrency).ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    JObject obj = (JObject)JsonConvert.DeserializeObject(reader.ReadLine().ToString());
                    return obj.SelectToken("rates." + toCurrency).ToString();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                throw;
            }
        }

        public static String getWeather(string city)
        {
            string apiKey = "8f5d06de227e024cd7ecb6a9b34e4db4";
            string URL = String.Format("http://api.openweathermap.org/data/2.5/weather?mode=json&units=metric&q={0}&appid={1}", city, apiKey).ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    JObject obj = (JObject)JsonConvert.DeserializeObject(reader.ReadLine().ToString());
                    int degrees = (int) obj.SelectToken("main.temp");
                    string conditionOutside = obj.SelectToken("weather[0].description").ToString();
                    return conditionOutside + " and " + degrees + " celsius degrees";
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                throw;
            }
        }


        public void playOnYoutube(string searchedItem, RichTextBox richTextBox1)
        {
            VideoSearch items = new VideoSearch();
            List<string> list = new List<string>();
            
            foreach (var item in items.SearchQuery(searchedItem, 1))
            {  
                list.Add(item.Url);               
            }
            Random rnd = new Random();
            int randomVideoIndex = rnd.Next(list.Count);
            
            Process youtubeProcessInChrome = new Process();

            youtubeProcessInChrome.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            youtubeProcessInChrome.StartInfo.Arguments = list[randomVideoIndex];

            youtubeProcessInChrome.Start();
        }

        public void closeChrome(RichTextBox richTextBox1, string chromeOrYoutube)
        {
            Process[] chromeInstances = Process.GetProcessesByName("chrome");
            foreach (Process chromeProc in chromeInstances)
            {
                chromeProc.Kill();
            }
        }

        private void infoCommands_Click(object sender, EventArgs e)
        {
            PopupForm popup = new PopupForm();
            popup.Text = "How to use";
            popup.VerticalScroll.Visible = true;
            
            popup.EnteredText += String.Join(Environment.NewLine, new List<string>{ "Commands:", ""});
            popup.EnteredText += String.Join(Environment.NewLine, this.listOfCommands);
            popup.Font = new Font(popup.Font, FontStyle.Italic);
            DialogResult dialogresult = popup.ShowDialog();           
            popup.Dispose();
        }

        private void aboutMona_Click(object sender, EventArgs e)
        {
            PopupForm popup = new PopupForm();
            popup.Text = "About Mona";
            popup.VerticalScroll.Visible = false;
            popup.Font = new Font(popup.Font, FontStyle.Regular);

            popup.EnteredText += "Acest produs software este dezvoltat de catre echipa Dreamteam si are ca scop indeplinirea unui set de comenzi vocale rostite de catre utilizator.";
            DialogResult dialogresult = popup.ShowDialog();
            popup.Dispose();
        }
    }
}
