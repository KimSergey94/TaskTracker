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
    public class EmailRepository : IRepository<Email>
    {
        private TaskTrackerContext db;
        public EmailRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Email item)
        {
            db.Emails.Add(item);
        }

        public void Delete(int id)
        {
            Email item = db.Emails.Find(id);
            if (item != null)
                db.Emails.Remove(item);

            db.SaveChanges();
        }

        public List<Email> Find(Func<Email, bool> predicate)
        {
            return db.Emails.Where(predicate).ToList();
        }

        public Email Get(int id)
        {
            return db.Emails.Find(id);
        }

        public List<Email> GetAll()
        {
            return db.Emails.ToList();
        }

        public void Update(Email item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}