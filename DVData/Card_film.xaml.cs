using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Card_film.xaml
    /// </summary>
    public partial class Card_film : Window
    {
        public string LinkFilm = "";    
        public ulong ID;
        public SqlCeConnection pripojeni;
        public MainWindow Client;
        public string link;
        string DVDcheck, seencheck;
        bool SameFilms = false;

        public Card_film(string odkaz)
        {
            InitializeComponent();
            IDActor.Binding = new Binding("IDArt");
            Actor.Binding = new Binding("NameArt");
            Link.Binding = new Binding("LinkArt");
            LinkFilm = odkaz;
        }

        private void CloseWin(object sender, RoutedEventArgs e)
        {
            if (Accept.Content.ToString() == "Přidat film do databáze")
            {
                CheckChecked();
                do
                {
                    for (int i = 0; i < Client.Filmy.Items.Count; i++)
                    {
                        DataRowView data = (DataRowView)Client.Filmy.Items[i];
                        string rok = data.Row.ItemArray[4].ToString();
                        if ((data.Row.ItemArray[1].ToString() == name.Text.ToString())
                            && (rok == year.Text.ToString()))
                        {
                            SameFilms = true;
                            break;
                        }
                    }

                    bool okay = false;

                    if (SameFilms)
                    {
                        if (MessageBox.Show("Varování\n\nVáš film má shodný název jako jeden z filmů v databázi.\n\n" +
                            "Přidáním filmu můžete duplikovat záznamy a tím zpomalovat program.\n\nPřejete si i přesto film přidat do databáze?", "Varování: Shodné názvy filmů", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.OK)
                        {
                            okay = true;
                        }
                        else
                        {
                            Client.stav_prog("Zobrazuji kartu filmu; Přidání filmu nepotvrzeno");
                        }
                    }
                    else
                        okay = true;
                    SameFilms = false;

                    if (okay)
                    {
                        SqlCeCommand Query = new SqlCeCommand("INSERT INTO Filmy " +
                               "([ID],[Film],[typ],[Země],[Rok],[délka],[Adresa - CSFD],[Hodnocení - CSFD],[Viděl],[DVD]) " +
                               "VALUES (@idcko,@Filmname,@typtyp,@zem,@year,@length,@adresa,@hodnoceni,@vid,@cd)", pripojeni);

                        Query.Parameters.AddWithValue("@idcko", ID);
                        Query.Parameters.AddWithValue("@Filmname", name.Text.ToString());
                        Query.Parameters.AddWithValue("@typtyp", type.Text.ToString());
                        Query.Parameters.AddWithValue("@zem", state.Text.ToString());
                        Query.Parameters.AddWithValue("@year", year.Text.ToString());
                        Query.Parameters.AddWithValue("@length", Regex.Split(length.Text.ToString(), " min")[0] + " min");
                        if (link.Contains("\""))
                        {
                            int i = link.IndexOf('\"');
                            link = link.Substring(0, i);
                        }
                        Query.Parameters.AddWithValue("@adresa", link);
                        Query.Parameters.AddWithValue("@hodnoceni", rating.Text.ToString());
                        Query.Parameters.AddWithValue("@vid", seencheck);
                        Query.Parameters.AddWithValue("@cd", DVDcheck);
                        try
                        {
                            int affected = Query.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Name, MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        Client.stav_prog("Záznam přidán do databáze\nFilm: " + name.Text.ToString());
                        SearchClass SClass = new SearchClass();
                        Client.Filmy.ItemsSource =
                            SClass.FindInData(new TextBox(), pripojeni, new CheckBox(), new CheckBox(), new ComboBox()).Items;
                        Client.Activate();
                        this.Close();
                    }
                }
                while (SameFilms);
            }
            else
            {
                Client.Activate();
                this.Close();
            }
        }

        private void CheckChecked()
        {
            if ((bool)DVD.IsChecked)
                DVDcheck = "Ano";
            else
                DVDcheck = "Ne";

            if ((bool)seen.IsChecked)
                seencheck = "Ano";
            else
                seencheck = "Ne";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Client.Activate();
            this.Close();
        }

        private void LoadGallery_Click(object sender, RoutedEventArgs e)
        {
            LoadGallery.Visibility = Visibility.Hidden;
            List<Image> Gal = new List<Image>();
            try
            {
                var webget = new HtmlWeb();
                int PagesCount = 1;
                if (LinkFilm.Contains("\""))
                {
                    int i = LinkFilm.IndexOf('\"');
                    LinkFilm = LinkFilm.Substring(0, i);
                }
                var doc = webget.Load(LinkFilm + "galerie/?type=1");
                try
                {
                    try
                    {
                        string MorePages = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[4]/div[3]/div[2]/a[1]").InnerText;
                        if (MorePages == "2")
                        {
                            while (true)
                            {
                                try
                                {
                                    MorePages = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[4]/div[3]/div[2]/a[" + (PagesCount + 1).ToString() + "]").InnerText;
                                  //  if (MorePages != "následující >>")
                                        PagesCount++;
                                }
                                catch { break; }
                            }
                            PagesCount--;
                            MorePages = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[4]/div[3]/div[2]/a[" + PagesCount.ToString() + "]").InnerText;
                            Int32.TryParse(MorePages, out PagesCount);
                        }
                    }
                    catch { }
                    int Position = 10;
                    int PicCount = 1;
                    LinkFilm = LinkFilm + "galerie/strana-";
                    for (int j = 1; j <= PagesCount; j++)
                    {
                        string alink = LinkFilm + j.ToString() + "/?type=1";
                        doc = webget.Load(alink);
                        for (int i = 1; ; i++)
                        {
                            try
                            {
                                Image Pic = new Image();
                                string s = doc.DocumentNode.SelectSingleNode("//*[@id='main']/div[4]/div[3]/ul[1]/li[" + i + "]").InnerHtml;
                                string p = s.Split('(')[1].Split(')')[0];
                                s = "http:" + p.Substring(1, p.Length - 2);
                                string Img = s;

                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.UriSource = new Uri(Img, UriKind.Absolute);
                                bitmap.EndInit();

                                Pic.Source = bitmap;
                                Pic.Name = "pic" + PicCount.ToString();
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
                                PicCount++;
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
                Label lab = new Label();
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
                Pics.Children.Add(lab);
            }
        }

        private void Actors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var webget = new HtmlWeb();
            var doc = webget.Load(LinkFilm);
            bool con = true;
            int div = 1;
            while (con)
            {
                string Actors = doc.DocumentNode.SelectSingleNode("//*[@id='profile']/div[1]/div[2]/div[1]/div[" + div + "]/h4[1]").InnerText;
                if (Actors == "Hrají:")
                    con = false;
                else
                    div++;
            }

            try
            {
                string LinkSource = doc.DocumentNode.SelectSingleNode("//*[@id='profile']/div[1]/div[2]/div[1]/div[" + div + "]/span[1]/a[" + (Actors.SelectedIndex + 1) + "]").OuterHtml;
                string Link = "http://www.csfd.cz" + Regex.Split(Regex.Split(LinkSource, "<a href=\"")[1], "\">")[0];

                ArtCard ACard = (ArtCard)Actors.SelectedItem;
                Card_art PropArt = ACard.LoadCard(ACard, (new SearchClass() { HDoc = webget.Load(Link) }).HDoc);
                PropArt.Client = Client;
                PropArt.LinkAct = Link;
                PropArt.Title = "Karta tvůrce: " + ACard.NameArt;
                PropArt.Show();
            }
            catch {}
        }

        private void Pic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Image img = sender as Image;
                PicDetail detail = new PicDetail();
                detail.Nadpis.Content += name.Text;
                detail.Actors.Content = img.ToolTip.ToString();
                detail.Title = name.Text;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(img.Source.ToString(), UriKind.Absolute);
                bitmap.EndInit();

                detail.Img.Source = bitmap;
                detail.Show();
            }
        }
    }
}
