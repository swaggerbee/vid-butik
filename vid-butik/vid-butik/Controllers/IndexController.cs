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

            FVM.vare = VIF.NewProduct();

            return View(FVM);
        }
        public ActionResult Kontakt()
        {
            return View(KF.Get(1));
        }
        public ActionResult omos()
        {
            Om_OsVM OOVM = new Om_OsVM();

            OOVM.Omos = OOF.Get(1);

            OOVM.Medarbejder = MF.GetAll();

            return View(OOVM);
        }
        public ActionResult mereinfo()
        {
            return View();
        }
    }
}