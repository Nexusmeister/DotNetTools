using System;
using System.Linq;
using System.Text;
using MimeKit;
using Tools.Core.DTOs.Administration;

namespace Tools.Core.Tools
{
    /// <summary>
    /// Service für Mailversand
    /// </summary>
    public class EMail
    {
        public static EMailCredentialsDto Credentials { get; set; }

        /// <summary>
        /// Mail an Standardempfänger
        /// </summary>
        /// <param name="inhalt"></param>
        /// <param name="betreff"></param>
        /// <returns></returns>
        public static bool VersendeMail(string inhalt, string betreff)
        {
            return VersendeMail(inhalt, betreff, Credentials.StandardEmpfaenger, string.Empty, string.Empty);
        }

        /// <summary>
        /// Standard Mailversand
        /// </summary>
        /// <param name="inhalt"></param>
        /// <param name="betreff"></param>
        /// <param name="empfaenger"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="dateiname"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public static bool VersendeMail(string inhalt, string betreff, string empfaenger, string cc, string bcc, string dateiname = null, bool html = true)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(".NET-Toolkit Mailer", Credentials.Username));
            bool keinEmpfaenger = false;
            // Empfänger angeben
            if (empfaenger != null && (!string.IsNullOrWhiteSpace(empfaenger) || empfaenger.Contains(",")))
            {
                char[] splitter = { ',' };
                var multiEmpfaenger = empfaenger.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList();
                var mehrereAdressen = new InternetAddressList();
                foreach (var adresse in multiEmpfaenger)
                {
                    mehrereAdressen.Add(new MailboxAddress(Encoding.UTF8, adresse, adresse));
                }

                message.To.AddRange(mehrereAdressen);
            }
            else
            {
                message.To.Add(new MailboxAddress(Encoding.UTF8, Credentials.StandardEmpfaenger, Credentials.StandardEmpfaenger));
                keinEmpfaenger = true;
            }

            if (!string.IsNullOrWhiteSpace(cc))
            {
                message.Cc.Add(new MailboxAddress(Encoding.UTF8, cc, cc));
            }

            if (!string.IsNullOrWhiteSpace(bcc))
            {
                message.Bcc.Add(new MailboxAddress(Encoding.UTF8, bcc, bcc));
            }

            // Betreff
            if (keinEmpfaenger)
            {
                message.Subject = "[Kein Empfänger angegeben]";
            }

            if (AppContext.BaseDirectory.Contains("Debug"))
            {
                message.Subject = "[DEV]";
            }

            if (!string.IsNullOrWhiteSpace(message.Subject))
            {
                message.Subject += string.IsNullOrWhiteSpace(betreff) ? " Toolkit Notification" : " " + betreff;
            }
            else
            {
                message.Subject = string.IsNullOrWhiteSpace(betreff) ? "Toolkit Notification" : betreff;
            }

            // Nachrichtinhalt
            var builder = new BodyBuilder();
            if (html)
            {
                builder.HtmlBody = $"<html>{inhalt}</html>";
            }
            else
            {
                builder.TextBody = inhalt;
            }

            // Anlagen mitsenden
            if (!string.IsNullOrWhiteSpace(dateiname))
            {
                builder.Attachments.Add(dateiname);
            }

            message.Body = builder.ToMessageBody();

            // Sende Mail
            using var client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect(Credentials.SmtpServer, Credentials.SmtpPort, true);
            client.Authenticate(Credentials.Username, Credentials.PasswordDecrypted);

            client.Send(message);
            client.Disconnect(true);
            return true;
        }
    }
}