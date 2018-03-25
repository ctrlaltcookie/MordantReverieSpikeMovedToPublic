using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using System.Media;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using WPFPrototypeReverie.Libraries;

namespace WPFPrototypeReverie
{
    /// <summary>
    /// Interaction logic for TestScene.xaml
    /// </summary>
    public partial class TestScene2 : Page
    {
        MediaPlayer player;

        public TestScene2()
        {
            InitializeComponent();
            TestText.Visibility = Visibility.Collapsed;
            TestText.Visibility = Visibility.Visible;
            TestText.Foreground = Brushes.WhiteSmoke;
            string dialogue = "\"Unspoken dialogue of a differnet " +
                "characeterer that is a the face on the screeeeen\"";
            string narration = "\n\n Some other text and stuff omg." +
                " Descrption of this new character person and shit wowwww.";
            List<string> sceneText = new List<string>();
            sceneText.Add(dialogue);
            sceneText.Add(narration);

            NextLabel.Visibility = Visibility.Collapsed;
            NextLabel.Foreground = Brushes.WhiteSmoke;
            List<Label> labels = new List<Label>();
            labels.Add(NextLabel);

            TextWriter tr = new TextWriter(sceneText, TestText, labels);
            tr.StartWriting();

            PlayMusic(@"C:\Users\Jack\source\repos\WPFPrototypeReverie\lowfi-loop.wav");
            PlaySFX(@"C:\Users\Jack\source\repos\WPFPrototypeReverie\AHEM.wav");
        }

        private void PlayMusic(string path)
        {
            player = new MediaPlayer();
            player.Open(new Uri(path));
            player.Play();
            player.MediaEnded += new EventHandler(Replay);
        }

        private void Replay(object sender, EventArgs e)
        {
            player.Position = TimeSpan.Zero;
            player.Play();
        }

        private void NextLabel_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PlaySFX(string path)
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 5)
            };
            timer.Tick += (sender, e) => SpecialEffect_Tick(sender, e, path);
            timer.Start();
        }

        private void SpecialEffect_Tick(object sender, EventArgs e, string path)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            MediaPlayer cough = new MediaPlayer();
            cough.Open(new Uri(path));
            cough.Play();
            timer.Stop();
        }
    }
}
