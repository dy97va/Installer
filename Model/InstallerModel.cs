using System.IO;

namespace Installer.Model
{
    public class InstallationModel
    {
        private string[] _files;
        private int _currentFileIndex;
        private string _targetDirectory;
        public double Progress { get; private set; }

        public event EventHandler InstallationComplete;
        public event EventHandler ProgressUpdate;

        public InstallationModel(string sourceDirectory, string targetDirectory)
        {
            _targetDirectory = targetDirectory;
            _files = Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories);
            _currentFileIndex = 0;
            Progress = 0;
        }

        public async Task CopyNextFileAsync()
        {
            if (_currentFileIndex >= _files.Length)
            {
                InstallationComplete?.Invoke(this, EventArgs.Empty);
                return;
            }

            string sourceFilePath = _files[_currentFileIndex];
            string fileName = Path.GetFileName(sourceFilePath);
            string targetFilePath = Path.Combine(_targetDirectory, fileName);

            await Task.Delay(500);

            using (var sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (var destinationStream = new FileStream(targetFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                await sourceStream.CopyToAsync(destinationStream);
            }

            _currentFileIndex++;
            Progress = (double)_currentFileIndex / _files.Length * 100;

            ProgressUpdate?.Invoke(this, EventArgs.Empty);

            await CopyNextFileAsync();
        }
    }
}
