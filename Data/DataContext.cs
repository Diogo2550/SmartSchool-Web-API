using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using SmartSchool_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Data {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<StudentSubject>().HasKey(SS => new { SS.StudentId, SS.SubjectId });

            builder.Entity<Teacher>().HasData(new List<Teacher>() {
                new Teacher(1, "Diogo"),
                new Teacher(2, "Felipe"),
                new Teacher(3, "Valentim"),
                new Teacher(4, "Marcos"),
                new Teacher(5, "Dálvio")
            });

            builder.Entity<Subject>().HasData(new List<Subject>() {
                new Subject(1, "Programção Avançada", 1),
                new Subject(2, "Matemática", 2),
                new Subject(3, "Português", 3),
                new Subject(4, "Técnicas de Programação", 4),
                new Subject(5, "Arquitetura de Computadores", 5),
                new Subject(6, "Web", 1)
            });

            builder.Entity<Student>().HasData(new List<Student>() {
                new Student(1, "Diogo", "Alves", "857193485"),
                new Student(2, "Alice", "Gonçalves", "425879635"),
                new Student(3, "Rodrigo", "Santos", "975813495"),
                new Student(4, "Mayall", "Malhado", "679185425"),
                new Student(5, "Angelo", "Pompeu", "579281648"),
                new Student(6, "Myllene", "Figueiredo", "948759168"),
                new Student(7, "Thammy", "Maravilha", "486792183"),
                new Student(8, "Jamilly", "Souza", "684973812")
            });

            builder.Entity<StudentSubject>().HasData(new List<StudentSubject>() {
                new StudentSubject() { StudentId = 1, SubjectId = 2},
                new StudentSubject() { StudentId = 1, SubjectId = 3},
                new StudentSubject() { StudentId = 1, SubjectId = 5},
                new StudentSubject() { StudentId = 2, SubjectId = 1},
                new StudentSubject() { StudentId = 2, SubjectId = 2},
                new StudentSubject() { StudentId = 2, SubjectId = 3},
                new StudentSubject() { StudentId = 2, SubjectId = 6},
                new StudentSubject() { StudentId = 3, SubjectId = 2},
                new StudentSubject() { StudentId = 3, SubjectId = 4},
                new StudentSubject() { StudentId = 4, SubjectId = 3},
                new StudentSubject() { StudentId = 5, SubjectId = 3},
                new StudentSubject() { StudentId = 5, SubjectId = 2},
                new StudentSubject() { StudentId = 6, SubjectId = 1},
                new StudentSubject() { StudentId = 6, SubjectId = 4},
                new StudentSubject() { StudentId = 7, SubjectId = 1},
                new StudentSubject() { StudentId = 7, SubjectId = 2},
                new StudentSubject() { StudentId = 7, SubjectId = 3},
                new StudentSubject() { StudentId = 7, SubjectId = 4},
                new StudentSubject() { StudentId = 7, SubjectId = 5},
                new StudentSubject() { StudentId = 7, SubjectId = 6},
                new StudentSubject() { StudentId = 8, SubjectId = 2},
                new StudentSubject() { StudentId = 8, SubjectId = 3}
            });

        }

    }
}
