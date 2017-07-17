<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockStatus.aspx.cs" Inherits="WebApplication1.MagWeb.StockStatus" %>

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
    <link href="../css/StockStatus.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="top">
            <ul>
                   <li>选择库房</li>
                   <li>
                        <select id="Sheng"></select> 
                   </li>
                   <li>选择库区</li>
                       <li>
                  <select id="Shi"></select>
                   </li>
                   <li> <input type="button" name="name" id="StockID" value="查询" /></li>
            </ul>
        </div>
        <h2 style="margin-left:300px; margin-bottom:50px;">库存情况</h2>
      <div id="box">
      </div>
        <script type="text/javascript">
            $("#box").datagrid({
                url: "Handler/StockStatusinfo.ashx",
                columns: [[
                { "title": "库房", "field": "HouseName", width: 120, "align": "center" },
                { "title": "库区", "field": "SubareaName", width: 100, "align": "center" },
                { "title": "商品编号", "field": "productID", width: 100, "align": "center" },
                 { "title": "商品名称", "field": "ProductName", width: 100, "align": "center" },
                { "title": "库存上限", "field": "uplimit", width: 100, "align": "center" },
                { "title": "库存下限", "field": "downlimit", width: 100, "align": "center" },
                { "title": "成本", "field": "Cost", width: 100, "align": "center" },
                { "title": "库存量", "field": "num", width: 100, "align": "center" }
                ]],
                height: 300,
                width: 1000,
                pagination: true,
                fitColumns: true,
                pageList: [10, 20, 30],
                pageSize: 10,
            })
            $("#StockID").click(function () {
                var storename = $("#Sheng").combobox("getText");
                var subname = $("#Shi").combobox("getText");
                console.info(storename + subname)
                $("#box").datagrid({
                    url: "Handler/StockStatuStorename.ashx?storeName=" + storename + "&Subname=" + subname,
                    columns: [[
                    { "title": "库房", "field": "HouseName", width: 120, "align": "center" },
                    { "title": "库区", "field": "SubareaName", width: 100, "align": "center" },
                    { "title": "商品编号", "field": "productID", width: 100, "align": "center" },
                     { "title": "商品名称", "field": "ProductName", width: 100, "align": "center" },
                    { "title": "库存上限", "field": "uplimit", width: 100, "align": "center" },
                    { "title": "库存下限", "field": "downlimit", width: 100, "align": "center" },
                    { "title": "成本", "field": "Cost", width: 100, "align": "center" },
                    { "title": "库存量", "field": "num", width: 100, "align": "center" }
                    ]],
                    height: 300,
                    width: 1000,
                    pagination: true,
                    fitColumns: true,
                    pageList: [10, 20, 30],
                    pageSize: 10,
                })
            })
            $("#Sheng").combobox({
                width: 80,
                url: "Handler/StockComboboxA.ashx",
                valueField: "HouseID",
                textField: "HouseName",
                onLoadSuccess: function () {
                    $("#Sheng").combobox('select', 1);
                },
            })
            $("#Sheng").combobox({
                onChange: function () {
                    $("#Shi").combobox({
                        width: 80,
                        url: "Handler/StockStatusa.ashx?a=" + $("#Sheng").combobox("getValue"),
                        valueField: "HouseID",
                        textField: "SubareaName",
                        onLoadSuccess: function () {
                        },
                    })
                }
            })

        </script>
    </form>
</body>
</html>

