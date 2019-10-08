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
                var users = GetUsers();
                user = users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    Session["Email"] = user.Email;
                    Session["Id"] = user.UserId;
                    Session["Role"] = orderService.GetUserRoleName(user.RoleId);

                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return View(model);
        }

        private List<UserVM> GetUsers()
        {
            List<UserDTO> userDtos = orderService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO,
            UserVM>()).CreateMapper();
            return mapper.Map<List<UserDTO>, List<UserVM>>(userDtos);
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
                var users = GetUsers();
                user = users.FirstOrDefault(u => u.Email == model.Email &&
                        u.Password == model.Password);

                if (user == null)
                {
                    var userDTO = new UserDTO
                    {
                        Email = model.Email,
                        Password = model.Password,
                        RoleId = 1
                    };
                    orderService.AddUser(userDTO);

                    users = GetUsers();

                    AdminDTO admin = new AdminDTO { UserId = users.Where(email => email.Email == model.Email)
                        .Select(id => id.UserId).FirstOrDefault()};
                    orderService.AddAdmin(admin);

                    user = users.Where(u => u.Email == model.Email &&
                                        u.Password == model.Password).FirstOrDefault();
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        Session["Email"] = user.Email;
                        Session["Id"] = user.UserId;
                        Session["Role"] = orderService.GetUserRoleName(user.RoleId);
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


        public ActionResult RegisterManager()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterManager(ManagerRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserVM user = null;
                var users = GetUsers();
                user = users.FirstOrDefault(u => u.Email == model.Email &&
                        u.Password == model.Password);

                if (user == null)
                {
                    var userDTO = new UserDTO
                    {
                        Email = model.Email,
                        Password = model.Password,
                        RoleId = 2
                    };
                    orderService.AddUser(userDTO);

                    users = GetUsers();
                    user = users.Where(u => u.Email == model.Email &&
                                        u.Password == model.Password).FirstOrDefault();
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        EmployeeDTO employee = new EmployeeDTO
                        {
                            Country = model.Country,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Salary = model.Salary,
                            Position = model.Position,
                            UserId = users.Where(email => email.Email == model.Email)
                                        .Select(id => id.UserId).FirstOrDefault()
                        };
                        orderService.AddEmployee(employee);

                        employee = orderService.GetEmployees().Where(x => x.UserId == user.UserId).FirstOrDefault();

                        ManagerDTO manager = new ManagerDTO
                        {
                            EmployeeId = employee.EmployeeId
                        };
                        orderService.AddManager(manager);

                        Session["Email"] = user.Email;
                        Session["Id"] = user.UserId;
                        Session["Role"] = orderService.GetUserRoleName(user.RoleId);
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

        public ActionResult RegisterEmployee()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterEmployee(EmployeeRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserVM user = null;
                var users = GetUsers();
                user = users.FirstOrDefault(u => u.Email == model.Email &&
                        u.Password == model.Password);

                if (user == null)
                {
                    var userDTO = new UserDTO
                    {
                        Email = model.Email,
                        Password = model.Password,
                        RoleId = 3
                    };
                    orderService.AddUser(userDTO);

                    users = GetUsers();
                    user = users.Where(u => u.Email == model.Email &&
                                        u.Password == model.Password).FirstOrDefault();
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        EmployeeDTO employee = new EmployeeDTO
                        {
                            Country = model.Country,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Salary = model.Salary,
                            Position = model.Position,
                            UserId = users.Where(email => email.Email == model.Email)
                                        .Select(id => id.UserId).FirstOrDefault()
                        };
                        orderService.AddEmployee(employee);

                        Session["Email"] = user.Email;
                        Session["Id"] = user.UserId;
                        Session["Role"] = orderService.GetUserRoleName(user.RoleId);
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

        public ActionResult RegisterClient()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterClient(ClientRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserVM user = null;
                var users = GetUsers();
                user = users.FirstOrDefault(u => u.Email == model.Email &&
                        u.Password == model.Password);

                if (user == null)
                {
                    var userDTO = new UserDTO
                    {
                        Email = model.Email,
                        Password = model.Password,
                        RoleId = 3
                    };
                    orderService.AddUser(userDTO);

                    users = GetUsers();
                    user = users.Where(u => u.Email == model.Email &&
                                        u.Password == model.Password).FirstOrDefault();
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        ClientDTO client = new ClientDTO
                        {
                            Country = model.Country,
                            CompanyName = model.CompanyName,
                            Address = model.Address,
                            UserId = users.Where(email => email.Email == model.Email)
                                        .Select(id => id.UserId).FirstOrDefault()
                        };
                        orderService.AddClient(client);

                        Session["Email"] = user.Email;
                        Session["Id"] = user.UserId;
                        Session["Role"] = orderService.GetUserRoleName(user.RoleId);
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
            Session["Role"] = null;
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
    
