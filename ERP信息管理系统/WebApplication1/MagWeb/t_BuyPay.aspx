<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t_BuyPay.aspx.cs" Inherits="WebApplication1.MagWeb.t_BuyPay" %>

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
        #top {
            width:600px;
            height:40px;
            margin-left:100px;
        }
        #btnsure, #insert, #delete {
           width:100px;
           height:38px;
        }
    </style>
    <form id="form1" runat="server">
        <div id="top">
           <input type="button" name="name" id="btnsure" value="审核付款单" />
           <input type="button" name="name" id="delete" value="删除付款单" />
            <input type="button" name="name" id="insert" value="新增付款单" />
        </div>
           订单编号：<input type="text" name="name" id="getid"  value="" />
             <input  type="text" id="put_begin" style="width:100px" class="easyui-datebox" required="required"></input>从
            <input  type="text" id="tb_end" style="width:100px" class="easyui-datebox" required="required"></input>
           状态：  <asp:DropDownList ID="DropDownList1" class="a"  runat="server"  >
            <asp:ListItem Value="2">未审核</asp:ListItem>
            <asp:ListItem Value="1">已审核</asp:ListItem>
                                         </asp:DropDownList>
           <input type="button" name="btn" id="btn"  value="确定"/>
           <h2 style="margin-left:200px">采购付款</h2>
        <div id="box">

        </div>

        <script type="text/javascript">

            $("#delete").click(function () {
                var s = "";
                var big = $("#box").datagrid("getSelections");
                $.each(big, function (i, item) {
                    s += "'" + item.BuyReceiptID + "'" + ",";
                })
                $.ajax({
                    url: "Handler/GetBuyPaydel.ashx",
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
                    s += "'" + item.BuyReceiptID + "'" + ",";
                })
                $.ajax({
                    url: "Handler/GetBuyPaysheng.ashx",
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
                    url: "Handler/getBuyPayid.ashx?getid=" + getid + "&end=" + end + "&begin=" + begin + "&deataid=" + deataid,
                    columns: [[
                    { "title": "选择", "field": "ck", checkbox: true, width: 100, "align": "center" },
                    { "title": "入库单号", "field": "BuyReceiptID", width: 120, "align": "center" },
                    { "title": "付款方式", "field": "PayTypeName", width: 100, "align": "center" },
                    { "title": "实付金额", "field": "RealPay", width: 100, "align": "center" },
                    { "title": "附加金额", "field": "AttachPay", width: 100, "align": "center" },
                    { "title": "日期", "field": "CreateDate", width: 100, "align": "center" },
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
                    height: 300,
                    width: 1050,
                    pagination: true,
                    fitColumns: true,
                    pageList: [10, 20, 30],
                    pageSize: 10,
                })

            })



            $(function () {
                $("#box").datagrid({
                    url: "Handler/t_BuyPayHandler1.ashx ",
                    columns: [[
                    { "title": "选择", "field": "ck", checkbox: true, width: 100, "align": "center" },
                    { "title": "入库单号", "field": "BuyReceiptID", width: 120, "align": "center" },
                    { "title": "付款方式", "field": "PayTypeName", width: 100, "align": "center" },
                    { "title": "实付金额", "field": "RealPay", width: 100, "align": "center" },
                    { "title": "附加金额", "field": "AttachPay", width: 100, "align": "center" },
                    { "title": "日期", "field": "CreateDate", width: 100, "align": "center" },
                    { "title": "制单人", "field": "UserName", width: 100, "align": "center" },
                    { "title": "状态", "field": "StateName", width: 100, "align": "center" }
                    ]],
                    height: 300,
                    width: 1050,
                    pagination: true,
                    fitColumns: true,
                    pageList: [10, 20, 30],
                    pageSize: 10,
                })
            })

        </script>
    </form>
</body>
</html>