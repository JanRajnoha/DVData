using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media.Imaging;

namespace DVData
{
    public class FilmCard
    {
        public string NameFilm { get; set; }
        public string Year { get; set; }
        public string IDFilm { get; set; }
        public string LinkFilm { get; set; }

        public Card_film LoadCard(DataRowView dataRow)
        {
            string[] data = new string[10];
            for (int i = 0; i < dataRow.Row.ItemArray.Length; i++)
                data[i] = dataRow.Row.ItemArray[i].ToString();
            return LoadCard(data);
        }

        public Card_film LoadCard(string[] data)
        {
            var webget = new HtmlWeb();
            SearchClass SClass = new SearchClass();
            Card_film card = new Card_film(data[6]);
            card.name.Text = data[1];
            card.type.Text = data[2];
            card.state.Text = data[3];
            card.year.Text = data[4];
            card.length.Text = data[5];
            card.seen.IsChecked = Check(data[8]);
            card.seen.IsEnabled = false;
            card.DVD.IsEnabled = false;
            card.DVD.IsChecked = Check(data[9]);
            card.Accept.Content = "Ok";
            card.Accept.IsCancel = true;
            card.Cancel.Visibility = Visibility.Hidden;
            try
            {
                var doc = webget.Load(data[6]);
                try
                {
                    var FindH2Tag = doc.DocumentNode.Descendants("h2").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("average"));
                    var rating = FindH2Tag.Select(c => c.InnerHtml).Single();
                    card.rating.Text = rating;
                }
                catch { card.rating.Text = ""; }

                try
                {
                    card.dej.Text = doc.DocumentNode.SelectSingleNode("//*[@id='plots']/div[2]/ul[1]/li[1]/div[1]").InnerText;
                    while (card.dej.Text.Contains("\t") || card.dej.Text.Contains("\n"))
                    {
                        if (card.dej.Text.Contains("\t"))
                            card.dej.Text = card.dej.Text.Replace("\t", "");
                        else
                            card.dej.Text = card.dej.Text.Replace("\n", "");
                    }
                }
                catch
                {
                    card.dej.Text = "Nebylo možné načíst děj filmu";
                }

                try
                {
                    int i = 1;
                    card.chart.Text = "";
                    for (i = 1; ; i++)
                    {
                        try
                        {
                            card.chart.Text += doc.DocumentNode.SelectSingleNode("//*[@id='rating']/p[1]/a[" + i + "]").InnerText + ", ";
                        }
                        catch { break; }
                    }
                    card.chart.Text = card.chart.Text.Substring(0, card.chart.Text.Length - 2);
                    if (i == 1)
                        card.chart.Text = "";
                }
                catch { card.chart.Text = ""; }

                try
                {
                    string img = "http:" + Regex.Split(Regex.Split(doc.DocumentNode.SelectSingleNode("//*[@id='poster']").InnerHtml, "<img src=\"")[1], "\"")[0];
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(img, UriKind.Absolute);
                    bitmap.EndInit();
                    card.poster.Source = bitmap;
                    card.poster.Stretch = System.Windows.Media.Stretch.UniformToFill;
                }
                catch { }

                try
                {
                    for (int i = 1; ; i++)
                    {
                        string Property = doc.DocumentNode.SelectSingleNode("//*[@id='profile']/div[1]/div[2]/div[1]/div[" + i + "]/h4[1]").InnerText;
                        switch (Property)
                        {
                            case "Režie:":
                                card.Rezie.Text = LoadCreators(i, doc);
                                break;

                            case "Scénář:":
                                card.Scenar.Text = LoadCreators(i, doc);
                                break;

                            case "Kamera:":
                                card.Kamera.Text = LoadCreators(i, doc);
                                break;

                            case "Hudba:":
                                card.Hudba.Text = LoadCreators(i, doc);
                                break;

                            case "Předloha:":
                                card.Predloha.Text = LoadCreators(i, doc);
                                break;
                        }
                    }
                }
                catch { }
            }
            catch { }

