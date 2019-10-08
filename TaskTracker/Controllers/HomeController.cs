using AutoMapper;
using BL_TaskTracker.Interfaces;
using BLL_TaskTracker.DTO;
using BL_TaskTracker.Infrastructure;

using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TaskTracker.Models;
using ValidationException = BL_TaskTracker.Infrastructure.ValidationException;

namespace TaskTracker.Controllers
{
    public class HomeController : Controller
    {
        IOrderService taskService;

       
        public HomeController(IOrderService serv)
        {
            taskService = serv;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Index page";

            return View();
        }


        public ActionResult RegisterAdmin()
        {
            ViewBag.Title = "Index page";

            return View();
        }


        //[Authorize(Roles = "admin")]
        public ActionResult ListAllTasks()
        {
            ViewBag.Title = "All Tasks";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()
            //.ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
            //.ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
            //.ForMember(dest => dest.TaskDefinition, opt => opt.MapFrom(src => src.TaskDefinition))
            //.ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
            ).CreateMapper();

            var tasks = mapper.Map<List<TaskDTO>, List<TaskVM>>(taskService.GetTasks());
            return View(tasks);
        }
        public ActionResult ListAllUsers()
        {
            ViewBag.Title = "All Users";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()
            //.ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
            //.ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.ManagerId))
            //.ForMember(dest => dest.TaskDefinition, opt => opt.MapFrom(src => src.TaskDefinition))
            //.ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId))
            ).CreateMapper();

            var tasks = mapper.Map<List<UserDTO>, List<UserVM>>(taskService.GetUsers());
            return View(tasks);
        }
        


        [Authorize]
        public ActionResult CreateTask(int managerId)
        {
            ViewBag.ManagerId = managerId;

            try
            {
                TaskVM newTask = new TaskVM
                {
                    ManagerId = managerId
                };
                return View(newTask);
            }
            catch (BL_TaskTracker.Infrastructure.ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]

        public ActionResult CreateTask(TaskVM task)
        {
            try
            {
                var taskDTO = new TaskDTO
                {
                    TaskId = 2,
                    IsCompleted = false,
                    ManagerId = task.ManagerId,
                    TaskDefinition = task.TaskDefinition
                };
                taskService.CreateTask(taskDTO);
                return View("Confirm");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(task);
        }


        protected override void Dispose(bool diposing)
        {
            taskService.Dispose();
            base.Dispose(diposing);

        }
    }

}