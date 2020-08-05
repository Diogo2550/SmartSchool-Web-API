using Microsoft.EntityFrameworkCore;
using SmartSchool_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Data {
    public class Repository : IRepository {

        private readonly DataContext _context;

        public Repository(DataContext context) {
            _context = context;
        }

        public void Add<T>(T entity) where T : class {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync() {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Student[]> GetAllStudentsAsync(bool includeTeacher = false) {
            IQueryable<Student> query = _context.Students;

            if(includeTeacher) {
                query = query.Include(pe => pe.StudentsSubjects)
                                .ThenInclude(s => s.Subject)
                                .ThenInclude(t => t.Teacher);
            }

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentAsyncById(int studentId, bool includeSubject) {
            IQueryable<Student> query = _context.Students;

            if(includeSubject) {
                query = query.Include(p => p.StudentsSubjects)
                                .ThenInclude(s => s.Subject);
            }

            query = query.AsNoTracking()
                            .OrderBy(c => c.Id)
                            .Where(aluno => aluno.Id == studentId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Student[]> GetStudentsAsyncBySubjectId(int subjectId, bool includeSubject) {
            IQueryable<Student> query = _context.Students;

            if(includeSubject) {
                query = query.Include(p => p.StudentsSubjects)
                             .ThenInclude(ad => ad.Subject)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.StudentsSubjects.Any(ad => ad.SubjectId == subjectId));

            return await query.ToArrayAsync();
        }

        public async Task<Teacher[]> GetAllTeachersAsync(bool includeSubject) {
            IQueryable<Teacher> query = _context.Teacher;

            if(includeSubject) {
                query = query.Include(c => c.Subject);
            }

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeSubject) {
            IQueryable<Teacher> query = _context.Teacher;

            if(includeSubject) {
                query = query.Include(pe => pe.Subject);
            }

            query = query.AsNoTracking()
                         .OrderBy(teacher => teacher.Id)
                         .Where(teacher => teacher.Id == teacherId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Teacher[]> GetTeachersAsyncByStudentId(int studentId, bool includeSubject) {
            IQueryable<Teacher> query = _context.Teacher;

            if(includeSubject) {
                query = query.Include(p => p.Subject);
            }

            query = query.AsNoTracking()
                         .OrderBy(student => student.Id)
                         .Where(student => student.Subject.Any(d =>
                                d.StudentsSubjects.Any(ad => ad.StudentId == studentId)));

            return await query.ToArrayAsync();
        }


    }
}
