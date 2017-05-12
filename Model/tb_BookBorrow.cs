using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tb_BookBorrow
    {
        public tb_BookBorrow()
        { }
        #region Model
        private int _id;
        private int _bookid;
        private string _name;
        private int? _daynum;
        private string _company;
        private string _phone;
        private string _idcard;
        private int? _borrownum;
        private int? _backnum;
        private DateTime? _borrowdate;
        private DateTime? _backdate;
        private int? _status;
        private string _remark;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
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
        /// Book表外键
        /// </summary>
        public int bookId
        {
            set { _bookid = value; }
            get { return _bookid; }
        }
        /// <summary>
        /// 借阅人
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 借阅天数
        /// </summary>
        public int? dayNum
        {
            set { _daynum = value; }
            get { return _daynum; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string idCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 借阅数
        /// </summary>
        public int? borrowNum
        {
            set { _borrownum = value; }
            get { return _borrownum; }
        }
        /// <summary>
        /// 归还数
        /// </summary>
        public int? backNum
        {
            set { _backnum = value; }
            get { return _backnum; }
        }
        /// <summary>
        /// 借阅日期
        /// </summary>
        public DateTime? borrowDate
        {
            set { _borrowdate = value; }
            get { return _borrowdate; }
        }
        /// <summary>
        /// 归还日期
        /// </summary>
        public DateTime? backDate
        {
            set { _backdate = value; }
            get { return _backdate; }
        }
        /// <summary>
        /// 状态（1.已归还，2.未归还，3.部分归还）
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        public int? updateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
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