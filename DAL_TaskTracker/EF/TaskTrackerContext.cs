using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Models;

namespace DAL_TaskTracker.EF
{
    public class TaskTrackerContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        static TaskTrackerContext()
        {
            Database.SetInitializer<TaskTrackerContext>(new StoreDbInitializer());
        }
        public TaskTrackerContext(string connectionString) : base(connectionString)
        { }
    }


    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<TaskTrackerContext>
    {
        protected override void Seed(TaskTrackerContext db)
        {
            db.Goods.Add(new Good { Name = "Nokia Lumia", Company = "Nokia", Price = 72000 }); db.Goods.Add(new Good { Name = "iPhone", Company = "Apple", Price = 220000 }); db.Goods.Add(new Good { Name = "LG G", Company = "lG", Price = 100000 }); db.Goods.Add(new Good { Name = "Samsung Galaxy", Company = "Samsung", Price = 80000 });
            db.Roles.Add(new Role { Name = "admin", Id = 1 }); db.Roles.Add(new Role { Name = "user", Id = 2 });
            db.Users.Add(new User { Name = "admin", Login = "admin", Password = "1", RoleId = 1, Id = 1 }); db.Users.Add(new User { Name = " user1", Login = "user1", Password = "1", RoleId = 2, Id = 2 });
            db.Orders.Add(new Order { Id = 1, Name = "Nokia Lumia", Price = 72000 Sum = 72000, Date = new DateTime(2019, 01, 01), UserId = 2 });
            db.SaveChanges();



            db.Clients.Add(new Client { CompanyName = "Google Inc.", Email = "google@google.com" });
            db.Clients.Add(new Client { CompanyName = "Test", Email = "google@google.com" });
            db.Clients.Add(new Client { CompanyName = "Accenture", Email = "techsupport@accenture.com" });

            db.Employees.Add(new Employee { FirstName = "Edward", LastName = "Johnson", Position = ".NET Developer", Salary = 60000 });
            db.Employees.Add(new Employee { FirstName = "Bill", LastName = "White", Position = "C# Developer", Salary = 55000 });
            db.Employees.Add(new Employee { FirstName = "Alex", LastName = "Ferguson", Position = "Project Manager", Salary = 75000 });
            db.Employees.Add(new Employee { FirstName = "Daniel", LastName = "Washington", Position = "Tester", Salary = 60000 });
            db.Employees.Add(new Employee { FirstName = "Eashaan", LastName = "Watermenon", Position = "Java Developer", Salary = 66000 });
            db.Employees.Add(new Employee { FirstName = "Kate", LastName = "McConnor", Position = "Android Developer", Salary = 60000 });
            db.Employees.Add(new Employee { FirstName = "Marshal", LastName = "Houston", Position = "JavaScript Developer", Salary = 60000 });

            db.Managers.Add(new Manager { employee = db.Employees.Where(emp => emp.FirstName == "Alex" && emp.LastName == "Ferguson").FirstOrDefault() });

            db.Tasks.Add(new Task
            {
                Steps = new Dictionary<string, bool> { true, true, true, true, false, false },
                Comments = new string[]
                                { "Step 1) Manager (1, Alex): The task has been successfully assigned to (5, Eshaan)",
                                        "Step 2) Java Developer (5, Eashaan): The task has been successfully received",
                                    "Step 3) Java Developer (5, Eashaan): The task has been successfully completed (Waiting for approval)",
                                    "Step 4) Java Developer (5, Eashaan): The task has been successfully completed (Waiting for approval)",
                                    "Step 4) Java Developer (5, Eashaan): The task has been successfully completed (Waiting for approval)",
                                    "Step 3) Java Developer (5, Eashaan): The task has been successfully completed (Waiting for approval)",
                                }
            });
        }
    }
}
