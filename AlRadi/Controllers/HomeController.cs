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
                System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
                message.From = System.Configuration.ConfigurationManager.AppSettings["FromAddress"];
                message.To = System.Configuration.ConfigurationManager.AppSettings["ToAddress"];
                message.Body = string.Format(GetMailTemplate(), mail.Name, mail.Email, mail.Subject, mail.Message);
                message.Subject = mail.Subject;
                message.BodyFormat = MailFormat.Html;
                SmtpMail.SmtpServer = "relay-hosting.secureserver.net";
                SmtpMail.Send(message);
                return Content("success");
            }
            catch (Exception ex)
            {
                return Content(ex.Message + ex.InnerException + ex.StackTrace);
            }
        }

        private string GetMailTemplate()
        {
            string mailTemplate = System.IO.File.ReadAllText(Server.MapPath(@"~/MailTemplate.html"));

            return mailTemplate;
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