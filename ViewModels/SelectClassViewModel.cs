using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

using FaceRecognitionApp.Commands;
using FaceRecognitionApp.Models;
using FaceRecognitionApp.Services;
using FaceRecognitionApp.Stores;

namespace FaceRecognitionApp.ViewModels
{
    public class SelectClassViewModel : BaseViewModel
    {
        private readonly IDBService dBService;
        private Lecture selectedLecture = null;

        public ObservableCollection<Lecture> Classes { get; set; }
        public ICommand ShowNewClassDialogCommand { get; set; }
        public ICommand ConfirmSelectedClassCommand { get; set; }
        public IDialogService DialogService { get; set; }
        public NavigationStore NavStore { get; set; }
        public IDBService DbService => dBService;
        public Lecture SelectedLecture {
            get { return selectedLecture; }
            set
            {
                selectedLecture = value;

                OnPropertyChanged(nameof(SelectedLecture));
            }
        }

        public SelectClassViewModel(IDBService _dBService, IDialogService dialogService, NavigationStore navigationStore)
        {
            dBService = _dBService;
            NavStore = navigationStore;

            var lectures = dBService.GetAllLectures();
            PopulateClasses(lectures);

            DialogService = dialogService;

            ShowNewClassDialogCommand = new ShowNewClassDialogCommand(dBService, this);
            ConfirmSelectedClassCommand = new ConfirmSelectedClassCommand(this);
        }

        private void PopulateClasses(List<Lecture> lectures)
        {
            if (Classes == null) Classes = new();

            foreach (var lecture in lectures)
            {
                Classes.Add(lecture);
            }
        }
    }
}
