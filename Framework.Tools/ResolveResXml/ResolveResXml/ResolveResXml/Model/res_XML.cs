using System;
namespace ResolveResXml.Model
{
    /// <summary>
    /// 实体类res_XML 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class res_XML
    {
        public res_XML()
        { }
        #region Model
        private int _id;
        private string _key;
        private string _value;
        private int? _projectid;
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
        public string key
        {
            set { _key = value; }
            get { return _key; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value
        {
            set { _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? projectId
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        #endregion Model

    }
}

