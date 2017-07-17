<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t_BuyOrder.aspx.cs" Inherits="WebApplication1.MagWeb.t_BuyOrder" %>

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
        <link href="css/t_BuyOrder.css" rel="stylesheet" />
    <form id="form1" runat="server">
       <div id="top">
           订单编号：<input type="text" name="name" id="getid"  value="" />
             <input  type="text" id="put_begin" style="width:100px" class="easyui-datebox" required="required"></input>从
            <input  type="text" id="tb_end" style="width:100px" class="easyui-datebox" required="required"></input>
           状态：  <asp:DropDownList ID="DropDownList1" class="a"  runat="server">
            <asp:ListItem Value="2">未审核</asp:ListItem>
            <asp:ListItem Value="1">已审核</asp:ListItem>
        </asp:DropDownList>
           <input type="button" name="btn" id="btn"  value="确定"  />
           <input type="button" name="name" id="btnsure" value="审核" />
           <input type="button" name="name" id="notsure" value="反审核" />
       </div>
        <h2> 采购订单</h2>
       <div id="box">
        </div> 
        <script type="text/javascript">
            $("#notsure").click(function () {
                var s = "";
                var big = $("#box").datagrid("getSelections");

                $.each(big, function (i, item) {
                    s += "'" + item.BuyOrderID + "'" + ",";
                })
                $.ajax({
                    url: "Handler/getnotseletionsHandler.ashx",
                    dataType: "Text",
                    data: "getid=" + s,
                    type: "post",
                    success: function (data) {
                        if (data == "True") {
                            $.messager.alert("审批成功", "审批成功");
                        }
                        else {
                            $.messager.alert("审批失败", "审批失败");
                        }
                    }
                })
            })




            $("#btnsure").click(function () {
                var s = "";
                var big = $("#box").datagrid("getSelections");

                $.each(big, function (i, item) {
                    s += "'" + item.BuyOrderID + "'" + ",";
                })
                $.ajax({
                    url: "Handler/getSelectionsHandler1.ashx",
                    dataType: "Text",
                    data: "getid=" + s,
                    type: "post",
                    success: function (data) {
                        if (data == "True") {
                            $.messager.alert("审批成功", "审批成功");
                        }
                        else {
                            $.messager.alert("审批失败", "审批失败");
                        }
                    }
                })
            })
            $("#btn").click(function () {
                var deataid = $(".a").val();
                var getid = $("#getid").val();
                var begin = $("#put_begin").val();
                var end = $("#tb_end").val();

                $("#box").datagrid({
                    height: 300,
                    url: "Handler/GetorderID.ashx?getid=" + getid + "&begin=" + begin + "&end=" + end + "&deataid=" + deataid,
                    columns: [[
                        { "title": "选择", "field": "ck", checkbox: true, width: 100, "align": "center" },
                        { "title": "订单编号", "field": "BuyOrderID", width: 120, "align": "center" },
                        { "title": "日期", "field": "BuyOrderDate", width: 100, "align": "center" },
                        { "title": "厂状态库名", "field": "HouseName", width: 100, "align": "center" },
                        { "title": "总价", "field": "TotalPrice", width: 100, "align": "center" },
                        { "title": "库区", "field": "SubareaName", width: 100, "align": "center" },
                        { "title": "制单人", "field": "UserName", width: 100, "align": "center" },
                        {
                            "title": "状态", "field": "StateName", width: 100, "align": "center", formatter: function (value, row, index) {
                                if (row.StateName == "未审核") {
                                    return "<span style='color:red'>" + value + "</span>"
                                }
                                else {
                                    return "<span style='color:green'>" + value + "</span>"
                                }
                            }
                        }
                    ]],
                    width: 800,
                    pagination: true,
                    fitColumns: true,
                    pageList: [8, 16, 24],
                    pageSize: 8,
                })
            })
            $(function () {
                $("#box").datagrid({

                    url: "Handler/t_BuyOrderHandler1.ashx ",
                    columns: [[
                    { "title": "选择", "field": "ck", checkbox: true, width: 100, "align": "center" },
                    { "title": "订单编号", "field": "BuyOrderID", width: 120, "align": "center" },
                    { "title": "日期", "field": "BuyOrderDate", width: 100, "align": "center" },
                    { "title": "厂状态库名", "field": "HouseName", width: 100, "align": "center" },
                    { "title": "总价", "field": "TotalPrice", width: 100, "align": "center" },
                    { "title": "库区", "field": "SubareaName", width: 100, "align": "center" },
                    { "title": "制单人", "field": "UserName", width: 100, "align": "center" },
                        { "title": "状态", "field": "StateName", width: 100, "align": "center" }
                    ]],
                    height: 300,
                    width: 1000,
                    pagination: true,
                    fitColumns: true,
                    pageList: [8, 16, 24],
                    pageSize: 8,
                })
            })
        </script>
    </form>
</body>
</html>

