using System.Web.Mvc;
using TestAssignment.BizRepositories;
using TestAssignment.Controllers;
using TestAssignment.Models;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace TestAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<AccountController>(new InjectionConstructor());

            // register the ApplicationDbContext
            container.RegisterType<ApplicationDbContext>();
            /*container.RegisterType<IBizRepository<Student, int>, StudentRepository>();
            container.RegisterType<IBizRepository<Course, int>, CourseRepository>();
            container.RegisterType<IBizRepository<Trainer, int>, TrainerRepository>();*/

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}