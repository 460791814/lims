using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.News
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public partial class E_tb_News
    {
        public E_tb_News()
        { }
        #region Model
        private int _newid;
        private int? _newtypeid;
        private string _title;
        private string _contents;
        private int? _areaid;
        private int? _editpersonnelid;
        private DateTime? _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public int NewID
        {
            set { _newid = value; }
            get { return _newid; }
        }
        /// <summary>
        /// 新闻类型（1：公司动态 2：公告通知）
        /// </summary>
        public int? NewTypeID
        {
            set { _newtypeid = value; }
            get { return _newtypeid; }
        }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 新闻内容
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
        /// 编辑用户ID
        /// </summary>
        public int? EditPersonnelID
        {
            set { _editpersonnelid = value; }
            get { return _editpersonnelid; }
        }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model

        #region 数据接口
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }

        /// <summary>
        /// 新闻类别名称
        /// </summary>
        public string TypeName { get; set; }
        #endregion
    }
}
