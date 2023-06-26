using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClosedXML.Excel;

namespace LostOrStolenMobiles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        DataSet data_set = new DataSet();
        string file_name;

        public void Import_button(object sender, EventArgs e)
        {
            var import = new Microsoft.Win32.OpenFileDialog();
            import.FileName = "Workbook"; 
            import.DefaultExt = ".txt"; 
            import.Filter = "Excel Workbook (.xlsx)|*.xlsx";
            bool? result = import.ShowDialog();
            if (result == true)
            {
                file_name = import.FileName;
                data_set.Import_data(file_name);
                MobileGrid.ItemsSource = null;
                MobileGrid.ItemsSource = data_set.GetLosted;
            }
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-extra-bonus-in-a-video-game-2045.wav");
            player.Play();
        }
        
        public void Export_button(object sender, EventArgs e)
        {
            data_set.Export_data(file_name);
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-extra-bonus-in-a-video-game-2045.wav");
            player.Play();
        }

        public void Export_As_button(object sender, EventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Workbook"; 
            dialog.DefaultExt = ".xlsx"; 
            dialog.Filter = "Excel Workbook (.xlsx)|*.xlsx"; 

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                file_name = dialog.FileName;
                data_set.Export_data(file_name);
            }
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-extra-bonus-in-a-video-game-2045.wav");
            player.Play();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-extra-bonus-in-a-video-game-2045.wav");
            player.Play();
            Close();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (Search_tb.Text == "") Reset_Click(sender, e);
            else
            {
                var filtered = data_set.GetLosted.Where(losted => losted.Id.ToString().StartsWith(Search_tb.Text));

                MobileGrid.ItemsSource = filtered;
            }
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-cool-interface-click-tone-2568.wav");
            player.Play();
        }
        private void SearchGotFocusEvent(object sender, RoutedEventArgs e)
        {
            Search_tb.Text = "";
            Search_tb.GotFocus -= SearchGotFocusEvent;
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Search_tb.Text = "Введіть ідентифікатор";
            Search_tb.GotFocus += SearchGotFocusEvent;
            MobileGrid.ItemsSource = null;
            MobileGrid.ItemsSource = data_set.GetLosted;
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-cool-interface-click-tone-2568.wav");
            player.Play();
        }
        private void Search_tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Open_adding_window(object sender, RoutedEventArgs e)
        {
            Adding Add_Data = new(data_set);
            Add_Data.Show();
            MobileGrid.ItemsSource = null;
            MobileGrid.ItemsSource = data_set.GetLosted;
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-extra-bonus-in-a-video-game-2045.wav");
            player.Play();
        }
       
        private void Open_deleting_window(object sender, RoutedEventArgs e)
        {
            Deleting delete_el = new(data_set);
            delete_el.Show();

            MobileGrid.ItemsSource = null;
            MobileGrid.ItemsSource = data_set.GetLosted;
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-extra-bonus-in-a-video-game-2045.wav");
            player.Play();
        }
        private void buttom_IsMouseOver(object sender, DependencyPropertyChangedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-cool-interface-click-tone-2568.wav");
            player.Play();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Admin\Downloads\музыка\mixkit-extra-bonus-in-a-video-game-2045.wav");
            player.Play();
        }
    }
}
