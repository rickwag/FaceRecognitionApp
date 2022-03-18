using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace FaceRecognitionApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        #region properties
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<AttendanceEntry> AttendanceEntries { get; set; } 
        #endregion

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
