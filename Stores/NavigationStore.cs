using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FaceRecognitionApp.ViewModels;

namespace FaceRecognitionApp.Stores
{
    public class NavigationStore
    {
        public event Action currentViewModelChanged;
        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                if (currentViewModel != null) currentViewModel.Dispose();

                currentViewModel = value;

                OnCurrentViewModelChanged();
            }
        }


        private void OnCurrentViewModelChanged()
        {
            currentViewModelChanged?.Invoke();
        }
    }
}
