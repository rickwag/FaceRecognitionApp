using System;
using System.Windows.Input;

using FaceRecognitionApp.Commands;
using FaceRecognitionApp.Models;
using FaceRecognitionApp.Services;
using FaceRecognitionApp.Stores;

namespace FaceRecognitionApp.ViewModels
{
    public class CreateNewClassViewModel : BaseViewModel
    {
        private readonly IDBService dBService;
        private readonly IDialogService dialogService;
        private readonly NavigationStore navigationStore;

        public Lecture NewClass { get; set; } = new();
        public ICommand CreateNewClassCommand { get; set; }

        public IDBService DbService => dBService;
        public IDialogService DialogService => dialogService;
        public NavigationStore NavStore => navigationStore;


        public CreateNewClassViewModel(IDBService _dBService, NavigationStore _navigationStore, IDialogService _dialogService)
        {
            dialogService = _dialogService;

            dBService = _dBService;

            navigationStore = _navigationStore;

            CreateNewClassCommand = new CreateNewClassCommand(this);
        }
    }
}
