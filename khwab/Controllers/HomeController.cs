using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using khwab.Models;
using System.Data.Entity;
using khwab.Models.Filters;

namespace khwab.Controllers
{
    [LoginFilter]
    public class HomeController : Controller
    {
        private khwabEntities db = new khwabEntities();
        // GET: Home
        public ActionResult Index()
        {
            var a = db.Papers;

            return View(a.ToList());
        }

     
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(FormCollection form)
        //{
        //    string e = form["email"];
        //    string p = form["password"];

        //   var a = db.users.Where(x => x.username == e).Where(x => x.password == p).FirstOrDefault();
        //    if (a != null)
        //    {
        //        return RedirectToAction("Index", "Papers");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }


            
        //}

        public ActionResult Create(string id)
        {
            ViewBag.paperCode = id;

            return View();

        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            mcq mcq = new mcq();

            for (int i = 1; i <= 60; i++)
            {
                mcq.type = form["type" + i];
                mcq.mcqOption = form["option" + i];

                mcq.paperId = form["paperId"];

                db.mcqs.Add(mcq);

                db.SaveChanges();
            }
            return RedirectToAction("Index", "Papers");
        }

        public ActionResult Details(string id)
        {
            var mc = db.mcqs.Where(x=> x.paperId == id).ToList();


            if (mc == null)
            {
                return HttpNotFound();
            }
            return View(mc);
        }


        public ActionResult Edit(string id)
        {
            //var mc = db.mcqs.Where(x => x.paperId == id).ToList();
            Class1 paper = new Class1();
            paper.paperId = id;
            paper.read(id);
            if (paper.mcqs == null)
            {
                return HttpNotFound();
            }
            return View(paper);
            //  ViewBag.userId = new SelectList(db.companies, "userId", "firstName", mcq.userId);
            
        }

        //
        // POST: /mcq/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
     
           
            for (int i = 1; i <= 60; i++)
            {
                int idc = Convert.ToInt32(form["mcqid" + i]);
                mcq mc = db.mcqs.Where(x => x.id==idc).FirstOrDefault();
                if (mc != null)
                {
                    mc.type = form["type" + i];
                    mc.mcqOption = form["option" + i];
                    mc.paperId = form["paperId"];
                    //    mcq.id = Convert.ToInt32(form["mcqid"+ i]);


                    db.Entry(mc).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index","Papers");
        }

        //
        // GET: /mcq/Delete/5

        public ActionResult Delete(string id)
        {
            var mc = db.mcqs.Where(x => x.paperId == id).ToList();


            if (mc == null)
            {
                return HttpNotFound();
            }
            return View(mc);
        }

        //
        // POST: /mcq/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            var mc = db.mcqs.Where(x => x.paperId == id).ToList();

            foreach (var item in mc)
            {

                db.mcqs.Remove(item);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}