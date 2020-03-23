using khwab.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using khwab.Models;

namespace khwab.Controllers
{
    public class AccountController : Controller
    {
        
        private khwabEntities db = new khwabEntities();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            string n = Session["username"].ToString();
            var a = db.users.Where(m => m.username == n).FirstOrDefault();

            Session["status"] = false;

            
            return RedirectToAction("Index","Papers");
        }
        public ActionResult changePassword()
        {

            return View();
        }

        [HttpPost]
       public ActionResult changePasswordNow(FormCollection form)
        {
            var user = db.users.FirstOrDefault(x => x.username == "admin");

            if (user.password == form["oldPassword"])
            {
                if (form["newPassword"] == form["conPassword"])
                {
                    user.password = form["newPassword"];
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    //TempData["pwdError"] = "There exist error! Kindly Try again";
                    return RedirectToAction("changePasswordNow");
                }
            }
            else
            {
                TempData["pwdError"] = "There exist error! Kindly Try again";
                return RedirectToAction("changePasswordNow");
            }

            TempData["pwdChange"] = "Your Password has been successfully changed! Kindly Login Again";
            return RedirectToAction("Logout", "Account");
        }



        public JsonResult verifyPassword(String oldPassword)
        {
           // String userName = Session["username"].ToString();
            user user = db.users.FirstOrDefault(x => x.username == "admin");

            if (user.password != oldPassword)
            {
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json(false, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult Login()
        {
            ViewBag.url = Request.QueryString["ReturnUrl"];
            return View();
        }



        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string e = form["email"];
            string p = form["password"];

            var a = db.users.Where(x => x.username == e).Where(x => x.password == p).FirstOrDefault();
            if (a != null)
            {

                Session["username"] = a.username;
                Session["status"] = true;
               
               
                string url = form["url"];
                return Redirect(url);
            }
            else
            {
                return RedirectToAction("Login");
            }




        }
    }
}