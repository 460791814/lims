<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImg.aspx.cs" Inherits="OnlineClass.Web.TeacherCenter.UploadImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta HTTP-EQUIV="pragma" CONTENT="no-cache">  
    <meta HTTP-EQUIV="Cache-Control" CONTENT="no-cache, must-revalidate">  
    <meta HTTP-EQUIV="expires" CONTENT="0">  
    <title></title>
    <style type="text/css">
        .UpLoadBtn{ width:52px; height:27px; background:url(/Content/Images/images_18.jpg) no-repeat;}
        .UpLoadBtn1{ width:72px; height:27px; background:url(/Content/Images/images_19.jpg) no-repeat 0px 0px;}
        .UpLoadBtn2{ width:72px; height:27px; background:url(/Content/Images/images_19.jpg) no-repeat 0px -27px;}
    </style>
    <link href="../css/Main.css" rel="stylesheet" type="text/css" />
    <link href="/Js/uploadifyAuth/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="/Js/jquery.js" type="text/javascript"></script>
    <script src="/Js/uploadifyAuth/jquery.uploadify.min.js?ver=<%=(new Random()).Next(0, 99999999).ToString() %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#fileinput").uploadify({
                "auto": true,
                "buttonClass": 'UpLoadBtn2',
                "buttonCursor": "hand",     // arrow、hand
                "buttonImage": null,
                "buttonText": "", //浏览
                "checkExisting": false,     // 检查文件是否存在的处理程序url
                "debug": false,
                "fileObjName": "fileinput",      // 请求文件名称
                "fileSizeLimit": "2MB",     // 文件大小限制 100KB
                "fileTypeDesc": "请选择文件",     // 选择文件框说明
                "fileTypeExts": "*.jpg; *.gif;*.jpeg;*.png;*.doc;*.docx;*.pdf;*.xls;*.xlsx;*.zip;*.rar",
                "formData": {},      // 表单数据
                "height": 20,
                "width": 125,
                "itemTemplate": false,      // 文件上传队列html（文件参数：${instanceID}、${fileID}、${fileName}、${fileSize}）
                "method": "post",
                "multi": false,
                "overrideEvents": ["onSelectError", "onDialogOpen", "onDialogClose"/**/],       // 重写的事件 ["onUploadProgress"]
                "preventCaching": true,
                "progressData": "percentage",       // speed、percentage
                "queueID": false,       // 队列标签ID
                "swf": "/Scripts/uploadify/uploadify.swf",
                "uploader": "UploadHandler.ashx",     // 上传处理程序的url
                "onUploadSuccess": function (file, data, response) {
                
                    if (data == "1") {
                        alert("请上传小于2M的图片");
                    } else if (data == "2") {
                        alert("文件格式不正确！");
                    } else {
                        if ('<%=Request["FileType"] %>' == "1") { //文件上传
                            $("#upFileName").html(data);
                        }
                        else {
                            $("#imgID").attr("src", "/UpFile/" + data); //图片上传
                        }
                        parent.SetVal('<%=Request["hidid"] %>', data);
                    }
                },
                "onUploadError": function (file, errorCode, errorMsg, errorString) {
                    alert(errorMsg + "///");
                }
            });

            $("#fileinput").removeAttr("style");
            $("#fileinput-button").removeAttr("style").removeClass("uploadify-button");
        });
    </script>
</head>
<body style=" background-color:transparent;">
    <form method="post" action="/UploadFile/UploadHandler.ashx">

    <%if (Request["FileType"].ToString() == "1")
      {
      %>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="left">
                    <span id="upFileName" style=" float:left;"><%=Request["filepath"]%></span>
                    <div style=" clear:both; height:5px;"></div>
                    <input type="file" id="fileinput" name="fileinput" />
                </td>
            </tr>
        </table>
      <%}else {%>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width:160px;">
                <div style="border:1px solid #ccc; width:150px; height:89px;">
                <img id="imgID" src="<%=Request["filepath"]==""?"/Content/Images/images_15.jpg":Request["filepath"] %>" width="150" height="89">
                </div>
            </td>
            <td align="left">
                <input type="file" id="fileinput" name="fileinput" />
            </td>
        </tr>
    </table>
    <%}%>
    </form>
</body>
</html>
