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

        [Authorize(Roles = "manager")]
        public ActionResult ListAllTasks()
        {
            ViewBag.Title = "All Tasks";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();

            var tasks = mapper.Map<List<TaskDTO>, List<TaskVM>>(orderService.GetTasks());
            return View(tasks);
        }

        [Authorize(Roles = "employee")]
        public ActionResult ListEmpTasks()
        {
            ViewBag.Title = "All Employee Tasks";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var dbTasks = orderService.GetTasks();
            List<TaskVM> tasks = new List<TaskVM>();
            int employeeId = Convert.ToInt32(Session["EmployeeId"]);

            foreach (TaskDTO task in dbTasks)
            {
                if (task.EmployeeId == employeeId)
                {
                    tasks.Add(mapper.Map<TaskDTO, TaskVM>(task));
                }
            }
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

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var model = mapper.Map<TaskDTO, TaskVM>(task);

            int completedSteps = 0;

            foreach (StepDTO step in model.Steps)
            {
                if (step.IsCompleted == true)
                {
                    completedSteps += 1;
                }
            }
            model.TaskPercentage = completedSteps * 100 / model.NumberOfSteps;
            if (model.TaskPercentage > 100)
                model.TaskPercentage = 100;

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
                    return RedirectToAction("ListAllTasks", "Task");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            TempData["Employees"] = new SelectList(orderService.GetEmployees().ToArray(), "EmployeeId", "FirstName", "1");
            return View();
        }

        [Authorize(Roles = "manager")]
        public ActionResult EditTask(int? taskId)
        {
            TaskDTO taskDTO = orderService.GetTasks().FirstOrDefault(taskID => taskID.TaskId == taskId);
            //taskDTO = orderService.GetTasksWithIncludedSteps(taskDTO);

            SelectList emp = new SelectList(orderService.GetEmployees(), "EmployeeId", "FirstName", 1);
            ViewBag.Employees = emp;
            SelectList cli = new SelectList(orderService.GetClients(), "ClientId", "CompanyName", 1);
            ViewBag.Clients = cli;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var model = mapper.Map<TaskDTO, TaskVM>(taskDTO);

            return View(model);
        }

        [Authorize(Roles = "manager")]
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
            return RedirectToAction("ListAllTasks", "Task");
        }

        [Authorize(Roles = "manager")]
        public ActionResult DeleteTask(int taskId)
        {
            var task = orderService.GetTasks().FirstOrDefault(taskID => taskID.TaskId == taskId);
            task = orderService.GetTaskWithIncludedSteps(task);

            TempData["Steps"] = new SelectList(task.Steps.ToArray(), "StepId", "Message", "1");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var taskVM = mapper.Map<TaskDTO, TaskVM>(task);
            return View(taskVM);
        }

        [Authorize(Roles = "manager")]
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
                ViewBag.Message = "The task has not been deleted successfully. Sorry.";
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

                    if (Session["Role"] != null)
                    {
                        if (Session["Role"].ToString() == "employee")
                        {
                            return RedirectToAction("ListEmpTasks", "Task");
                        }
                        else
                        {
                            return RedirectToAction("ListAllTasks", "Task");
                        }
                    }
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            return View();
        }


        [Authorize(Roles = "manager, employee")]
        public ActionResult EditStep(int? stepId)
        {
            StepDTO stepDTO = orderService.GetSteps().FirstOrDefault(stepID => stepID.StepId == stepId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StepDTO, StepVM>()).CreateMapper();
            var model = mapper.Map<StepDTO, StepVM>(stepDTO);

            return View(model);
        }

        [Authorize(Roles = "manager, employee")]
        [HttpPost]
        public ActionResult EditStep(StepVM stepVM)
        {
            var dbStep = orderService.GetSteps().FirstOrDefault(x => x.StepId == stepVM.StepId);
            dbStep.Message = stepVM.Message;
            dbStep.IsCompleted = stepVM.IsCompleted;
            dbStep.Comments = stepVM.Comments;

            orderService.EditStep(dbStep);

            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "employee")
                {
                    return RedirectToAction("ListEmpTasks", "Task");
                }
                else
                {
                    return RedirectToAction("ListAllTasks", "Task");
                }
            }
            else
            {
                ViewBag.Message = "The step has not been edited successfully. Sorry";
                ViewBag.Title = "Edition error.";
                return View("Error");
            }
        }


        [Authorize(Roles = "manager, employee")]
        public ActionResult DeleteStep(int stepId)
        {
            var step = orderService.GetSteps().FirstOrDefault(taskID => taskID.StepId == stepId);
            step = orderService.GetStepWithIncludedComments(step);

            TempData["Comments"] = new SelectList(step.Comments.ToArray(), "CommentId", "Message", "1");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StepDTO, StepVM>()).CreateMapper();
            var taskVM = mapper.Map<StepDTO, StepVM>(step);
            return View(taskVM);
        }

        [Authorize(Roles = "manager, employee")]
        [HttpPost]
        public ActionResult DeleteStep(StepVM step)
        {
            var stepDTO = orderService.GetSteps().FirstOrDefault(taskID => taskID.StepId == step.StepId);
            orderService.DeleteStep(stepDTO);

            if (Session["Role"] != null && orderService.GetSteps().Exists(x => x.StepId == step.StepId) == false)
            {
                if (Session["Role"].ToString() == "employee")
                {
                    return RedirectToAction("ListEmpTasks", "Task");
                }
                else
                {
                    return RedirectToAction("ListAllTasks", "Task");
                }
            }
            else
            {
                ViewBag.Message = "The step has not been deleted successfully. Sorry";
                ViewBag.Title = "Deletion error.";
                return View("Error");
            }
        }

        #endregion Steps


        #region Comments


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

        [Authorize(Roles = "manager, employee")]
        public ActionResult CreateComment(int stepId)
        {
            TempData["StepId"] = stepId;
            return View();
        }

        [Authorize(Roles = "manager, employee")]
        [HttpPost]
        public ActionResult CreateComment(CommentVM comment)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    int stepId = Convert.ToInt32(TempData["StepId"]);
                    if (stepId == 0 || stepId == null)  // null??
                    {
                        return HttpNotFound();
                    }

                    var commentDTO = new CommentDTO
                    {
                        StepId = comment.StepId,
                        Message = comment.Message,
                    };
                    orderService.AddComment(commentDTO);

                    if (Session["Role"] != null)
                    {
                        if (Session["Role"].ToString() == "employee")
                        {
                            return RedirectToAction("ListEmpTasks", "Task");
                        }
                        else
                        {
                            return RedirectToAction("ListAllTasks", "Task");
                        }
                    }
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            return View();
        }

        [Authorize(Roles = "manager, employee")]
        public ActionResult EditComment(int? commentId)
        {
            CommentDTO commentDTO = orderService.GetComments().FirstOrDefault(commentID => commentID.CommentId == commentId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentVM>()).CreateMapper();
            var model = mapper.Map<CommentDTO, CommentVM>(commentDTO);

            return View(model);
        }


        [Authorize(Roles = "manager, employee")]
        [HttpPost]
        public ActionResult EditComment(CommentVM commentVM)
        {
            var dbComment= orderService.GetComments().FirstOrDefault(x => x.CommentId == commentVM.CommentId);
            dbComment.Message = commentVM.Message;

            orderService.EditComment(dbComment);

            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "employee")
                {
                    return RedirectToAction("ListEmpTasks", "Task");
                }
                else
                {
                    return RedirectToAction("ListAllTasks", "Task");
                }
            }
            else
            {
                ViewBag.Message = "The step has not been edited successfully. Sorry";
                ViewBag.Title = "Edition error.";
                return View("Error");
            }
        }

        [Authorize(Roles = "manager, employee")]
        public ActionResult DeleteComment(int commentId)
        {
            var comment = orderService.GetComments().FirstOrDefault(taskID => taskID.CommentId == commentId);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentVM>()).CreateMapper();
            var commentVM = mapper.Map<CommentDTO, CommentVM>(comment);
            return View(commentVM);
        }

        [Authorize(Roles = "manager, employee")]
        [HttpPost]
        public ActionResult DeleteComment(CommentVM comment)
        {
            var commentDTO = orderService.GetComments().FirstOrDefault(commentID => commentID.CommentId == comment.CommentId);
            orderService.DeleteComment(commentDTO);

            if (Session["Role"] != null && orderService.GetComments().Exists(x => x.CommentId == comment.CommentId) == false)
            {
                if (Session["Role"].ToString() == "employee")
                {
                    return RedirectToAction("ListEmpTasks", "Task");
                }
                else
                {
                    return RedirectToAction("ListAllTasks", "Task");
                }
            }
            else
            {
                ViewBag.Message = "The comment has not been deleted successfully. Sorry";
                ViewBag.Title = "Deletion error.";
                return View("Error");
            }
        }

        #endregion Comments



        [Authorize(Roles = "manager")]
        public ActionResult SendEmail(int clientId, int managerId, int taskId)
        {
            try
            {
                ViewBag.Title = "Email Notification";
                ViewBag.Message = "The email notification has been successfully sent.";

                if (Convert.ToInt32(Session["ManagerId"]) == managerId)
                {
                    orderService.SendEmail(clientId, managerId, taskId);
                }
                return View();
            }
            catch
            {
                return View("Shared/Error");
            }
        }

        [Authorize(Roles = "client")]
        public ActionResult ReceiveEmail()
        {
            try
            {
                int clientId = Convert.ToInt32(Session["clientId"]);

                ViewBag.Title = "Client Finished Tasks";
                ViewBag.Message = "The email notification has been successfully sent.";

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientTaskDTO, ClientTaskVM>()).CreateMapper();
                var clientNotifications = mapper.Map<List<ClientTaskDTO>, List<ClientTaskVM>>(orderService.ReceiveEmails(clientId));
                
                return View(clientNotifications);
            }
            catch
            {
                return View("Shared/Error");
            }
        }
    }
}