namespace FaceRecognitionApp.ViewModels
{
    public class ProgressViewModel : BaseViewModel
    {

        private string title = ".....";
        private int progressValue = 20;
        private string info = "Loading.....";


        public string Title
        {
            set
            {
                title = value;

                OnPropertyChanged(nameof(Title));
            }
            get { return title; }
        }
        public int ProgressValue
        {
            set
            {
                progressValue = value;

                OnPropertyChanged(nameof(ProgressValue));
            }
            get { return progressValue; }
        }
        public string Info
        {
            set
            {
                info = value;

                OnPropertyChanged(nameof(Info));
            }
            get { return info; }
        }
    }
}
