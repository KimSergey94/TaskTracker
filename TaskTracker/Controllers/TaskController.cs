using BLL_TaskTracker.DTO;
using BLL_TaskTracker.Interfaces;
using BLL_TaskTracker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TaskController : Controller
    {
        ITaskService taskService;
        IOrderService orderService;


        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "manager")]
        public ActionResult CreateTask()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateTask(TaskVM task)
        {
            try
            {
                int employeeId = orderService.GetEmployees().Where(id => id.UserId == Convert.ToInt32(Session["id"]))
                    .FirstOrDefault().EmployeeId;
                int managerId = orderService.GetManagers().Where(id => id.ManagerId == employeeId).FirstOrDefault().ManagerId;

                var taskDTO = new TaskDTO
                {
                    TaskId = 2,
                    IsCompleted = false,
                    ManagerId = managerId,
                    TaskDefinition = task.TaskDefinition
                };
                taskService.CreateTask(taskDTO);
                return View("Index", "Home");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(task);
        }

        public ActionResult EditTask()
        {
            return View();
        }

        public ActionResult DeleteTask()
        {
            return View();
        }
    }
}