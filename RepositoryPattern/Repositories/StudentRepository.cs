using RepositoryPattern.Dal;
using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RepositoryPattern.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private StudentContext _context;
        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            _context.Entry(student).State = EntityState.Deleted;
        }

        public Student GetStudent(int id)
        {
            return _context.Students.Where(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}