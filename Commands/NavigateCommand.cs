using System;

namespace FaceRecognitionApp.Commands
{
    public class NavigateCommand : BaseCommand
    {
        private Action action;
        public NavigateCommand(Action _action)
        {
            action = _action;
        }

        public override void Execute(object parameter)
        {
            action?.Invoke();
        }
    }
}
