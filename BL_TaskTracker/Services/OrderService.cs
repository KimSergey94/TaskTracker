using AutoMapper;
using BL_TaskTracker.DTO;
using BL_TaskTracker.Interfaces;
using BLL_TaskTracker.DTO;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Task = DAL_TaskTracker.Entities.Task;

namespace BL_TaskTracker.Services
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
            //var tasks = AutoMapper.Mapper.Map<List<Task>, List<TaskDTO>>();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>()
            .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
            .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
            .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
            ).CreateMapper();

            return mapper.Map<List<Task>, List<TaskDTO>>(allTasks);
        }


        public List<StatusDTO> GetStatusReports()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Status, StatusDTO>()).CreateMapper();
            return mapper.Map<List<Status>, List<StatusDTO>>(database.StatusReports.GetAll());
        }

        public List<CommentDTO> GetComments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()
            .ForMember(dest => dest.CommentId, opt => opt.MapFrom(src => src.CommentId))
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
            ).CreateMapper();
            return mapper.Map<List<Comment>, List<CommentDTO>>(database.Comments.GetAll());
        }



        public List<ManagerDTO> GetManagers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            RoleDTO userRole = mapper.Map<Role, RoleDTO>(database.Roles.Get(roleId));

            return userRole.Name;
        }


        public void AddTask(TaskDTO taskDTO)
        {
            Task task = new Task
            {
                ManagerId = taskDTO.ManagerId,
                TaskDefinition = taskDTO.TaskDefinition,
                IsCompleted = taskDTO.IsCompleted
            };
            database.Tasks.Create(task);
            database.Save();
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

        public void CreateTask(TaskDTO taskDTO)
        {
            Manager manager = database.Managers.Get(taskDTO.ManagerId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, Task>()
            .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
            .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
            .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
            ).CreateMapper();


            Task task = mapper.Map<TaskDTO, Task>(taskDTO);// new Task
            
            database.Tasks.Create(task); ;
            database.Save();

        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
