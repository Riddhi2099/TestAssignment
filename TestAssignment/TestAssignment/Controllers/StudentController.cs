using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAssignment.BizRepositories;
using TestAssignment.Models;

namespace TestAssignment.Controllers
{
    public class StudentController : Controller
    {
        IBizRepository<Student, int> StudentRepository;

        public StudentController()
        {
            StudentRepository = new StudentRepository();
        }

        /*public TrainerController(IBizRepository<Trainer, int> TrainerRepository)
            {
                this.TrainerRepository = TrainerRepository;

            }*/



        public ActionResult Index()
        {
            var result = StudentRepository.GetData();

            return View(result);
        }


        public ActionResult Create()
        {
            var result = new Student();

            return View(result);
        }


        [HttpPost]
        public ActionResult Create(Student data)
        {
            if (ModelState.IsValid)
            {

                data = StudentRepository.Create(data);

                return RedirectToAction("Index");
            }

            return View(data);
        }


        public ActionResult Edit(int id)
        {

            var result = StudentRepository.GetData(id);

            return View(result);
        }


        [HttpPost]
        public ActionResult Edit(int id, Student data)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }


        public ActionResult Delete(int id)
        {
            var result = StudentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}