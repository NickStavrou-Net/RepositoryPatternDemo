using RepositoryPattern.Models;
using System.Data.Entity;

namespace RepositoryPattern.Dal
{
    public class StudentContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public StudentContext() : base("name=StudentContext")
        {
            Database.SetInitializer<StudentContext>(new SchoolDbInitializer());
        }

        public DbSet<Student> Students { get; set; }
    }
}
