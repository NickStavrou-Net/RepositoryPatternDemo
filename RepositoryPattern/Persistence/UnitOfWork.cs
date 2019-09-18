using RepositoryPattern.Dal;
using RepositoryPattern.Repositories;

namespace RepositoryPattern.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private StudentContext _context;
        public IStudentRepository StudentRepository { get; set; }

        public UnitOfWork(StudentContext context)
        {
            _context = context;
            StudentRepository = new StudentRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}