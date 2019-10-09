using BLL_TaskTracker.DTO;
using BLL_TaskTracker.Interfaces;
using BLL_TaskTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskTracker.Models;
using AutoMapper;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.EF;

namespace TaskTracker.Controllers
{
    public class TaskController : Controller
    {
        IOrderService orderService;

        public TaskController(IOrderService serv) { orderService = serv; }
        public TaskController() { }


        // GET: Task
        public ActionResult Index()
        {
            return View();
        }


        //[Authorize(Roles = "admin")]
        public ActionResult ListAllTasks()
        {
            ViewBag.Title = "All Tasks";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();

            var tasks = mapper.Map<List<TaskDTO>, List<TaskVM>>(orderService.GetTasks());
            return View(tasks);
        }

        [Authorize(Roles = "manager, employee")]
        public ActionResult CreateStatus(int taskId)
        {
            TempData["TaskId"] = taskId;
            return View();
        }

        [Authorize(Roles = "manager, employee")]
        [HttpPost]
        public ActionResult CreateStatus(StatusVM status)
        {

            //if (Session["Role"].ToString() == "manager")
            //{
            //    Session["ManagerId"] = orderService.GetManagers().Find(empId => empId.EmployeeId ==
            //                    (orderService.GetEmployees().Find(x => x.UserId == user.UserId).EmployeeId)).ManagerId;
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    int taskId = Convert.ToInt32(TempData["TaskId"]);
                    if (taskId == 0 || taskId == null)  // null??
                    {
                        return HttpNotFound();
                    }
                    var statusDTO = new StatusDTO
                    {
                        IsCompleted = status.IsCompleted,
                        TaskId = status.TaskId,
                        Message = status.Message,
                    };
                    orderService.CreateStatus(statusDTO);
                    return RedirectToAction("Index", "Home");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            //TempData["TaskId"] = taskId; status?
            return View();
        }

        [Authorize(Roles = "manager")]
        public ActionResult CreateTask()
        {
            TempData["Employees"] = new SelectList(orderService.GetEmployees().ToArray(), "EmployeeId", "FirstName", "1");
            return View();
        }

        [Authorize(Roles = "manager")]
        [HttpPost]
        public ActionResult CreateTask(TaskVM task)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int managerId = Convert.ToInt32(Session["ManagerId"]);
                    if (managerId == 0)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    var taskDTO = new TaskDTO
                    {
                        IsCompleted = task.IsCompleted,
                        ManagerId = managerId,
                        TaskDefinition = task.TaskDefinition,
                        EmployeeId = task.EmployeeId,
                        NumberOfSteps = task.NumberOfSteps

                    };
                    orderService.CreateTask(taskDTO);
                    return RedirectToAction("Index", "Home");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            TempData["Employees"] = new SelectList(orderService.GetEmployees().ToArray(), "EmployeeId", "FirstName", "1");
            return View();
        }

        public ActionResult EditTask(int taskId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var task = mapper.Map<TaskDTO, TaskVM>(orderService.GetTasks().FirstOrDefault(id => id.TaskId == taskId));
            return View();
        }

        public ActionResult DeleteTask(int taskId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var task = mapper.Map<TaskDTO, TaskVM>(orderService.GetTasks().FirstOrDefault(id => id.TaskId == taskId));
            return View();
        }

        [Authorize(Roles = "manager, employee")]
        public ActionResult TaskDetails(int taskId)
        {
            if (taskId == null)
            {
                return HttpNotFound();
            }

            TaskDTO task = orderService.GetTasks().FirstOrDefault(t => t.TaskId == taskId);
            if (task == null)
            {
                return HttpNotFound();
            }
            task.Statuses = orderService.GetStatuses().Where(id => id.TaskId == taskId).ToList();
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()
            .ForMember(dest => dest.Statuses, opt => opt.MapFrom(st => st.Statuses))
            ).CreateMapper();
            var model = mapper.Map<TaskDTO, TaskVM>(task);

            return View(model);
        }

        [Authorize(Roles = "manager, employee")]
        public ActionResult StatusDetails(int statusId)
        {
            if (statusId == null)
            {
                return HttpNotFound();
            }

            StatusDTO status = orderService.GetStatuses().FirstOrDefault(t => t.StatusId == statusId);
            if (status == null)
            {
                return HttpNotFound();
            }
            status.Comments = orderService.GetComments().Where(id => id.StatusId == statusId).ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StatusDTO, StatusVM>()
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(st => st.Comments))
            ).CreateMapper();
            var model = mapper.Map<StatusDTO, StatusVM>(status);

            return View(model);
        }


        [Authorize(Roles = "manager, employee")]
        public ActionResult CommentDetails(int commentId)
        {
            if (commentId == null)
            {
                return HttpNotFound();
            }

            CommentDTO comment = orderService.GetComments().FirstOrDefault(t => t.CommentId == commentId);
            if (comment == null)
            {
                return HttpNotFound();
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentVM>()).CreateMapper();
            var model = mapper.Map<CommentDTO, CommentVM>(comment);

            return View(model);
        }


        [HttpGet]
        public ActionResult EditTask(int? taskId)
        {
            TaskDTO task = orderService.GetTasks().FirstOrDefault(taskID => taskID.TaskId == taskId);
            task = orderService.GetTasksWithIncludedStatuses(task);

            //TempData["Employees"] =
            //if (emp != null)
            SelectList emp = new SelectList(orderService.GetEmployees(), "EmployeeId", "FirstName", 1);
            ViewBag.Employees = emp;//Statuses().Where(x => x.TaskId == task.TaskId);
            
            return View(task);
        
        }


        //[HttpPost]
        //public ActionResult EditEmp(TaskVM emp)
        //{
        //    db.Entry(emp).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}