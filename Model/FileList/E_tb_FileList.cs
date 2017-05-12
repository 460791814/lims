using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.FileList
{
    /// <summary>
    /// tb_FileList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_FileList
    {
        public E_tb_FileList()
        { }
        #region Model
        private int _fileid;
        private int? _filetype;
        private int? _parentid;
        private string _filename;
        private string _filepath;
        /// <summary>
        /// 
        /// </summary>
        public int FileID
        {
            set { _fileid = value; }
            get { return _fileid; }
        }
        /// <summary>
        /// 文件类型（1：人员资质）
        /// </summary>
        public int? FileType
        {
            set { _filetype = value; }
            get { return _filetype; }
        }
        /// <summary>
        /// 父内容ID
        /// </summary>
        public int? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 文件
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
        }
        #endregion Model

    }
}
