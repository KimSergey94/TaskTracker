using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class TaskTrackerContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public class StaffDbInitializer : DropCreateDatabaseAlways<TaskTrackerContext>
        {
            protected override void Seed(TaskTrackerContext db)
            {
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

                db.Tasks.Add(new Task { Steps = new Dictionary<string, bool>{ true, true, true, true, false, false}, Comments = new string[] 
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