using System;

namespace Model
{
    /// <summary>
    /// 计算检定
    /// </summary>
    [Serializable]
    public partial class tb_Measure
    {
        public tb_Measure()
        { }
        #region Model
        private int _id;
        private string _devicename;
        private string _standard;
        private string _assetcode;
        private string _devicecode;
        private DateTime? _buydate;
        private DateTime? _usedate;
        private decimal? _ovalue;
        private int? _deperciation;
        private int? _periodverification;
        private DateTime? _lastverification;
        private string _verification;
        private DateTime? _nextverification;
        private string _technologystate;
        private string _problem;
        private string _usecompany;
        private string _useperson;
        private int? _createuser;
        private DateTime? _createdate;
        private int? _updateuser;
        private DateTime? _updatedate;
        private string _temp1;
        private string _temp2;
        private string _companyname;
        private string _verificationcompany;
        private string _phonenumber;
        private string _isdevice;
        private string _measuretype;
        private int _device_Id;

        public int Device_Id
        {
            get { return _device_Id; }
            set { _device_Id = value; }
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
        /// 设备名称
        /// </summary>
        public string deviceName
        {
            set { _devicename = value; }
            get { return _devicename; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string standard
        {
            set { _standard = value; }
            get { return _standard; }
        }
        /// <summary>
        /// 资产编号
        /// </summary>
        public string assetCode
        {
            set { _assetcode = value; }
            get { return _assetcode; }
        }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string deviceCode
        {
            set { _devicecode = value; }
            get { return _devicecode; }
        }
        /// <summary>
        /// 购置日期
        /// </summary>
        public DateTime? buyDate
        {
            set { _buydate = value; }
            get { return _buydate; }
        }
        /// <summary>
        /// 启用日期
        /// </summary>
        public DateTime? useDate
        {
            set { _usedate = value; }
            get { return _usedate; }
        }
        /// <summary>
        /// 原值
        /// </summary>
        public decimal? oValue
        {
            set { _ovalue = value; }
            get { return _ovalue; }
        }
        /// <summary>
        /// 折旧年限
        /// </summary>
        public int? deperciation
        {
            set { _deperciation = value; }
            get { return _deperciation; }
        }
        /// <summary>
        /// 检定周期
        /// </summary>
        public int? periodVerification
        {
            set { _periodverification = value; }
            get { return _periodverification; }
        }
        /// <summary>
        /// 上次检定日期
        /// </summary>
        public DateTime? lastVerification
        {
            set { _lastverification = value; }
            get { return _lastverification; }
        }
        /// <summary>
        /// 检定结论
        /// </summary>
        public string verification
        {
            set { _verification = value; }
            get { return _verification; }
        }
        /// <summary>
        /// 下次检定日期
        /// </summary>
        public DateTime? nextVerification
        {
            set { _nextverification = value; }
            get { return _nextverification; }
        }
        /// <summary>
        /// 技术状况
        /// </summary>
        public string technologyState
        {
            set { _technologystate = value; }
            get { return _technologystate; }
        }
        /// <summary>
        /// 存在问题
        /// </summary>
        public string problem
        {
            set { _problem = value; }
            get { return _problem; }
        }
        /// <summary>
        /// 使用单位
        /// </summary>
        public string useCompany
        {
            set { _usecompany = value; }
            get { return _usecompany; }
        }
        /// <summary>
        /// 使用人
        /// </summary>
        public string usePerson
        {
            set { _useperson = value; }
            get { return _useperson; }
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
        /// <summary>
        /// 单位名称
        /// </summary>
        public string companyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 检测单位
        /// </summary>
        public string verificationCompany
        {
            set { _verificationcompany = value; }
            get { return _verificationcompany; }
        }
        /// <summary>
        /// 联系号码
        /// </summary>
        public string phoneNumber
        {
            set { _phonenumber = value; }
            get { return _phonenumber; }
        }
        /// <summary>
        /// 是否设备
        /// </summary>
        public string isDevice
        {
            set { _isdevice = value; }
            get { return _isdevice; }
        }
        /// <summary>
        /// 计量类型（计算、送检、自校）
        /// </summary>
        public string measureType
        {
            set { _measuretype = value; }
            get { return _measuretype; }
        }
        #endregion Model
    }
}
