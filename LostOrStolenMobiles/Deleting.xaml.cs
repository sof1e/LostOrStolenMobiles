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

namespace LostOrStolenMobiles
{
    /// <summary>
    /// Interaction logic for Deleting.xaml
    /// </summary>
    public partial class Deleting : Window
    {
        DataSet data_set;

        public Deleting(DataSet losted)
        {
            this.data_set = losted;
            InitializeComponent();
        }
        private void DeleteGotFocusEvent(object sender, RoutedEventArgs e)
        {
            Id_TextBox.Text = "";
            Id_TextBox.GotFocus -= DeleteGotFocusEvent;
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (Id_TextBox.Text != "Введіть ідентифікатор")
            {
                if (data_set.GetLosted.Any(lost => lost.Id == Id_TextBox.Text))
                { 
                    data_set.GetLosted.RemoveAll((lost) => lost.Id == Id_TextBox.Text);
                    MessageBox.Show("Запис за ідентифікатором " + Id_TextBox.Text + " було видалено", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                    MessageBox.Show("Немає такого ідентифікатора", "Помилка видалення", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
