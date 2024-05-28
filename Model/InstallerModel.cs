using System.IO;
using System;
using System.Threading.Tasks;

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

                // Use synchronous methods for reading and writing files
                byte[] fileContents;
                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    fileContents = new byte[sourceStream.Length];
                    await sourceStream.ReadAsync(fileContents, 0, (int)sourceStream.Length);
                }

                using (FileStream targetStream = new FileStream(targetFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await targetStream.WriteAsync(fileContents, 0, fileContents.Length);
                }

                _currentFileIndex++;
                Progress = (double)_currentFileIndex / _files.Length * 100;
                ProgressUpdate?.Invoke(this, EventArgs.Empty);

                await Task.Delay(500); // Delay to check if progress bar UI updates, delete or comment out before submitting the task
            }

            InstallationComplete?.Invoke(this, EventArgs.Empty);
        }

    }
}
