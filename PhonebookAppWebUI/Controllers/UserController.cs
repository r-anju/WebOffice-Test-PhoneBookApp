using PhoneBookApp.BusinessLogicLayer;
using PhoneBookApp.BusinessObjectLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhonebookAppWebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserBll _userBll;
        public UserController()
        {
            _userBll = new UserBll();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(UserRegistrationDto userRegistrationDto)
        {
            var userRegResponse = _userBll.AddUser(userRegistrationDto);
            if (!userRegResponse.Status)
            {
                ViewBag.Success = false;
                ViewBag.Message = userRegResponse.Message;
                return View("Register");
            }
            ViewBag.Success = true;
            ViewBag.Message = userRegResponse.Message;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDto loginDto)
        {
            var userRegResponse = _userBll.LoginUser(loginDto);
            if (!userRegResponse.Status)
            {
                ViewBag.Success = false;
                ViewBag.Message = userRegResponse.Message;
                return RedirectToAction("Index","Home");
            }
            ViewBag.Success = true;
            Session["UserId"] = userRegResponse.UserInfo.Id;
            Session["NickName"] = userRegResponse.UserInfo.NickName;
            Session["EmailAddress"] = userRegResponse.UserInfo.EmailAddress;
            return RedirectToAction("Index", "Contact");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}