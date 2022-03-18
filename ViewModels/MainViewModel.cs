using FaceRecognitionApp.Services;

namespace FaceRecognitionApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IDBService dBService;
        private IFaceRecognitionService faceRecognitionService;

        public BaseViewModel CurrentViewModel { get; set; }

        public MainViewModel(IDBService _dBService)
        {
            dBService = _dBService;
            faceRecognitionService = new FaceRecognitionService(dBService);

            CurrentViewModel = new MarkAttendanceViewModel(dBService, faceRecognitionService);
        }
    }
}
