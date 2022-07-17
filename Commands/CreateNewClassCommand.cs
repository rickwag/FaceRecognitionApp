using FaceRecognitionApp.Models;
using FaceRecognitionApp.ViewModels;

namespace FaceRecognitionApp.Commands
{
    public class CreateNewClassCommand : BaseCommand
    {
        private CreateNewClassViewModel createNewClassViewModel;
            
        public CreateNewClassCommand(CreateNewClassViewModel createNewClassViewModel)
        {
            this.createNewClassViewModel = createNewClassViewModel;
        }

        public override void Execute(object parameter)
        {
            createNewClassViewModel.DialogService.CloseDialog(nameof(CreateNewClassViewModel));

            var newClass = createNewClassViewModel.DbService.CreateNewClass(new Lecture()
            {
                Name = createNewClassViewModel.NewClass.Name,
                LecturerName = createNewClassViewModel.NewClass.LecturerName,
                LectureDateTime = createNewClassViewModel.NewClass.LectureDateTime
            });

            createNewClassViewModel.NavStore.CurrentViewModel = new RegisterStudentViewModel(createNewClassViewModel.NavStore, createNewClassViewModel.DbService, newClass);
        }
    }
}
