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
            textTimer.Interval = new TimeSpan(0, 0, 0, 100); // having this run on miliseconds is nicer
            textTimer.Start();
        }

        private void text_Tick(object sender, EventArgs e)
        {
            // this needs some finesse, atm it's just spitting at the screen
            // it needs to instead come out a little slower, like a typewritter
            // it'd also be good to force the voice and text to come out as units
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
