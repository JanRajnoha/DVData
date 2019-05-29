using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DVData
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {

        internal int CurrentRecordIndex;
        internal int CurrentRowIndex;
        public string DB = "";
        public ArtCard ArtData;

        public Result()
        {
            InitializeComponent();
            MyWindowHeightRes = 500;
            Nazev.Binding = new Binding("NameFilm");
            Rok.Binding = new Binding("Year");
            IDfilm.Binding = new Binding("IDFilm");
            Jmeno.Binding = new Binding("NameArt");
            Narozen.Binding = new Binding("Birth");
            Prace.Binding = new Binding("Job");
            IDact.Binding = new Binding("IDArt");
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            Films.RowStyle = rowStyle;
            MyWindowHeightRes = 500;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (DB)
                {
                    case "Films":
                        FilmCard FilmData = (FilmCard)Films.Items[Films.SelectedIndex];
                        Int32.TryParse(FilmData.IDFilm, out CurrentRecordIndex);
                        CurrentRowIndex = Films.SelectedIndex;
                        DialogResult = true;
                        break;

                    case "Actors":
                        ArtData = (ArtCard)Actors.Items[Actors.SelectedIndex];
                        Int32.TryParse(ArtData.IDArt, out CurrentRecordIndex);
                        CurrentRowIndex = Actors.SelectedIndex;
                        DialogResult = true;
                        break;

                    default:
                        Accept.IsEnabled = false;
                        break;
                }
            }
            catch { }
        }

        private void Najdi(object sender, MouseButtonEventArgs e)
        {
            DataGrid DataG = sender as DataGrid;
            if (DataG.Name == "Films")
                DB = "Films";
            else
                DB = "Actors";
            Accept.IsEnabled = true;
            Accept_Click(sender, e);
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Accept_Click(sender, e);
        }

        private void SwitchDB(object sender, RoutedEventArgs e)
        {
            DataGrid DataG = sender as DataGrid;
            DB = DataG.Name;
            Accept.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OpenClose(object sender, RoutedEventArgs e)
        {
            Expander Exp = sender as Expander;
            if (Exp.Name == "Exp1")
            {
                if (Exp.IsExpanded)
                    Clanek1.Height = new GridLength(1, GridUnitType.Star);
                else
                    Clanek1.Height = new GridLength(1, GridUnitType.Auto);
            }
            else
            {
                if (Exp.IsExpanded)
                    Clanek2.Height = new GridLength(1, GridUnitType.Star);
                else
                    Clanek2.Height = new GridLength(1, GridUnitType.Auto);
            }
        }

        private void Kontrola(object sender, SizeChangedEventArgs e)
        {
            MyWindowHeightRes = 500;
        }

        private double m_MyWindowHeightRes = 0;
        public double MyWindowHeightRes
        {
            get
            {
                return m_MyWindowHeightRes;
            }
            set
            {
                m_MyWindowHeightRes = value;
                this.OnPropertyChanged("MyWindowHeightRes");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Pok(object sender, RoutedEventArgs e)
        {
            MyWindowHeightRes = 500;

        /*    Films.Height = double.NaN;
            Actors.Height = double.NaN;*/
        }
    }
}
