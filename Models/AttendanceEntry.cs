using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionApp.Models
{
    public class AttendanceEntry
    {
        public int ID { get; set; }
        public DateTime AttendanceDateTime { get; set; }
        public Student Student { get; set; }
        public Lecture Lecture { get; set; }
    }
}
