using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Data;

namespace Common
{
    /// <summary>
    /// 页面工具类
    /// 作者：小朱
    /// </summary>
    public static class PageTools
    {
        public static string AddWhere(string OldWhere, string StrWhere)
        {
            OldWhere +=(OldWhere.Length > 0 ? " and " : "") + StrWhere;
            return OldWhere;
        }

        /// <summary>
        /// 加载下拉框数据
        /// </summary>
        /// <returns></returns>
        public static SelectList GetSelectList(DataTable dt, string CloumValue, string CloumName, bool IsSearch)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (IsSearch)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
            }
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new SelectListItem() { Text = row[CloumName].ToString(), Value = row[CloumValue].ToString() });
            }
            if (list != null && list.Count > 0)
            {
                list.First().Selected = true;
            }
            return new SelectList(list, "Value", "Text");
        }
    }
}
