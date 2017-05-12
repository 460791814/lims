using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ShowImage
{
    /// <summary>
	/// tb_ShowImages:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public partial class E_tb_ShowImages
    {
        public E_tb_ShowImages()
        { }
        #region Model
        private int _imgid;
        private int? _imgtypeid;
        private string _imgname;
        private string _imgpath;
        private string _filepath;
        private int? _orderid;
        private int? _areaid;
        private int? _editpersonnelid;
        /// <summary>
        /// 
        /// </summary>
        public int ImgID
        {
            set { _imgid = value; }
            get { return _imgid; }
        }
        /// <summary>
        /// 图片类型ID（1：大图 2：小图）
        /// </summary>
        public int? ImgTypeID
        {
            set { _imgtypeid = value; }
            get { return _imgtypeid; }
        }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImgName
        {
            set { _imgname = value; }
            get { return _imgname; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgPath
        {
            set { _imgpath = value; }
            get { return _imgpath; }
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
        /// 排序ID
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
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
