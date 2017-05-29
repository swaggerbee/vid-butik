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
    public class DataController : Controller
    {
        // GET: Data
        [ChildActionOnly]
        public ActionResult BannerKurv()
        {
            BKurvVM bkVM = new BKurvVM();
            Vare_infoFac ViF = new Vare_infoFac();

            int antal = 0;
            decimal total = 0;

            foreach(string ses in Session.Contents)
            {
                int id = int.Parse(ses.Replace("vare_",""));
                decimal pris = ViF.Get(id).Pris;
                int a = int.Parse(Session[ses].ToString());

                decimal ialt = pris * a;

                antal = antal + a;

                total = total + ialt;
            }


            bkVM.Antal = antal;
            bkVM.Total = total;

            return PartialView(bkVM);
        }
    }
}