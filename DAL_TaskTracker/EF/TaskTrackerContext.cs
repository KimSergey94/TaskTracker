using DAL_TaskTracker.Entities;
using System.Data.Entity;
using System.Linq;
using Task = DAL_TaskTracker.Entities.Task;

namespace DAL_TaskTracker.EF
{
    public class TaskTrackerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Email> Emails { get; set; }

        public static void Initialize()
        {
            Database.SetInitializer(new TaskTrackerDbInitializer());
        }

        static TaskTrackerContext()
        {
            Database.SetInitializer(new TaskTrackerDbInitializer());
        }
        public TaskTrackerContext(string connectionString) : base(connectionString)
        { }
    }


    public class TaskTrackerDbInitializer : DropCreateDatabaseIfModelChanges<TaskTrackerContext>
    {
        protected override void Seed(TaskTrackerContext db)
        {
            db.Roles.Add(new Role { Name = "admin" });
            db.Roles.Add(new Role { Name = "manager" });
            db.Roles.Add(new Role { Name = "employee" });
            db.Roles.Add(new Role { Name = "client" });

            db.Users.Add(new User { Email = "admin@ad.min", Password = "admin@ad.min", RoleId = 1 });
            db.Admins.Add(new Admin { UserId = 1 });

            db.Users.Add(new User { RoleId = 4, Email = "google@client.com", Password = "test" });
            db.Users.Add(new User { RoleId = 4, Email = "accenture@client.com", Password = "test" });

            db.Clients.Add(new Client { CompanyName = "Google Inc.", Country = "USA", Address = "666 Central Avenue", UserId = 2 });
            db.Clients.Add(new Client { CompanyName = "Accenture", Country = "USA", Address = "8th Mile", UserId = 3 });

            db.Managers.Add(new Manager { EmployeeId = 1 });
            db.Users.Add(new User { RoleId = 2, Email = "edward@manager.com", Password = "test" });

            db.Managers.Add(new Manager { EmployeeId = 2 });
            db.Users.Add(new User { RoleId = 2, Email = "bill@manager.com", Password = "test" });
            db.Users.Add(new User { RoleId = 2, Email = "eashaan@employee.com", Password = "test" });

            db.Employees.Add(new Employee { FirstName = "Edward", LastName = "Johnson", Country = "USA", Position = ".NET Developer", Salary = 60000, UserId = 4 });
            db.Employees.Add(new Employee { FirstName = "Bill", LastName = "White", Country = "USA", Position = "C# Developer", Salary = 55000, UserId = 5 });
            db.Employees.Add(new Employee { FirstName = "Eashaan", LastName = "Watermenon", Country = "India", Position = "Java Developer", Salary = 66000, UserId = 6 });

            db.Comments.Add(new Comment { Message = "The task has been assigned", StepId = 1 });
            db.Comments.Add(new Comment { Message = "The employee has received the task", StepId = 1 });
            db.Comments.Add(new Comment { Message = "The employee is working on the task", StepId = 2 });

            db.Steps.Add(new Step { Message = "Assigning the tasks", IsCompleted = true, TaskId = 1 });
            db.Steps.Add(new Step { Message = "The task is in progress", IsCompleted = false, TaskId = 1 });

            db.Tasks.Add(new Task { IsCompleted = false, EmployeeId = 3, ManagerId = 1, NumberOfSteps = 6, TaskDefinition = "Create Web App" });

            db.SaveChanges();

        }
    }
}
