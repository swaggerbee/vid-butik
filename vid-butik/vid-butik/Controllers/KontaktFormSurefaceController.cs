//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using VBRepo;
//using System.Text;
//using System.Net;
//using System.Net.Mail;



//namespace vid_butik.Controllers
//{
//    public class KontaktFormSurefaceController : Controller
//    {
//        // GET: KontaktFormSureface
//        public ActionResult Index()
//        {
//            return PartialView ("KontaktForm", new contactModel());
//        }

//        public ActionResult HandleFormSUbmit()
//        {
//            if (ModelState.IsValid)
//            {
//                string brugernavn = CurrentPage.GetPropertyValue<string>("brugernavn");
//                string kodeord = CurrentPage.GetPropertyValue<string>("kodeord");
//                string mailServer = CurrentPage.GetPropertyValue<string>("mailServer");
//                int portNummer = CurrentPage.GetPropertyValue<string>("portNummer");
//                string emailFra = CurrentPage.GetPropertyValue<string>("emailFra");
//                string emailTil = CurrentPage.GetPropertyValue<string>("emailTil");

//                SmtpClient smpt = new SmtpClient();
//                smpt.UseDefaultCredentials = false;
//                smpt.Credentials = new NetworkCredential(brugernavn, kodeord);
//                smpt.Host = mailServer;
//                smpt.Port = portNummer;
//                smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
//                smpt.EnableSsl = false;

//                string mailFrom = emailFra;
//                string mailTo = emailTil;

//                string mailSubject = "Emaiil fra Hjemmesiden";

//                StringBuilder mailContent = new StringBuilder();
//                mailContent.Append("<h3>Kontakt oplysninger:</h3>");
//                mailContent.AppendFormat("Navn: <b>{0}</b><br />", Model.Navn);
//                mailContent.AppendFormat("Kontakt: <b>{0}</b>", Model.Info);
//                mailContent.AppendFormat("<hr />{0}", ModelBinderAttribute.Besked.Replace(Environment.NewLine, "<br />"));

//                MailMessage mail = new MailMessage(mailFrom, mailTo, mailSubject, mailContent.ToString());
//                mail.IsBodyHtml = true;
//                mail.HeadersEncoding = Encoding.UTF8;
//                mail.BodyEncoding = Encoding.UTF8;
//                mail.SubjectEncoding = Encoding.UTF8;
//                try
//                {
//                    smpt.Send(mail);
//                }
//                catch (SmtpException sex)
//                {
//                    //TemData["MailFormSuccess"]=sex.Message;
//                }
//                catch (Exception ex)
//                {
//                    //TemData["MailFormSuccess"]=ex.Message;
//                }
//                return RedirectToAction("");

//            }
//            else
//            {
//                return RedirectToAction("");
//            }
//        }
//    }
//}