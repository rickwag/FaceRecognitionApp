using System;
using System.Linq;

using FaceRecognitionApp.Models;

namespace FaceRecognitionApp.Services
{
    public class DBService : IDBService
    {
        ApplicationDbContextFactory dbContextFactory;

        public DBService(ApplicationDbContextFactory _dbContextFactory)
        {
            dbContextFactory = _dbContextFactory;
        }

        public int AddNewStudent(Student newStudent)
        {
            var id = -1; //by default

            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                var result = dbContext.Students.Add(newStudent);

                dbContext.SaveChanges();

                id = result.Entity.ID;
            }

            return id;
        }

        public string GetStudentName(int id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var result = dbContext.Students.First(student => student.ID == id);

            return result.FullName;
        }
    }
}
