using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FundingPilotSystem.Areas.UserManagement.Models
{
    public static class AccessLog
    {
        private static string WebAccessLogFolderPath
        {
            get
            {
                var webAccessLogFolderPath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["WebAccessLogFolderPath"]);
                return string.Format(@"{0}\WebAccessLog", webAccessLogFolderPath);
            }
        }

        public static string WebAccessLogFilePath
        {
            get
            {
                var webAccessLogFolderPath = WebAccessLogFolderPath;

                if (!Directory.Exists(webAccessLogFolderPath))
                {
                    Directory.CreateDirectory(webAccessLogFolderPath);
                }

                var filePath = string.Format(@"{0}\{1}-{2}-{3}.txt"
                                                , webAccessLogFolderPath
                                                , DateTime.Now.Day
                                                , DateTime.Now.Month
                                                , DateTime.Now.Year);

                if (!File.Exists(filePath))
                {
                    using (var fs = File.Create(filePath))
                    {
                    }
                }

                return filePath;
            }
        }

        public static void WriteWebAccessLog(WebAccessLogModel webAccessLogModel)
        {
            if (string.Compare(webAccessLogModel.Action, "FPResource", StringComparison.CurrentCultureIgnoreCase) == 0)
            {
                return;
            }

            using (var file = new System.IO.StreamWriter(AccessLog.WebAccessLogFilePath, true))
            {
                file.WriteLine(webAccessLogModel.ToString());
            }
        }

        public static List<WebAccessLogModel> ReadWebAccessLog()
        {
            var webAccessLog = new List<WebAccessLogModel>();

            string[] filePaths = Directory.GetFiles(AccessLog.WebAccessLogFolderPath);

            foreach (var filePath in filePaths)
            {
                using (var file = new System.IO.StreamReader(filePath, true))
                {
                    var line = string.Empty;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var webAccessLogModel = new WebAccessLogModel(line);
                            if (webAccessLogModel.UserId > 0)
                                webAccessLog.Add(webAccessLogModel);
                        }
                    }
                }
            }

            return webAccessLog;
        }

        public static List<WebAccessLogModel> ReadWebAccessLog(int userId, DateTime? fromDate, DateTime? toDate)
        {
            var webAccessLog = new List<WebAccessLogModel>();

            string[] filePaths = Directory.GetFiles(AccessLog.WebAccessLogFolderPath);

            foreach (var filePath in filePaths)
            {
                using (var file = new System.IO.StreamReader(filePath, true))
                {
                    var line = string.Empty;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var webAccessLogModel = new WebAccessLogModel(line);

                            if (webAccessLogModel.UserId > 0)
                            {
                                if (webAccessLogModel.UserId == userId)
                                {
                                    if ((fromDate != null && fromDate != DateTime.MinValue) && (toDate != null && toDate != DateTime.MinValue))
                                    {
                                        if (webAccessLogModel.DateTime.Date >= fromDate && webAccessLogModel.DateTime.Date <= toDate)
                                        {
                                            webAccessLog.Add(webAccessLogModel);
                                        }
                                    }
                                    else
                                    {
                                        webAccessLog.Add(webAccessLogModel);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return webAccessLog.OrderByDescending(t => t.DateTime).ToList();
        }
    }

    public class WebAccessLogModel
    {
        public WebAccessLogModel()
        {
        }
        public WebAccessLogModel(string logText)
        {
            string[] logTextList = logText.Split(Delimeter);

            for (int index = 0; index < logTextList.Length; index++)
            {
                switch (index)
                {
                    case 0:
                        UserId = Convert.ToInt32(logTextList[index]);
                        break;
                    case 1:
                        UserName = logTextList[index];
                        break;
                    case 2:
                        Controller = logTextList[index];
                        break;
                    case 3:
                        Action = logTextList[index];
                        break;
                    case 4:
                        Parameters = logTextList[index];
                        if (!string.IsNullOrWhiteSpace(Parameters))
                            Parameters = Parameters.Trim(new char[] { '&' }).Trim();

                        if (Parameters.Length > 100)
                        {
                            Parameters = string.Format("{0}...", Parameters.Substring(0, 100));
                        }

                        break;
                    case 5:
                        IsAjaxRequest = Convert.ToBoolean(logTextList[index]);
                        break;
                    case 6:
                        IP = logTextList[index];
                        break;
                    case 7:
                        try
                        {
                            DateTime = Convert.ToDateTime(logTextList[index]);
                        }
                        catch
                        {
                        }
                        break;
                }
            }
        }

        private const char Delimeter = '|';

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Parameters { get; set; }
        public bool IsAjaxRequest { get; set; }
        public string IP { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}"
                    , UserId
                    , UserName ?? string.Empty
                    , Controller ?? string.Empty
                    , Action ?? string.Empty
                    , Parameters ?? string.Empty
                    , IsAjaxRequest
                    , IP ?? string.Empty
                    , DateTime);

        }

    }
}