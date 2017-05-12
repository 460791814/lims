using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tb_MSDS
    {
        public tb_MSDS()
        { }
        #region Model
        private int _id;
        private int? _wid;
        private string _filename;
        private string _fileurl;
        private string _filetype;
        private int? _createuser;
        private DateTime? _createdate;
        private string _temp1;
        private string _temp2;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 入库、出库主键ID
        /// </summary>
        public int? wId
        {
            set { _wid = value; }
            get { return _wid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fileUrl
        {
            set { _fileurl = value; }
            get { return _fileurl; }
        }
        /// <summary>
        /// 文件归属
        /// </summary>
        public string fileType
        {
            set { _filetype = value; }
            get { return _filetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? createUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string temp1
        {
            set { _temp1 = value; }
            get { return _temp1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string temp2
        {
            set { _temp2 = value; }
            get { return _temp2; }
        }
        #endregion Model

    }
}