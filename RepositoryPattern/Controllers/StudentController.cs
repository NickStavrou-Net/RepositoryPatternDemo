using RepositoryPattern.Models;
using RepositoryPattern.Persistence;
using System.Web.Mvc;

namespace RepositoryPattern.Controllers
{
    public class StudentController : Controller
    {
        private IUnitOfWork unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public StudentController()
        {

        }

        // GET: Student
        public ActionResult Index()
        {
            return View(unitOfWork.StudentRepository.GetStudents());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {

            var student = unitOfWork.StudentRepository.GetStudent(id);
            if (student == null)
            {
                return View("NotFound");
            }
            return View(student);
        }


        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.StudentRepository.CreateStudent(student);
                unitOfWork.Complete();
                TempData["Message"] = "You have created a new Student!";
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = unitOfWork.StudentRepository.GetStudent(id);
            if (student == null)
            {
                return View("NotFound");
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.StudentRepository.UpdateStudent(student);
                unitOfWork.Complete();
                TempData["Message"] = "You have saved the student!";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = unitOfWork.StudentRepository.GetStudent(id);
            if (student == null)
            {
                return View("NotFound");
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection form)
        {
            unitOfWork.StudentRepository.DeleteStudent(id);
            unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
