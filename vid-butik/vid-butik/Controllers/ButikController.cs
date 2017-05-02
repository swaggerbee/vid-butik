using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBRepo;

namespace vid_butik.Controllers
{
    public class ButikController : Controller
    {


        Vare_infoFac VIF = new Vare_infoFac();
        // GET: Butik
        public ActionResult butikken()
        {

            return View(VIF.GetAll());
        }

        public ActionResult Vare(int id)
        {
            return View(VIF.Get(id));
        }
    }
}