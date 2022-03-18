using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionApp.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string RegNumber { get; set; }
        public string FullName { get; set; }
        public Lecture Lecture { get; set; }
    }
}
