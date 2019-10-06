using DAL_TaskTracker.EF;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DAL_TaskTracker.Repositories
{
    class ClientRepository : IRepository<Client>
    {
        private TaskTrackerContext db;
        public ClientRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Client item)
        {
            db.Clients.Add(item);
        }

        public void Delete(int id)
        {
            Client item = db.Clients.Find(id);
            if (item != null)
                db.Clients.Remove(item);
        }

        public List<Client> Find(Func<Client, bool> predicate)
        {
            return db.Clients.Where(predicate).ToList();
        }

        public Client Get(int id)
        {
            return db.Clients.Find(id);
        }

        public List<Client> GetAll()
        {
            return db.Clients.ToList();
        }

        public void Update(Client item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}