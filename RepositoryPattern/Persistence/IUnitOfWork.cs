using RepositoryPattern.Repositories;

namespace RepositoryPattern.Persistence
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }

        void Complete();
    }
}
