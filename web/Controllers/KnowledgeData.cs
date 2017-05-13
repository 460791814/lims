using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DictManage;
using BLL.DictManage;
using BLL.RoleManage;
using Model.RoleManage;
using BLL.Laboratory;
using Model.Laboratory;

namespace Web.Controllers
{
    public class KnowledgeData
    {
        T_tb_TypeDict tTypeDict = new T_tb_TypeDict();
        T_tb_Area tArea = new T_tb_Area();
        T_tb_Laboratory tLaboratory = new T_tb_Laboratory();

        /// <summary>
        /// 获取类别字典下拉菜单数据
        /// </summary>
        /// <param name="IsSearch">是否为查询项</param>
        /// <param name="SubjectID">类别类型ID（1：公告类别 2:项目类别）</param>
        /// <returns></returns>
        public SelectList GetTypeDictList(bool IsSearch,int SubjectID)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (IsSearch)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
            }
            List<E_tb_TypeDict> TempList = tTypeDict.GetModelList("SubjectID=" + SubjectID);
            foreach (E_tb_TypeDict eTypeDict in TempList)
            {
                list.Add(new SelectListItem() { Text = eTypeDict.TypeName, Value = eTypeDict.TypeID.ToString() });
            }
            list.First().Selected = true;
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 获取区域字典下拉菜单数据
        /// </summary>
        /// <param name="IsSearch"></param>
        /// <returns></returns>
        public SelectList GetAreaList(bool IsSearch)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (IsSearch)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
            }
            List<E_tb_Area> TempList = tArea.GetModelList("");
            foreach (E_tb_Area eTypeDict in TempList)
            {
                list.Add(new SelectListItem() { Text = eTypeDict.AreaName, Value = eTypeDict.AreaID.ToString() });
            }
            list.First().Selected = true;
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 获取区域字典下拉菜单数据
        /// </summary>
        /// <param name="IsSearch"></param>
        /// <returns></returns>
        public SelectList GetLaboratoryList(bool IsSearch)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (IsSearch)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
            }
            List<E_tb_Laboratory> TempList = tLaboratory.GetModelList("");
            foreach (E_tb_Laboratory eTypeDict in TempList)
            {
                list.Add(new SelectListItem() { Text = eTypeDict.LaboratoryName, Value = eTypeDict.LaboratoryID.ToString() });
            }
            list.First().Selected = true;
            return new SelectList(list, "Value", "Text");
        }

        /// <summary>
        /// 获取区域字典下拉菜单数据
        /// </summary>
        /// <param name="IsSearch"></param>
        /// <returns></returns>
        public SelectList GetIsOrNo(bool IsSearch)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (IsSearch)
            {
                list.Add(new SelectListItem() { Text = "请选择", Value = "-1", Selected = true });
            }
            list.Add(new SelectListItem() { Text = "否", Value = "0" });
            list.Add(new SelectListItem() { Text = "是", Value = "1" });
            list.First().Selected = true;
            return new SelectList(list, "Value", "Text");
        }

    }
}