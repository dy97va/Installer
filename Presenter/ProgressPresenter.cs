﻿using Installer.Model;
using Installer.View;

namespace Installer.Presenter
{
    public class ProgressPresenter
    {
        private readonly IProgressView _view;
        private readonly InstallationModel _model;

        public ProgressPresenter(IProgressView view, string targetDirectory)
        {
            _view = view;
            _model = new InstallationModel(targetDirectory);
            _model.InstallationComplete += OnInstallationComplete;
            _model.ProgressUpdate += OnProgressUpdate;
        }

        public async Task StartInstallationAsync()
        {
            await _model.CopyNextFileAsync();
        }

        private void OnProgressUpdate(object sender, EventArgs e)
        {
            _view.UpdateProgress(_model.Progress);
        }

        private void OnInstallationComplete(object sender, EventArgs e)
        {
            _view.CompleteInstallation();
        }
    }
}
