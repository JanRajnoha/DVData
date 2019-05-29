using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DVData
{
    /// <summary>
    /// Interaction logic for Card_art.xaml
    /// </summary>
    public partial class Card_art : Window
    {
        public MainWindow Client;
        public string LinkAct;

        public Card_art(string odkaz)
        {
            InitializeComponent();
            LinkAct = odkaz;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadGallery_Click(object sender, RoutedEventArgs e)
        {
            LinkAct = "http://www.csfd.cz/" + LinkAct;
            SearchClass SClass = new SearchClass(LinkAct + "galerie");
            var FindComboBox = SClass.HDoc.DocumentNode.Descendants("option").Where(d => d.Attributes.Contains("value")).Select(d => d.Attributes["value"].Value);
            LoadGallery.Visibility = Visibility.Hidden;
            List<Image> Gal = new List<Image>();
            if (FindComboBox.Count() != 0)
            foreach (string Film in FindComboBox)
            {
                try
                {
                    var webget = new HtmlWeb();
                    int PagesCount = 1;
                    var doc = webget.Load(LinkAct + "galerie/filtr-" + Film + "/?type=1");
                    try
                    {
                        try
                        {
                            string MorePages = doc.DocumentNode.SelectSingleNode("//*[@id='action']/div[2]/div[3]/a[1]").InnerText;
                            if (MorePages == "2")
                            {
                                while (true)
                                {
                                    try
                                    {
                                        MorePages = doc.DocumentNode.SelectSingleNode("//*[@id='action']/div[2]/div[3]/a[" + (PagesCount + 1).ToString() + "]").InnerText;
                                        //  if (MorePages != "následující >>")
                                        PagesCount++;
                                    }
                                    catch { break; }
                                }
                                PagesCount--;
                                MorePages = doc.DocumentNode.SelectSingleNode("//*[@id='action']/div[2]/div[3]/a[" + PagesCount.ToString() + "]").InnerText;
                                Int32.TryParse(MorePages, out PagesCount);
                            }
                        }
                        catch { }

                        int Position = 10;
                        int PicCount = 1;
                        LinkAct = LinkAct + "galerie/" + Film + "/strana-";
                        for (int j = 1; j <= PagesCount; j++)
                        {
                            string alink = LinkAct + j.ToString() + "/?type=1";
                            doc = webget.Load(alink);
                            for (int i = 1; ; i++)
                            {
                                try
                                {
                               /*     Image Pic = new Image();
                                    string s = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[4]/div[3]/ul[1]/li[" + i + "]").InnerHtml;
                                    string p = s.Split('(')[1].Split(')')[0];
                                    s = "http:" + p.Substring(1, p.Length - 2);
                                    string Img = s;

                                    BitmapImage bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.UriSource = new Uri(Img, UriKind.Absolute);
                                    bitmap.EndInit();
                                    
                                    Pic.Source = bitmap;
                                    Pic.Name = Film + "-pic" + PicCount.ToString();
                                    Pic.Stretch = Stretch.Uniform;
                                    Pic.Width = 300;
                                    Pic.Height = 200;
                                    Pic.MouseDown += Pic_MouseDown;

                                    Thickness ItemPosition = Pic.Margin;
                                    ItemPosition.Left = 0;
                                    ItemPosition.Top = Position;
                                    Pic.Margin = ItemPosition;
                                    
                                    string PicActors = "";
                                    try
                                    {
                                        PicActors = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[4]/div[3]/ul[1]/li[" + i + "]/p[2]").InnerText;
                                    }
                                    catch { }
                                    Pic.ToolTip = PicActors;
                                    Pic.HorizontalAlignment = HorizontalAlignment.Center;
                                    Pic.VerticalAlignment = VerticalAlignment.Top;

                                    Position += 210;
                                    Gal.Add(Pic);
                                    Pics.Children.Add(Pic);
                                    PicCount++;*/
                                }
                                catch { break; }
                            }
                        }
                    }
                    catch { }
                }
                catch { }
                if (Gal.Count == 0)
                {
                  /*  Label lab = new Label();
                    Thickness ItemPosition = lab.Margin;
                    ItemPosition.Left = 0;
                    ItemPosition.Top = 0;
                    lab.Margin = ItemPosition;
                    lab.HorizontalAlignment = HorizontalAlignment.Center;
                    lab.VerticalAlignment = VerticalAlignment.Stretch;
                    SearchClass SClass = new SearchClass();
                    if (SClass.CheckNet())
                    {
                        lab.Content = "Tento film neobsahuje foto k filmu";
                        lab.ToolTip = "Tento film neobsahuje foto k filmu";
                    }
                    else
                    {
                        lab.Content = "Nejste připojeni k internetu";
                        lab.ToolTip = "Nejste připojeni k internetu";
                    }
                    lab.Height = 50;
                    Pics.Children.Add(lab);*/
                }
            }
        }

        private void Pic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
               /* Image img = sender as Image;
                PicDetail detail = new PicDetail();
                detail.Nadpis.Content += name.Text;
                detail.Actors.Content = img.ToolTip.ToString();
                detail.Title = name.Text;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(img.Source.ToString(), UriKind.Absolute);
                bitmap.EndInit();

                detail.Img.Source = bitmap;
                detail.Show();*/
            }
        }
    }
}
