using DAL_TaskTracker.EF;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DAL_TaskTracker.Repositories
{
    public class ManagerRepository : IRepository<Manager>
    {
        private TaskTrackerContext db;
        public ManagerRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Manager item)
        {
            db.Managers.Add(item);
        }

        public void Delete(int id)
        {
            Manager item = db.Managers.Find(id);
            if (item != null)
                db.Managers.Remove(item);
        }

        public List<Manager> Find(Func<Manager, bool> predicate)
        {
            return db.Managers.Where(predicate).ToList();
        }

        public Manager Get(int id)
        {
            return db.Managers.Find(id);
        }

        public List<Manager> GetAll()
        {
            return db.Managers.ToList();
        }

        public void Update(Manager item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}