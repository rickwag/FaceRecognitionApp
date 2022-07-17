using System;
using System.Collections;
using System.Collections.Generic;
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

        public void AddAttendance(AttendanceEntry attendanceEntry)
        {
            using var dbContext = dbContextFactory.CreateDbContext();

            dbContext.AttendanceEntries.Add(attendanceEntry);

            dbContext.Students.Attach(attendanceEntry.Student);
            dbContext.Lectures.Attach(attendanceEntry.Lecture);

            dbContext.SaveChangesAsync();
        }

        public int AddNewStudent(Student newStudent)
        {
            var id = -1; //by default

            using (var dbContext = dbContextFactory.CreateDbContext())
            {
                dbContext.Attach(newStudent.Lecture);
                var result = dbContext.Students.Add(newStudent);

                newStudent.Lecture.Students.Add(newStudent);

                dbContext.SaveChangesAsync();

                id = result.Entity.ID;
            }

            return id;
        }

        public bool CheckIfAttendanceExists(int studentID)
        {
            var exists = false;

            try
            {
                using var dbContext = dbContextFactory.CreateDbContext();
                var attendanceEntry = dbContext.AttendanceEntries.First(entry => entry.Student.ID == studentID);

                exists = true;
            }
            catch (Exception e)
            {
                return exists;
            }

            return exists;
        }

        public Student GetStudent(int id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var result = dbContext.Students.First(student => student.ID == id);

            return result;
        }

        public string GetStudentName(int id)
        {
            return GetStudent(id).FullName;
        }

        public List<Lecture> GetAllLectures()
        {
            var lectures = new List<Lecture>();

            using var dbContext = dbContextFactory.CreateDbContext();
            lectures = dbContext.Lectures.ToList();

            return lectures;
        }

        public Lecture CreateNewClass(Lecture newClass)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var result = dbContext.Lectures.Add(newClass);

            dbContext.SaveChanges();

            return dbContext.Lectures.First((lecture) => lecture.ID == result.Entity.ID);
        }

        public Lecture GetLecture(int id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var lecture = dbContext.Lectures.First(lec => lec.ID == id);

            return lecture;
        }
    }
}
