using FaceRecognitionApp.ViewModels;

namespace FaceRecognitionApp.Commands
{
    public class ConfirmSelectedClassCommand : BaseCommand
    {
        private SelectClassViewModel selectClassViewModel;

        public ConfirmSelectedClassCommand(SelectClassViewModel selectClassViewModel)
        {
            this.selectClassViewModel = selectClassViewModel;
        }

        public override void Execute(object parameter)
        {
            selectClassViewModel.DialogService.CloseDialog(nameof(SelectClassViewModel));

            selectClassViewModel.NavStore.CurrentViewModel = new RegisterStudentViewModel(selectClassViewModel.NavStore, selectClassViewModel.DbService, selectClassViewModel.SelectedLecture);
        }
    }
}
