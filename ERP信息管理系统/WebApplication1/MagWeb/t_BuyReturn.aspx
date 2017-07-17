<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t_BuyReturn.aspx.cs" Inherits="WebApplication1.MagWeb.t_BuyReturn" %>

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
            <input type="button" style="width:100px; height:38px" name="name" id="btnsure" value="审核退货订单" />
            <input  type="button"  style="width:100px; height:38px" name="name" id="delete" value="删除退货订单" />
            <input  type="button"  style="width:100px; height:38px" name="name" id="insert" value="新增退货订单" />
        </div>
    <div>
          订单编号：<input type="text" name="name" id="getid"  value="" />
             <input  type="text" id="put_begin" style="width:100px" class="easyui-datebox" required="required"></input>从
            <input  type="text" id="tb_end" style="width:100px" class="easyui-datebox" required="required"></input>状态：
                  <asp:DropDownList ID="DropDownList1" class="a"  runat="server"   >
                 <asp:ListItem Value="1">已审核</asp:ListItem>
               <asp:ListItem Value="2">未审核</asp:ListItem>
        </asp:DropDownList>
                        <input type="button" name="btn" id="btn"  value="确定"  />
        </div>
       
            <h2 style="margin-left:200px">采货退货单</h2>
         <div id="box"></div>
        <script type="text/javascript">
            $(function () {
                getinfo();
                //根据ID删除
                $("#delete").click(function () {
                    var s = "";
                    var big = $("#box").datagrid("getSelections");
                    $.each(big, function (i, item) {
                        s += "'" + item.BuyReturnID + "'" + ",";
                    })
                    $.ajax({
                        url: "/Handler/t_BuyReturnDel.ashx",
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
                //查询确定订单
                $("#btn").click(function () {
                    var deataid = $(".a").val();
                    var getid = $("#getid").val().trim();
                    var begin = $("#put_begin").val();
                    var end = $("#tb_end").val();
                    $("#box").datagrid({
                        url: "Handler/t_BuyReturnHandler.ashx?getid= " + getid + "&begin=" + begin + "&end=" + end + "&deataid=" + deataid,
                        columns: [[
                        { "title": "选择", "field": "ck", checkbox: true, width: 100, "align": "center" },
                        { "title": "订单编号", "field": "BuyReturnID", width: 120, "align": "center" },
                        { "title": "日期", "field": "BuyReturnDate", width: 100, "align": "center" },
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
                        height: 300,
                        width: 1050,
                        pagination: true,
                        fitColumns: true,
                        pageList: [10, 20, 30],
                        pageSize: 10,
                    })
                })
                //审核退货订单
                $("#btnsure").click(function () {
                    var s = "";
                    var big = $("#box").datagrid("getSelections");
                    $.each(big, function (i, item) {
                        s += "'" + item.BuyReturnID + "'" + ",";
                    })
                    $.ajax({
                        url: "/Handler/t_BuyReturnsheng.ashx",
                        dataType: "Text",
                        data: "getid=" + s,
                        type: "post",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("审批成功", "审批成功");
                                getinfo();
                            }
                            else {
                                $.messager.alert("审批失败", "审批失败");
                            }
                        }
                    })
                })
            })
            ///最开始
            function getinfo() {
                $("#box").datagrid({
                    url: "Handler/t_BuyReturninfoHandler.ashx",
                    columns: [[
                    { "title": "选择", "field": "ck", checkbox: true, width: 100, "align": "center" },
                    { "title": "订单编号", "field": "BuyReturnID", width: 120, "align": "center" },
                    { "title": "日期", "field": "BuyReturnDate", width: 100, "align": "center" },
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
                    height: 300,
                    width: 1050,
                    pagination: true,
                    fitColumns: true,
                    pageList: [10, 20, 30],
                    pageSize: 10,
                    fixRowHeight: 5,
                    autoRowHeight: false
                })
            }
        </script>
    </form>
</body>
</html>
