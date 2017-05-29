using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using VBRepo;

namespace vid_butik.Controllers
{
    public class ButikController : Controller
    {


        Vare_infoFac VIF = new Vare_infoFac();
        // GET: Butik
        public ActionResult butikken()
        {

            var VareTaeller = VIF.GetAll();
            var AntalVare = VareTaeller.Count;

            if ((AntalVare % 3) == 0)
            {
                ViewBag.test = "antallet af vare kan deles med 3";
            }
            else
            {
                do
                {

                    ViewBag.filler_1 = "<div class='Vare'> </div>";

                    AntalVare = AntalVare + 1;

                    if ((AntalVare % 3) != 0)
                    {
                        ViewBag.filler_2 = "<div class='Vare'> </div>";

                        AntalVare = AntalVare + 1;
                    }
                }
                while ((AntalVare % 3) != 0);
            }

            return View(VIF.GetAll());
        }

        public ActionResult Vare(int id)
        {
            return View(VIF.Get(id));
        }

        public ActionResult Kurv()
        {
            List<Vare_info> list = new List<Vare_info>();

            foreach (string ses in Session.Contents)
            {

                int id = int.Parse(ses.Replace("vare_", ""));

                list.Add(VIF.Get(id));


            }

            return View(list);
        }

        public ActionResult Add(int id)
        {
            string navn = "vare_" + id;

            if (Session[navn] == null)
            {
                Session[navn] = 1;
            }
            else
            {
                Session[navn] = int.Parse(Session[navn].ToString()) + 1;
            }


            return RedirectToAction("Kurv");
        }

        public ActionResult Sub(int id)
        {
            string navn = "vare_" + id;

            int antal = int.Parse(Session[navn].ToString());

            if (antal <= 1)
            {
                Session.Remove(navn);
            }
            else
            {
                Session[navn] = antal - 1;
            }


            return RedirectToAction("Kurv");
        }

        public ActionResult Del(int id)
        {
            string navn = "vare_" + id;
            Session.Remove(navn);

            return RedirectToAction("Kurv");
        }


    }
}


