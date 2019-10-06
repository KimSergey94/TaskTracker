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
    public class StatusRepository : IRepository<Status>
    {
        private TaskTrackerContext db;
        public StatusRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Status item)
        {
            db.StatusReports.Add(item);
        }

        public void Delete(int id)
        {
            Status item = db.StatusReports.Find(id);
            if (item != null)
                db.StatusReports.Remove(item);
        }

        public List<Status> Find(Func<Status, bool> predicate)
        {
            return db.StatusReports.Where(predicate).ToList();
        }

        public Status Get(int id)
        {
            return db.StatusReports.Find(id);
        }

        public List<Status> GetAll()
        {
            return db.StatusReports.ToList();
        }

        public void Update(Status item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}