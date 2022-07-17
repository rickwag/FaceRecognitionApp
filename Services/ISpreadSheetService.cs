using System.Collections.Generic;

using FaceRecognitionApp.Models;

namespace FaceRecognitionApp.Services
{
    public interface ISpreadSheetService
    {
        public void PrintToExcel(IList<AttendanceEntry> attendanceEntries);
    }
}
