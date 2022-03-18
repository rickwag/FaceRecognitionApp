using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace FaceRecognitionApp.Models
{
    public class ApplicationDbContextFactory
    {
        private string connectionString;

        public ApplicationDbContextFactory(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public ApplicationDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;

            return new ApplicationDbContext(options);
        }
    }
}
