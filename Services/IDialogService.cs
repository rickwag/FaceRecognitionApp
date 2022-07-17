using System.Windows;

using FaceRecognitionApp.ViewModels;

namespace FaceRecognitionApp.Services
{
    public interface IDialogService
    {
        public bool CheckIfExists(string viewModel);
        public void CreateNewDialog(BaseViewModel viewModel, Window parent);

        /// <summary>
        /// shows the specified dialog window   
        /// </summary>
        /// <param name="viewModel">nameof(viewModel)</param>
        public void ShowDialog(string viewModel);
        public void CloseDialog(string viewModel);
        public void ShowAsWindow(string viewModel);

        /// <summary>
        /// gets the view associated with the viewModel
        /// </summary>
        /// <param name="viewModel">the viewModel</param>
        /// <returns></returns>
        public Window GetView(string viewModel);
    }
}
