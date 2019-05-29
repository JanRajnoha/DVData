using System;
using System.Collections.Generic;
using System.Data;
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
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace DVData
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public bool CheckSame, stejny = false;
        internal string[] novy = new string[9];
        int[] check = new int[5];
        string[] CheckBoxy = new string[2];
        int stop = 0;
        string LastName = "";
        DataGrid kontrola;
        bool FindFilm = true;

        public Add(DataGrid Filmy)
        {
            InitializeComponent();
            Refresh.Visibility = Visibility.Hidden;
            kontrola = Filmy;
            name.Focus();
        }

        public Add(Add pridej, DataGrid Filmy)
        {
            InitializeComponent();
            Refresh.Visibility = Visibility.Hidden;
            kontrola = Filmy;
            name.Focus();
            name.Text = pridej.name.Text;
            typ.Text = pridej.typ.Text;
            zeme.Text = pridej.zeme.Text;
            rok.Text = pridej.rok.Text;
            delka.Text = pridej.delka.Text;
            adresa.Text = pridej.adresa.Text;
            hodnoceni.Text = pridej.hodnoceni.Text;
            seen.IsChecked = pridej.seen.IsChecked;
            dvd.IsChecked = pridej.dvd.IsChecked;
            more.IsChecked = pridej.more.IsChecked;
            CheckProperties();
            Accept.IsEnabled = true;
        }

        public Add(string edit, DataRowView data, DataGrid Filmy)
        {
            InitializeComponent();
            more.Visibility = Visibility.Hidden;
            var Minutes = Regex.Split(data.Row.ItemArray[5].ToString(), "min");
            FindFilm = false;
            BrushConverter bc = new BrushConverter();
            this.Title = edit;
            LastName = data.Row.ItemArray[1].ToString();
            Nadpis.Content = edit;
            Accept.Content = edit;
            name.Text = data.Row.ItemArray[1].ToString();
            typ.Text = data.Row.ItemArray[2].ToString();
            zeme.Text = data.Row.ItemArray[3].ToString();
            rok.Text = data.Row.ItemArray[4].ToString();
            delka.Text = Minutes[0];
            if (data.Row.ItemArray[6].ToString().Length != 0)
            {
                name.IsEnabled = false;
                typ.IsEnabled = false;
                zeme.IsEnabled = false;
                SearchBut.IsEnabled = false;
                rok.IsEnabled = false;
                delka.IsEnabled = false;
                adresa.Text = data.Row.ItemArray[6].ToString();
                Nadpis.Content += " (Nelze upravovat položky z CSFD.cz)";
                hodnoceni.Text = data.Row.ItemArray[7].ToString();
                Accept.IsEnabled = true;
            }
            else
            {
                Refresh.Visibility = Visibility.Hidden;
            }
            CheckProperties();
            name.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            TextCheck(zeme);
            TextCheck(rok);
            TextCheck(typ);
            TextCheck(delka);
            TextCheck(name);
            kontrola = Filmy;
        }

        private void Pridat_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

        private void AddItem()
        {
            novy[0] = name.Text;
            novy[1] = typ.Text;
            novy[2] = zeme.Text;
            novy[3] = rok.Text;
            novy[4] = delka.Text;
            if (adresa.Text.Length != 0)
            {
                novy[5] = adresa.Text;
                novy[6] = hodnoceni.Text;
            }
            else
            {
                novy[5] = "";
                novy[6] = "";
            }
            novy[7] = Property(seen);
            novy[8] = Property(dvd);
            DialogResult = true;
            this.Hide();
        }

        private string Property(CheckBox CBox)
        {
            if (CBox.IsChecked.Value)
                return "Ano";
            else
                return "Ne";
        }

        private void Placeholder(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text == "")
            {
                BrushConverter bc = new BrushConverter();
                box.Foreground = (Brush)bc.ConvertFrom("#FF999999");
                box.Text = box.ToolTip.ToString();
            }
        }

        private void Replace(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            BrushConverter bc = new BrushConverter();
            SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            if ((((SolidColorBrush)box.Foreground).Color == scb.Color) || (box.Text == box.ToolTip.ToString()))
                box.Text = "";
            box.Foreground = (Brush)bc.ConvertFrom("#FF000000");
        }

        private void NumberCheck(object sender, TextChangedEventArgs e)
        {
            TextBox NumberBox = sender as TextBox;
            int Index;
            if (NumberBox.Name == rok.Name)
                Index = 3;
            else
                Index = 4;
            if (NumberBox.Text != "xxx")
            {
                int Number;
                if (int.TryParse(NumberBox.Text, out Number))
                {
                    check[Index] = 1;
                }
                else
                {
                    check[Index] = 0;
                }
            }
            else
                check[Index] = 1;
            AccessControl(check);
        }

        private void TextCheck(object sender, TextChangedEventArgs e)
        {
            TextCheck(sender);
        }

        public void TextCheck(object sender)
        {
            TextBox TBox = sender as TextBox;
            if (TBox.Text == TBox.ToolTip.ToString())
            {
                BrushConverter bc = new BrushConverter();
                TBox.Foreground = (Brush)bc.ConvertFrom("#FF999999");
            }
            int i = 0;
            SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            switch (TBox.Name)
            {
                case "name":
                    i = 0;
                    try
                    {
                        if (TBox.Text == TBox.ToolTip.ToString())
                            SearchBut.IsEnabled = false;
                        else
                            SearchBut.IsEnabled = true;
                        if (LastName == TBox.Text)
                            stejny = true;
                        else
                            stejny = false;
                    }
                    catch { }
                    break;

                case "typ":
                    i = 1;
                    break;

                case "zeme":
                    i = 2;
                    break;
            }
            if ((TBox.Text == "") || (((SolidColorBrush)TBox.Foreground).Color == scb.Color) || (TBox.Text == TBox.ToolTip.ToString()))
                check[i] = 0;
            else
                check[i] = 1;
            AccessControl(check);
        }

        private void AccessControl(int[] check)
        {
            int result = 0;
            foreach (int i in check)
            {
                result += i;
            }
            if (result == 5)
            {
                Accept.IsEnabled = true;
            }
            else
                Accept.IsEnabled = false;
        }

        private void FindOnNet()
        {
            if (FindFilm == true)
                if (name.Text == name.ToolTip.ToString())
                {
                    SearchBut.IsEnabled = false;
                }
                else
                {
                    try
                    {
                        #region koment
                        /* var webget = new HtmlWeb();
                        SearchClass SClass = new SearchClass();
                         Result res = SClass.FindFilm(name, false);
                         if (stop == 0)
                             if ((bool)res.ShowDialog())
                             {
                                 var dataRow = res.Films.Items[res.CurrentRowIndex] as FilmCard;
                                 name.Text = dataRow.NameFilm;
                                 /*    var FindH3Tag = doc.DocumentNode.Descendants("a").Where(d => d.Attributes.Contains("class"));
                                     var puvod2 = FindH3Tag.Where(c => c.InnerText == dataRow.Nazev).Select(c => c.OuterHtml);*/
                        /*int ul = 1;
                        if (res.CurrentRecordIndex > 4)
                        {
                            ul = 2;
                            res.CurrentRecordIndex -= 5;
                        }
                        string asd = SClass.HDoc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[" + ul.ToString() + "]/li[" + (res.CurrentRecordIndex) + "]").InnerHtml;
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
                                        rok.Text = info[j];
                                        properties[1] = true;
                                    }
                                    else if (info[j].Contains(" min"))
                                    {
                                        delka.Text = info[j].Substring(0, info[j].Length - 4);
                                        properties[2] = true;
                                    }
                                    else
                                    {
                                        zeme.Text = info[j];
                                        properties[0] = true;
                                    }
                                }
                                for (int j = 0; j < properties.Length; j++)
                                {
                                    if (properties[j] == false)
                                        switch (j)
                                        {
                                            case 0:
                                                zeme.Text = "xxx";
                                                break;
                                            case 1:
                                                rok.Text = "xxx";
                                                break;
                                            case 2:
                                                delka.Text = "xxx";
                                                break;
                                        }
                                }
                            }
                            else
                            {
                                rok.Text = "xxx";
                                delka.Text = "xxx";
                                zeme.Text = "xxx";
                            }
                        }
                        catch { }
                        try
                        {
                            FindPTag = SClass.HDoc.DocumentNode.Descendants("p").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("genre"));
                            var type = FindPTag.Select(c => c.InnerHtml).Single();
                            typ.Text = type;
                        }
                        catch { typ.Text = "xxx"; }
                        /*   if (ul == 2)
                               ul = 4;
                           else
                               ul = 0;*//*
                        adresa.Text = "http://www.csfd.cz" + link[0];
                        try
                        {
                            var FindH2Tag = SClass.HDoc.DocumentNode.Descendants("h2").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("average"));
                            var rating = FindH2Tag.Select(c => c.InnerHtml).Single();
                            hodnoceni.Text = rating;
                        }
                        catch { hodnoceni.Text = ""; }
                        CheckProperties();
                    }
                    else
                    {
                        stop--;
                    }
                stop++;*/
                        #endregion

                        SearchClass SClass = new SearchClass();
                        Result res = SClass.FindFilm(name.Text, false);

                        if (res.Films.Items.Count == 0)
                            res.Exp1.IsExpanded = false;
                        else
                            res.Exp1.IsExpanded = true;

                        if (res.Actors.Items.Count == 0)
                            res.Exp2.IsExpanded = false;
                        else
                            res.Exp2.IsExpanded = true;

                        if ((bool)res.ShowDialog())
                        {
                            FilmCard FCard = new FilmCard();
                            string NameOfFilm = name.Text;
                            string[] data = FCard.LoadProperties(ref NameOfFilm, res, SClass.HDoc);
                            name.Text = NameOfFilm;
                            typ.Text = data[2];
                            zeme.Text = data[3];
                            rok.Text = data[4];
                            delka.Text = data[5];
                            adresa.Text = data[6];
                            hodnoceni.Text = data[7];
                            CheckProperties();
                        }
                    }
                    catch
                    {
                        name.Text = "";
                        object obj = new object();
                        obj = name;
                        RoutedEventArgs e = new RoutedEventArgs();
                        Placeholder(obj, e);
                    }
                    Accept.IsEnabled = true;
                    if (name.Text[name.Text.Length - 1] == ' ')
                        name.Text = name.Text.Substring(0, name.Text.Length - 1);
                }
        }

        private void CheckProperties()
        {
            BrushConverter bc = new BrushConverter();
            name.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            rok.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            zeme.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            delka.Foreground = (Brush)bc.ConvertFrom("#FF000000");
            typ.Foreground = (Brush)bc.ConvertFrom("#FF000000");
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            stop = 0;
            FindOnNet();
        }

        private void hand_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                HandMade.IsEnabled = true;
                typ.Text = typ.ToolTip.ToString();
                zeme.Text = zeme.ToolTip.ToString();
                rok.Text = rok.ToolTip.ToString();
                delka.Text = delka.ToolTip.ToString();
                adresa.Text = adresa.ToolTip.ToString();
                hodnoceni.Text = hodnoceni.ToolTip.ToString();
            }
            catch { }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            if (adresa.Text != adresa.ToolTip.ToString())
            {
                var webget = new HtmlWeb();
                var doc = webget.Load(adresa.Text);
                try
                {
                    var FindH2Tag = doc.DocumentNode.Descendants("h2").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("average"));
                    var rating = FindH2Tag.Select(c => c.InnerHtml).Single();
                    hodnoceni.Text = rating;
                }
                catch
                {
                    hodnoceni.Text = "";
                }
            }
        }
    }
}
