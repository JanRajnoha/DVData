using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DVData
{
    /// <summary>
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Feedback : Window
    {

        string celkove = "";

        public Feedback()
        {
            InitializeComponent();
            rating.SelectedIndex = 0;
            Accept.IsEnabled = false;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add("frantanov8k@gmail.com");
                message.Subject = "Hodnocení programu DVData";
                message.From = new System.Net.Mail.MailAddress("neznamej@je.tu");
                message.Body = "Program hodnotil: " + name.Text + "\nE_mail: " + mail.Text +
                    "\n\nCelkové hodnocení programu: " + celkove +
                    "\n\n" + words.Text;


                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Timeout = 10000;
                smtp.Credentials = new System.Net.NetworkCredential("frantanov8k@gmail.com", "asdfghjkloiuytrewq");
                smtp.Send(message);

                System.Windows.Forms.MessageBox.Show("Zpráva odeslána. Děkujeme za Váš názor", "Děkujeme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                message.Dispose();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString() + "\n\nAkci zopakujte za pár minut.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult = true;
        }

        private void Placeholder(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox box = sender as System.Windows.Controls.TextBox;
            if (box.Text == "")
            {
                BrushConverter bc = new BrushConverter();
                box.Foreground = (Brush)bc.ConvertFrom("#FF999999");
                box.Text = box.ToolTip.ToString();
            }
        }

        private void Replace(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox box = sender as System.Windows.Controls.TextBox;
            BrushConverter bc = new BrushConverter();
            SolidColorBrush asd = new SolidColorBrush();
            asd = (SolidColorBrush)box.Foreground;
            SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            if (((SolidColorBrush)box.Foreground).Color == scb.Color)
                box.Text = "";
            box.Foreground = (Brush)bc.ConvertFrom("#FF000000");
        }

        private void Convert(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)rating.SelectedItem;
            celkove = typeItem.Content.ToString();
        }

        private void CheckMail(object sender, TextChangedEventArgs e)
        {
            int zavinac = 0;
            int mezera = 0;
            foreach (char c in mail.Text)
            {
                if (c == '@')
                {
                    zavinac++;
                }
                else if (zavinac == 1)
                    break;
            }
            foreach(char c in mail.Text)
            {
                if (c == ' ')
                {
                    mezera++;
                }
                else if (mezera == 1)
                    break;
            }

            try
            {
                int tecka = 0;
                string[] domena = mail.Text.Split('@');
                foreach (char c in domena[1])
                {
                    if (c == '.')
                    {
                        tecka++;
                    }
                    else if (tecka == 1)
                        break;
                }

                if (((zavinac == 1) && (tecka == 1)) && (mezera != 1))
                    Accept.IsEnabled = true;
                else
                    Accept.IsEnabled = false;
            }

            catch { }
        }
    }
}
