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
    public class TargetController : Controller
    {
        private AdminConsoleEntities db = new AdminConsoleEntities();

        //
        // GET: /Target/

        public ViewResult Index()
        {
            var targets = db.Targets.Include(t => t.TargetType);
            return View(targets.ToList());
        }

        //
        // GET: /Target/Details/5

        public ViewResult Details(int id)
        {
            Target target = db.Targets.Find(id);
            return View(target);
        }

        //
        // GET: /Target/Create

        public ActionResult Create(int targetContainerId)
        {
            //Target target = new Target();
            //target.TargetContainers.Add(db.TargetContainers.Find(targetContainerId));

            ViewBag.TargetContainerId = targetContainerId;
            ViewBag.TargetType_TargetTypeCode = new SelectList(db.TargetTypes, "TargetTypeCode", "Description");
            return View();
        } 

        //
        // POST: /Target/Create

        [HttpPost]
        public ActionResult Create(Target target)
        {
            target.TargetContainers.Add(db.TargetContainers.Find(Int32.Parse(Request["TargetContainerId"])));

            if (ModelState.IsValid)
            {
                db.Targets.Add(target);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.TargetType_TargetTypeCode = new SelectList(db.TargetTypes, "TargetTypeCode", "Description", target.TargetType_TargetTypeCode);
            return View(target);
        }
        
        //
        // GET: /Target/Edit/5
 
        public ActionResult Edit(int id)
        {
            Target target = db.Targets.Find(id);
            ViewBag.TargetType_TargetTypeCode = new SelectList(db.TargetTypes, "TargetTypeCode", "Description", target.TargetType_TargetTypeCode);
            return View(target);
        }

        //
        // POST: /Target/Edit/5

        [HttpPost]
        public ActionResult Edit(Target target)
        {
            if (ModelState.IsValid)
            {
                db.Entry(target).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TargetType_TargetTypeCode = new SelectList(db.TargetTypes, "TargetTypeCode", "Description", target.TargetType_TargetTypeCode);
            return View(target);
        }

        //
        // GET: /Target/Delete/5
 
        public ActionResult Delete(int id)
        {
            Target target = db.Targets.Find(id);
            return View(target);
        }

        //
        // POST: /Target/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Target target = db.Targets.Find(id);
            db.Targets.Remove(target);
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