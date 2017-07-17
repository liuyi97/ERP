<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t_ProductsStock.aspx.cs" Inherits="WebApplication1.MagWeb.t_ProductsStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../UI/jquery.min.js"></script>
    <script src="../UI/jquery.easyui.min.js"></script>   
    <link href="../UI/themes/icon.css" rel="stylesheet" />
    <link href="../UI/themes/default/easyui.css" rel="stylesheet" />
    <script src="../UI/locale/easyui-lang-zh_CN.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        商品编号 ：<input type="text" name="name" id="idtext" value="" />
         <input type="button" name="name" id="btn" value="查询" />
    <div id="box">
    </div>
        <script type="text/javascript">
            $(function () {
                url: ""
                columns: [[
                { "title": "库房", "field": "", width: 120, "align": "center" },
                { "title": "库区", "field": "", width: 100, "align": "center" },
                { "title": "存量", "field": "", width: 120, "align": "center" }
                ]],
                $("#box").datagrid({
                    height: 300,
                    width: 800,
                    pagination: true,
                    fitColumns: true,
                    pageList: [10, 20, 30],
                    pageSize: 10,
                })
                $("#btn").click(function () {
                    var id = $("#idtext").val()
                    $("#box").datagrid({
                        url: "Handler/t_ProductsStockGetID.ashx?id=" + id,
                        columns: [[
                        { "title": "库房", "field": "HouseName", width: 120, "align": "center" },
                        { "title": "库区", "field": "SubareaName", width: 100, "align": "center" },
                        { "title": "存量", "field": "num", width: 120, "align": "center" }
                        ]],
                        height: 300,
                        width: 800,
                        pagination: true,
                        fitColumns: true,
                        pageList: [10, 20, 30],
                        pageSize: 10,
                    })
                })
            })
        </script>
    </form>
</body>
</html>
