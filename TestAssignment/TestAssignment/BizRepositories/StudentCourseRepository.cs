using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAssignment.Models;

namespace TestAssignment.BizRepositories
{
    public class StudentCourseRepository : IBizRepository<StudentCourse, int>
    {
        RHealDbContext ctx;
       
        public StudentCourseRepository()
        {
            ctx = new RHealDbContext();
        }

        public StudentCourse Create(StudentCourse entity)
        {
            entity = ctx.StudentCourse.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.StudentCourse.Find(id);
            if (res == null) return false;
            ctx.StudentCourse.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<StudentCourse> GetData()
        {
            var res = ctx.StudentCourse.ToList();
            return res;
        }

        public StudentCourse GetData(int id)
        {
            var res = ctx.StudentCourse.Find(id);
            return res;
        }

        public StudentCourse Update(int id, StudentCourse entity)
        {
            var res = ctx.StudentCourse.Find(id);
            if (res != null)
            {
                res.StudentCourseRowId = entity.StudentCourseRowId;
                res.StudentRowId = entity.StudentRowId;
                res.CourseRowId = entity.CourseRowId;

                ctx.SaveChanges();
                return res;
            }
            return entity;
        }

    }

}