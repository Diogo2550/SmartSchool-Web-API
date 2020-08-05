using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Models {
    public class StudentSubject {

        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public StudentSubject() { }

        public StudentSubject(int studentId, int subjectId) {
            StudentId = studentId;
            SubjectId = subjectId;
        }

    }
}
