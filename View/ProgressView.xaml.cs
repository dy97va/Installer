using Installer.Presenter;
using System.Windows.Controls;

namespace Installer.View
{
    public interface IProgressView
    {
        void UpdateProgress(double progress);
        void CompleteInstallation();
    }

    public partial class ProgressView : System.Windows.Controls.UserControl, IProgressView
    {
        private ProgressPresenter _presenter;

        public ProgressView(string sourceDirectory, string targetDirectory)
        {
            InitializeComponent();
            _presenter = new ProgressPresenter(this, sourceDirectory, targetDirectory);
        }

        public async void StartInstallation()
        {
            await _presenter.StartInstallationAsync();
        }

        public void UpdateProgress(double progress)
        {
            ProgressBar.Value = progress; // Update the progress bar value.
            ProgressText.Text = $"Installation Progress: {progress:F2}%"; // Update the progress text.
        }

        public void CompleteInstallation()
        {
            ProgressText.Text = "Installation Complete!"; // Display completion message.
        }
    }
}
