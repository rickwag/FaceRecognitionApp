using FaceRecognitionApp.Models;

namespace FaceRecognitionApp.Services
{
    public interface IDBService
    {
        public int AddNewStudent(Student newStudent);
        public string GetStudentName(int id);
    }
}
