using System.Windows.Input;

using FaceRecognitionApp.Commands;
using FaceRecognitionApp.Services;
using FaceRecognitionApp.Stores;

namespace FaceRecognitionApp.ViewModels
{
    public class DashBoardViewModel : BaseViewModel
    {
        public ICommand NavigateToRegisterNewStudent { get; set; }
        public ICommand NavigateToMarkAttendance { get; set; }

        public DashBoardViewModel(NavigationStore _navigationStore, IDBService _dBService)
        {
            NavigateToRegisterNewStudent = new NavigateCommand(() => NavToRegisterNewStudent(_navigationStore, _dBService));
            NavigateToMarkAttendance = new NavigateCommand(() => _navigationStore.CurrentViewModel = new MarkAttendanceViewModel(_navigationStore, _dBService));
        }

        private void NavToRegisterNewStudent(NavigationStore navigationStore, IDBService dBService)
        {
            var dialogService = new DialogService();
            var selectClassViewModel = new SelectClassViewModel(dBService, dialogService, navigationStore);

            if (!dialogService.CheckIfExists(nameof(SelectClassViewModel)))
                dialogService.CreateNewDialog(selectClassViewModel, App.Current.MainWindow);

            dialogService.ShowDialog(nameof(SelectClassViewModel));

            //navigationStore.CurrentViewModel = new RegisterStudentViewModel(navigationStore, dBService);
        }
    }
}
