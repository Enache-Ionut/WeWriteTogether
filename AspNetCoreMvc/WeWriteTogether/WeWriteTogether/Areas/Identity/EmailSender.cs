using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace WeWriteTogether.Areas.Identity
{
  public class EmailSender : IEmailSender
  {
    private readonly string apiKey;
    private readonly string fromName;
    private readonly string fromEmail;

    public EmailSender(IConfiguration config)
    {
      apiKey = config["SendGrid:ApiKey"];
      fromName = config["SendGrid:FromName"];
      fromEmail = config["SendGrid:FromEmail"];
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
      var client = new SendGridClient(apiKey);
      var msg = new SendGridMessage()
      {
        From = new EmailAddress(fromEmail, fromName),
        Subject = subject,
        PlainTextContent = htmlMessage,
        HtmlContent = htmlMessage
      };
      msg.AddTo(new EmailAddress(email));

      // Disable click tracking
      msg.SetClickTracking(false, false);

      await client.SendEmailAsync(msg);

    }
  }
}
