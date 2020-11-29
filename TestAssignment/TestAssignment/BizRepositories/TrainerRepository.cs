using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestAssignment.Models;

namespace TestAssignment.BizRepositories
{
    public class TrainerRepository : IBizRepository<Trainer, int>
    {
        RHealDbContext ctx;

        public TrainerRepository()
        {
            ctx = new RHealDbContext();
        }

        public Trainer Create(Trainer entity)
        {
            entity = ctx.Trainer.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var res = ctx.Trainer.Find(id);
            if (res == null) return false;
            ctx.Trainer.Remove(res);
            ctx.SaveChanges();
            return true;
        }

        public List<Trainer> GetData()
        {
            var res = ctx.Trainer.ToList();
            return res;
        }

        public Trainer GetData(int id)
        {
            var res = ctx.Trainer.Find(id);
            return res;
        }

        public Trainer Update(int id, Trainer entity)
        {
            var res = ctx.Trainer.Find(id);
            if (res != null)
            {
                res.TrainerRowId = entity.TrainerRowId;
                res.TrainerId = entity.TrainerId;
                res.TrainerName = entity.TrainerName;
                res.Expertise = entity.Expertise;

                ctx.SaveChanges();
                return res;
            }
            return entity;
        }
    }
}