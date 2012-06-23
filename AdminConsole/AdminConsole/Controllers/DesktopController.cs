using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminConsole.Models;
using System.Data.Entity.Validation;
using System.Text;
using System.Web.Routing;

namespace AdminConsole.Controllers
{ 
    public class DesktopController : Controller
    {
        private AdminConsoleEntities db = new AdminConsoleEntities();

        //
        // GET: /Desktop/

        public ViewResult Index()
        {
            return View(db.DesktopTypes.ToList());
        }

        //
        // GET: /Desktop/Details/5

        public ViewResult Details(string id)
        {
            Desktop desktoptype = db.DesktopTypes.Find(id);
            return View(desktoptype);
        }

        //
        // GET: /Desktop/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Desktop/Create

        [HttpPost]
        public ActionResult Create(Desktop desktoptype)
        {
            if (ModelState.IsValid)
            {
                db.DesktopTypes.Add(desktoptype);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    StringBuilder routeValues = new StringBuilder();
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            routeValues.AppendFormat("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                            //Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                    ViewData.Add("Error", routeValues.ToString());
                    return View();
                    //return RedirectToAction("Create");
                    //return RedirectToAction("Create", new RouteValueDictionary(new Dictionary<String, String>{ {"Error", routeValues.ToString()} }));
                }
                return RedirectToAction("Index");  
            }

            return View(desktoptype);
        }
        
        //
        // GET: /Desktop/Edit/5
 
        public ActionResult Edit(string id)
        {
            Desktop desktoptype = db.DesktopTypes.Find(id);
            return View(desktoptype);
        }

        //
        // POST: /Desktop/Edit/5

        [HttpPost]
        public ActionResult Edit(Desktop desktoptype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desktoptype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(desktoptype);
        }

        //
        // GET: /Desktop/Delete/5
 
        public ActionResult Delete(string id)
        {
            Desktop desktoptype = db.DesktopTypes.Find(id);
            return View(desktoptype);
        }

        //
        // POST: /Desktop/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            Desktop desktoptype = db.DesktopTypes.Find(id);
            db.DesktopTypes.Remove(desktoptype);
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