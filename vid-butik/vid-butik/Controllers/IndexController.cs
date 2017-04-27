﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VBRepo;

namespace vid_butik.Controllers
{
    public class IndexController : Controller
    {
        IndexFac IF = new IndexFac();
        KontaktFac KF = new KontaktFac();
        MedarbejderFac MF = new MedarbejderFac();
        Om_OsFac OOF = new Om_OsFac();
        Vare_infoFac VIF = new Vare_infoFac();

        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kontakt()
        {
            return View(KF.Get(1));
        }
        public ActionResult omos()
        {

            return View();
        }
        public ActionResult mereinfo()
        {
            return View();
        }
    }
}