using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace khwab.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index (string id)
        {
            if (id == "Khwab25384Tech") {

                return View();
               
            }

            return RedirectToAction("Login", "Account");
        }
    }
}