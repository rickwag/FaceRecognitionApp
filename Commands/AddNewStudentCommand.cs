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

        public AddNewStudentCommand(RegisterStudentViewModel _registerStudentViewModel, IDBService _dBService)
        {
            registerStudentViewModel = _registerStudentViewModel;
            dBService = _dBService;
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
                //save new student
                var id = dBService.AddNewStudent(new Student()
                {
                    FullName = registerStudentViewModel.NewStudent.FullName,
                    RegNumber = registerStudentViewModel.NewStudent.RegNumber
                });

                //save new student's training face images
                registerStudentViewModel.SaveTrainingImages(id);
            }
        }
    }
}
