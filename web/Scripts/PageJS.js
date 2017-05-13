var PageInfo = "";
    
    //删除
    function Delete(InfoID) {
        if (confirm("确定要删除数据吗？")) {
            $.getJSON("/" + PageInfo + "/Delete/" + InfoID,
            function (data) {
                alert(data);
                if (data == "删除成功！") {
                    $('#dgtable').datagrid('reload');
                }
            });
        }
    }
    //查询
    function click_Search() {
        var txts = $("#txt_Search").val();
        $('#dgtable').datagrid('options').url = "/" + PageInfo + "/GetList?pageNumber=1&pageSize=8&StrSearch=" + txts;
        $("#dgtable").datagrid("reload");
    }

    //添加
    function Add() {
        $('#EditForms').window({ href: "/" + PageInfo + "/" + PageInfo + "Edit?EditType=Add" });
        $('#EditForms').window('refresh');
        $('#EditForms').window('open');
    }

    //弹出编辑页
    function Edit(InfoID) {
        $('#EditForms').window({ href: "/" + PageInfo + "/" + PageInfo + "Edit?EditType=Edit&InfoID=" + InfoID });
        $('#EditForms').window('refresh');
        $('#EditForms').window('open');
    }

    //关闭弹出层
    function Close() {
        $('#EditForms').window('close');
    }

    //保存提示
    function handle(e) {
        if (e == "1") {
            alert("保存成功！");
            $('#EditForms').window('close');
            $('#dgtable').datagrid('reload');
        } else {
            alert("保存失败！");
        }
    }

    function failed(e) {
        alert("保存失败！");
    }