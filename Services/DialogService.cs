using System;
using System.Collections.Generic;
using System.Windows;

using FaceRecognitionApp.ViewModels;
using FaceRecognitionApp.Views;

namespace FaceRecognitionApp.Services
{
    public class DialogService : IDialogService
    {
        private Dictionary<string, Window> viewModelToDialog = new ();

        
        public void CreateNewDialog(BaseViewModel viewModel, Window parent)
        {
            if (viewModel is SelectClassViewModel)
            {
                var selectClassDialog = new SelectClassDialog();
                selectClassDialog.DataContext = viewModel as SelectClassViewModel;
                selectClassDialog.Owner = parent;

                viewModelToDialog.Add(nameof(SelectClassViewModel), selectClassDialog);
            }
            else if (viewModel is CreateNewClassViewModel)
            {
                var createNewClassDialog = new CreateNewClassDialog();
                createNewClassDialog.DataContext = viewModel as CreateNewClassViewModel;
                createNewClassDialog.Owner = parent;

                viewModelToDialog.Add(nameof(CreateNewClassViewModel), createNewClassDialog);
            }
            else if (viewModel is ProgressViewModel)
            {
                var progressView = new ProgressView();
                progressView.DataContext = viewModel as ProgressViewModel;
                progressView.Owner = parent;

                viewModelToDialog.Add(nameof(ProgressViewModel), progressView);
            }
        }

        public void ShowDialog(string viewModel)
        {
            if (CheckIfExists(viewModel))
            {
                var dialog = viewModelToDialog[viewModel];

                dialog.ShowDialog();
            }
        }

        public void CloseDialog(string viewModel)
        {
            if (CheckIfExists(viewModel))
            {
                var dialog = viewModelToDialog[viewModel];

                if (dialog.IsLoaded)
                    dialog.Close();
            }
        }

        public bool CheckIfExists(string viewModel)
        {
            return viewModelToDialog.ContainsKey(viewModel);
        }

        public Window GetView(string viewModel)
        {
            if (CheckIfExists(viewModel))
                return viewModelToDialog[viewModel];
            else return null;
        }

        public void ShowAsWindow(string viewModel)
        {
            if (CheckIfExists(viewModel))
            {
                var dialog = viewModelToDialog[viewModel];

                dialog.Show();
            }
        }
    }
}
