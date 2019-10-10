using DAL_TaskTracker.EF;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TaskTracker.Repositories
{
    public class StepRepository : IRepository<Step>
    {
        private TaskTrackerContext db;
        public StepRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Step item)
        {
            db.Statuses.Add(item);
        }

        public void Delete(int id)
        {
            Step item = db.Statuses.Find(id);
            if (item != null)
                db.Statuses.Remove(item);
        }

        public List<Step> Find(Func<Step, bool> predicate)
        {
            return db.Statuses.Where(predicate).ToList();
        }

        public Step Get(int id)
        {
            return db.Statuses.Find(id);
        }

        public List<Step> GetAll()
        {
            return db.Statuses.ToList();
        }

        public void Update(Step item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}