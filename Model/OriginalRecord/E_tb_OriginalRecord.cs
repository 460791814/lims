using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.OriginalRecord
{
    /// <summary>
    /// 原始记录
    /// </summary>
    [Serializable]
    public partial class E_tb_OriginalRecord
    {
        public E_tb_OriginalRecord()
        { }
        #region Model
        private int _recordid;
        private int? _projectid;
        private string _taskno;
        private DateTime? _detecttime;
        private int? _detectpersonnelid;
        private string _filepath;
        private string _contents;
        private int? _areaid;
        private int? _editpersonnelid;
        private int? _sampleid;
        private string _insStand;

        public string InsStand
        {
            get { return _insStand; }
            set { _insStand = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RecordID
        {
            set { _recordid = value; }
            get { return _recordid; }
        }
        /// <summary>
        /// 项目ID
        /// </summary>
        public int? ProjectID
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 任务单号
        /// </summary>
        public string TaskNo
        {
            set { _taskno = value; }
            get { return _taskno; }
        }
        /// <summary>
        /// 检验日期
        /// </summary>
        public DateTime? DetectTime
        {
            set { _detecttime = value; }
            get { return _detecttime; }
        }
        /// <summary>
        /// 检验人员ID
        /// </summary>
        public int? DetectPersonnelID
        {
            set { _detectpersonnelid = value; }
            get { return _detectpersonnelid; }
        }
        /// <summary>
        /// 文件地址
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
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
        /// <summary>
        /// 样品ID
        /// </summary>
        public int? SampleID
        {
            set { _sampleid = value; }
            get { return _sampleid; }
        }
        #endregion Model

        #region 数据接口
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }

        /// <summary>
        /// 检验人名称
        /// </summary>
        public string DetectPersonnelName { get; set; }
        #endregion

    }
}
