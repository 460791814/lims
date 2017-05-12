using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class tb_Book
    {
        public tb_Book()
        { }
        #region Model
        private int _id;
        private string _code;
        private string _name;
        private int? _type1;
        private int? _type2;
        private string _author;
        private decimal? _price;
        private int? _num;
        private int? _repertory;
        private int? _status;
        private string _press;
        private string _remark;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
        private string _temp1;
        private string _temp2;
        private string _zhongshu;

        public string zhongshu
        {
            get { return _zhongshu; }
            set { _zhongshu = value; }
        }
        private string _leibie;

        public string leibie
        {
            get { return _leibie; }
            set { _leibie = value; }
        }
        private string _zhuangtai;

        public string zhuangtai
        {
            get { return _zhuangtai; }
            set { _zhuangtai = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 种属
        /// </summary>
        public int? type1
        {
            set { _type1 = value; }
            get { return _type1; }
        }
        /// <summary>
        /// 类别
        /// </summary>
        public int? type2
        {
            set { _type2 = value; }
            get { return _type2; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int? num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 库存
        /// </summary>
        public int? repertory
        {
            set { _repertory = value; }
            get { return _repertory; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 出版社、出处
        /// </summary>
        public string press
        {
            set { _press = value; }
            get { return _press; }
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? createUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? updateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string temp1
        {
            set { _temp1 = value; }
            get { return _temp1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string temp2
        {
            set { _temp2 = value; }
            get { return _temp2; }
        }
        #endregion Model

    }
}