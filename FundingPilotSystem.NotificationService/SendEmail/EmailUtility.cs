using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using FundingPilotSystem.Services.FPConfigurationService;
using FundingPilotSystem.VM;

namespace FundingPilotSystem.NotificationService
{
    public static class EmailUtility
    {
        #region [Declaration]

        public static string FromEmail
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["FromEmail"].ToString());
            }
        }

        private static string SmtpClient
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SmtpClient"].ToString());
            }
        }

        private static string SmtpUserName
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SmtpUserName"].ToString());
            }
        }

        private static string SmtpPassword
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SmtpPassword"].ToString());
            }
        }

        private static int SmtpClientPort
        {
            get
            {
                int smtpPort;
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"].ToString(), out smtpPort);
                return smtpPort;
            }
        }

        public static double EmailNotificationInterval
        {
            get
            {
                return Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["EmailNotificationInterval"].ToString());
            }
        }

        #endregion

        #region [Method]

        /// <summary>
        /// Send mail 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="emailSubject"></param>
        /// <param name="emailBody"></param>
        /// <param name="attachmentFilePath"></param>
        /// <returns></returns>
        public static Tuple<bool, string> SendEmail(string from, IEnumerable<string> to, IEnumerable<string> cc, IEnumerable<string> bcc, string emailSubject, string emailBody, string attachmentFilePath)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(SmtpClient);

                if(SmtpClientPort > 0)
                {
                    smtpClient.Port = SmtpClientPort;
                }

                MailMessage mailMessage = new MailMessage();
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(SmtpUserName, SmtpPassword);
                smtpClient.EnableSsl = true;

                if (!string.IsNullOrEmpty(from))
                {
                    mailMessage.From = new MailAddress(from);
                }

                if ((to == null || to.Count() == 0)
                    && (cc == null || cc.Count() == 0)
                    && (bcc == null || bcc.Count() == 0))
                {
                    return new Tuple<bool, string>(false, "no recipients");
                }

                if (to != null)
                {
                    foreach (string email in to)
                    {
                        mailMessage.To.Add(email);
                    }
                }

                if (cc != null)
                {
                    foreach (string email in cc)
                    {
                        mailMessage.CC.Add(email);
                    }
                }

                if (bcc != null)
                {
                    foreach (string email in bcc)
                    {
                        mailMessage.Bcc.Add(email);
                    }
                }

                mailMessage.IsBodyHtml = true;
                mailMessage.Body = emailBody;
                mailMessage.Subject = emailSubject;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

                // Add Attachment
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
        /// Update email queue on error coming in sending email.
        /// </summary>
        public static int UpdateEmailQueue(EmailQueueVM emailQueueVM)
        {
            return ServiceReferences.FPConfigurationProviderServiceClient.UpdateEmailQueue(emailQueueVM);
        }

        /// <summary>
        /// Save email log 
        /// </summary>
        public static int SaveEmailLog(EmailLogVM emailLogVM, int emailQueueId)
        {
            return ServiceReferences.FPConfigurationProviderServiceClient.SaveEmailLog(emailLogVM, emailQueueId);
        }

        /// <summary>
        /// Get Pending email queue
        /// </summary>
        /// <returns></returns>
        public static List<EmailQueueVM> GetPendingEmailQueue()
        {
            return ServiceReferences.FPConfigurationProviderServiceClient.GetPendingEmailQueue();
        }

        #endregion
    }
}
