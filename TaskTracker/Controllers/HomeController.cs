using AutoMapper;
using BLL_TaskTracker.DTO;
using BLL_TaskTracker.Interfaces;
using DAL_TaskTracker.Entities;
using DAL_TaskTracker.Repositories.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;

       
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Index page";

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
        public ActionResult ListAllUsers()
        {
            ViewBag.Title = "All Users";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserVM>()).CreateMapper();

            var users = mapper.Map<List<UserDTO>, List<UserVM>>(orderService.GetUsers());
            return View(users);
        }
        public ActionResult ListAllAdmins()
        {
            ViewBag.Title = "All Admins";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AdminDTO, AdminVM>()).CreateMapper();

            var admins = mapper.Map<List<AdminDTO>, List<AdminVM>>(orderService.GetAdmins());
            return View(admins);
        }
        public ActionResult ListAllClients()
        {
            ViewBag.Title = "All Clients";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientVM>()).CreateMapper();

            var clients = mapper.Map<List<ClientDTO>, List<ClientVM>>(orderService.GetClients());
            return View(clients);
        }

        public ActionResult ListAllManagers()
        {
            ViewBag.Title = "All Managers";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ManagerDTO, ManagerVM>()).CreateMapper();

            var clients = mapper.Map<List<ManagerDTO>, List<ManagerVM>>(orderService.GetManagers());
            return View(clients);
        }

        public ActionResult ListAllEmployees()
        {
            ViewBag.Title = "All Employees";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeVM>()).CreateMapper();

            var clients = mapper.Map<List<EmployeeDTO>, List<EmployeeVM>>(orderService.GetEmployees());
            return View(clients);
        }


        protected override void Dispose(bool diposing)
        {
            orderService.Dispose();
            base.Dispose(diposing);

        }
    }

}