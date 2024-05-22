using System.Windows.Forms;
using Installer.View;

namespace Installer.Presenter
{
    public class InstallationDirectoryPresenter
    {
        private readonly IInstallationDirectoryView _view;

        public InstallationDirectoryPresenter(IInstallationDirectoryView view)
        {
            _view = view;
        }

        public void SelectPath()
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _view.SetDirectoryPath(dialog.SelectedPath);
            }
        }

        public void ConfirmInstallation()
        {
            string targetDirectory = _view.GetDirectoryPath();
            if (string.IsNullOrEmpty(targetDirectory))
            {
                _view.ShowMessage("Please select an installation directory.");
                return;
            }
            _view.NavigateToProgressView(targetDirectory);
        }
    }
}
