using System.Windows;
using System.Windows.Controls;

namespace Installer.View
{
    public partial class InstallationDirectoryView : System.Windows.Controls.UserControl
    {
        private Frame _mainFrame;

        public InstallationDirectoryView() : this(null) { }

        public InstallationDirectoryView(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void PathSelectorClicked(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryTextBox.Text = dialog.SelectedPath;
            }
        }

        private void ConfirmInstallationButtonClicked(object sender, RoutedEventArgs e)
        {
            string targetDirectory = DirectoryTextBox.Text;
            if (string.IsNullOrEmpty(targetDirectory))
            {
                System.Windows.MessageBox.Show("Please select an installation directory.");
                return;
            }

            // Pass a source directory string instead of _mainFrame
            string sourceDirectory = @"C:\Users\dy97v\Desktop\folder\Files"; // Replace with actual source directory
            var progressView = new ProgressView(sourceDirectory, targetDirectory);
            _mainFrame.Navigate(progressView);
            progressView.StartInstallation();
        }
    }
}

