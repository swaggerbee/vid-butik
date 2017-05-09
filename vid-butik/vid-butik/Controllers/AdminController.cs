using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vid_butik.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdmIndex()
        {
            return View();
        }
        public ActionResult AdmKontakt()
        {
            return View();
        }
        public ActionResult AdmMereinfo()
        {
            return View();
        }
        public ActionResult AdmOmos()
        {
            return View();
        }
        public ActionResult AdmButikken()
        {
            return View();
        }
    }
}