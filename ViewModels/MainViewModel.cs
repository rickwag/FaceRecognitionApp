using FaceRecognitionApp.Services;

namespace FaceRecognitionApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; set; }
        public IDBService dBService;

        public MainViewModel(IDBService _dBService)
        {
            dBService = _dBService;

            CurrentViewModel = new RegisterStudentViewModel(dBService);
        }
    }
}
