﻿using AutoMapper;
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


        [Authorize(Roles = "admin")]
        public ActionResult ListAllAdmins()
        {
            ViewBag.Title = "All Admins";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AdminDTO, AdminVM>()).CreateMapper();

            var admins = mapper.Map<List<AdminDTO>, List<AdminVM>>(orderService.GetAdmins());
            return View(admins);
        }

        [Authorize(Roles = "admin, manager")]
        public ActionResult ListAllClients()
        {
            ViewBag.Title = "All Clients";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ClientDTO, ClientVM>()).CreateMapper();
            var clients = mapper.Map<List<ClientDTO>, List<ClientVM>>(orderService.GetClients());
            return View(clients);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ListAllManagers()
        {
            ViewBag.Title = "All Managers";
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeVM>()).CreateMapper();
            var managers = orderService.GetAllManagers();
            List<EmployeeVM> result = new List<EmployeeVM>();

            foreach (EmployeeDTO manager in managers)
            {
                result.Add(mapper.Map<EmployeeDTO, EmployeeVM>(managers.Find(x => x.EmployeeId == manager.EmployeeId)));
            }
           
            return View(result);
        }

        [Authorize(Roles = "admin, manager")]
        public ActionResult ListAllEmployees()
        {
            ViewBag.Title = "All Employees";

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeVM>()).CreateMapper();

            var clients = mapper.Map<List<EmployeeDTO>, List<EmployeeVM>>(orderService.GetEmployees());
            return View(clients);
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Please, feel free to call and send us emails ";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }



        protected override void Dispose(bool diposing)
        {
            orderService.Dispose();
            base.Dispose(diposing);

        }
    }

}