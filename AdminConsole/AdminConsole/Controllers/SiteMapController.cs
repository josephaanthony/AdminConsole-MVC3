using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminConsole.Models;

namespace AdminConsole.Controllers
{
    public class SiteMapController : Controller
    {
        private AdminConsoleEntities db = new AdminConsoleEntities();

        //
        // GET: /SiteMap/

        public ActionResult Index(String desktopType)
        {
            return View();
        }

        public ViewResult SiteMap()
        {
            return View(db.DesktopTypes.ToList());
        }

    }
}
