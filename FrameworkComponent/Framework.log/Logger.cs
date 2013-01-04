/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2011-10-18 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Framework.log
{
    class Logger
    {
        private static object falg = new object();
        internal static void WriteFile(string content)
        {
            try
            {
                string path = Configuration.LogSection.LogFilePath;

                if (string.IsNullOrEmpty(path))
                    return;

                path = path.Replace("/", @"\");
                if (!path.EndsWith(@"\"))
                    path += @"\";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileName = path + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                lock (falg)
                {
                    File.AppendAllText(fileName, content, Encoding.Default);
                }
            }
            catch
            {

            }
        }

        public static void WriteLog(string content)
        {
            content = content + "\r\n -------------------------" +
            DateTime.Now.ToString() + "-----------------------------------\r\n";
            Logger.WriteFile(content);
        }


        public static void HandleException(Exception e, int errorCode, string message, bool isWriteFile, bool isSendMail)
        {
            try
            {
                string code = errorCode.ToString().PadLeft(4, '0');

                string content = "Exception ---- " + code + " \r\n";
                content += "\t Code:" + code + "\r\n";
                content += "\t Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                content += "\t ApplicationName:" + Logger.GetApplicationName() + "\r\n";
                content += "\t ApplicationPath:" + AppDomain.CurrentDomain.BaseDirectory + "\r\n";
                content += "\t MachineName:" + Environment.MachineName + "\r\n";
                content += "\t UserDomain:" + Environment.UserDomainName + "\r\n";
                content += "\t UserName:" + Environment.UserName + "\r\n";
                content += "\t Information:" + message + "\r\n";
                content += "\t Message:" + e.Message + "\r\n";
                content += "\t Source:" + e.Source + "\r\n";
                content += "\t StackTrace:" + e.StackTrace + "\r\n\r\n";

                if (isWriteFile)
                    Logger.WriteFile(content);

                if (isSendMail)
                    Logger.SendMail(content);
            }
            catch
            {

            }
        }

        private static string GetApplicationName()
        {
            string name = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            if (new FileInfo(name).Extension.ToLower().Replace(".", "").Equals("exe"))
                return name;
            else
                return "";
        }

        internal static void SendMail(string content)
        {
            try
            {
                //EmailService service = new EmailService();
                //service.Url = Configuration.LogSection.EmailServiceUrl;
                //service.SendMail_Text(
                //    Configuration.LogSection.MailFrom,
                //    "",
                //    Configuration.LogSection.MailTo,
                //    "", "",
                //    Configuration.LogSection.MailSubject,
                //    content);
            }
            catch (Exception e)
            {
                Logger.HandleException(e, 101, string.Format("Can Not Send Notification EMail,Please Check EMail Service Configuration!"), true, false);
            }
        }


    }
}
