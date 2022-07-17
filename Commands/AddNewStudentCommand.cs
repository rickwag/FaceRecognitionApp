using System;
using System.Windows;

using FaceRecognitionApp.Models;
using FaceRecognitionApp.Services;
using FaceRecognitionApp.ViewModels;

namespace FaceRecognitionApp.Commands
{
    public class AddNewStudentCommand : BaseCommand
    {
        private RegisterStudentViewModel registerStudentViewModel;
        private IDBService dBService;
        private IDialogService dialogService;
        private ProgressViewModel progressViewModel;

        public AddNewStudentCommand(RegisterStudentViewModel _registerStudentViewModel, IDBService _dBService, IDialogService _dialogService)
        {
            registerStudentViewModel = _registerStudentViewModel;
            dBService = _dBService;
            dialogService = _dialogService;
            progressViewModel = registerStudentViewModel.ProgViewModel;
        }

        public override void Execute(object parameter)
        {
            //continue only if has student name and registration number
            if (String.IsNullOrEmpty(registerStudentViewModel.NewStudent.FullName))
            {
                MessageBox.Show("please fill in the student's full name", "adding new student", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (String.IsNullOrEmpty(registerStudentViewModel.NewStudent.RegNumber))
            {
                MessageBox.Show("please fill in the student's registration number", "adding new student", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (!dialogService.CheckIfExists(nameof(ProgressViewModel)))
                    dialogService.CreateNewDialog(progressViewModel, App.Current.MainWindow);

                progressViewModel.ProgressValue = 10;
                progressViewModel.Info = $"saving {registerStudentViewModel.NewStudent.FullName}...";

                dialogService.ShowAsWindow(nameof(ProgressViewModel));

                //save new student
                var id = dBService.AddNewStudent(new Student()
                {
                    FullName = registerStudentViewModel.NewStudent.FullName,
                    RegNumber = registerStudentViewModel.NewStudent.RegNumber,
                    Lecture = registerStudentViewModel.NewStudent.Lecture
                });

                //save new student's training face images
                registerStudentViewModel.SaveTrainingImages(id);
            }
        }
    }
}
