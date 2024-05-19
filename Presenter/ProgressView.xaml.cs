using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Installer.View
{
    public partial class ProgressView : System.Windows.Controls.UserControl
    {
        private Frame _mainFrame;
        private string _targetDirectory;
        private DispatcherTimer _timer;
        private string[] _files;
        private int _currentFileIndex;

        public ProgressView(Frame mainFrame, string targetDirectory)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            _targetDirectory = targetDirectory;
        }

        public void StartInstallation()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += UpdateProgress;
            _timer.Start();

            string sourceDirectory = @"C:\Users\dy97v\Desktop\folder\Files";
            _files = Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories);
            _currentFileIndex = 0;

            CopyFile();
        }

        private void CopyFile()
        {
            if (_currentFileIndex >= _files.Length)
            {
                // All files copied
                _timer.Stop();
                ProgressText.Text = "Installation Complete!";
                return;
            }

            string sourceFilePath = _files[_currentFileIndex];
            string fileName = Path.GetFileName(sourceFilePath);
            string targetFilePath = Path.Combine(_targetDirectory, fileName);

            // Copy file
            File.Copy(sourceFilePath, targetFilePath, true);
            _currentFileIndex++;
        }

        private void UpdateProgress(object sender, EventArgs e)
        {
            if (_files.Length > 0)
            {
                double progress = (double)_currentFileIndex / _files.Length * 100;
                ProgressBar.Value = progress;
                ProgressText.Text = $"Installation Progress: {progress:F2}%";

                // Copy next file
                if (_currentFileIndex < _files.Length)
                {
                    CopyFile();
                }
            }
        }
    }
}

