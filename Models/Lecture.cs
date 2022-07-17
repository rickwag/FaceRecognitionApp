using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionApp.Models
{
    public class Lecture
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime LectureDateTime { get; set; }
        public string LecturerName { get; set; }

        //navigation properties
        public List<Student> Students { get; set; }
    }
}
