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
            return mapper.Map<IEnumerable<Manager>, List<ManagerDTO>>(database.Managers.GetAll());
        }

        public List<EmployeeDTO> GetEmployees()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(database.Employees.GetAll());
        }

        public List<ClientDTO> GetClients()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Client>, List<ClientDTO>>(database.Clients.GetAll());
        }

        public List<AdminDTO> GetAdmins()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Admin, AdminDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Admin>, List<AdminDTO>>(database.Admins.GetAll());
        }


        public void CreateTask(TaskDTO taskDTO)
        {
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
