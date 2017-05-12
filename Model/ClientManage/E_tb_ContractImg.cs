using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.ClientManage
{
    /// <summary>
    /// 合同图标
    /// </summary>
    [Serializable]
    public partial class E_tb_ContractImg
    {
        public E_tb_ContractImg()
        { }
        #region Model
        private int _contractimgid;
        private string _title;
        private string _imgpath;
        private string _contents;
        private DateTime? _addtime;
        /// <summary>
        /// 
        /// </summary>
        public int ContractImgID
        {
            set { _contractimgid = value; }
            get { return _contractimgid; }
        }
        /// <summary>
        /// 图片标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
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
        /// 图片说明
        /// </summary>
        public string Contents
        {
            set { _contents = value; }
            get { return _contents; }
        }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model

        #region 扩展属性
        /// <summary>
        /// 编辑类型
        /// </summary>
        public string EditType { get; set; }
        #endregion

    }
}
