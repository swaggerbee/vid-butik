using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using VBRepo;
using MVCEmail.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            BrugerFac bf = new BrugerFac();
            Bruger bruger = bf.Login(email.Trim(),(password.Trim()));

            if (bruger.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(bruger.ID.ToString(), false);
                Response.Redirect("/Admin/AdmIndex");
            }

            return Redirect("/Index/Login"); 
        }
        public ActionResult Logud()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("luca0327@videndjurs.net"));  // replace with valid value 
                message.From = new MailAddress("sender@outlook.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "luca0327@videndjurs.net",  // replace with valid value
                        Password = "killemall1983"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}