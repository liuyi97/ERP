<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t_Inventory.aspx.cs" Inherits="WebApplication1.MagWeb.t_Inventory" %>

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
        <div id="top">
             <input type="button" style="height:40px;width:100px;margin-left:300px" name="name" id="btnsure" value="审核盘点单" />
              <input type="button"  style="height:40px;width:100px;margin-left:30px"  name="name" id="delete" value="删除单据" />
              <input type="button"  style="height:40px;width:100px;margin-left:30px"  name="name" id="insert" value="新添盘点单" />
        </div>
               <div id="middle" style="margin-left:150px">
           单据编号：<input type="text" name="name" id="getid"  value="" />
             <input  type="text" id="put_begin" style="width:100px" class="easyui-datebox" required="required"></input>从
            <input  type="text" id="tb_end" style="width:100px" class="easyui-datebox" required="required"></input>
           状态：  <asp:DropDownList ID="DropDownList1" class="a"  runat="server">
            <asp:ListItem Value="0">全部</asp:ListItem>
            <asp:ListItem Value="2">未审核</asp:ListItem>
            <asp:ListItem Value="1">已审核</asp:ListItem>
        </asp:DropDownList>
           <input type="button" name="btn" id="btn"  value="查询"  />
       </div>
        <h2> 库存盘点</h2>
    <div id="box">
    </div>
         <script type="text/javascript">
             $("#delete").click(function () {
                 var s = "";
                 var big = $("#box").datagrid("getSelections");
                 $.each(big, function (i, item) {
                     s += "'" + item.InventoryID + "'" + ",";
                 })
                 $.ajax({
                     url: "Handler/t_BuyReturnDel.ashx",
                     dataType: "Text",
                     data: "getid=" + s,
                     type: "post",
                     success: function (data) {
                         if (data == "True") {
                             $.messager.alert("删除", "删除成功");
                             getinfo();
                         }
                         else {
                             $.messager.alert("删除", "删除失败");
                         }
                     }
                 })
             })


             $(function () {
                 geeg();
                 $("#btnsure").click(function () {
                     var s = "";
                     var big = $("#box").datagrid("getSelections");
                     $.each(big, function (i, item) {
                         s += "'" + item.InventoryID + "'" + ",";
                     })
                     $.ajax({
                         url: "Handler/t_Inventorysheng.ashx",
                         dataType: "Text",
                         data: "getid=" + s,
                         type: "post",
                         success: function (data) {
                             if (data == "True") {
                                 $.messager.alert("审批成功", "审批成功")
                                 geeg();
                             }
                             else {
                                 $.messager.alert("审批失败", "审批失败");
                             }
                         }
                     })
                 })
             })
             $("#btn").click(function () {
                 var deataid = $(".a").val();
                 var getid = $("#getid").val();
                 var begin = $("#put_begin").val();
                 var end = $("#tb_end").val();
                 $("#box").datagrid({
                     url: "Handler/t_InventoryChaxun.ashx?getid=" + getid + "&begin=" + begin + "&end=" + end + "&deataid=" + deataid,
                     columns: [[
                     { "title": "选择", "field": "ck", checkbox: true, width: 100, "align": "center" },
                     { "title": "盘点单号", "field": "InventoryID", width: 120, "align": "center" },
                     { "title": "创建时间", "field": "CreateDate", width: 100, "align": "center" },
                     { "title": "产品名称", "field": "productName", width: 100, "align": "center" },
                     { "title": "盘点库区", "field": "zugename", width: 100, "align": "center" },
                     { "title": "调整数量", "field": "AdjustNum", width: 100, "align": "center" },
                     { "title": "账面数量", "field": "BillNum", width: 100, "align": "center" },
                     { "title": "实际数量", "field": "RealityNum", width: 100, "align": "center" },
                     {
                     "title": "状态", "field": "StateName", width: 100, "align": "center", formatter: function (value, row, index) {
                     if (row.State == "未审核") {
                         return "<span style='color:red'>" + value + "</span>"
                     }
                     else {
                         return "<span style='color:green'>" + value + "</span>"
                     }
                 }
             }
                     ]],
                     height: 300,
                     width: 1000,
                     pagination: true,
                     fitColumns: true,
                     pageList: [5, 10, 15],
                     pageSize: 5,
                 })
             })
             function geeg() {
                 $("#box").datagrid({
                     url: "Handler/t_InventoryInfo.ashx",
                     columns: [[
                     { "title": "选择", "field": "ck", checkbox: true, width: 100, "align": "center" },
                     { "title": "盘点单号", "field": "InventoryID", width: 120, "align": "center" },
                     { "title": "创建时间", "field": "CreateDate", width: 100, "align": "center" },
                     { "title": "产品名称", "field": "productName", width: 100, "align": "center" },
                      { "title": "盘点库区", "field": "zugename", width: 100, "align": "center" },
                     { "title": "调整数量", "field": "AdjustNum", width: 100, "align": "center" },
                     { "title": "账面数量", "field": "BillNum", width: 100, "align": "center" },
                     { "title": "实际数量", "field": "RealityNum", width: 100, "align": "center" },
                     { "title": "状态", "field": "StateName", width: 100, "align": "center" }
                     ]],
                     height: 300,
                     width: 1000,
                     pagination: true,
                     fitColumns: true,
                     pageList: [5, 10, 15],
                     pageSize: 5,
                 })
             }
        </script>
    </form>
</body>
</html>
