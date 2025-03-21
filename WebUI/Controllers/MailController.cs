using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebUI.Constants;
using WebUI.Dtos.MailDtos;

namespace WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mineMessage = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Kartal Restaurant - Rezervasyon", MailKeyCosntants.Mail);
            mineMessage.From.Add(from);

            MailboxAddress to = new MailboxAddress("User", createMailDto.ReceiverMail);
            mineMessage.To.Add(to);

            var bodyBuilder = new BodyBuilder()
            {
                TextBody = createMailDto.Body
            };
            mineMessage.Body = bodyBuilder.ToMessageBody();

            mineMessage.Subject=createMailDto.Subject;
            
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate(MailKeyCosntants.Mail, MailKeyCosntants.Password);
            client.Send(mineMessage);
            client.Disconnect(true);

            return RedirectToAction("Index","Statistic");
        }
    }
}
