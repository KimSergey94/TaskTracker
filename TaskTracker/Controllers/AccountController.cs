using AutoMapper;
using BL_TaskTracker.Interfaces;
using BLL_TaskTracker.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class AccountController : Controller
    {
        IOrderService orderService;
        public AccountController(IOrderService serv) { orderService = serv; }
        public ActionResult Login() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserVM model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                UserVM user = null;
                var users = GetUser();
                user = users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    Session["email"] = user.Email;
                    Session["Id"] = user.UserId;
                    FormsAuthentication.SetAuthCookie(model.Email, true); return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return View(model);
        }

        private List<UserVM> GetUser()
        {
            IEnumerable<UserDTO> userDtos = orderService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO,
            UserVM>()).CreateMapper();
            return mapper.Map<IEnumerable<UserDTO>, List<UserVM>>(userDtos);
        }


        public ActionResult RegisterAdmin()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterAdmin(AdminRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserVM user = null;
                var users = GetUser();
                user = users.FirstOrDefault(u => u.Email == model.Email &&
                        u.Password == model.Password);

                if (user == null)
                {
                    var userDTO = new UserDTO
                    {
                        Email = model.Email,
                        Password = model.Password
                    };
                    orderService.AddUser(userDTO);

                    users = GetUser();
                    user = users.Where(u => u.Email == model.Email &&
                                        u.Password == model.Password).FirstOrDefault();
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        Session["Email"] = user.Email;
                        Session["Id"] = user.UserId;
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }
            return View(model);
        }


        public ActionResult Logoff()
        {
            Session["Email"] = null;
            Session["Id"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }


    }
}
    