            if (SClass.CheckNet())
            {
                try
                {
                    card.Actors.ItemsSource = SClass.LoadArt(data[6]).Items;
                }
                catch
                {
                }
            }
            else
            {
                card.rating.Text = data[7];
            }
            return card;
        }

        private string LoadCreators(int i, HtmlDocument doc)
        {
            string Creator = "";
            for (int j = 1; ; j++)
            {
                try
                {
                    Creator += doc.DocumentNode.SelectSingleNode("//*[@id='profile']/div[1]/div[2]/div[1]/div[" + i + "]/span[1]/a[" + j + "]").InnerText;
                }
                catch { break; }
                Creator += ", ";
            }
            return Creator.Substring(0, Creator.Length - 2);
        }

        public string[] LoadProperties(ref string name, Result res, HtmlDocument HDoc)
        {
            SearchClass SClass = new SearchClass();
            SClass.HDoc = HDoc;
            string[] data = new string[10];
            var webget = new HtmlWeb();
            var dataRow = res.Films.Items[res.CurrentRowIndex] as FilmCard;
            name = dataRow.NameFilm;
            data[1] = name;
            data[0] = "---";
            /*    var FindH3Tag = doc.DocumentNode.Descendants("a").Where(d => d.Attributes.Contains("class"));
                var puvod2 = FindH3Tag.Where(c => c.InnerText == dataRow.Nazev).Select(c => c.OuterHtml);*/
            int ul = 1;
            if (res.CurrentRecordIndex > 4)
            {
                ul = 2;
                res.CurrentRecordIndex -= 4;
            }
            string[] mezi = Regex.Split(SClass.HDoc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[" + ul.ToString() + "]/li[" + (res.CurrentRecordIndex) + "]").InnerHtml, "<a href=\"");
            string[] link = Regex.Split(mezi[1], "\">");
            SClass.HDoc = webget.Load("http://www.csfd.cz" + link[0]);
            var FindPTag = SClass.HDoc.DocumentNode.Descendants("p").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("origin"));
            try
            {
                var puvod = FindPTag.Select(c => c.InnerHtml).Single();
                string[] info = Regex.Split(puvod, ", ");
                int cislo = 0;
                if (info.Length != 0)
                {
                    bool[] properties = new bool[3];
                    for (int j = 0; j < info.Length; j++)
                    {
                        if (Int32.TryParse(info[j], out cislo))
                        {
                            data[4] = info[j];
                            properties[1] = true;
                        }
                        else if (info[j].Contains(" min"))
                        {
                            data[5] = info[j].Substring(0, info[j].Length - 4);
                            properties[2] = true;
                        }
                        else
                        {
                            data[3] = info[j];
                            properties[0] = true;
                        }
                    }
                    for (int j = 0; j < properties.Length; j++)
                    {
                        if (properties[j] == false)
                            switch (j)
                            {
                                case 0:
                                    data[3] = "xxx";
                                    break;
                                case 1:
                                    data[4] = "xxx";
                                    break;
                                case 2:
                                    data[5] = "xxx";
                                    break;
                            }
                    }
                }
                else
                {
                    data[3] = "xxx";
                    data[4] = "xxx";
                    data[5] = "xxx";
                }
            }
            catch { }
            try
            {
                FindPTag = SClass.HDoc.DocumentNode.Descendants("p").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("genre"));
                var type = FindPTag.Select(c => c.InnerHtml).Single();
                data[2] = type;
            }
            catch { data[2] = "xxx"; }
            /*   if (ul == 2)
                   ul = 4;
               else
                   ul = 0;*/
            data[6] = "http://www.csfd.cz" + link[0];
            try
            {
                var FindH2Tag = SClass.HDoc.DocumentNode.Descendants("h2").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("average"));
                var rating = FindH2Tag.Select(c => c.InnerHtml).Single();
                data[7] = rating;
            }
            catch { data[7] = ""; }
            return data;
        }

        private bool? Check(string item)
        {
            if (item == "Ano")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
