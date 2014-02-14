using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using FundingPilotSystem.Services.FPConfigurationService;
using FundingPilotSystem.VM;

namespace FundingPilotSystem.NotificationService
{
    public partial class EmailNotificationService : ServiceBase
    {
        #region [Declaration]

        private Timer mailSendingTimer = new Timer();

        #endregion

        #region [Constructor]

        public EmailNotificationService()
        {
            InitializeComponent();
        }

        #endregion

        #region [Service Event]

        /// <summary>
        /// Service strat event
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            mailSendingTimer = new Timer(EmailUtility.EmailNotificationInterval);
            mailSendingTimer.Elapsed += new System.Timers.ElapsedEventHandler(emailNotificationTimer_Elapsed);
            mailSendingTimer.Enabled = true;
        }

        /// <summary>
        /// service Stop event
        /// </summary>
        protected override void OnStop()
        {
            mailSendingTimer.Stop();
        }

        #endregion

        #region [Method]

        /// <summary>
        /// Timer elapsed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emailNotificationTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SendingMail();
        }

        /// <summary>
        /// Email seding regrading process
        /// </summary>
        public void SendingMail()
        {
            var pendingEmailQueue = EmailUtility.GetPendingEmailQueue();
            foreach (var queue in pendingEmailQueue)
            {
                queue.EmailContent = GetEmailContent(queue);
                try
                {
                    List<string> to = new List<string>();
                    to.Add(queue.Receiver);

                    Tuple<bool, string> mailResult = EmailUtility.SendEmail(EmailUtility.FromEmail, to.AsEnumerable(), null, null, queue.ProcessName, queue.EmailContent, null);
                    if (mailResult.Item1 == true)
                    {
                        EmailLogVM emailLogVM = new EmailLogVM();
                        emailLogVM.Process = queue.Process;
                        emailLogVM.EmailBody = queue.EmailContent;
                        emailLogVM.Receiver = queue.Receiver;
                        emailLogVM.SentTime = System.DateTime.Now;
                        EmailUtility.SaveEmailLog(emailLogVM, queue.Id);
                    }
                    else
                    {
                        queue.ErrorStatus = mailResult.Item2;
                        EmailUtility.UpdateEmailQueue(queue);
                    }
                }
                catch (Exception ex)
                {
                    queue.ErrorStatus = ex.Message;
                    EmailUtility.UpdateEmailQueue(queue);
                }
            }
        }

        /// <summary>
        /// Get Email Content after replacing place holder
        /// </summary>
        /// <param name="emailQueue"></param>
        /// <returns></returns>
        public static string GetEmailContent(EmailQueueVM emailQueue)
        {
            if (emailQueue == null || string.IsNullOrWhiteSpace(emailQueue.EmailContent))
            {
                return string.Empty;
            }

            var placeHolderList = emailQueue.GetType().GetProperties();

            foreach (var placeHolder in placeHolderList)
            {
                string placeHolderName = string.Format("##{0}##", placeHolder.Name).ToLower();
                string placeHolderValue = Convert.ToString(placeHolder.GetValue(emailQueue, null) ?? "&nbsp;");

                emailQueue.EmailContent = emailQueue.EmailContent.Replace(placeHolderName, placeHolderValue);
            }

            return emailQueue.EmailContent;
        }

        #endregion
    }
}
