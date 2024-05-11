using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MundrisoftAssignment.Models;
using MundrisoftAssignment.Services;

namespace MundrisoftAssignment.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Users user)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    int res = _userService.RegisterUser(user);
                    if (res == 1)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            try
            {

                Users signinuser = _userService.Authenticate(user);
                if (signinuser != null)
                {
                    HttpContext.Session.SetString("userid", signinuser.UserId.ToString());
                    HttpContext.Session.SetString("email", signinuser.Email);
                    HttpContext.Session.SetString("roleid", signinuser.RoleId.ToString());
                    if (signinuser.RoleId == Convert.ToInt32(Role.Admin))
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Invalid Email Id or Password";
                }

            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(Users user)
        {
            try
            {

                string userid = HttpContext.Session.GetString("userid");
                user.UserId = Convert.ToInt32(userid);
                int result = _userService.UpdatePassword(user);
                if (result == 1)
                {
                    ViewBag.SuccessMessage = "Password Updated Successfully !";
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong!";
                }


            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Something went wrong!";
                return View();
            }
            return View();
        }

    }
}
