using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            var senderMail = _configuration["MailSettings:SenderMail"];
            var password = _configuration["MailSettings:Password"];
            var host = _configuration["MailSettings:Host"];
            var port = int.Parse(_configuration["MailSettings:Port"]);

            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Admin", senderMail));
            mimeMessage.To.Add(new MailboxAddress("User", createMailDto.ReceiverMail));

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Content;
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