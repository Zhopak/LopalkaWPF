using System.Data;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Media;
using System.Numerics;
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
        private int clickCount = 0;
        private readonly Random rnd;
        private readonly MediaPlayer mediaPlayer;

        private const string BaseMediaPath = "C:\\Users\\Snipe\\Source\\Repos\\LopalkaWPF\\Lopalka\\Sounds\\";

        private readonly Dictionary<int, string> SoundPathes;

        public MainWindow()
        {
            InitializeComponent();
            rnd = new Random();
            mediaPlayer = new MediaPlayer();

            SoundPathes = new Dictionary<int, string>()
            {
                { 1, "first-blood-101soundboards.mp3" },
                { 2, "double-kill-101soundboards.mp3" },
                { 3, "triple-kill-101soundboards.mp3" },
                { 4, "ultra-kill-101soundboards.mp3" },
                { 5, "rampage-101soundboards.mp3" },
                { 6, "sunstrike-101soundboards.mp3" }
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            Start.IsEnabled = false;
            Start.Visibility = Visibility.Collapsed;


            Maingrid.Background = new SolidColorBrush(Color.FromRgb(51, 102, 255));

            Score.Visibility = Visibility.Visible;
            Click.Visibility = Visibility.Visible;

            CreateBubble();

        }

        private void CreateBubble()
        {
            int xPos = rnd.Next(0, 1100);
            int yPos = rnd.Next(0, 700);


            Click.Margin = new Thickness(xPos, yPos, 0, 0);
        }

        private void BubbleClick(object sender, RoutedEventArgs e)
        {
            clickCount++;
            Score.Text = $"{clickCount}";

            var soundNum = clickCount >= 6 ? 6 : clickCount;

            mediaPlayer.Open(new Uri($"{BaseMediaPath}{SoundPathes[soundNum]}"));
            mediaPlayer.Play();

            CreateBubble();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}