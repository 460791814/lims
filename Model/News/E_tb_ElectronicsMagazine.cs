using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.News
{
    /// <summary>
    /// tb_ElectronicsMagazine:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_ElectronicsMagazine
    {
        public E_tb_ElectronicsMagazine()
        { }
        #region Model
        private int _magazineid;
        private string _magazinename;
        private string _imgpath;
        private string _fliepath;
        private int? _magazinetypeid;
        private DateTime? _addtime;
        private int? _areaid;
        private int? _editpersonnelid;
        /// <summary>
        /// 
        /// </summary>
        public int MagazineID
        {
            set { _magazineid = value; }
            get { return _magazineid; }
        }
        /// <summary>
        /// 杂志名称
        /// </summary>
        public string MagazineName
        {
            set { _magazinename = value; }
            get { return _magazinename; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgPath
        {
            set { _imgpath = value; }
            get { return _imgpath; }
        }
        /// <summary>
        /// 杂志文件（PDF）
        /// </summary>
        public string FliePath
        {
            set { _fliepath = value; }
            get { return _fliepath; }
        }
        /// <summary>
        /// 杂志类型（1：年刊、2：月刊）
        /// </summary>
        public int? MagazineTypeID
        {
            set { _magazinetypeid = value; }
            get { return _magazinetypeid; }
        }
        /// <summary>
        /// 上传日期
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
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

        /// <summary>
        /// 上一页索引
        /// </summary>
        public string PageHtml { get; set; }
        #endregion
    }
}
