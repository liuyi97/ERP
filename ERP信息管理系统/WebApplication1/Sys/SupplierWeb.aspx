<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierWeb.aspx.cs" Inherits="WebApplication1.Sys.SupplierWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Script/jquery-1.8.3.min.js"></script>
    <script src="../UI/jquery.easyui.min.js"></script>
    <link href="../UI/themes/icon.css" rel="stylesheet" />
    <link href="../UI/themes/default/easyui.css" rel="stylesheet" />
    <script src="../UI/locale/easyui-lang-zh_CN.js"></script>
    <style type="text/css">
        #you {
            margin: 0px;
            padding: 0px;
            width: 850px;
        }

        #you1 table tr td {
            height: 60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>>供应商设置</div>
        <div id="you">
            <h2>供应商维护</h2>
            <input type="button" name="name" value="添加供应商" id="Button1" />
            <br />
            <br />
            <table id="tab"></table>
        </div>
        <div id="you1">
            <p id="xx">供应商编号：<input type="text" id="bianhao" /></p>
            <table>
                <tr>
                    <td>供应商名称：</td>
                    <td><input type="text" id="m1" /></td>
                </tr>
                <tr>
                    <td>所属地区：</td>
                    <td><input type="text" id="m2" /></td>
                </tr>
                <tr>
                    <td>邮政编码：</td>
                    <td><input type="text" id="m3" /></td>
                </tr>
                <tr>
                    <td>通讯地址：</td>
                    <td><input type="text" id="m4" /></td>
                </tr>
                <tr>
                    <td>联系人：</td>
                    <td><input type="text" id="m5" /></td>
                </tr>
                <tr>
                    <td>联系电话：</td>
                    <td><input type="text" id="m6" /></td>
                </tr>
                <tr>
                    <td>企业网址：</td>
                    <td><input type="text" id="m7" /></td>
                </tr>
                <tr>
                    <td>电子邮箱：</td>
                    <td><input type="text" id="m8" /></td>
                </tr>
                <tr>
                    <td>汇款银行：</td>
                    <td><input type="text" id="m9" /></td>
                </tr>
                <tr>
                    <td>汇款账户：</td>
                    <td><input type="text" id="m10" /></td>
                </tr>
                <tr>
                    <td>纳税号：</td>
                    <td><input type="text" id="m11" /></td>
                </tr>
                <tr>
                    <td>关系建立日：</td>
                    <td><input type="text" id="m12" /></td>
                </tr>
                <tr>
                    <td>状态：</td>
                    <td>
                        <asp:DropDownList ID="m13" runat="server">
                            <asp:ListItem>正常</asp:ListItem>
                            <asp:ListItem>停止</asp:ListItem>
                            </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>备注：</td>
                    <td><input type="text" id="m14" /></td>
                </tr>
            </table>
            <input type="button" id="m15" value="提交" />
        </div>
        <script type="text/javascript">
            var mm = 3;
            function Supplierbianji(id) {
                mm = 2;
                $("#you").css("display", "none");
                $("#you1").css("display", "block");
                $("#xx").css("display", "block");
                $("#bianhao").val(id);
                $.ajax({
                    data: { "id": id },
                    type: "post",
                    dataType: "json",
                    url: "handler/SupplierID.ashx",
                    success: function (data) {
                        $("#m1").val(data[0]["SupplierName"]);
                        $("#m2").val(data[0]["Area"]);
                        $("#m3").val(data[0]["Postcode"]);
                        $("#m4").val(data[0]["Address"]);
                        $("#m5").val(data[0]["Linkman"]);
                        $("#m6").val(data[0]["Tel"]);
                        $("#m7").val(data[0]["WebUrl"]);
                        $("#m8").val(data[0]["Email"]);
                        $("#m9").val(data[0]["Bankname"]);
                        $("#m10").val(data[0]["BankAccount"]);
                        $("#m11").val(data[0]["TaxNum"]);
                        $("#m12").val(data[0]["CreateDate"]);
                        $("#m13").val(data[0]["State"]);
                        $("#m14").val(data[0]["Description"]);
                    }
                })
            }
            function Suppliershanchu(id) {
                $.ajax({
                    data: { "id": id },
                    type: "post",
                    dataType: "Text",
                    url: "handler/SupplierDelete.ashx",
                    success: function (data) {
                        if (data == "True") {
                            $.messager.alert("提示", "删除成功！");
                        } else {
                            $.messager.alert("提示", "删除失败！");
                        }
                        $("#tab").datagrid("reload");
                    }
                })
            }
            $(function () {
                $("#m15").click(function(){
                    if ($("m1").val() != "") {
                        var obj = {
                            SupplierName: $("#m1").val(),
                            Area: $("#m2").val(),
                            Postcode: $("#m3").val(),
                            Address: $("#m4").val(),
                            Linkman: $("#m5").val(),
                            Tel: $("#m6").val(),
                            WebUrl: $("#m7").val(),
                            Email: $("#m8").val(),
                            Bankname: $("#m9").val(),
                            BankAccount: $("#m10").val(),
                            TaxNum: $("#m11").val(),
                            CreateDate: $("#m12").val(),
                            State: $("#m13").val(),
                            Description: $("#m14").val()
                        }
                        if (mm == 2) {//编辑
                            $.ajax({
                                data: obj,
                                type: "post",
                                dataType: "Text",
                                url: "handler/SupplierInsert.ashx?id=" + $("#bianhao").val(),
                                success: function (data) {
                                    if (data == "True") {
                                        $.messager.alert("提示", "修改成功！");
                                        $("#you").css("display", "block");
                                        $("#you1").css("display", "none");
                                        $("#zheid").css("display", "none");
                                    } else {
                                        $.messager.alert("提示", "修改失败！");
                                    }
                                    $("#tab").datagrid("reload");
                                }
                            })
                        } else if (mm = 3) {//添加
                            $.ajax({
                                data: obj,
                                type: "post",
                                dataType: "Text",
                                url: "handler/SupplierInsert.ashx?id="+"",
                                success: function (data) {
                                    if (data == "True") {
                                        $.messager.alert("提示", "添加成功！");
                                        $("#you").css("display", "block");
                                        $("#you1").css("display", "none");
                                    } else {
                                        $.messager.alert("提示", "添加失败！");
                                    }
                                    $("#tab").datagrid("reload");
                                }
                            })
                        }
                        } else{
                        $.messager.alert("供应商名不能为空！");
                    }
                });
                $("#Button1").click(function () {
                    mm = 3;
                    $("#you").css("display", "none");
                    $("#you1").css("display", "block");
                    $("#xx").css("display", "none");
                    $("#m1").val("");
                    $("#m2").val("");
                    $("#m3").val("");
                    $("#m4").val("");
                    $("#m5").val("");
                    $("#m6").val("");
                    $("#m7").val("");
                    $("#m8").val("");
                    $("#m9").val("");
                    $("#m10").val("");
                    $("#m11").val("");
                    $("#m12").val("");
                    $("#m13").val("");
                    $("#m14").val("");
                });
                $("#you").css("display", "block");
                $("#you1").css("display", "none");
                $("#xx").css("display", "none");
                $("#tab").datagrid({
                    url: "handler/SupplierALL.ashx",
                    columns: [[
                        {
                            "title": "查看", "field": "pp", width: 20, "align": "center", formatter: function (value, row, index) {
                                return "<a href='SupplierList.aspx?id=" + row.SupplierID + "'>查看</a>"
                            }
                        },
                    { "title": "供应商", "field": "SupplierName", width: 20, "align": "center" },
                    { "title": "地区", "field": "Address", width: 40, "align": "center" },
                    { "title": "联系人", "field": "Linkman", width: 40, "align": "center" },
                    { "title": "电子邮箱", "field": "Email", width: 20, "align": "center" },
                    {
                        "title": "编辑", "field": "nu3", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:Supplierbianji(" + row.SupplierID + ")'>编辑</a>"
                        }
                    },
                    {
                        "title": "删除", "field": "num", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:Suppliershanchu(" + row.SupplierID + ")'>删除</a>"
                        }
                    }
                    ]],
                    width: 800,
                    pagination: true,
                    fitColumns: true,
                    pageList: [10, 20, 30],
                    pageSize: 10
                })
            })
        </script>
    </form>
</body>
</html>
