using Installer.Model;
using System.Windows.Controls;

namespace Installer.View
{
    public partial class ProgressView : System.Windows.Controls.UserControl
    {
        private InstallationModel _installationModel;

        public ProgressView(string sourceDirectory, string targetDirectory)
        {
            InitializeComponent();
            _installationModel = new InstallationModel(sourceDirectory, targetDirectory);
            _installationModel.InstallationComplete += InstallationCompleteHandler;
            _installationModel.ProgressUpdate += ProgressUpdateHandler;
        }

        public async void StartInstallation()
        {
            await _installationModel.CopyNextFileAsync();
        }

        private void ProgressUpdateHandler(object sender, EventArgs e)
        {
            ProgressBar.Value = _installationModel.Progress;
            ProgressText.Text = $"Installation Progress: {_installationModel.Progress:F2}%";
        }

        private void InstallationCompleteHandler(object sender, EventArgs e)
        {
            ProgressText.Text = "Installation Complete!";
        }
    }
}
