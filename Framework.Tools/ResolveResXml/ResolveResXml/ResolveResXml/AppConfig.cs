using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ResolveResXml
{
    public class AppConfig
    {
        //读
        public static string GetValue(string AppKey)
        {
            try
            {
                string AppKeyValue;
                AppKeyValue = System.Configuration.ConfigurationManager.AppSettings.Get(AppKey);
                return AppKeyValue;
            }
            catch (Exception ex)
            {
                throw new Exception("配置文件读取错误",ex);
            }
        }
        //读
        public static string GetValue(string AppKey,string defaultValue)
        {
            try
            {
                string AppKeyValue;
                AppKeyValue = System.Configuration.ConfigurationManager.AppSettings.Get(AppKey);
                if (AppKeyValue.Trim()=="")
                {
                    return defaultValue;
                }
                return AppKeyValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SetValue(AppKey, defaultValue);
                return defaultValue;
            }
        }
        //写
        public static void SetValue(string appKey, string appValue)
        {
            System.Configuration.ConfigurationManager.AppSettings.Set(appKey,appValue);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");

            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("value", appValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", appKey);
                xElem2.SetAttribute("value", appValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
        }
        //读取配置文件中所有的Key值
        public static string[] GetKeys()
        {
            try
            {
                string[] AppKeyValue;
                AppKeyValue = System.Configuration.ConfigurationManager.AppSettings.AllKeys;
                return AppKeyValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
