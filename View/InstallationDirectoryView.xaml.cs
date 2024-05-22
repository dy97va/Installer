using System.Windows;
using System.Windows.Controls;
using Installer.Presenter;

namespace Installer.View
{
    public interface IInstallationDirectoryView
    {
        void SetDirectoryPath(string path);
        string GetDirectoryPath();
        void ShowMessage(string message);
        void NavigateToProgressView(string targetDirectory);
    }

    public partial class InstallationDirectoryView : System.Windows.Controls.UserControl, IInstallationDirectoryView
    {
        private Frame _mainFrame;
        private InstallationDirectoryPresenter _presenter;

        public InstallationDirectoryView() : this(null) { }

        public InstallationDirectoryView(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            _presenter = new InstallationDirectoryPresenter(this);
        }

        public void SetDirectoryPath(string path)
        {
            DirectoryTextBox.Text = path;
        }

        public string GetDirectoryPath()
        {
            return DirectoryTextBox.Text;
        }

        public void ShowMessage(string message)
        {
            System.Windows.MessageBox.Show(message);
        }

        public void NavigateToProgressView(string targetDirectory)
        {
            var progressView = new ProgressView(targetDirectory);
            _mainFrame.Navigate(progressView);
            progressView.StartInstallation();
        }

        private void PathSelectorClicked(object sender, RoutedEventArgs e)
        {
            _presenter.SelectPath();
        }

        private void ConfirmInstallationButtonClicked(object sender, RoutedEventArgs e)
        {
            _presenter.ConfirmInstallation();
        }
    }
}


