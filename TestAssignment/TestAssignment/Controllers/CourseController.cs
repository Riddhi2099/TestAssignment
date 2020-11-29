using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAssignment.BizRepositories;
using TestAssignment.Models;

namespace TestAssignment.Controllers
{
    public class CourseController : Controller
    {
        IBizRepository<Course, int> CourseRepository;

        public CourseController()
        {
            CourseRepository = new CourseRepository();
        }

        /*public TrainerController(IBizRepository<Trainer, int> TrainerRepository)
            {
                this.TrainerRepository = TrainerRepository;

            }*/


        [Authorize(Roles = "Trainer")]
        public ActionResult Index()
        {
            var result = CourseRepository.GetData();

            return View(result);
        }

        [Authorize(Roles = "Trainer")]
        public ActionResult Create()
        {
            var result = new Course();

            return View(result);
        }


        [HttpPost]
        public ActionResult Create(Course data)
        {
            if (ModelState.IsValid)
            {

                data = CourseRepository.Create(data);

                return RedirectToAction("Index");
            }

            return View(data);
        }


        public ActionResult Edit(int id)
        {

            var result = CourseRepository.GetData(id);

            return View(result);
        }


        [HttpPost]
        public ActionResult Edit(int id, Course data)
        {
            if (ModelState.IsValid)
            {
                CourseRepository.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }


        public ActionResult Delete(int id)
        {
            var result = CourseRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}