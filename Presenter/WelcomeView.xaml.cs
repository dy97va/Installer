using System.Windows;
using System.Windows.Controls;

namespace Installer.View
{
    public partial class WelcomeView : System.Windows.Controls.UserControl
    {
        private Frame _mainFrame;

        public WelcomeView(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void StartButtonClicked(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new InstallationDirectoryView(_mainFrame));
        }
    }
}
