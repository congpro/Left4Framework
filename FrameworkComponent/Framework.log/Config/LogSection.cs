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
using System.Xml;
using System.Reflection;

namespace Framework.log
{
    internal class LogSection
    {
        private string _logPath = "";
        private string _emailService = "";
        private string _mailFrom = "";
        private string _mailTo = "";
        private string _mailTitle = "";

        internal LogSection(XmlNode section)
        {
            this.LoadData(section);
        }

        private void LoadData(XmlNode section)
        {
            if (section != null)
            {
                PropertyInfo[] pinfos = this.GetType().GetProperties();
                foreach (XmlNode node in section.ChildNodes)
                {
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        string name = node.Attributes["name"].Value.ToLower();
                        string value = node.Attributes["value"].Value;

                        foreach (PropertyInfo pi in pinfos)
                        {
                            if (pi.Name.ToLower().Equals(name))
                            {
                                pi.SetValue(this, Convert.ChangeType(value, pi.PropertyType), null);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public string LogFilePath
        {
            get { return this._logPath; }
            private set { this._logPath = value; }
        }

        public string EmailServiceUrl
        {
            get { return this._emailService; }
            private set { this._emailService = value; }
        }

        public string MailFrom
        {
            get { return this._mailFrom; }
            private set { this._mailFrom = value; }
        }

        public string MailTo
        {
            get { return this._mailTo; }
            private set { this._mailTo = value; }
        }

        public string MailSubject
        {
            get { return this._mailTitle; }
            private set { this._mailTitle = value; }
        }
    }
}
