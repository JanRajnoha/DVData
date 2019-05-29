using System.Data.SqlServerCe;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CheckBox = System.Windows.Controls.CheckBox;
using ComboBox = System.Windows.Controls.ComboBox;
using DataGrid = System.Windows.Controls.DataGrid;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using MessageBox = System.Windows.Forms.MessageBox;
using TextBox = System.Windows.Controls.TextBox;
using System.ComponentModel;
using System.Windows.Data;

namespace DVData
{
    class SearchClass
    {

        public SearchClass(string Link)
        {
            var webget = new HtmlWeb();
            HDoc = webget.Load(Link);
        }

        public SearchClass()
        {

        }

        public HtmlDocument HDoc { get; set; }

        public Result FindFilm(string name, bool complet)
        {   
            var webget = new HtmlWeb();
            Result res = new Result();
            var doc = webget.Load("http://www.seznam.cz");
            var advanced = "";
            int pokracovani = 0;
            doc = webget.Load("http://www.csfd.cz/hledat/?q=" + name);
            HDoc = doc;
            for (int i = 1; i <= 4; i++)
            {
                try
                {
                    string[] rok = doc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[1]/li[" + i + "]/div[1]/p[1]").InnerHtml.Split(',');
                    if (doc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[1]/li[" + i + "]/h3/span") != null)
                        advanced = " " + doc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[1]/li[" + i + "]/div[1]/h3/span").InnerHtml;
                    int index = 1;
                    if (rok.Length > 2)
                    {
                        index = 2;
                    }
                    res.Films.Items.Add(new FilmCard() { IDFilm = i.ToString(), NameFilm = doc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[1]/li[" + i + "]/div[1]/h3/a").InnerHtml + advanced, Year = rok[index].Substring(1, 4) });
                    pokracovani++;
                    advanced = "";
                }
                catch
                {
                    pokracovani = i;
                    break;
                }
            }

            doc = webget.Load("http://www.csfd.cz/hledat/?q=" + name);
            for (int i = 1; ; i++)
            {
                try
                {
                    string rok;
                    int index = 1;
                    if (doc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[2]/li[" + i + "]/span[1]").InnerHtml.Length != 6)
                    {
                        advanced = " " + doc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[2]/li[" + i + "]/span[1]").InnerHtml;
                        index = 2;
                    }
                    rok = doc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[2]/li[" + i + "]/span[" + index.ToString() + "]").InnerHtml;
                    var radek = new FilmCard { IDFilm = (i + pokracovani).ToString(), NameFilm = doc.DocumentNode.SelectSingleNode("//*[@id='search-films']/div[1]/ul[2]/li[" + i + "]/a[1]").InnerHtml + advanced, Year = rok.Substring(1, 4) };
                    res.Films.Items.Add(radek);
                    advanced = "";
                }
                catch { break; }
            }
            if (!complet)
                return res;
            else
            {
                res.Actors.ItemsSource = FindArt(name).Items;
                return res;
            }
        }

        public DataGrid FindArt(string name)
        {
            Result res = new Result();
            HtmlWeb webget = new HtmlWeb();
            try
            {
                var doc = webget.Load("http://www.csfd.cz/hledat/?q=" + name);
                for (int i = 1; i <= 4; i++)
                {
                    try
                    {
                        string[] info = new string[2];
                        try
                        {
                            info[0] = doc.DocumentNode.SelectSingleNode("//*[@id='search-creators']/div[1]/ul[1]/li[" + i + "]/p[1]").InnerHtml;
                            info[1] = doc.DocumentNode.SelectSingleNode("//*[@id='search-creators']/div[1]/ul[1]/li[" + i + "]/p[2]").InnerHtml;
                        }
                        catch
                        {
                            info[0] = "";
                            info[1] = "";
                        }
                        try
                        {
                            res.Actors.Items.Add(new ArtCard() { IDArt = i.ToString(), NameArt = doc.DocumentNode.SelectSingleNode("//*[@id='search-creators']/div[1]/ul[1]/li[" + i + "]/h3[1]/a[1]").InnerHtml, Job = info[0], Birth = info[1] });
                        }
                        catch { }
                    }
                    catch
                    {
                        break;
                    }
                }

                doc = webget.Load("http://www.csfd.cz/hledat/?q=" + name);
                for (int i = 1; ; i++)
                {
                    try
                    {
                        string BirthYear = "";
                        int EditJob = 1;
                        string[] info = doc.DocumentNode.SelectSingleNode("//*[@id='search-creators']/div[1]/ul[2]/li[" + i + "]/span[1]").InnerHtml.Split(',');
                        if (info[0][info[0].Length - 1] == ')')
                            EditJob = 2;
                        else
                            EditJob = 1;
                        if (info.Length == 2)
                            BirthYear = info[1];
                        try
                        {
                            res.Actors.Items.Add(new ArtCard() { IDArt = i.ToString(), NameArt = doc.DocumentNode.SelectSingleNode("//*[@id='search-creators']/div[1]/ul[2]/li[" + i + "]/a[1]").InnerHtml, Job = info[0].Substring(1, info[0].Length - EditJob), Birth = BirthYear.Substring(0, BirthYear.Length - 1) });
                        }
                        catch
                        {
                            res.Actors.Items.Add(new ArtCard() { IDArt = i.ToString(), NameArt = doc.DocumentNode.SelectSingleNode("//*[@id='search-creators']/div[1]/ul[2]/li[" + i + "]/a[1]").InnerHtml, Job = info[0].Substring(1, info[0].Length - EditJob), Birth = BirthYear});
                        }
                    }
                    catch { break; }
                }
            }
            catch { }
            return res.Actors;
        }

        public bool CheckNet()
        {
            try
            {
                var webget = new HtmlWeb();
                var doc = webget.Load("http://www.csfd.cz");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataGrid FindInData(TextBox SearchQuery, SqlCeConnection pripojeni, CheckBox seen, CheckBox DVD, ComboBox Type)
        {
            DataGrid Database = new DataGrid();
            Database.DataContext = null;
            Database.CanUserAddRows = false;
            SqlCeCommand prikaz = new SqlCeCommand("SELECT * FROM Filmy", pripojeni);

            System.Data.DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int64");
            DataTable tabulka = new DataTable();
            tabulka.Columns.Add("ID", dc.DataType);                          //ID       
            dc.DataType = System.Type.GetType("System.String");
            tabulka.Columns.Add("Film", dc.DataType);                        //Film
            tabulka.Columns.Add("Typ", dc.DataType);                         //Typ 
            tabulka.Columns.Add("Země", dc.DataType);                        //Země
            dc.DataType = System.Type.GetType("System.Int32");
            tabulka.Columns.Add("Rok", dc.DataType);                         //Rok
            dc.DataType = System.Type.GetType("System.String");
            tabulka.Columns.Add("Délka", dc.DataType);                       //Délka
            tabulka.Columns.Add("Adresa - CSFD", dc.DataType);               //Adresa - CSFD
            tabulka.Columns.Add("Hodnocení - CSFD", dc.DataType);            //Hodnocení - CSFD
            tabulka.Columns.Add("Viděl", dc.DataType);                       //Viděl
            tabulka.Columns.Add("DVD", dc.DataType);                         //DVD
            SqlCeDataReader reader = prikaz.ExecuteReader();
            while (reader.Read())
            {
                bool AddRow = false;
                int Index = Type.SelectedIndex + 1;
                switch (Index)
                {
                    case 0:
                        AddRow = true;
                        break;
                    
                    case 1:
                    case 2:
                    case 3:
                    case 6:
                        if (reader[Index].ToString().ToUpper().Contains(SearchQuery.Text.ToUpper()))
                            AddRow = true;
                        break;
                
                    case 4:
                        if (reader[Index].ToString().ToUpper() == SearchQuery.Text.ToUpper())
                            AddRow = true;
                        break;

                    case 5:
                        int LengthData, LengthFind;
                        string Row = reader[Index].ToString();
                        if (reader[Index].ToString().Contains('x'))
                        {
                            Row = reader[Index].ToString().Split('x')[1];
                        }
                        Int32.TryParse(SearchQuery.Text, out LengthFind);
                        var Minutes = Regex.Split(Row, " min");
                        Int32.TryParse(Minutes[0], out LengthData);
                        if (LengthData <= LengthFind)
                            AddRow = true;
                        break;

                    case 7:
                        if (reader[Index].ToString() != "")
                        {
                            int RatingData;
                            Int32.TryParse(reader[Index].ToString().Substring(0, reader[Index].ToString().Length - 1),
                                out RatingData);
                            int RatingFind;
                            Int32.TryParse(SearchQuery.Text.Substring(0, SearchQuery.Text.Length - 1),
                                out RatingFind);
                            if (RatingData >= RatingFind)
                                AddRow = true;
                        }
                        break;
                }
                if ((bool) seen.IsChecked)
                {
                    if (reader[8].ToString() != "Ano")
                        AddRow = false;
                }
                if ((bool) DVD.IsChecked)
                {
                    if (reader[9].ToString() != "Ano")
                        AddRow = false;
                }

                if (AddRow)
                    tabulka.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                    reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString()); //místo jména můžeš klidně použít i index - čísluje se klasicky od nuly
            }
            Database.ItemsSource = tabulka.DefaultView; //snad to půjde
           /* ICollectionView dataView = CollectionViewSource.GetDefaultView(Database.ItemsSource);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
            dataView.Refresh();*/
            return Database;
        }

        internal DataGrid LoadArt(string URL)
        {
            DataGrid Database = new DataGrid();
            Database.CanUserAddRows = false;
            var webget = new HtmlWeb();
            var doc = webget.Load(URL);
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
            for (int i = 1; ; i++)
            {
                try
                {
                    Database.Items.Add(new ArtCard() { IDArt = i.ToString(), NameArt = doc.DocumentNode.SelectSingleNode("//*[@id='profile']/div[1]/div[2]/div[1]/div[" + div + "]/span[1]/a[" + i + "]").InnerText });
                }
                catch { break; }
            }
            return Database;
        }
    }
}
