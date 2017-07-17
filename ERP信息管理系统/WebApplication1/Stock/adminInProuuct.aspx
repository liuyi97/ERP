<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminInProuuct.aspx.cs" Inherits="WebApplication1.Stock.adminInProuuct" %>

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
    <link href="../css/adminInProduct.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div  id="main">
    <h2 style="margin-left:325px;margin-top:10px;">商品入库管理</h2>
        <div id="top">
            单据编号：
            <asp:TextBox ID="TextBox1" Width="165px" runat="server"></asp:TextBox>
          <%--  <asp:DropDownList ID="DropDownList1" Width="165px" runat="server"></asp:DropDownList>--%>
            从：<asp:TextBox ID="TextBox2" Width="90px" runat="server"></asp:TextBox>
            到：<asp:TextBox ID="TextBox3" Width="90px" runat="server"></asp:TextBox>
            状态：<asp:DropDownList ID="DropDownList2" Width="70px" runat="server"></asp:DropDownList>
            <input type="button" id="Button1" name="name" value="查询" />
            <input type="button" id="Button2" name="name" value="审核" />
            <input type="button" id="Button3" name="name" value="删除单据" />
          
        </div>
        <div id="box"></div>
   </div>
    </form>
</body>
    <script type="text/javascript">
        $(function () {
            $("#TextBox2").datebox({
                required: true
            })
            $("#TextBox3").datebox({
                required: true
            })

            $("#box").datagrid({
                url: "ashx/adminP.ashx",
                pagination: true,
                pageSize: 5,
                height: 200,
                pageList: [5, 10, 15, 20],
                columns: [[
                    { field: "ck", checkbox: true, title: "", align: "center", width: 80 },
                    { field: "ProductsName", title: "商品名", align: "center", width: 80 },
                    { field: "OutID", title: "订单编号", align: "center", width: 160 },
                    { field: "CreateDate", title: "创建时间", align: "center", width: 80 },
                    { field: "HouseName", title: "库房", align: "center", width: 80 },
                    { field: "SubareaName", title: "库区", align: "center", width: 80 },
                    { field: "TradeDate", title: "结束时间", align: "center", width: 80 },
                    { field: "Quantity", title: "数量", align: "center", width: 30 },
                    { field: "Price", title: "价格", align: "center", width: 80 },
                    {
                        field: "StateName", title: "状态", align: "center", width: 80,
                        formatter: function (value, row, index) {
                            if (row.StateName == "未审核") {
                                return "<span style='color:red'>" + value + "</span>"
                            }
                            else {
                                return "<span style='color:green'>" + value + "</span>"
                            }
                        }
                    }
                ]]
            })
            $("#Button3").linkbutton({
                onClick: function () {
                    var s = "";
                    var c = $("#box").datagrid("getSelections");
                    $.each(c, function (i, item) {
                        s += "'" + item.OutID + "'" + ",";
                    })
                    $.ajax({
                        url:"ashx/Delete.ashx?outid=" + s,
                        type: "post",
                        dataType: "text",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "删除成功");
                            }
                            else {
                                $.messager.alert("提示", "删除失败");
                            }
                        }
                    })

                }


            })

            $("#Button2").linkbutton({
                onClick: function () {
                    var c = $("#box").datagrid("getSelected");
                    var obj = 1;
                    var OutID = c.OutID;
                    $.ajax({
                        url: "ashx/adminUpdate.ashx?statename=" + obj + "&OutID=" + OutID,
                        type: "post",
                        dataType: "text",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "修改成功");
                            }
                            else {
                                $.messager.alert("提示", "修改失败");
                            }
                        }
                    })
                }
            })
            $("#Button1").linkbutton({
                onClick: function () {
                    var outid = $("#TextBox1").val();
                    var create = $("#TextBox2").val();
                    var tradetime = $("#TextBox3").val();
                    var statename = $("#DropDownList2").val();
                    $("#box").datagrid({
                        url: "ashx/adminAll.ashx?outid=" + outid + "&create=" + create + "&tradetime=" + tradetime + "&statename=" + statename,
                        pagination: true,
                        pageSize: 5,
                        height: 200,
                        pageList: [5, 10, 15, 20],
                        columns: [[
                            { field: "ck", checkbox: true, title: "", align: "center", width: 80 },
                            { field: "ProductsName", title: "商品名", align: "center", width: 80 },
                            { field: "OutID", title: "订单编号", align: "center", width: 160 },
                            { field: "CreateDate", title: "创建时间", align: "center", width: 80 },
                            { field: "HouseName", title: "库房", align: "center", width: 80 },
                            { field: "SubareaName", title: "库区", align: "center", width: 80 },
                            { field: "TradeDate", title: "结束时间", align: "center", width: 80 },
                            { field: "Quantity", title: "数量", align: "center", width: 30 },
                            { field: "Price", title: "价格", align: "center", width: 100 },
                            {
                                field: "StateName", title: "状态", align: "center", width: 80,
                                formatter: function (value, row, index) {
                                    if (row.StateName == "未审核") {
                                        return "<span style='color:red'>" + value + "</span>"
                                    }
                                    else {
                                        return "<span style='color:green'>" + value + "</span>"
                                    }
                                }
                            },
                        ]]
                    })
                    $("#box").datagrid("reload");
                }
            })
        })
    </script>
</html>

