using System.Data;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Lopalka
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            this.Start.IsEnabled = false;
            this.Start.Visibility = Visibility.Collapsed;


            maingrid.Background = new SolidColorBrush(Color.FromRgb(51,102,255));

            schet.Visibility = Visibility.Visible;
            Puz.Visibility = Visibility.Visible;

            Random random = new Random();
            int x_pos = random.Next(0, 1100);
            int y_pos = random.Next(0, 700);


            Puz.Margin = new Thickness(x_pos, y_pos, 0, 0);





        }
        private int clickcount = 0;
        private void puz_click(object sender, RoutedEventArgs e)
        {

            var mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("C:\\Users\\zikku\\source\\repos\\Lopalka\\untitled.wav")); // Укажите путь к вашему звуковому файлу
            mediaPlayer.Stop();
            mediaPlayer.Play();
            clickcount++;
            schet.Text = $"{clickcount}";


            Random random = new Random();
            int x_pos = random.Next(0, 1100);
            int y_pos = random.Next(0, 700);
            Puz.Margin = new Thickness(x_pos, y_pos, 0, 0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}