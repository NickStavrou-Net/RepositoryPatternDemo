using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace RepositoryPattern.Dal
{
    public class SchoolDbInitializer : DropCreateDatabaseAlways<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            var students = new List<Student>
            {
               new Student { LastName = "Thompson", FirstName = "Michel", City = "Melbourne" },
               new Student { LastName = "James", FirstName = "Lily", City = "Washington" },
               new Student { LastName = "Hannah", FirstName = "Ruby", City = "Sydney" },
               new Student { LastName = "Catherine", FirstName = "Mia", City = "Sydney" },
               new Student { LastName = "Marshall", FirstName = "Officer", City = "Dallas" },
               new Student { LastName = "Parker", FirstName = "Peter", City = "New York" },
               new Student { LastName = "Smith", FirstName = "Steve", City = "Miami" }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}