using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Data;

namespace DVData
{
    public class ArtCard
    {
        public string NameArt { get; set; }

        public string Birth { get; set; }

        public string Job { get; set; }

        public string IDArt { get; set; }

        public string LinkArt { get; set; }

        internal Card_art LoadCard(ArtCard data, Result res, HtmlDocument HDoc)
        {
            var webget = new HtmlWeb();
            SearchClass SClass = new SearchClass();
            SClass.HDoc = HDoc;
            int ul = 1;
            if (res.CurrentRecordIndex > 4)
            {
                ul = 2;
                res.CurrentRecordIndex -= 4;
            }
            string[] mezi = Regex.Split(SClass.HDoc.DocumentNode.SelectSingleNode("//*[@id='search-creators']/div[1]/ul[" + ul.ToString() + "]/li[" + (res.CurrentRecordIndex) + "]").InnerHtml, "<a href=\"");
            string[] link = Regex.Split(mezi[1], "\">");
            data.LinkArt = link[0];
            SClass.HDoc = webget.Load("http://www.csfd.cz" + link[0]);

            return LoadCard(data, SClass.HDoc);
        }

        internal Card_art LoadCard(ArtCard data, HtmlDocument HDoc)
        {
            Card_art card = new Card_art(data.LinkArt);
            card.ArtName.Text = data.NameArt;
            card.Birthday.Text = data.Birth;
            card.Job.Text = data.Job;
            try
            {
                try
                {
                    card.Die.Text = HDoc.DocumentNode.SelectSingleNode("//*[@id='profile']/div[1]/div[2]/ul[1]/li[2]").InnerText;
                    card.Die.Text = Replace(card.Die.Text, "\n", " ");
                    card.Die.Text = Replace(card.Die.Text, "\t");
                    card.Die.Text = card.Die.Text.Substring(1, card.Die.Text.Length - 2);
                }
                catch { }

                try
                {
                    card.Birthday.Text = HDoc.DocumentNode.SelectSingleNode("//*[@id='profile']/div[1]/div[2]/ul[1]/li[1]").InnerText;
                    card.Birthday.Text = Replace(card.Birthday.Text, "\n", " ");
                    card.Birthday.Text = Replace(card.Birthday.Text, "\t");
                    card.Birthday.Text = card.Birthday.Text.Substring(1, card.Birthday.Text.Length - 2);
                }
                catch { }

                try
                {
                    var FindDivTag = HDoc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("image"));
                    var ImageHTMLSource = FindDivTag.Select(c => c.InnerHtml).Single();
                    string Img = "http:" + Regex.Split(Regex.Split(ImageHTMLSource, "<img src=\"")[1], "\"")[0];
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(Img, UriKind.Absolute);
                    bitmap.EndInit();
                    card.Photo.Source = bitmap;
                    card.Photo.Stretch = System.Windows.Media.Stretch.UniformToFill;
                }
                catch { }

                try
                {
                    for (int i = 1; ; i++)
                    {
                        try
                        {
                            string AwardsSource = HDoc.DocumentNode.SelectSingleNode("//*[@id='fanclub-chart']/p[" + i + "]/a").InnerHtml;
                            string Awards = Replace(Replace(Regex.Split(AwardsSource, "<br>")[0], "\t"), "\n") + " " + Regex.Split(AwardsSource, "<br>")[1];
                            card.FanAwards.Text += Replace(Awards, "\t") + ", ";
                        }
                        catch { break; }
                    }
                    card.FanAwards.Text = card.FanAwards.Text.Substring(0, card.FanAwards.Text.Length - 2);
                }
                catch { }

                try
                {
                    card.Story.Text = HDoc.DocumentNode.SelectSingleNode("//*[@id='action']/div[2]/p[1]").InnerText;
                }
                catch { card.Story.Text = "Nepodařilo se nám načíst biografii tvůrce."; }

                try
                {
                    try
                    {
                        for (int i = 1; ; i++)
                        {
                            string Header = "";
                            try
                            {
                                Header = HDoc.DocumentNode.SelectSingleNode("//*[@id='filmography']/div[" + i + "]/div[1]/h2").InnerText;
                                DataGrid DataG = new DataGrid();
                                DataG.IsReadOnly = true;

                                DataGridTextColumn Column = new DataGridTextColumn();
                                Column.Header = "ID";
                                Column.Binding = new Binding("IDFilm");
                                Column.Visibility = Visibility.Collapsed;
                                DataG.Columns.Add(Column);

                                Column = new DataGridTextColumn();
                                Column.Header = "Rok";
                                Column.Binding = new Binding("Year");
                                DataG.Columns.Add(Column);

                                Column = new DataGridTextColumn();
                                Column.Header = "Název filmu";
                                Column.Binding = new Binding("NameFilm");
                                DataG.Columns.Add(Column);

                                string last = "";

                                for (int j = 1; ; j++)
                                {
                                    try
                                    {
                                        string pok = HDoc.DocumentNode.SelectSingleNode("//*[@id='filmography']/div[" + i + "]/div[2]/table/tr[" + j + "]/td[1]").InnerText;
                                        try
                                        {
                                            string year = HDoc.DocumentNode.SelectSingleNode("//*[@id='filmography']/div[" + i + "]/div[2]/table/tr[" + j + "]/th").InnerText;
                                            Replace(ref year, "\n");
                                            Replace(ref year, "\t");
                                            string film = HDoc.DocumentNode.SelectSingleNode("//*[@id='filmography']/div[" + i + "]/div[2]/table/tr[" + j + "]/td").InnerText;
                                            Replace(ref film, "\n");
                                            Replace(ref film, "\t");
                                            if (year != "")
                                                last = year;
                                            else
                                                year = last;
                                            if (film != "")
                                                DataG.Items.Add(new FilmCard() { IDFilm = j.ToString(), Year = year, NameFilm = film });
                                        }
                                        catch { }
                                    }
                                    catch { break; }
                                }

                                TabItem ti = new TabItem();
                                ti.Header = Header;
                                Grid asdd = new Grid();
                                BrushConverter bc = new BrushConverter();
                                asdd.Background = (Brush)bc.ConvertFrom("#FF000000");
                                ti.Content = DataG;
                                card.FilmTypes.Items.Add(ti);
                            }
                            catch { break; }
                        }
                    }
                    catch { }
                }
                catch { }

            }
            catch { }

            return card;
        }

        public string Replace (string Source, string Old, string New = "")
        {
            while (Source.Contains(Old))
            {
                int Position = Source.IndexOf(Old) + 1;
                if (Position == 1)
                    Source = New + Source.Substring(Old.Length, Source.Length - Old.Length);
                else
                {
                    string Join = Source.Substring(0, Position - 1);
                    Source = Join + New + Source.Substring(Position - 1 + Old.Length, Source.Length - Join.Length - 1);
                }
            }
            return Source;
        }

        public void Replace(ref string Source, string Old, string New = "")
        {
            Source = Replace(Source, Old, New);
        }
    }
}
