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
        Om_OsFac oof = new Om_OsFac();
        MedarbejderFac mf = new MedarbejderFac();
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
                ViewBag.MSG = "prøv igen og husk at udfylde all felter";
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
        public ActionResult AdmOpredMed()
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
            return RedirectToAction("AdmMedarbejder");
        }
        public ActionResult AdmMedarbejder()
        {
            return View(mf.GetAll());
        }
        [HttpPost]
        public ActionResult AdmMedarbejderResult(HttpPostedFileBase IMG, string Navn, string Tekst)
        {
            Uploader U = new Uploader();
            int width = 500;
            string path = Request.PhysicalApplicationPath + "Content/IMG/";
            string File = U.UploadImage(IMG, path, width, true);

            Medarbejder m = new Medarbejder();
            m.IMG = Path.GetFileName(File);
            m.Navn = Navn;
            m.Tekst = Tekst;
            mf.Insert(m);
            return RedirectToAction("AdmMedarbejder");
        }
        public ActionResult AdmMedarbejderSlet(int ID)
        {
            string IMG = mf.Get(ID).IMG;
            string path = Request.PhysicalApplicationPath + "Content/IMG/" + IMG + "";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                mf.Delete(ID);
            }
            else
            {
                mf.Delete(ID);
            }
            return RedirectToAction("AdmMedarbejder");
        }
        [HttpGet]
        public ActionResult AdmButikkenEdit(int ID)
        {
            
            return View(vif.Get(ID));
        }
        [HttpPost]
        public ActionResult AdmButikkenEditResult(int ID, string Navn, string Tekst, int Pris, HttpPostedFileBase IMG)
        {
            if (IMG != null && Tekst != null && Navn != null)
            {
                Uploader U = new Uploader();
                int width = 500;
                string path = Request.PhysicalApplicationPath + "Content/IMG/";
                string File = U.UploadImage(IMG, path, width, true);

                Vare_info vi = new Vare_info();
                vi.ID = ID;
                vi.Pris = Pris;
                vi.Tekst = Tekst;
                vi.Navn = Navn;
                vi.IMG = Path.GetFileName(File);
                vif.Update(vi);
                ViewBag.MSG = "updateret";
            }
            else
            {
                ViewBag.MSG = "prøv igen og husk at udfylde all felter";
            }

            return RedirectToAction("AdmButikken");
        }
    }
}