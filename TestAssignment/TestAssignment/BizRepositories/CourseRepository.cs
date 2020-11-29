using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAssignment.Models;

namespace TestAssignment.BizRepositories
{
    public class CourseRepository : IBizRepository<Course, int>
    {
        RHealDbContext ctx;

        public CourseRepository()
        {
            ctx = new RHealDbContext();
        }

        public Course Create(Course entity)
        {
            entity = ctx.Course.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Course.Find(id);
            if (res == null) return false;
            ctx.Course.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<Course> GetData()
        {
            var res = ctx.Course.ToList();
            return res;
        }

        public Course GetData(int id)
        {
            var res = ctx.Course.Find(id);
            return res;
        }

        public Course Update(int id, Course entity)
        {
            var res = ctx.Course.Find(id);
            if (res != null)
            {
                res.CourseRowId = entity.CourseRowId;
                res.CourseId = entity.CourseId;
                res.CourseName = entity.CourseName;
                res.CourseTrainer = entity.CourseTrainer;
                res.NoOfModules = entity.NoOfModules;
                res.Price = entity.Price;
                res.TrainerRowId = entity.TrainerRowId;
                ctx.SaveChanges();
                return res;
            }
            return entity;
        }

    }
}