using AutoMapper;
using BLL_TaskTracker.DTO;
using BLL_TaskTracker.Interfaces;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System.Collections.Generic;
using Task = DAL_TaskTracker.Entities.Task;

namespace BLL_TaskTracker.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork database { get; set; }
        public OrderService(IUnitOfWork uow)
        {
            database = uow;
        }

        


        public List<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<List<User>, List<UserDTO>>(database.Users.GetAll());
        }

        public List<TaskDTO> GetTasks()
        {
            var allTasks = database.Tasks.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>()
            .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
            .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
            .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
            ).CreateMapper();
            return mapper.Map<List<Task>, List<TaskDTO>>(allTasks);
        }

        public List<StepDTO> GetSteps()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Step, StepDTO>()).CreateMapper();
            return mapper.Map<List<Step>, List<StepDTO>>(database.Steps.GetAll());
        }

        public List<CommentDTO> GetComments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()
            .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId))
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
            .ForMember(dest => dest.StepId, opt => opt.MapFrom(src => src.StepId))
            ).CreateMapper();
            return mapper.Map<List<Comment>, List<CommentDTO>>(database.Comments.GetAll());
        }

        public List<ManagerDTO> GetManagers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Manager, ManagerDTO>()).CreateMapper();
            return mapper.Map<List<Manager>, List<ManagerDTO>>(database.Managers.GetAll());
        }

        public List<EmployeeDTO> GetEmployees()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<List<Employee>, List<EmployeeDTO>>(database.Employees.GetAll());
        }

        public List<ClientDTO> GetClients()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<List<Client>, List<ClientDTO>>(database.Clients.GetAll());
        }

        public List<AdminDTO> GetAdmins()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>()).CreateMapper();
            return mapper.Map<List<Admin>, List<AdminDTO>>(database.Admins.GetAll());
        }

        public List<RoleDTO> GetRoles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            return mapper.Map<List<Role>, List<RoleDTO>>(database.Roles.GetAll());
        }




        public string GetUserRoleName(int roleId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(t => t.RoleId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(t => t.Name))
            ).CreateMapper();
            RoleDTO userRole = mapper.Map<Role, RoleDTO>(database.Roles.Get(roleId));
            return userRole.Name;
        }

        public TaskDTO GetTaskWithIncludedSteps(TaskDTO task)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Step, StepDTO>()).CreateMapper();
            ICollection<Step> steps = database.Steps.GetAll().FindAll(x => x.TaskId == task.TaskId);
            var taskSteps = mapper.Map<ICollection<Step>, ICollection<StepDTO>>(steps);

            task.Steps = taskSteps;

            return task;
        }

        public StepDTO GetStepWithIncludedComments(StepDTO step)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            ICollection<Comment> comments = database.Comments.GetAll().FindAll(x => x.StepId == step.StepId);
            var stepComments = mapper.Map<ICollection<Comment>, ICollection<CommentDTO>>(comments);

            step.Comments = stepComments;

            return step;
        }
        


        public void AddTask(TaskDTO taskDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, Task>()).CreateMapper();

            Task task = mapper.Map<TaskDTO, Task>(taskDTO);

            database.Tasks.Create(task); ;
            database.Save();
        }

        public void EditTask(TaskDTO taskDTO)
        {
            var task = database.Tasks.Find(x => x.TaskId == taskDTO.TaskId).Find(x=> x.TaskId == taskDTO.TaskId);
            task.ManagerId = taskDTO.ManagerId;
            task.EmployeeId = taskDTO.EmployeeId;
            task.ClientId = taskDTO.ClientId;
            task.TaskDefinition = taskDTO.TaskDefinition;
            task.NumberOfSteps = taskDTO.NumberOfSteps;
            task.IsCompleted = taskDTO.IsCompleted;

            database.Tasks.Update(task);
        }

        public void DeleteTask(TaskDTO taskDTO)
        {
            database.Tasks.Delete(taskDTO.TaskId);
        }




        public void AddStep(StepDTO stepDTO)
        {
            Step status = new Step
            {
                TaskId = stepDTO.TaskId,
                Message = stepDTO.Message,
                IsCompleted = stepDTO.IsCompleted
            };
            database.Steps.Create(status);
            database.Save();
        }
        public void EditStep(StepDTO stepDTO)
        {
            var step = database.Steps.Find(x => x.StepId == stepDTO.StepId).Find(x => x.StepId == stepDTO.StepId);
            step.Message = stepDTO.Message;
            step.IsCompleted = stepDTO.IsCompleted;

            database.Steps.Update(step);   /// /ds /a/d as/d/ as/d
        }
        




        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee
            {
                Country = employeeDTO.Country,
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Position = employeeDTO.Position,
                Salary = employeeDTO.Salary,
                UserId = employeeDTO.UserId,
            };
            database.Employees.Create(employee);
            database.Save();
        }

        public void AddManager(ManagerDTO managerDTO)
        {
            Manager manager = new Manager
            {
                EmployeeId = managerDTO.EmployeeId
            };
            database.Managers.Create(manager);
            database.Save();
        }

        public void AddAdmin(AdminDTO adminDTO)
        {
            Admin admin = new Admin { UserId = adminDTO.UserId };//userId
            database.Admins.Create(admin);
            database.Save();
        }

        public void AddUser(UserDTO userDTO)
        {
            User user = new User
            {
                Email = userDTO.Email,
                Password = userDTO.Password,
                RoleId = userDTO.RoleId
            };
            database.Users.Create(user);
            database.Save();
        }

        public void AddClient(ClientDTO clientDTO)
        {
            Client client = new Client
            {
                Address = clientDTO.Address,
                CompanyName = clientDTO.CompanyName,
                Country = clientDTO.Country,
                UserId = clientDTO.UserId
            };
            database.Clients.Create(client);
            database.Save();
        }

        



        public void Dispose()
        {
            database.Dispose();
        }
    }
}
