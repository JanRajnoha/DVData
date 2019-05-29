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
    /// Interaction logic for Find.xaml
    /// </summary>
    public partial class Find : Window
    {
        public Find()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
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
            SolidColorBrush asd = new SolidColorBrush();
            asd = (SolidColorBrush)box.Foreground;
            SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            if (((SolidColorBrush)box.Foreground).Color == scb.Color)
                box.Text = "";
            box.Foreground = (Brush)bc.ConvertFrom("#FF000000");
        }
    }
}
