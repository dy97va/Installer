using Installer.Presenter;
using System.Windows;
using System.Windows.Controls;

namespace Installer.View
{
    public partial class ProgressView : System.Windows.Controls.UserControl
    {
        private ProgressPresenter _presenter;

        public ProgressView(string targetDirectory)
        {
            InitializeComponent();
            _presenter = new ProgressPresenter(this, targetDirectory);
        }

        public async void StartInstallation()
        {
            await _presenter.StartInstallationAsync();
        }

        public void UpdateProgress(double progress)
        {
            ProgressBar.Value = progress;
            ProgressText.Text = $"Installation Progress: {progress:F2}%";
        }

        public void CompleteInstallation()
        {
            ProgressText.Text = "Installation Complete!";
            DoneButton.Visibility = Visibility.Visible;
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
