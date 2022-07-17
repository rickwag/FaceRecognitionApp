using FaceRecognitionApp.Services;
using FaceRecognitionApp.Stores;

namespace FaceRecognitionApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region fields
        private IDBService dBService;
        private readonly NavigationStore navigationStore; 
        #endregion

        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;

        public MainViewModel(IDBService _dBService, NavigationStore _navigationStore)
        {
            dBService = _dBService;

            navigationStore = _navigationStore;

            navigationStore.currentViewModelChanged += CurrentViewModelChanged;

            //CurrentViewModel = new MarkAttendanceViewModel(dBService, faceRecognitionService);
        }

        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
