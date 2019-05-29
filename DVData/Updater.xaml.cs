using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DVData
{
    /// <summary>
    /// Interaction logic for Updater.xaml
    /// </summary>
    public partial class Updater : Window
    {
        HtmlWeb webget = new HtmlWeb();
        string product, link, describe   = "";
        int size = 0;
        MainWindow client;
        System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
        public bool Update = false;
        bool SilentUpdate = false;

        public Updater(string produkt, MainWindow MWindow, bool Notify)
        {
            InitializeComponent();
            product = produkt;
            client = MWindow;
            SilentUpdate = Notify;
        }

        private static Action EmptyDelegate = delegate () { };

        internal void CheckUpdate()
        {
            SearchClass SClass = new SearchClass();
            if (SClass.CheckNet())
                try
                {
                    InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    Steps.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    Steps.Maximum = 4;
                    InfoBox.Text = "Připojuji se na server";
                    InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    var doc = webget.Load("http://www.goid-cz.webnode.cz/update");
                    InfoBox.Text += "\nPřipojení proběhlo úspěšně";
                    Steps.Value++;
                    InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    Steps.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    InfoBox.Text += "\nZjišťuji verze:";
                    InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    string NetVersion = doc.DocumentNode.SelectSingleNode("//*[@id='" + product + "-version']").InnerText;
                    if (NetVersion.Contains("\n\t"))
                        NetVersion = NetVersion.Substring(2, NetVersion.Length - 2);
                    InfoBox.Text += "\nDostupná verze: " + NetVersion;
                    InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    string PCVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    InfoBox.Text += "\nAktuální verze: " + PCVersion;
                    Steps.Value++;
                    InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    Steps.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    for (int i = 0; i <= 6; i += 2)
                    {
                        int net, pc;
                        Int32.TryParse(PCVersion[i].ToString(), out pc);
                        Int32.TryParse(NetVersion[i].ToString(), out net);
                        if (net > pc)
                        {
                            Update = true;
                            break;
                        }
                    }
                    Steps.Value++;
                    Steps.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    if (Update)
                    {
                        Accept.Visibility = Visibility.Visible;
                        InfoBox.Text += "\nJe dostupná novější verze";
                        InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                        InfoBox.Text += "\nKliknutím na Aktualizovat program aktualizujete";
                        InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                        link = doc.DocumentNode.SelectSingleNode("//*[@id='" + product + "-link']").InnerText;
                        if (link.Contains("\n\t"))
                            link = link.Substring(2, link.Length - 2);
                        client.NewVersion.Text = "Update k dispozici. Co nabízí nová verze?";
                        InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                        describe = doc.DocumentNode.SelectSingleNode("//*[@id='" + product + "-updateinfo']").InnerText;
                        if (describe.Contains("\n\t"))
                            client.DescribeNewVersion.Text = describe.Substring(2, describe.Length - 2);
                    }
                    else
                    {
                        InfoBox.Text += "\nVáš program je aktuální";
                        InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                        Steps.Value = Steps.Maximum;
                        Steps.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                        Accept.Content = "Zavřít";
                        Accept.Visibility = Visibility.Visible;
                    }
                }
                catch { }
            else
            {
                InfoBox.Text = "Nejste připojeni k internetu";
                InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
            }
            if (SilentUpdate)
                client.Running = false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (Accept.Content.ToString() != "Zavřít")
            {
                Accept.IsEnabled = false;
                InfoBox.Text += "\nPříprava ke stahování";
                InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                WebClient c = new WebClient();
                c.DownloadFileCompleted += new AsyncCompletedEventHandler(c_DownloadFileCompleted);
                c.DownloadProgressChanged += c_DownloadProgressChanged;
                Uri u = new Uri(link);
                size = (int)SizeOfFile(link);
                if (size != 0)
                {
                    time.Start();
                    Steps.Value = 0;
                    Steps.Maximum = 100;
                    Steps.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    InfoBox.Text += "\nProgram stáhne " + size / 1024 + "kB dat";
                    InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    InfoBox.Text += "\nStahuji";
                    InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\Aktualizace");
                    c.DownloadFileAsync(u, Environment.CurrentDirectory + "\\Aktualizace\\" + product + ".exe");
                }
                else
                {
                    InfoBox.Text += "\nProgram nemůže stáhnout soubor z důvoduu chyby na serveru";
                    InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                    Accept.Content = "Zavřít";
                }
            }
            else
                this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            client.Running = false;
        }

        long SizeOfFile(string adress)
        {
            System.Net.WebRequest req = System.Net.HttpWebRequest.Create(adress);
            req.Method = "HEAD";
            using (System.Net.WebResponse resp = req.GetResponse())
            {
                int ContentLength;
                if (int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                {
                    return ContentLength; 
                }
            }
            return 0;
        }

        private void c_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            System.IO.FileInfo i = new System.IO.FileInfo(product + ".exe");
            Steps.Value = e.ProgressPercentage;
            Steps.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

        private void c_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            time.Stop();
            if (Steps.Value == 100)
            {
                InfoBox.Text += "\nStahování bylo úspěšně dokončeno";
                InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                InfoBox.Text += "\nNyní se provede aktualizace programu";
                InfoBox.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
                string bat = "taskkill /im " + product + ".exe\n del " + product + ".exe \n" +
                    "move \"" + Environment.CurrentDirectory.ToString() + "\\Aktualizace\\" + product + ".exe\" \"" + Environment.CurrentDirectory.ToString() +
                    "\\" + product + ".exe\" \nrmdir \"" + Environment.CurrentDirectory.ToString() + "\\Aktualizace\" \n" + product + ".exe \nexit";
                using (System.IO.FileStream file = new System.IO.FileStream(Environment.CurrentDirectory.ToString() + @"\bat.bat", System.IO.FileMode.OpenOrCreate))
                using (System.IO.StreamWriter write = new System.IO.StreamWriter(file))
                {                    
                    write.Write(bat);
                    write.Close();
                }
                this.Close();
                client.IsUpdate = true;
                client.Close();
            }
        }
    }
}
