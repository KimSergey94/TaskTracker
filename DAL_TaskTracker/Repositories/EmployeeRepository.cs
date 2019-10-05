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
    public class EmployeeRepository : IRepository<Employee>
    {
        private TaskTrackerContext db;
        public EmployeeRepository(TaskTrackerContext context)
        {
            this.db = context;
        }
        public void Create(Employee item)
        {
            db.Employees.Add(item);
        }

        public void Delete(int id)
        {
            Employee item = db.Employees.Find(id);
            if (item != null)
                db.Employees.Remove(item);
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            return db.Employees.Where(predicate).ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees;
        }

        public void Update(Employee item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}