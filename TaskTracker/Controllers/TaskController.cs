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


        #region Tasks

        //[Authorize(Roles = "admin")]
        public ActionResult ListAllTasks()
        {
            ViewBag.Title = "All Tasks";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();

            var tasks = mapper.Map<List<TaskDTO>, List<TaskVM>>(orderService.GetTasks());
            return View(tasks);
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
            task.Steps = orderService.GetSteps().Where(id => id.TaskId == taskId).ToList();
            ///////////
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var model = mapper.Map<TaskDTO, TaskVM>(task);

            return View(model);
        }

        [Authorize(Roles = "manager")]
        public ActionResult CreateTask()
        {
            TempData["Employees"] = new SelectList(orderService.GetEmployees().ToArray(), "EmployeeId", "FirstName", "1");
            TempData["Clients"] = new SelectList(orderService.GetClients().ToArray(), "ClientId", "CompanyName", "1");
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
                        ClientId = task.ClientId,
                        ManagerId = managerId,
                        TaskDefinition = task.TaskDefinition,
                        EmployeeId = task.EmployeeId,
                        NumberOfSteps = task.NumberOfSteps

                    };
                    orderService.AddTask(taskDTO);
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

        public ActionResult EditTask(int? taskId)
        {
            TaskDTO taskDTO = orderService.GetTasks().FirstOrDefault(taskID => taskID.TaskId == taskId);
            //taskDTO = orderService.GetTasksWithIncludedSteps(taskDTO);

            SelectList emp = new SelectList(orderService.GetEmployees(), "EmployeeId", "FirstName", 1);
            ViewBag.Employees = emp;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var model = mapper.Map<TaskDTO, TaskVM>(taskDTO);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditTask(TaskVM taskVM)
        {
            var dbTask = orderService.GetTasks().FirstOrDefault(x => x.TaskId == taskVM.TaskId);
            dbTask.ClientId = taskVM.ClientId;
            dbTask.ManagerId = taskVM.ManagerId;
            dbTask.EmployeeId = taskVM.EmployeeId;
            dbTask.IsCompleted = taskVM.IsCompleted;
            dbTask.NumberOfSteps = taskVM.NumberOfSteps;
            dbTask.TaskDefinition = taskVM.TaskDefinition;
            dbTask.Steps = taskVM.Steps;

            orderService.EditTask(dbTask);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteTask(int taskId)
        {
            var task = orderService.GetTasks().FirstOrDefault(taskID => taskID.TaskId == taskId);
            task = orderService.GetTaskWithIncludedSteps(task);

            TempData["Steps"] = new SelectList(task.Steps.ToArray(), "StepId", "Message", "1");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var taskVM = mapper.Map<TaskDTO, TaskVM>(task);
            return View(taskVM);
        }
        [HttpPost]
        public ActionResult DeleteTask(TaskVM task)
        {
            var taskDTO = orderService.GetTasks().FirstOrDefault(taskID => taskID.TaskId == task.TaskId);
            orderService.DeleteTask(taskDTO);

            if (orderService.GetTasks().Exists(x => x.TaskId == task.TaskId) == false)
            {
                return RedirectToAction("ListAllTasks", "Task");
            }
            else
            {
                ViewBag.Message = "The task has not been deleted successfully.";
                ViewBag.Title = "Deletion error.";
                return View("Error");
            }
        }

        #endregion Tasks


        #region Steps


        [Authorize(Roles = "manager, employee")]
        public ActionResult StepDetails(int stepId)
        {
            if (stepId == null)
            {
                return HttpNotFound();
            }

            StepDTO step = orderService.GetSteps().FirstOrDefault(t => t.StepId == stepId);
            if (step == null)
            {
                return HttpNotFound();
            }
            step.Comments = orderService.GetComments().Where(id => id.StepId == stepId).ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StepDTO, StepVM>()
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(st => st.Comments))
            ).CreateMapper();
            var model = mapper.Map<StepDTO, StepVM>(step);

            return View(model);
        }

        [Authorize(Roles = "manager, employee")]
        public ActionResult CreateStep(int taskId)
        {
            TempData["TaskId"] = taskId;
            return View();
        }

        [Authorize(Roles = "manager, employee")]
        [HttpPost]
        public ActionResult CreateStep(StepVM step)
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
                    var stepDTO = new StepDTO
                    {
                        IsCompleted = step.IsCompleted,
                        TaskId = step.TaskId,
                        Message = step.Message,
                    };
                    orderService.AddStep(stepDTO);
                    return RedirectToAction("Index", "Home");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            return View();
        }

        public ActionResult EditStep(int? stepId)
        {
            StepDTO stepDTO = orderService.GetSteps().FirstOrDefault(stepID => stepID.StepId == stepId);
            //taskDTO = orderService.GetTasksWithIncludedSteps(taskDTO);

            SelectList cmnts = new SelectList(orderService.GetEmployees(), "EmployeeId", "FirstName", 1);
            ViewBag.Comments = cmnts;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StepDTO, StepVM>()).CreateMapper();
            var model = mapper.Map<StepDTO, StepVM>(stepDTO);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditStep(StepVM stepVM)
        {
            var dbStep = orderService.GetSteps().FirstOrDefault(x => x.StepId == stepVM.StepId);
            dbStep.Message = stepVM.Message;
            dbStep.IsCompleted = stepVM.IsCompleted;
            dbStep.Comments = stepVM.Comments;

            orderService.EditStep(dbStep);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteStep(int stepId)
        {
            var step = orderService.GetSteps().FirstOrDefault(taskID => taskID.TaskId == stepId);
            step = orderService.GetStepWithIncludedComments(step);

            TempData["Comments"] = new SelectList(step.Comments.ToArray(), "CommentId", "Message", "1");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StepDTO, StepVM>()).CreateMapper();
            var taskVM = mapper.Map<StepDTO, StepVM>(step);
            return View(taskVM);
        }
        [HttpPost]
        public ActionResult DeleteStep(TaskVM task)
        {
            var taskDTO = orderService.GetTasks().FirstOrDefault(taskID => taskID.TaskId == task.TaskId);
            orderService.DeleteTask(taskDTO);

            if (orderService.GetTasks().Exists(x => x.TaskId == task.TaskId) == false)
            {
                return RedirectToAction("ListAllTasks", "Task");
            }
            else
            {
                ViewBag.Message = "The task has not been deleted successfully.";
                ViewBag.Title = "Deletion error.";
                return View("Error");
            }
        }

        #endregion Steps



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




        
    }
}