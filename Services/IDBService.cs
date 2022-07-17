using System.Collections;
using System.Collections.Generic;

using FaceRecognitionApp.Models;

namespace FaceRecognitionApp.Services
{
    public interface IDBService
    {
        public int AddNewStudent(Student newStudent);
        public string GetStudentName(int id);
        public Student GetStudent(int id);
        public void AddAttendance(AttendanceEntry attendanceEntry);
        public bool CheckIfAttendanceExists(int studentID);
        public List<Lecture> GetAllLectures();

        public Lecture GetLecture(int id);

        /// <summary>
        /// adds a new lecture class to the database
        /// </summary>
        /// <param name="newClass">a lecture class</param>
        /// <returns></returns>
        public Lecture CreateNewClass(Lecture newClass);
    }
}
