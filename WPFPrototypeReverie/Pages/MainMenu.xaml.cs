namespace WPFPrototypeReverie.Pages
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    /// <summary>
    /// There is a little bit of blitting after the splash screen but it doesn't matter, i think
    /// it's fine, this is a proto / proof anyway
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            TestScene page = new TestScene();
            NavigationService.Navigate(page);
        }
    }
}
