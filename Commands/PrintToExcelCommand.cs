using System.Collections.Generic;

using FaceRecognitionApp.Models;
using FaceRecognitionApp.Services;
using FaceRecognitionApp.ViewModels;

namespace FaceRecognitionApp.Commands
{
    class PrintToExcelCommand : BaseCommand
    {
        private readonly ISpreadSheetService spreadSheetService;
        private readonly MarkAttendanceViewModel markAttendanceViewModel;


        public PrintToExcelCommand(MarkAttendanceViewModel _markAttendanceViewModel ,ISpreadSheetService _spreadSheetService)
        {
            markAttendanceViewModel = _markAttendanceViewModel;
            spreadSheetService = _spreadSheetService;
        }

        public override void Execute(object parameter)
        {
            spreadSheetService.PrintToExcel(markAttendanceViewModel.AttendanceEntries);
        }
    }
}
