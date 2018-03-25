using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Media;
using System.Collections.Generic;
using WPFPrototypeReverie.Libraries;

namespace WPFPrototypeReverie
{
    /// <summary>
    /// Interaction logic for TestScene.xaml
    /// </summary>
    public partial class TestScene : Page
    {
        GameProgressTracker _progressTracker;

        public TestScene(GameProgressTracker progressTracker)
        {
            InitializeComponent();
            _progressTracker = progressTracker;
            TestText.Visibility = Visibility.Collapsed;

            TestText.Visibility = Visibility.Visible;
            TestText.Foreground = Brushes.WhiteSmoke;
            string dialogue = "\"Well this is a piece of voice acting wow, look at the voice and the acting, wow\"";
            string narration = "\n\n Said the disembodied voice of a strange person writing code.";
            List<string> sceneText = new List<string>();
            sceneText.Add(dialogue);
            sceneText.Add(narration);

            NextLabel.Visibility = Visibility.Collapsed;
            NextLabel.Foreground = Brushes.WhiteSmoke;
            List<Label> labels = new List<Label>();
            labels.Add(NextLabel);

            TextWriter tr = new TextWriter(sceneText, TestText, labels);
            tr.StartWriting();

            SoundPlayer player = new SoundPlayer(@"C:\Users\Jack\source\repos\WPFPrototypeReverie\wowActingWow.wav");
            player.Load();
            player.Play();
            
        }

        private void NextLabel_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TestScene2 page = new TestScene2(_progressTracker);
            _progressTracker.MarkSceneViewed("scene1");
            _progressTracker.SaveGame();
            NavigationService.Navigate(page);
        }
    }
}
