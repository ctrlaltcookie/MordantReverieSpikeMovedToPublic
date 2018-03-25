using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using System.Media;

namespace WPFPrototypeReverie
{
    /// <summary>
    /// Interaction logic for TestScene.xaml
    /// </summary>
    public partial class TestScene : Page
    {
        DispatcherTimer textTimer;
        public TestScene()
        {
            InitializeComponent();
            TestText.Visibility = Visibility.Collapsed;
            textTimer = new DispatcherTimer();
            textTimer.Tick += new EventHandler(text_Tick);
            textTimer.Interval = new TimeSpan(0, 0, 1);
            textTimer.Start();
        }

        private void text_Tick(object sender, EventArgs e)
        {
            TestText.Visibility = Visibility.Visible;
            TestText.Foreground = Brushes.WhiteSmoke;
            TestText.Text = "well this is a piece of voice acting wow, look at the voice and the acting, wow";
            SoundPlayer player = new SoundPlayer(@"C:\Users\Jack\source\repos\WPFPrototypeReverie\wowActingWow.wav");
            player.Load();
            player.Play();
            textTimer.Stop();
        }
    }
}
