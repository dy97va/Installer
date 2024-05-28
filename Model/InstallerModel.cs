using System.IO;
using System.Reflection;

namespace Installer.Model
{
    public class InstallationModel
    {
        private string[] _files;
        private int _currentFileIndex;
        private string _targetDirectory;
        private string _sourceDirectory;
        public double Progress { get; private set; }

        public event EventHandler InstallationComplete;
        public event EventHandler ProgressUpdate;

        public InstallationModel(string targetDirectory)
        {
            string exeDirectory = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            _sourceDirectory = Path.Combine(exeDirectory, "Tiedostot");
            _targetDirectory = targetDirectory;
            _files = Directory.GetFiles(_sourceDirectory, "*.*", SearchOption.AllDirectories);
            _currentFileIndex = 0;
            Progress = 0;
        }

        public async Task CopyNextFileAsync()
        {
            while (_currentFileIndex < _files.Length)
            {
                string sourceFilePath = _files[_currentFileIndex];
                string relativePath = sourceFilePath.Substring(_sourceDirectory.Length + 1);
                string targetFilePath = Path.Combine(_targetDirectory, relativePath);
                string targetDirectory = Path.GetDirectoryName(targetFilePath);
                Directory.CreateDirectory(targetDirectory);

                byte[] fileContents = await File.ReadAllBytesAsync(sourceFilePath);
                await File.WriteAllBytesAsync(targetFilePath, fileContents);
                _currentFileIndex++;
                Progress = (double)_currentFileIndex / _files.Length * 100;
                ProgressUpdate?.Invoke(this, EventArgs.Empty);

                await Task.Delay(500); // Delay to check if progress bar UI updates, delete or comment out before submitting the task
            }

            InstallationComplete?.Invoke(this, EventArgs.Empty);
        }
    }
}
