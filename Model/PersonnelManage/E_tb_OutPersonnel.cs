using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.PersonnelManage
{
    /// <summary>
    /// tb_OutPersonnel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_OutPersonnel
    {
        public E_tb_OutPersonnel()
        { }
        #region Model
        private int _personnelid;
        private string _personnelname;
        private string _department;
        private string _sex;
        private string _reason;
        private DateTime? _starttime;
        private DateTime? _endtime;
        private string _remark;
        private string _tel;
        private int? _areaid;
        private int? _editpersonnelid;
        private string _work_type;

        /// <summary>
        /// 类型
        /// </summary>
        public string Work_type
        {
            get { return _work_type; }
            set { _work_type = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PersonnelID
        {
            set { _personnelid = value; }
            get { return _personnelid; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string PersonnelName
        {
            set { _personnelname = value; }
            get { return _personnelname; }
        }
        /// <summary>
        /// 所属部门
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
        /// 事由
        /// </summary>
        public string Reason
        {
            set { _reason = value; }
            get { return _reason; }
        }
        /// <summary>
        /// 进入时间
        /// </summary>
        public DateTime? StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 离开时间
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        /// 区域ID
        /// </summary>
        public int? AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 编辑用户
        /// </summary>
        public int? EditPersonnelID
        {
            set { _editpersonnelid = value; }
            get { return _editpersonnelid; }
        }
        #endregion Model

        #region 数据接口
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }
        #endregion

    }
}
