using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tb_Base
    {
        public tb_Base()
        { }
        #region Model
        private int _id;
        private int? _pid;
        private string _basename;
        private string _temp1;
        private string _temp2;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 父级Id
        /// </summary>
        public int? pId
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string baseName
        {
            set { _basename = value; }
            get { return _basename; }
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

