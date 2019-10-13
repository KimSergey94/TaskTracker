using DAL_TaskTracker.Entities;
using System;

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
        IRepository<Step> Steps { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Role> Roles { get; }
        IRepository<Email> Emails { get; }

        void Save();
    }
}
