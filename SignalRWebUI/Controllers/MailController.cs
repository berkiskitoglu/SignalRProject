using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.ViewModels.MailViewModels;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        private readonly IConfiguration _configuration;

        public MailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(CreateMailViewModel createMailViewModel)
        {
            if (!ModelState.IsValid)
                return View(createMailViewModel);

            string senderMail = _configuration["MailSettings:SenderMail"];
            string password = _configuration["MailSettings:Password"];
            string host = _configuration["MailSettings:Host"];
            int port = int.Parse(_configuration["MailSettings:Port"]);

            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Admin", senderMail));
            mimeMessage.To.Add(new MailboxAddress("User", createMailViewModel.ReceiverMail));

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailViewModel.Content;
            mimeMessage.Subject = createMailViewModel.Subject;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect(host, port, false);
            smtpClient.Authenticate(senderMail, password);
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return RedirectToAction("CategoryList", "Category");
        }
    }
}