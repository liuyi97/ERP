<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogWeb.aspx.cs" Inherits="WebApplication1.Sys.LogWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script src="../Script/jquery-1.8.3.min.js"></script>
    <script src="../UI/jquery.easyui.min.js"></script>
    <link href="../UI/themes/icon.css" rel="stylesheet" />
    <link href="../UI/themes/default/easyui.css" rel="stylesheet" />
    <script src="../UI/locale/easyui-lang-zh_CN.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>>系统日志</div>
        <table id="tab"></table>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#tab").datagrid({
                url: "handler/LogALL.ashx",
                columns: [[
                { "title": "编号", "field": "LogID", width: 20, "align": "center" },
                { "title": "群名", "field": "LogTime", width: 20, "align": "center" },
                { "title": "描述", "field": "Description", width: 20, "align": "center" }
                ]],
                width: 600,
                pagination: true,
                fitColumns: true,
                pageList: [10, 20, 30],
                pageSize: 10
            })
        })
    </script>
</body>
</html>
