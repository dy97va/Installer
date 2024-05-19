using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

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

            // Navigate to ProgressView and start the installation process
            var progressView = new ProgressView(_mainFrame, targetDirectory);
            _mainFrame.Navigate(progressView);
            progressView.StartInstallation();
        }
    }
}

