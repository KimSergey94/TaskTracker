using DAL_TaskTracker.EF;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL_TaskTracker.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        private TaskTrackerContext db;
        public TaskRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Task item)
        {
            db.Tasks.Add(item);
        }

        public void Delete(int id)
        {
            Task item = db.Tasks.Find(id);
            if (item != null)
                db.Tasks.Remove(item);
        }

        public IEnumerable<Task> Find(Func<Task, bool> predicate)
        {
            return db.Tasks.Where(predicate).ToList();
        }

        public Task Get(int id)
        {
            return db.Tasks.Find(id);
        }

        public IEnumerable<Task> GetAll()
        {
            return db.Tasks;
        }

        public void Update(Task item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}