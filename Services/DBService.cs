using System;

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
    }
}
