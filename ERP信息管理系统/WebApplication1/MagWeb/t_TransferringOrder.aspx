<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t_TransferringOrder.aspx.cs" Inherits="WebApplication1.MagWeb.t_TransferringOrder" %>

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
      <style type="text/css">
        * {
            font-family:"微软雅黑";
        }
        #top ul li {
           float:left;
           margin-left:40px;
           list-style:none;
        }
        #top {
            margin: 0px auto;
            width:1000px;
            height:100px;
        }
        .btncss {
             width:120px;
             height:40px;
             text-align:center;
             line-height:40px;
        }
    </style>
    <form id="form1" runat="server">
    <div id="top">
        <ul>
            <li>  <input type="submit" name="name" id="btncss" value="审核调拨单" /></li>
            <li> <input type="submit" name="name" id="delbtn" value="删除调拨单" /></li>
            <li><input type="submit" name="name" class="btncss" value="新增调拨单" /></li>

        </ul>
      <div id="box"></div>
    </div>
       <script type="text/javascript">
           $("#box").datagrid({
               url: "Handler/t_TransferringOrderinfo.ashx",
               columns: [[
              { "title": "选择", "field": "ck", checkbox: true, width: 100, "align": "center" },
               { "title": "编号", "field": "ID", width: 120, "align": "center" },
               { "title": "调出仓库", "field": "inStoreName", width: 100, "align": "center" },
               { "title": "调入仓库", "field": "outStoreName", width: 120, "align": "center" },
               { "title": "操作人", "field": "Username", width: 120, "align": "center" },
               { "title": "商品名", "field": "Productname", width: 120, "align": "center" },
                 {
                     "title": "状态", "field": "State", width: 100, "align": "center", formatter: function (value, row, index) {
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
               width: 800,
               pagination: true,
               fitColumns: true,
               pageList: [5, 20, 30],
               pageSize: 5,
           })
           $("#btncss").click(function () {
               var s = "";
               var big = $("#box").datagrid("getSelections");
               $.each(big, function (i, item) {
                   s += "'" + item.ID + "'" + ",";
               })
               $.ajax({
                   url: "Handler/t_TransferringOrdersheng.ashx",
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
           $("#delbtn").click(function () {
               var s = "";
               var big = $("#box").datagrid("getSelections");
               $.each(big, function (i, item) {
                   s += "'" + item.ID + "'" + ",";
               })
               $.ajax({
                   url: "Handler/t_TransferringOrderDel.ashx",
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
   
       </script>
    </form>
</body>
</html>
