using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FundingPilotSystem.Common
{
    public class EmailUtility
    {
        #region [Declaration]


        public string SmtpClient
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings["SmtpClient"]); }
        }

        public string SmtpUserName
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings["SmtpUserName"]); }
        }

        public string SmtpPassword
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings["SmtpPassword"]); }
        }

        #endregion

        #region [Send Email Method]
        /// <summary>
        /// Send mail function for multiple recipeients
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="emailBody"></param>
        /// <param name="emailSubject"></param>
        /// <param name="attachmentFilePath"></param>
        /// <returns></returns>
        public Tuple<bool, string> SendEmail(string from, IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string emailBody, string emailSubject, string attachmentFilePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.SmtpClient)
                        || string.IsNullOrWhiteSpace(this.SmtpUserName)
                        || string.IsNullOrWhiteSpace(this.SmtpPassword))
                {
                    return new Tuple<bool, string>(false, "Configuration Parameter not set");
                }

                if (string.IsNullOrWhiteSpace(from))
                {
                    return new Tuple<bool, string>(false, "Mail From not set");
                }

                if (to == null && to.Count() == 0)
                {
                    return new Tuple<bool, string>(false, "Mail to not set");
                }

                if (string.IsNullOrWhiteSpace(emailBody))
                {
                    return new Tuple<bool, string>(false, "Mail Body not set");
                }

                if (string.IsNullOrWhiteSpace(emailBody))
                {
                    return new Tuple<bool, string>(false, "Mail Body not set");
                }

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Host = this.SmtpClient;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                MailMessage mailMessage = new MailMessage();

                smtpClient.Credentials = new System.Net.NetworkCredential(this.SmtpUserName, this.SmtpPassword);

                if (!string.IsNullOrWhiteSpace(from))
                {
                    mailMessage.From = new MailAddress(from);
                }

                foreach (string emailTo in to)
                {
                    mailMessage.To.Add(emailTo);
                }

                foreach (string emailCc in cc)
                {
                    mailMessage.CC.Add(emailCc);
                }

                foreach (string emailBcc in bcc)
                {
                    mailMessage.Bcc.Add(emailBcc);
                }

                mailMessage.IsBodyHtml = true;
                mailMessage.Body = emailBody;
                mailMessage.Subject = emailSubject;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

                if (!string.IsNullOrWhiteSpace(attachmentFilePath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentFilePath));
                }

                smtpClient.Send(mailMessage);

                return new Tuple<bool, string>(true, string.Empty);

            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        /// <summary>
        /// Send mail functionality to single user
        /// </summary>
        /// <param name="smtpClient"></param>
        /// <param name="smtpUserName"></param>
        /// <param name="smtpPassword"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="emailBody"></param>
        /// <param name="emailSubject"></param>
        /// <param name="attachmentFilePath"></param>
        /// <returns></returns>
        public Tuple<bool, string> SendEmail(string smtpClient, string smtpUserName, string smtpPassword, string from, IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string emailBody, string emailSubject, string attachmentFilePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(smtpClient)
                        || string.IsNullOrWhiteSpace(smtpUserName)
                        || string.IsNullOrWhiteSpace(smtpPassword))
                {
                    return new Tuple<bool, string>(false, "Configuration Parameter not set");
                }

                if (string.IsNullOrWhiteSpace(from))
                {
                    return new Tuple<bool, string>(false, "Mail From not set");
                }

                if (to == null && to.Count() == 0)
                {
                    return new Tuple<bool, string>(false, "Mail to not set");
                }

                if (string.IsNullOrWhiteSpace(emailBody))
                {
                    return new Tuple<bool, string>(false, "Mail Body not set");
                }

                if (string.IsNullOrWhiteSpace(emailBody))
                {
                    return new Tuple<bool, string>(false, "Mail Body not set");
                }

                SmtpClient smtp = new SmtpClient();

                smtp.Host = smtpClient;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                MailMessage mailMessage = new MailMessage();

                smtp.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);

                if (!string.IsNullOrWhiteSpace(from))
                {
                    mailMessage.From = new MailAddress(from);
                }

                foreach (string emailTo in to)
                {
                    mailMessage.To.Add(emailTo);
                }

                foreach (string emailCc in cc)
                {
                    mailMessage.CC.Add(emailCc);
                }

                foreach (string emailBcc in bcc)
                {
                    mailMessage.Bcc.Add(emailBcc);
                }

                mailMessage.IsBodyHtml = true;
                mailMessage.Body = emailBody;
                mailMessage.Subject = emailSubject;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

                if (!string.IsNullOrWhiteSpace(attachmentFilePath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentFilePath));
                }

                smtp.Send(mailMessage);

                return new Tuple<bool, string>(true, string.Empty);

            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        #endregion

    }
}
