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
    public class RoleRepository : IRepository<Role>
    {
        private TaskTrackerContext db;
        public RoleRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Role item)
        {
            db.Roles.Add(item);
        }

        public void Delete(int id)
        {
            Role item = db.Roles.Find(id);
            if (item != null)
                db.Roles.Remove(item);
        }

        public List<Role> Find(Func<Role, bool> predicate)
        {
            return db.Roles.Where(predicate).ToList();
        }

        public Role Get(int id)
        {
            return db.Roles.Find(id);
        }

        public List<Role> GetAll()
        {
            return db.Roles.ToList();
        }

        public void Update(Role item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}