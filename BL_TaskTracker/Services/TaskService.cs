using AutoMapper;
using BL_TaskTracker.Interfaces;
using BLL_TaskTracker.DTO;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = DAL_TaskTracker.Entities.Task;

namespace BL_TaskTracker.Services
{
    public class TaskService : ITaskService
    {
        IUnitOfWork database { get; set; }
        public TaskService(IUnitOfWork uow)
        {
            database = uow;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(database.Users.GetAll());
        }

        public IEnumerable<Task> GetTasks()
        {
            var allTasks = database.Tasks.GetAll();
            var tasks = AutoMapper.Mapper.Map<List<Task>, List<TaskDTO>>(allTasks);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>()).CreateMapper();
            return mapper.Map<List<Task>, List<TaskDTO>>(database.Tasks.GetAll());
        }


        public IEnumerable<Status> GetStatusReports()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Status, StatusDTO>())..CreateMapper();
            return mapper.Map<IEnumerable<Status>, IEnumerable<StatusDTO>>(database.StatusReports.GetAll());
        }

        public IEnumerable<Comment> GetComments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(database.Comments.GetAll());
        }

        

        public IEnumerable<UserDTO> GetManagers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(database.Users.GetAll());
        }

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(database.Employees.GetAll());
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Client>, List<ClientDTO>>(database.Clients.GetAll());
        }

        public IEnumerable<AdminDTO> GetAdmins()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Admin>, List<AdminDTO>>(database.Admins.GetAll());
        }
       

        public void CreateTask(TaskDTO taskDTO)
        {
            TaskDTO task = new TaskDTO
            {
                IsCompleted = false,
                ManagerId = 666,
                StatusReports = new List<StatusDTO>
                {
                    StatusDTO = new StatusDTO
                    {
                        IsCompleted = false,
                        Message = string.Format("The task has been successfully created by {0}.", "managerID")
                    }
                }
            }
            StatusReports
            
            database.Tasks.Create(taskDTO);
            database.Save();

        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
