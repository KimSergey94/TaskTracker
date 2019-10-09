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
    public class CommentRepository : IRepository<Comment>
    {
        private TaskTrackerContext db;
        public CommentRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Comment item)
        {
            db.Comments.Add(item);
        }

        public void Delete(int id)
        {
            Comment item = db.Comments.Find(id);
            if (item != null)
                db.Comments.Remove(item);
        }

        public List<Comment> Find(Func<Comment, bool> predicate)
        {
            return db.Comments.Where(predicate).ToList();
        }

        public Comment Get(int id)
        {
            return db.Comments.Find(id);
        }

        public List<Comment> GetAll()
        {
            return db.Comments.ToList();
        }

        public void Update(Comment item)
        {
            db.Entry(item).State = EntityState.Modified;
        }


    }
}