using AutoMapper;
using BL_TaskTracker.Interfaces;
using BLL_TaskTracker.DTO;
using DAL_TaskTracker.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class HomeController : Controller
    {
        ITaskService taskService;

        public HomeController(ITaskService serv)
        {
            taskService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<TaskDTO> taskDTOs = taskService.GetTasks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Task, TaskDTO>()).CreateMapper();
            var goods = mapper.Map<IEnumerable<Task>, List<TaskDTO>>(taskDTOs);
            return View(goods);
        }
        public ActionResult ListUser()
        {
            IEnumerable<UserDTO> userDtos = taskService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserVM>>(userDtos);
            return View(users);
        }

        public ActionResult Purchase()
        {
            IEnumerable<TaskDTO> orderDtos = taskService.GetOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TaskDTO, TaskVM>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<TaskDTO>, List<TaskVM>>(orderDtos);
            return View(orders);
        }

        public ActionResult Buy(string name, int price)
        {
            try
            {
                TaskVM orderNew = new TaskVM
                {
                    Name = name,
                    Price = price
                };
                return View(orderNew);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]

        public ActionResult Buy(TaskVM order)
        {
            try
            {
                var orderDto = new TaskDTO
                {
                    UserId = 2,
                    Name = order.Name,
                    Price = order.Price
                };
                taskService.MakeOrder(orderDto);
                return View("Confirm");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }

        protected override void Dispose(bool diposing)
        {
            taskService.Dispose();
            base.Dispose(diposing);

        }
    }

}