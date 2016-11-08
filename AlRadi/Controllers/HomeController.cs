using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Mail;

namespace AlRadi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(FromMail mail)
        {
            try
            {
                //MailAddress mailFrom = new MailAddress("admin@alradi-contracting.com", mail.Name);
                //MailAddress mailTo = new MailAddress("info@pointsqatar.com", "Alradi");
                System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
                message.From = "admin@alradi-contracting.com";
                message.To = "info@pointsqatar.com";
                message.Body = mail.Message;
                message.Subject = mail.Subject;
                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                SmtpMail.Send(message);


                //client.Host = "smtpout.secureserver.net";
                //client.Send(message);
                return Content("Success");
            }
            catch (Exception ex)
            {
                return Content(ex.Message + ex.InnerException + ex.StackTrace);
            }
        }
    }
    public class FromMail
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}