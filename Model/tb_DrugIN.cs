using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tb_DrugIN
    {
        public tb_DrugIN()
        { }
        #region Model
        private int _id;
        private int? _drugid;
        private string _drugcode;
        private DateTime? _enterdate;
        private decimal? _amount;
        private string _putarea;
        private bool _ismsds;
        private string _remark;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
        private string _temp1;
        private string _temp2;
        private DateTime? _productdate;
        private DateTime? _validdate;
        private string _manufacturers;
        private string _gps;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 药品
        /// </summary>
        public int? drugId
        {
            set { _drugid = value; }
            get { return _drugid; }
        }
        /// <summary>
        /// 编码
        /// </summary>
        public string drugCode
        {
            set { _drugcode = value; }
            get { return _drugcode; }
        }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime? EnterDate
        {
            set { _enterdate = value; }
            get { return _enterdate; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string putArea
        {
            set { _putarea = value; }
            get { return _putarea; }
        }
        /// <summary>
        /// 是否建立MSDS
        /// </summary>
        public bool isMSDS
        {
            set { _ismsds = value; }
            get { return _ismsds; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UpdateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
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
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? productDate
        {
            set { _productdate = value; }
            get { return _productdate; }
        }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime? validDate
        {
            set { _validdate = value; }
            get { return _validdate; }
        }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string manufacturers
        {
            set { _manufacturers = value; }
            get { return _manufacturers; }
        }
        /// <summary>
        /// 定位信息
        /// </summary>
        public string GPS
        {
            set { _gps = value; }
            get { return _gps; }
        }
        #endregion
    }
}

