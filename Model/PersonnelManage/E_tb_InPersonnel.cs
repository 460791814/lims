using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.PersonnelManage
{
    /// <summary>
    /// 内部员工
    /// </summary>
    [Serializable]
    public partial class E_tb_InPersonnel
    {
        public E_tb_InPersonnel()
        { }
        #region Model
        private int _personnelid;
        private int? _areaid;
        private string _personnelname;
        private string _department;
        private string _sex;
        private DateTime? _birthday;
        private string _educational;
        private string _title;
        private string _post;
        private string _workingtime;
        private string _description;
        private string _tel;
        private string _cid;
        private string _username;
        private string _password;
        /// <summary>
        /// 
        /// </summary>
        public int PersonnelID
        {
            set { _personnelid = value; }
            get { return _personnelid; }
        }
        /// <summary>
        /// 实验室ID(区域)
        /// </summary>
        public int? AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string PersonnelName
        {
            set { _personnelname = value; }
            get { return _personnelname; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string Educational
        {
            set { _educational = value; }
            get { return _educational; }
        }
        /// <summary>
        /// 职称
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 岗位
        /// </summary>
        public string Post
        {
            set { _post = value; }
            get { return _post; }
        }
        /// <summary>
        /// 工作时间
        /// </summary>
        public string WorkingTime
        {
            set { _workingtime = value; }
            get { return _workingtime; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        public string CID
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
        #endregion Model

        #region 数据接口
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }


        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }


        /// <summary>
        /// 角色IDS 集合
        /// </summary>
        public string RoleIDS { get; set; }


        /// <summary>
        /// 数据范围 (1:全部、2：区域、3：个人)
        /// </summary>
        public int DataRange { get; set; }
        #endregion

    }
}
