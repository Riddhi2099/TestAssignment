using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAssignment.BizRepositories;
using TestAssignment.Models;

namespace TestAssignment.Controllers
{
    public class TrainerController : Controller
    {
        IBizRepository<Trainer, int> TrainerRepository;

        public TrainerController()
        {
            TrainerRepository = new TrainerRepository();
        }
        
    /*public TrainerController(IBizRepository<Trainer, int> TrainerRepository)
        {
            this.TrainerRepository = TrainerRepository;

        }*/



        public ActionResult Index()
        {
            var result = TrainerRepository.GetData();

            return View(result);
        }


        public ActionResult Create()
        {
            var result = new Trainer();
           
            return View(result);
        }


        [HttpPost]
        public ActionResult Create(Trainer data)
        {
            if (ModelState.IsValid)
            {

                data = TrainerRepository.Create(data);

                return RedirectToAction("Index");
            }

            return View(data);
        }


        public ActionResult Edit(int id)
        {

            var result = TrainerRepository.GetData(id);

            return View(result);
        }


        [HttpPost]
        public ActionResult Edit(int id, Trainer data)
        {
            if (ModelState.IsValid)
            {
                TrainerRepository.Update(id, data);
                return RedirectToAction("Index");
            }
            return View(data);
        }


        public ActionResult Delete(int id)
        {
            var result = TrainerRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
