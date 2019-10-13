﻿using DAL_TaskTracker.EF;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System;


namespace DAL_TaskTracker.Repositories
{
    public class EFUnitOfWork : IDisposable, IUnitOfWork
    {
        private TaskTrackerContext db;
        private UserRepository userRepository;
        private AdminRepository adminRepository;
        private ClientRepository clientRepository;
        private EmployeeRepository employeeRepository;
        private ManagerRepository managerRepository;
        private TaskRepository taskRepository;
        private StepRepository stepRepository;
        private CommentRepository commentRepository;
        private RoleRepository roleRepository;
        private EmailRepository emailRepository;


        public EFUnitOfWork()
        {
            db = new TaskTrackerContext("TaskTrackerContext");
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Admin> Admins
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepository(db);
                return adminRepository;
            }
        }


        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public IRepository<Manager> Managers
        {
            get
            {
                if (managerRepository == null)
                    managerRepository = new ManagerRepository(db);
                return managerRepository;
            }
        }


        public IRepository<Task> Tasks
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(db);
                return taskRepository;
            }
        }

        public IRepository<Step> Steps
        {
            get
            {
                if (stepRepository == null)
                    stepRepository = new StepRepository(db);
                return stepRepository;
            }
        }


        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IRepository<Email> Emails
        {
            get
            {
                if (emailRepository == null)
                    emailRepository = new EmailRepository(db);
                return emailRepository;
            }
        }
        

    }
}