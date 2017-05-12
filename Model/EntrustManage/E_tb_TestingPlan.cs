using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.EntrustManage
{
    /// <summary>
    /// tb_TestingPlan:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_TestingPlan
    {
        public E_tb_TestingPlan()
        { }
        #region Model
        private int _testid;
        private string _planname;
        private string _version;
        private string _controllednum;
        private string _department;
        private string _weavepersonnel;
        private DateTime? _weavetime;
        private string _remark;
        private string _filepath;
        private int? _areaid;
        private int? _editpersonnelid;
        /// <summary>
        /// 
        /// </summary>
        public int TestID
        {
            set { _testid = value; }
            get { return _testid; }
        }
        /// <summary>
        /// 计划名称
        /// </summary>
        public string PlanName
        {
            set { _planname = value; }
            get { return _planname; }
        }
        /// <summary>
        /// 版本
        /// </summary>
        public string Version
        {
            set { _version = value; }
            get { return _version; }
        }
        /// <summary>
        /// 受控号
        /// </summary>
        public string ControlledNum
        {
            set { _controllednum = value; }
            get { return _controllednum; }
        }
        /// <summary>
        /// 编制单位
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 编辑人
        /// </summary>
        public string WeavePersonnel
        {
            set { _weavepersonnel = value; }
            get { return _weavepersonnel; }
        }
        /// <summary>
        /// 编制日期
        /// </summary>
        public DateTime? WeaveTime
        {
            set { _weavetime = value; }
            get { return _weavetime; }
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
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
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
