using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.OriginalRecord
{
    /// <summary>
    /// tb_RecordSample:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_RecordSample
    {
        public E_tb_RecordSample()
        { }
        #region Model
        private int _recordsampleid;
        private int? _recordid;
        private string _recordfilepath;
        private int? _sampleid;
        private string _samplename;
        private decimal? _result;
        /// <summary>
        /// 
        /// </summary>
        public int RecordSampleID
        {
            set { _recordsampleid = value; }
            get { return _recordsampleid; }
        }
        /// <summary>
        /// 原始记录ID
        /// </summary>
        public int? RecordID
        {
            set { _recordid = value; }
            get { return _recordid; }
        }
        /// <summary>
        /// 原始记录文件路径
        /// </summary>
        public string RecordFilePath
        {
            set { _recordfilepath = value; }
            get { return _recordfilepath; }
        }
        /// <summary>
        /// 样品编号
        /// </summary>
        public int? SampleID
        {
            set { _sampleid = value; }
            get { return _sampleid; }
        }
        /// <summary>
        /// 样品名称
        /// </summary>
        public string SampleName
        {
            set { _samplename = value; }
            get { return _samplename; }
        }
        /// <summary>
        /// 计算结果
        /// </summary>
        public decimal? Result
        {
            set { _result = value; }
            get { return _result; }
        }
        #endregion Model

        #region 扩展属性
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID { get; set; }
            

        #endregion
    }
}
