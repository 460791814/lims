using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// tb_Limit:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_Limit
    {
        public tb_Limit()
        { }
        #region Model
        private int _id;
        private string _limittype;
        private int? _limitid;
        private bool _limitread;
        private bool _limitwrite;
        private bool _limitdelete;
        private int? _fileid;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string limitType
        {
            set { _limittype = value; }
            get { return _limittype; }
        }
        /// <summary>
        /// 关联ID
        /// </summary>
        public int? limitId
        {
            set { _limitid = value; }
            get { return _limitid; }
        }
        /// <summary>
        /// 读
        /// </summary>
        public bool limitRead
        {
            set { _limitread = value; }
            get { return _limitread; }
        }
        /// <summary>
        /// 写
        /// </summary>
        public bool limitWrite
        {
            set { _limitwrite = value; }
            get { return _limitwrite; }
        }
        /// <summary>
        /// 删
        /// </summary>
        public bool limitDelete
        {
            set { _limitdelete = value; }
            get { return _limitdelete; }
        }
        /// <summary>
        /// 文件ID
        /// </summary>
        public int? fileId
        {
            set { _fileid = value; }
            get { return _fileid; }
        }
        #endregion Model
    }
}
