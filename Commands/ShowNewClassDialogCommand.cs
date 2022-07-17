using FaceRecognitionApp.Services;
using FaceRecognitionApp.ViewModels;
using FaceRecognitionApp.Views;

namespace FaceRecognitionApp.Commands
{
    public class ShowNewClassDialogCommand : BaseCommand
    {
        private readonly IDBService dBService;
        private readonly SelectClassViewModel selectClassViewModel;


        public ShowNewClassDialogCommand(IDBService _dBService, SelectClassViewModel _selectClassViewModel)
        {
            dBService = _dBService;
            selectClassViewModel = _selectClassViewModel;
        }

        public override void Execute(object parameter)
        {
            var dialogService = selectClassViewModel.DialogService;
            var newClassViewModel = new CreateNewClassViewModel(dBService, selectClassViewModel.NavStore, dialogService);

            if (!dialogService.CheckIfExists(nameof(CreateNewClassViewModel)))
            {
                var parentWindow = App.Current.MainWindow;

                dialogService.CreateNewDialog(newClassViewModel, parentWindow);
            }

            //close parent dialog first
            dialogService.CloseDialog(nameof(SelectClassViewModel));

            dialogService.ShowDialog(nameof(CreateNewClassViewModel));
        }
    }
}
