using System;
using System.Collections.Generic;
namespace ResolveResXml.Model
{
    /// <summary>
    /// 实体类res_project 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class res_project
    {
        public res_project()
        { }
        #region Model
        private int _id;
        private string _project_name;
        private string _project_countrycode;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string project_Name
        {
            set { _project_name = value; }
            get { return _project_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string project_CountryCode
        {
            set { _project_countrycode = value; }
            get { return _project_countrycode; }
        }
        #endregion Model

        private List<res_XML> _res_xmls;
        /// <summary>
        /// 子类 
        /// </summary>
        public List<res_XML> res_XMLs
        {
            set { _res_xmls = value; }
            get { return _res_xmls; }
        }

    }
   
}

