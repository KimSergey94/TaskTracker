﻿using DAL_TaskTracker.EF;
using DAL_TaskTracker.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DAL_TaskTracker.Repositories.Interfaces
{
    public class UserRepository : IRepository<User>
    {
        private TaskTrackerContext db;
        public UserRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User item = db.Users.Find(id);
            if (item != null)
                db.Users.Remove(item);
        }

        public List<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}