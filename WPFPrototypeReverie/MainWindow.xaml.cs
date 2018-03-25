namespace WPFPrototypeReverie
{
    using System.Windows.Navigation;

    /// <summary>
    /// // derp herp this is the main window that basically doesn't actually do anything at all, it's
    /// // just a nav really, but it is a good place to instantiate things that need to be used
    /// // globally, YEAH I KNOW GLOBALS ARE BAD BUT ITS A GAME FUCK OFF
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
