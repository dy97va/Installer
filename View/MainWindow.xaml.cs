using Installer.View;
using System.Windows;

namespace Installer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateToWelcomeView(); 
        }
        
        private void NavigateToWelcomeView()
        {
            WelcomeView welcomeView = new WelcomeView(MainFrame);

            MainFrame.Content = welcomeView;
        }

    }
}