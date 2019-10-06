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
        public DbSet<Status> StatusReports { get; set; }
        public DbSet<Comment> Comments { get; set; }



        //public DbSet<Role> Roles { get; set; }
        static TaskTrackerContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }
        public TaskTrackerContext(string connectionString) : base(connectionString)
        { }
    }


    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<TaskTrackerContext>
    {
        protected override void Seed(TaskTrackerContext db)
        {
            //db.Roles.Add(new Role { Name = "admin", Id = 1 }); db.Roles.Add(new Role { Name = "user", Id = 2 });

            db.Clients.Add(new Client { CompanyName = "Google Inc.", Email = "google@google.com", Country = "USA", Address = "666 Central Avenue" });
            db.Clients.Add(new Client { CompanyName = "Test", Email = "test@test.com", Country = "USA", Address = "5th Central Avenue" });
            db.Clients.Add(new Client { CompanyName = "Accenture", Email = "techsupport@accenture.com", Country = "USA", Address = "8th Mile" });

            db.Employees.Add(new Employee { FirstName = "Edward", LastName = "Johnson", Country = "USA", Position = ".NET Developer", Salary = 60000 });
            db.Employees.Add(new Employee { FirstName = "Bill", LastName = "White", Country = "USA", Position = "C# Developer", Salary = 55000 });
            db.Employees.Add(new Employee { FirstName = "Alex", LastName = "Ferguson", Country = "USA", Position = "Project Manager", Salary = 75000 });
            db.Employees.Add(new Employee { FirstName = "Daniel", LastName = "Washington", Country = "USA", Position = "Tester", Salary = 60000 });
            db.Employees.Add(new Employee { FirstName = "Eashaan", LastName = "Watermenon", Country = "India", Position = "Java Developer", Salary = 66000 });
            db.Employees.Add(new Employee { FirstName = "Kate", LastName = "McConnor", Country = "USA", Position = "Android Developer", Salary = 60000 });
            db.Employees.Add(new Employee { FirstName = "Marshal", LastName = "Houston", Country = "USA", Position = "JavaScript Developer", Salary = 60000 });

            db.Managers.Add(new Manager { EmployeeId= 2});
            //db.Managers.Add(new Manager { } );
            //db.Managers.Add(new Manager { } );

            db.Admins.Add(new Admin { Email = "admin@ad.min", Password = "admin"});

            db.Users.Add(new User { Email= "admin@ad.min", Password="admin@ad.min"});
            db.Users.Add(new User { Email = "google@google.com", Password = "google.com" });
            db.Users.Add(new User { Email = "test@test.com", Password = "test.com" });
            db.Users.Add(new User { Email = "techsupport@accenture.com", Password = "accenture.com" });

            db.Comments.Add( new Comment { Message = "The task has been assigned"});
            db.Comments.Add( new Comment { Message = "The employee has received the task" });

            db.StatusReports.Add(new Status { Title = "In progress", IsCompleted = false, Comments=db.Comments.Where(message => message.Message == "The task has been assigned").ToList()});
            db.StatusReports.Add(new Status { Title = "In progress", IsCompleted = false, Comments=db.Comments.Where(message => message.Message == "The employee has received the task").ToList()});

            db.Tasks.Add(new Task { IsCompleted = false, StatusReports = db.StatusReports.Where(title => title.Title == "In progress").ToList() });

            db.SaveChanges();

        }
    }
}
