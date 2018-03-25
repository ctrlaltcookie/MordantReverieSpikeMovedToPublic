namespace WPFPrototypeReverie.Pages
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using WPFPrototypeReverie.Libraries;

    /// <summary>
    /// There is a little bit of blitting after the splash screen but it doesn't matter, i think
    /// it's fine, this is a proto / proof anyway
    /// </summary>
    public partial class MainMenu : Page
    {
        GameProgressTracker _progressTracker;
        public MainMenu()
        {
            _progressTracker = new GameProgressTracker();
            InitializeComponent();
            ContinueButton.Visibility = Visibility.Collapsed;
            ShowsNavigationUI = false;
            List<string> scenes = _progressTracker.ViewedScenes();
            if(scenes.Contains("menu"))
            {
                ContinueButton.Visibility = Visibility.Visible;
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            TestScene page = new TestScene(_progressTracker);
            _progressTracker.MarkSceneViewed("menu");
            _progressTracker.SaveGame();
            NavigationService.Navigate(page);
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            string lastViewedScene = _progressTracker.LastViewedScene();
            if (lastViewedScene == "scene0")
            {
                NewGameButton_Click(null, null);
            }
            if(lastViewedScene == "scene1")
            {
                NavigationService.Navigate(new TestScene2(_progressTracker));
            }
        }
    }
}
