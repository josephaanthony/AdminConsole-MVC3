using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminConsole.Models;

namespace AdminConsole.Controllers
{ 
    public class TargetTypeController : Controller
    {
        private AdminConsoleEntities db = new AdminConsoleEntities();

        //
        // GET: /TargetType/

        public ViewResult Index()
        {
            return View(db.TargetTypes.ToList());
        }

        //
        // GET: /TargetType/Details/5

        public ViewResult Details(string id)
        {
            TargetType targettype = db.TargetTypes.Find(id);
            return View(targettype);
        }

        //
        // GET: /TargetType/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TargetType/Create

        [HttpPost]
        public ActionResult Create(TargetType targettype)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.TargetTypes.Add(targettype);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return View(targettype);
        }
        
        //
        // GET: /TargetType/Edit/5
 
        public ActionResult Edit(string id)
        {
            TargetType targettype = db.TargetTypes.Find(id);
            return View(targettype);
        }

        //
        // POST: /TargetType/Edit/5

        [HttpPost]
        public ActionResult Edit(TargetType targettype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(targettype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(targettype);
        }

        //
        // GET: /TargetType/Delete/5
 
        public ActionResult Delete(string id)
        {
            TargetType targettype = db.TargetTypes.Find(id);
            return View(targettype);
        }

        //
        // POST: /TargetType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            TargetType targettype = db.TargetTypes.Find(id);
            db.TargetTypes.Remove(targettype);
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