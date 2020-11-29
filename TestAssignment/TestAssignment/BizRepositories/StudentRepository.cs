using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAssignment.Models;

namespace TestAssignment.BizRepositories
{
    public class StudentRepository : IBizRepository<Student, int>
    {
        RHealDbContext ctx;

        public StudentRepository()
        {
            ctx = new RHealDbContext();
        }

        public Student Create(Student entity)
        {
            entity = ctx.Student.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Student.Find(id);
            if (res == null) return false;
            ctx.Student.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<Student> GetData()
        {
            var res = ctx.Student.ToList();
            return res;
        }

        public Student GetData(int id)
        {
            var res = ctx.Student.Find(id);
            return res;
        }

        public Student Update(int id, Student entity)
        {
            var res = ctx.Student.Find(id);
            if (res != null)
            {
                res.StudentRowId = entity.StudentRowId;
                res.StudentId = entity.StudentId;
                res.StudentName = entity.StudentName;
                res.Email = entity.Email;
                res.Address = entity.Address;
                res.City = entity.City;
                res.AreaOfInterest = entity.AreaOfInterest;
                res.DOB = entity.DOB;
                res.MobileNo = entity.MobileNo;
                res.SelectedCourse = entity.SelectedCourse;
                res.CourseCompleted = entity.CourseCompleted;

                ctx.SaveChanges();
                return res;
            }
            return entity;
        }

    }
}