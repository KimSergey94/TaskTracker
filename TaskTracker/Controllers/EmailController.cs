using BLL_TaskTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskTracker.Controllers
{
    public class EmailController : Controller
    {
        IOrderService orderService;

        public EmailController(IOrderService serv) { orderService = serv; }
        public EmailController() { }


        [Authorize(Roles = "manager")]
        public ActionResult SendEmail(int clientId, int taskId, int managerId)
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
                return RedirectToAction("Error", "Home");
            }
        }

    }
}