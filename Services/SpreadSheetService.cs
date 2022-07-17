using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using FaceRecognitionApp.Models;

using Microsoft.Win32;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace FaceRecognitionApp.Services
{
    public class SpreadSheetService : ISpreadSheetService
    {

        private string excelFilePath = "attendance.xlsx";
        private FileInfo excelFile;

        public SpreadSheetService()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void PrintToExcel(IList<AttendanceEntry> attendanceEntries)
        {
            if (attendanceEntries.Count > 0)
            {
                excelFile = new FileInfo(GetFileName());

                DeleteIfExists(excelFile);

                using var package = new ExcelPackage(excelFile);

                var workSheet = package.Workbook.Worksheets.Add($"Attendance ({DateTime.Now.ToShortDateString()})");

                var range = workSheet.Cells["A2"].LoadFromCollection(GetAttendanceDataFrom(attendanceEntries), true);
                range.AutoFitColumns();

                var title = workSheet.Cells["A1"];
                title.Value = $"Student Attendance On {DateTime.Now.ToShortDateString()}";
                workSheet.Cells["A1:D1"].Merge = true;
                title.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                title.Style.Font.Color.SetColor(Color.OrangeRed);
                title.Style.Font.Size = 14;

                var header = workSheet.Row(2);
                header.Style.Font.Bold = true;

                package.Save();
            }
        }

        private void DeleteIfExists(FileInfo excelFile)
        {
            if (File.Exists(excelFilePath))
                File.Delete(excelFilePath);
        }

        private IList<AttendanceData> GetAttendanceDataFrom(IList<AttendanceEntry> attendanceEntries)
        {
            IList<AttendanceData> attendanceDatas = new List<AttendanceData>();

            foreach (var entry in attendanceEntries)
            {
                attendanceDatas.Add(new AttendanceData()
                {
                    StudentRegNumber = entry.Student.RegNumber,
                    StudentName = entry.Student.FullName,
                    Date = entry.AttendanceDateTime.Date.ToShortDateString(),
                    Time = entry.AttendanceDateTime.ToShortTimeString()
                });
            }

            return attendanceDatas;
        }

        private string GetFileName()
        {
            var fileDialog = new SaveFileDialog();

            fileDialog.Filter = "excel file (*.xlsx) | *.xlsx";

            fileDialog.ShowDialog();

            if (!String.IsNullOrEmpty(fileDialog.FileName))
                return fileDialog.FileName;
            else
                return excelFilePath;
        }
    }
}
