using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Models {

    public class Student {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<StudentSubject> StudentsSubjects { get; set; }

        public Student() { } 

        public Student(int id, string name, string lastName, string phoneNumber) {
            Id = id;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

    }

}
