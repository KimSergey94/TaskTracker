using DAL_TaskTracker.EF;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DAL_TaskTracker.Repositories
{
    public class AdminRepository : IRepository<Admin>
    {
        private TaskTrackerContext db;
        public AdminRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Admin item)
        {
            db.Admins.Add(item);
        }

        public void Delete(int id)
        {
            Admin item = db.Admins.Find(id);
            if (item != null)
                db.Admins.Remove(item);
        }

        public IEnumerable<Admin> Find(Func<Admin, bool> predicate)
        {
            return db.Admins.Where(predicate).ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public IEnumerable<Admin> GetAll()
        {
            return db.Admins;
        }

        public void Update(Admin item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}