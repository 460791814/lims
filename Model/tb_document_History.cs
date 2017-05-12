using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tb_document_History
    {
        public tb_document_History()
        { }
        #region Model
        private int _id;
        private string _doc_code;
        private string _doc_name;
        private string _doc_guid;
        private int? _direct_id;
        private string _doc_type;
        private string _doc_url;
        private string _doc_size;
        private int? _doc_createuser;
        private int? _doc_updateuser;
        private DateTime? _doc_createdate;
        private DateTime? _doc_updatedate;
        private bool _isdelete;
        private string _doc_revo;
        private string _doc_source;
        private string _doc_path;
        private string _temp1;
        private string _temp2;
        private string _remark;
        private int? _doc_status;
        private string _doc_keyword;
        private int _doc_id;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 文件编码
        /// </summary>
        public string doc_Code
        {
            set { _doc_code = value; }
            get { return _doc_code; }
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string doc_Name
        {
            set { _doc_name = value; }
            get { return _doc_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doc_Guid
        {
            set { _doc_guid = value; }
            get { return _doc_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? direct_Id
        {
            set { _direct_id = value; }
            get { return _direct_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doc_Type
        {
            set { _doc_type = value; }
            get { return _doc_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doc_URL
        {
            set { _doc_url = value; }
            get { return _doc_url; }
        }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string doc_Size
        {
            set { _doc_size = value; }
            get { return _doc_size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? doc_CreateUser
        {
            set { _doc_createuser = value; }
            get { return _doc_createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? doc_UpdateUser
        {
            set { _doc_updateuser = value; }
            get { return _doc_updateuser; }
        }
        /// <summary>
        /// 实施日期
        /// </summary>
        public DateTime? doc_CreateDate
        {
            set { _doc_createdate = value; }
            get { return _doc_createdate; }
        }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? doc_UpdateDate
        {
            set { _doc_updatedate = value; }
            get { return _doc_updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 版本号
        /// </summary>
        public string doc_Revo
        {
            set { _doc_revo = value; }
            get { return _doc_revo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doc_Source
        {
            set { _doc_source = value; }
            get { return _doc_source; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string doc_Path
        {
            set { _doc_path = value; }
            get { return _doc_path; }
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
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int? doc_Status
        {
            set { _doc_status = value; }
            get { return _doc_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string doc_KeyWord
        {
            set { _doc_keyword = value; }
            get { return _doc_keyword; }
        }
        /// <summary>
        /// tb_document主键Id
        /// </summary>
        public int doc_Id
        {
            set { _doc_id = value; }
            get { return _doc_id; }
        }
        #endregion Model

    }
}
