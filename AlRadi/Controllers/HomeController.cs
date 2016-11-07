using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

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
                MailAddress mailFrom = new MailAddress("info@alradi-contracting.com", mail.Name);
                MailAddress mailTo = new MailAddress("info@pointsqatar.com", "Alradi");
                MailMessage message = new MailMessage(mailFrom, mailTo);
                message.Body = mail.Message;
                message.Subject = mail.Subject;
                SmtpClient client = new SmtpClient();
                client.Host = "smtpout.europe.secureserver.net ";
                client.Port = 465;
                client.Credentials = new NetworkCredential("info@alradi-contracting.com", "Admin@2016");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Send(message);
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