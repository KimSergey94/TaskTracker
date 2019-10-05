using DAL_TaskTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = DAL_TaskTracker.Entities.Task;

namespace DAL_TaskTracker.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Admin> Admins { get; }
        IRepository<Client> Clients { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Manager> Managers { get; }
        IRepository<Task> Tasks { get; }
        IRepository<Status> StatusReports { get; }
        IRepository<Comment> Comments { get; }

        void Save();
    }
}
