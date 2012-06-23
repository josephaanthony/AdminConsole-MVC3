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
    public class TargetContainerController : Controller
    {
        private AdminConsoleEntities db = new AdminConsoleEntities();

        //
        // GET: /TargetContainer/

        public ViewResult Index()
        {
            var targetcontainers = db.TargetContainers.Include(t => t.Desktop).Include(t => t.ParentTargetContainer);
            return View(targetcontainers.ToList());
        }

        //
        // GET: /TargetContainer/Details/5

        public ViewResult Details(int? id)
        {
            TargetContainer targetcontainer = db.TargetContainers.Find(id);
            return View(targetcontainer);
        }

        //
        // GET: /TargetContainer/Create

        public ActionResult Create(String desktopType, int? parentContainerId = null)
        {
            //ViewBag.DesktopType_DesktopCode = new SelectList(db.DesktopTypes, "DesktopCode", "Description");
            //ViewBag.ParentTargetContainer_Id = new SelectList(db.TargetContainers, "Id", "Description");


            ViewBag.DesktopType_DesktopCode = desktopType;
            ViewBag.ParentTargetContainer_Id = parentContainerId;
            return View();

            //return View(new TargetContainer() { Desktop = db.DesktopTypes.Find(desktopType) });
        } 

        //
        // POST: /TargetContainer/Create

        [HttpPost]
        public ActionResult Create(TargetContainer targetcontainer)
        {
            //ModelState.Clear();

            //targetcontainer.DesktopType = db.DesktopTypes.Find(targetcontainer.DesktopType_DesktopCode);
            //TryValidateModel(targetcontainer);

            if (ModelState.IsValid)
            {
                db.TargetContainers.Add(targetcontainer);
                db.SaveChanges();
                return RedirectToAction("Index", "SiteMap");
            }
            else
            {
                ViewData.Add("Error", String.Join(";", ModelState.Values.SelectMany(value => value.Errors).Select(
                    error => !String.IsNullOrEmpty(error.ErrorMessage) ? error.ErrorMessage : error.Exception != null ? error.Exception.Message : "" )));
            }

            //ViewBag.DesktopType_DesktopCode = new SelectList(db.DesktopTypes, "DesktopCode", "Description", targetcontainer.DesktopType_DesktopCode);
            //ViewBag.ParentTargetContainer_Id = new SelectList(db.TargetContainers, "Id", "Description", targetcontainer.ParentTargetContainer_Id);
            return View(targetcontainer);
        }
        
        //
        // GET: /TargetContainer/Edit/5
 
        public ActionResult Edit(int id)
        {
            TargetContainer targetcontainer = db.TargetContainers.Find(id);
            ViewBag.DesktopType_DesktopCode = new SelectList(db.DesktopTypes, "DesktopCode", "Description", targetcontainer.DesktopType_DesktopCode);
            ViewBag.ParentTargetContainer_Id = new SelectList(db.TargetContainers, "Id", "Description", targetcontainer.ParentTargetContainer_Id);
            return View(targetcontainer);
        }

        //
        // POST: /TargetContainer/Edit/5

        [HttpPost]
        public ActionResult Edit(TargetContainer targetcontainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(targetcontainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "SiteMap");
            }
            //ViewBag.DesktopType_DesktopCode = new SelectList(db.DesktopTypes, "DesktopCode", "Description", targetcontainer.DesktopType_DesktopCode);
            //ViewBag.ParentTargetContainer_Id = new SelectList(db.TargetContainers, "Id", "Description", targetcontainer.ParentTargetContainer_Id);
            return View(targetcontainer);
        }

        //
        // GET: /TargetContainer/Delete/5
 
        public ActionResult Delete(int id)
        {
            TargetContainer targetcontainer = db.TargetContainers.Find(id);
            return View(targetcontainer);
        }

        //
        // POST: /TargetContainer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            TargetContainer targetcontainer = db.TargetContainers.Find(id);
            db.TargetContainers.Remove(targetcontainer);
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