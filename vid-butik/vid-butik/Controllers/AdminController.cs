using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using VBRepo;

namespace vid_butik.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin
        KontaktFac KF = new KontaktFac();
        Vare_infoFac vif = new Vare_infoFac();
        public ActionResult AdmIndex()
        {
            return View();
        }
        public ActionResult AdmKontakt()
        {
            return View(KF.Get(1));
        }
        [HttpPost]
        public ActionResult AdmKontakt(int ID, string Tider, string Map, string Telefon, string Mail)
        {
            if (Tider != null && Mail != null && Telefon != null)
            {
                Kontakt k = new Kontakt();
                k.ID = ID;
                k.Mail = Mail;
                k.Map = null;
                k.Telefon = Telefon;
                k.Tider = Tider;
                KF.Update(k); 
                ViewBag.MSG = "updateret";
            }
            else
            {
                ViewBag.MSG = "du fuckede up";
            }

            return View(KF.Get(1));
        }

        public ActionResult AdmButikken()
        {
            return View(vif.GetAll());
        }
        public ActionResult Admopret()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdmButikkenResult(HttpPostedFileBase IMG, string Navn, int Pris, string Tekst)
        {
            Uploader U = new Uploader();
            int width = 500;
            string path = Request.PhysicalApplicationPath + "Content/IMG/";
            string File = U.UploadImage(IMG, path, width, true);

            Vare_info vi = new Vare_info();
            vi.IMG = Path.GetFileName(File);
            vi.Navn = Navn;
            vi.Pris = Pris;
            vi.Tekst = Tekst;
            vif.Insert(vi);
            return RedirectToAction("AdmButikken");
        }
        public ActionResult AdmButikkenSlet(int ID)
        {
            string IMG = vif.Get(ID).IMG;
            string path = Request.PhysicalApplicationPath + "Content/IMG/" + IMG + "";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                vif.Delete(ID);
            }
            else
            {
                vif.Delete(ID);
            }
            return RedirectToAction("AdmButikken");
        }
    }
}