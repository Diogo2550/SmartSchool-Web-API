using SmartSchool_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Data {
    
    public interface IRepository {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Student> GetStudentAsyncById(int studentId, bool includeSubject);
        Task<Student[]> GetAllStudentsAsync(bool includeTeacher);
        Task<Student[]> GetStudentsAsyncBySubjectId(int subjectId, bool includeSubject);

        Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeSubject);
        Task<Teacher[]> GetAllTeachersAsync(bool includeSubject);
        Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeSubject);

    }

}
