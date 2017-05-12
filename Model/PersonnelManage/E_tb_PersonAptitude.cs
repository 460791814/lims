using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// tb_PersonAptitude:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class E_tb_PersonAptitude
    {
        public E_tb_PersonAptitude()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _sex;
        private string _tel;
        private int? _post;
        private string _phone;
        private DateTime? _birthdate;
        private string _certificate;
        private int? _areaid;
        private int? _editpersonnelid;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 职务
        /// </summary>
        public int? Post
        {
            set { _post = value; }
            get { return _post; }
        }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate
        {
            set { _birthdate = value; }
            get { return _birthdate; }
        }
        /// <summary>
        /// 资质证书
        /// </summary>
        public string Certificate
        {
            set { _certificate = value; }
            get { return _certificate; }
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

        /// <summary>
        /// 职务名称
        /// </summary>
        public string PostName { get; set; }
        #endregion

    }
}
