using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBRepo;

namespace vid_butik.Controllers
{
    public class IndexController : Controller
    {
        ForsideFac FF = new ForsideFac();
        KontaktFac KF = new KontaktFac();
        MedarbejderFac MF = new MedarbejderFac();
        Om_OsFac OOF = new Om_OsFac();
        Vare_infoFac VIF = new Vare_infoFac();

        // GET: Index
        public ActionResult Index()
        {
            ForsideVM FVM = new ForsideVM();

            FVM.forside = FF.Get(1);

            FVM.vare = VIF.GetAll();

            return View(FVM);
        }
        public ActionResult Kontakt()
        {
            return View(KF.Get(1));
        }
        public ActionResult omos()
        {

            return View(OOF.Get(1));
        }
        public ActionResult mereinfo()
        {
            return View();
        }
    }
}