using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ClosedXML.Excel;


namespace LostOrStolenMobiles
{
    public partial class Adding : Window
    {
        DataSet data_set;

        Regex date_Regex = new Regex(@"\d{2}.\d{2}.\d{4}");
        Regex digit_Regex = new Regex(@"^\d+$");
        Regex imei_Regex = new Regex(@"^\d{15}");

        public Adding(DataSet data_set)
        {
            InitializeComponent();
            this.data_set = data_set;
        }

        private void CheckNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBoxGotFocusEvent(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
            ((TextBox)sender).GotFocus -= TextBoxGotFocusEvent;
        }
        private void Add(object sender, EventArgs e)
        {
            LostMobile losted = new LostMobile();

            if (Id_tb.Text == "")
            {
                MessageBox.Show("Введіть унікальний ідентифікатор запису", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);
                Id_tb.Text = "Введіть унікальний ідентифікатор запису";
                Id_tb.GotFocus += TextBoxGotFocusEvent;
            }

            else if (Ovd_tb.Text == "")
            {
                MessageBox.Show("Введіть назву підрозділу, що зареєстрував інформацію", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);
                Ovd_tb.Text = "Введіть назву підрозділу, що зареєстрував інформацію";
                Ovd_tb.GotFocus += TextBoxGotFocusEvent;
            }

            else if (Insert_date_tb.Text == "")
            {
                MessageBox.Show("Введіть дату внесення інформації", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);
                Insert_date_tb.Text = "Введіть дату внесення інформації";
                Insert_date_tb.GotFocus += TextBoxGotFocusEvent;
            }

            else if (Nz_tb.Text == "")
            {
                MessageBox.Show("Введіть модель/марку", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);
                Nz_tb.Text = "Введіть модель/марку";
                Nz_tb.GotFocus += TextBoxGotFocusEvent;
            }

            else if (Imei_tb.Text == "")
            {
                MessageBox.Show("Введіть IMEI номер", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);
                Imei_tb.Text = "Введіть IMEI номер";
                Imei_tb.GotFocus += TextBoxGotFocusEvent;
            }

            else if (Nk_tb.Text == "")
            {
                MessageBox.Show("Введіть номер реєстрації в журналі єд.обліку", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);
                Nk_tb.Text = "Введіть номер реєстрації в журналі єд.обліку";
                Nk_tb.GotFocus += TextBoxGotFocusEvent;
            }

            else if (Dk_tb.Text == "")
            {
                MessageBox.Show("Введіть дату реєстрації в журналі єд.обліку", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);
                Dk_tb.Text = "Введіть дату реєстрації в журналі єд.обліку";
                Dk_tb.GotFocus += TextBoxGotFocusEvent;
            }

            else
            {
                if (!digit_Regex.IsMatch(Id_tb.Text))
                    MessageBox.Show("Неправильний унікальний ідентифікатор запису. Введіть ідентифікатор", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);

                else if (!date_Regex.IsMatch(Insert_date_tb.Text))
                    MessageBox.Show("Неправильна дата внесення інформації. Введіть дату внесення інформації", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);

                else if (!imei_Regex.IsMatch(Imei_tb.Text))
                    MessageBox.Show("Неправильний IMEI номер. Введіть IMEI номер", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);

                else if (!digit_Regex.IsMatch(Nk_tb.Text))
                    MessageBox.Show("Неправильний номер реєстрації в журналі єд.обліку. Введіть номер реєстрації в журналі єд.обліку", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);

                else if (!date_Regex.IsMatch(Dk_tb.Text))
                    MessageBox.Show("Неправильна дата реєстрації в журналі єд.обліку. Введіть дату реєстрації в журналі єд.обліку", "Неможливо додати", MessageBoxButton.OK, MessageBoxImage.Error);

                else
                {
                    losted.Id = Id_tb.Text;
                    losted.Ovd = Ovd_tb.Text;
                    losted.Insert_date = Insert_date_tb.Text;
                    losted.Nz = Nz_tb.Text;
                    losted.Imei = Imei_tb.Text;
                    losted.Nk = Nk_tb.Text;
                    losted.Dk = Dk_tb.Text;

                    data_set.GetLosted.Add(losted);
                    MessageBox.Show("Запис було додано", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
        }
    }
}