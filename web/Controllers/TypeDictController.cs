using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DictManage;
using System.Text;
using System.Data;
using BLL.DictManage;

namespace Web.Controllers
{
    public class TypeDictController : Controller
    {
        T_tb_TypeDict tTypeDict = new T_tb_TypeDict();

        //
        // GET: /TypeDict/
        /// <summary>
        /// 类别字典列表
        /// </summary>
        /// <param name="eTypeDict">类别实体</param>
        /// <returns></returns>
        public ActionResult TypeDictList(E_tb_TypeDict eTypeDict)
        {
            //一级模板
            string LoopTemplate = @"<ul id='row1'>
                                        <li class='WidthID'>{$id}</li>
                                        <li class='WidthName'>{$imglist}<a href='javascript:void(0);' onclick='rowView({$id})'><img src='{$IcoImg}' id='Icon{$id}'/>{$TypeName}</a></li>
                                        <li class='WidthOperate'>
                                            <a href='javascript:void(0);' onclick='Add({$id})'>添加子类</a> | 
                                            <a href='javascript:void(0);' onclick='Edit({$id})'>修改</a> | 
                                            <a href='javascript:void(0);' onclick='Delete({$id})'>删除</a>
                                        </li>
                                    </ul>";
            //子模板
            string SubTemplate = "<div class='displaynone' id='SubItem{0}'>{1}</div>";

            StringBuilder TypeHtml = new StringBuilder();
            DataRow[] RowList = tTypeDict.GetList("ParentID=0 and SubjectID=" + eTypeDict.SubjectID).Tables[0].Select();
            string SubTypeHtml = AddTypeHtml(RowList, LoopTemplate, SubTemplate);
            TypeHtml.Append(SubTypeHtml);
            ViewData["TypeHtml"]=TypeHtml.ToString();
            return View(eTypeDict);
        }

        /// <summary>
        /// 添加子类HTML
        /// </summary>
        /// <param name="RowList"></param>
        /// <param name="Template"></param>
        /// <returns></returns>
        public string AddTypeHtml(DataRow[] RowList, string Template, string SubTemplate)
        {
            StringBuilder TypeHtml = new StringBuilder();
            for (int i = 0; i < RowList.Length; i++)
            {
                DataRow row = RowList[i];
                bool IsExistsSubItem = (tTypeDict.GetList("ParentID=" + row["TypeID"]).Tables[0].Select().Count() > 0);
                bool IsEnd = (i == RowList.Length - 1);
                TypeHtml.Append(this.AddTypeHtml(row, Template, IsExistsSubItem, IsEnd));
                if (IsExistsSubItem)
                {
                    string SubTypeHtml = AddTypeHtml(tTypeDict.GetList("ParentID=" + row["TypeID"]).Tables[0].Select(), Template, SubTemplate);
                    TypeHtml.AppendFormat(SubTemplate, row["TypeID"].ToString(), SubTypeHtml);
                }
            }
            return TypeHtml.ToString();
        }


        /// <summary>
        /// 添加子类HTML
        /// </summary>
        /// <param name="TypeRow"></param>
        /// <param name="Template"></param>
        /// <returns></returns>
        public string AddTypeHtml(DataRow TypeRow, string Template, bool IsExistsSubItem, bool IsEnd)
        {
            StringBuilder SubTypeHtml = new StringBuilder();
            Template = Template.Replace("{$id}", TypeRow["TypeID"].ToString());
            Template = Template.Replace("{$TypeName}", TypeRow["TypeName"].ToString());
            Template = Template.Replace("{$IcoImg}", IsExistsSubItem ? "/Content/Images/Tree/folder4.gif" : "/Content/Images/Tree/folder3.gif");
            StringBuilder strimg = new StringBuilder();
            int level = Convert.ToInt32(TypeRow["TypeLevel"].ToString());
            if (level > 0)
            {
                for (int i = 0; i < level - 1; i++)
                {
                    strimg.Append("<img src='/Content/Images/Tree/line3.gif' />");
                }
                strimg.Append("<img src='/Content/Images/Tree/line" + (IsEnd ? "2" : "1") + ".gif' />");
            }

            Template = Template.Replace("{$imglist}", strimg.ToString());
            SubTypeHtml.Append(Template);
            return SubTypeHtml.ToString();
        }

        /// <summary>
        /// 显示详情页
        /// </summary>
        /// <param name="EditType">编辑类型</param>
        /// <returns>返回编辑结果</returns>
        public JsonResult TypeDictEdit(E_tb_TypeDict eTypeDict, string EditType, int? InfoID)
        {
            if (EditType == "Edit")
            {
                eTypeDict = tTypeDict.GetModel(Convert.ToInt32(InfoID));
            }
            eTypeDict.EditType = EditType;
            return Json(eTypeDict, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除实验室信息
        /// 作者：小朱
        /// </summary>
        /// <param name="InfoID">要删除的实验室</param>
        /// <returns>返回是否删除成功</returns>
        public JsonResult Delete(int id)
        {
            string str = "";
            if (tTypeDict.GetList("ParentID=" + id).Tables[0].Rows.Count > 0)
            {
                str = "删除失败！";
            }
            else
            {
                str = (tTypeDict.Delete(id)) ? "删除成功！" : "删除失败！";
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存类别信息
        /// 作者：小朱
        /// </summary>
        /// <param name="eNews">要处理的对象</param>
        /// <returns>返回是否处理成功</returns>
        public string Save(E_tb_TypeDict eTypeDict)
        {
            string msg = "0";
            if (eTypeDict.EditType == "Add")
            {
                eTypeDict.TypeLevel = 0;
                if (eTypeDict.ParentID > 0)
                {
                    eTypeDict.TypeLevel = tTypeDict.GetModel(eTypeDict.ParentID).TypeLevel + 1;
                }
                tTypeDict.Add(eTypeDict);
                msg = "1";
            }
            else
            {
                tTypeDict.Update(eTypeDict);
                msg = "1";
            }
            return msg;
        }
    }
}
