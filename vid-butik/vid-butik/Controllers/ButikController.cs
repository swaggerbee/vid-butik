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

        public ActionResult Kurv()
        {
            List<Vare_info> list = new List<Vare_info>();

            foreach(string ses in Session.Contents)
            {
                
                    int id = int.Parse(ses.Replace("vare_", ""));

                    list.Add(VIF.Get(id));

                
            }

            return View(list);
        }

        public ActionResult Add(int id)
        {
            string navn = "vare_" + id;

            if (Session[navn] == null) {
                Session[navn] = 1;
            }
            else
            {
                Session[navn] = int.Parse(Session[navn].ToString()) + 1;
            }


            return RedirectToAction("Kurv");
        }
    }
}