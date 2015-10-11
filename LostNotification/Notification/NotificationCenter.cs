using System;
using System.Net.Mail;
using System.Net.Mime;

namespace Notification
{
    public class NotificationCenter
    {
        public void Notify(string emailAddress, string notificationTitle, string notificationContent)
        {
            //            try
            //            {
            var mailMsg = new MailMessage();
            mailMsg.To.Add(new MailAddress(emailAddress));
            mailMsg.From = new MailAddress("notifications@example.com", "YYC .NET UG");

            mailMsg.Subject = notificationTitle;
            var text = notificationContent;
            var html = $"<p>{notificationContent}</p>";
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            var smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
            var credentials = new System.Net.NetworkCredential(Environment.GetEnvironmentVariable("sendgrid.username", EnvironmentVariableTarget.User), Environment.GetEnvironmentVariable("sendgrid.password", EnvironmentVariableTarget.User));
            smtpClient.Credentials = credentials;

            smtpClient.Send(mailMsg);
            //            }
            //            catch (Exception ex)
            //            {
            //                Logger.Log("Failed to send notification", ex);
            //            }
        }
    }
}