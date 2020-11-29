using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAssignment.BizRepositories;
using TestAssignment.Models;

namespace TestAssignment.Controllers
{
    public class SearchController : Controller
    {
        ApplicationDbContext context;
        IBizRepository<StudentCourse, int> StudentCourseRepository;
        IBizRepository<Student, int> StudentRepository;
        IBizRepository<Course, int> CourseRepository;
        public SearchController()
        {
            context = new ApplicationDbContext();
            StudentRepository = new StudentRepository();
            CourseRepository = new CourseRepository();
        }
        RHealDbContext db = new RHealDbContext();
        [Authorize(Roles = "Student")]
        public ActionResult Index(string Searchby, string search)
         {
            if (Searchby == "CourseName")
            {
                var model = db.Course.Where(x => x.CourseName.StartsWith(search) || search == null).ToList();
                return View(model);
            }
            else
            {
                var model = db.Course.Where(x => x.NoOfModules.ToString() == search || search == null).ToList();
                return View(model);
            }
         }

        public ActionResult register()
        {
            ViewBag.StudentRowId = new SelectList(StudentRepository.GetData(), "StudentRowId", "StudentId");
            ViewBag.CourseRowId = new SelectList(CourseRepository.GetData(), "CourseRowId", "CourseName");
            return View();
        }
        [HttpPost]


        public ActionResult register(StudentCourse data)
        {
            Student s = new Student();
            s.StudentRowId = data.StudentRowId;
            Course c = new Course();
            c.CourseRowId = data.CourseRowId;
            if (ModelState.IsValid)
            {

                data = StudentCourseRepository.Create(data);
                ViewBag.StudentRowId = new SelectList(StudentRepository.GetData(), "StudentRowId", "StudentId");
                ViewBag.CourseKeyId = new SelectList(CourseRepository.GetData(), "CourseRowId", "CourseName");
                return RedirectToAction("Index");
            }
           
            return View(data);
        }
       
    }

    


}