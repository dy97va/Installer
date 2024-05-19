using Installer.View;
using System.Windows;
using System;

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