<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWeb.aspx.cs" Inherits="WebApplication1.Sys.UserWeb" %>

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
            width: 800px;
        }

        #ku1 table tr td {
            height: 40px;
        }
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="you">
            <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>>管理用户</div>
            <h2>用户基本维护</h2>
            <input type="button" id="tianjia"  value="添加用户" />
            <div id="ku2">
                <table id="tab"></table>
            </div>

        </div>
        <div id="ku3">
            <p id="zheid">编辑商品信息编号：<label id="bianhao"></label></p>
            <table>
                <tr>
                    <td>账号：</td>
                    <td><input type="text" id="m1" /></td>
                    <td>用户一级类型：</td>
                    <td><input id="d1" /></td>
                </tr>
                <tr>
                    <td>密码：</td>
                    <td><input type="text" id="m2" /></td>
                    <td>用户二级类型：</td>
                    <td><input id="d2" /></td>
                </tr>
                <tr>
                    <td>用户权限：</td>
                    <td><input id="d3" /></td>
                    <td>真实姓名：</td>
                    <td><input type="text" id="m4" /></td>
                </tr>
                <tr>
                    <td>性别：</td>
                    <td><asp:DropDownList ID="DropDownList1" class="t6" runat="server">
                            <asp:ListItem Value="男">男</asp:ListItem>
                            <asp:ListItem Value="女">女</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>用户特征：</td>
                    <td><input type="text" id="m6" /></td>
                </tr>
                <tr>
                    <td class="auto-style1">联系电话：</td>
                    <td class="auto-style1"><input type="text" id="m7" /></td>
                    <td class="auto-style1">电子邮箱：</td>
                    <td class="auto-style1"><input type="text" id="m8" /></td>
                </tr>
                <tr>
                    <td class="auto-style2">QQ：</td>
                    <td class="auto-style2"><input type="text" id="m9" /></td>
                    <td class="auto-style2">淘宝（旺旺）：</td>
                    <td class="auto-style2"><input type="text" id="m10" /></td>
                </tr>
                <tr>
                    <td>公司名称：</td>
                    <td><input type="text" id="m11" /></td>
                    <td>部门：</td>
                    <td><input type="text" id="m12" /></td>
                </tr>
                <tr>
                    <td>公司状况：</td>
                    <td><input type="text" id="m13"/></td>
                    <td>开户银行：</td>
                    <td><input type="text" id="m14"/></td>
                </tr>
                <tr>
                    <td>开户账号：</td>
                    <td><input type="text" id="m15"/></td>
                    <td>通讯地址：</td>
                    <td><input type="text" id="m16"/></td>
                </tr>
                <tr>
                    <td>状态：</td>
                    <td><asp:DropDownList ID="DropDownList3" class="t7" runat="server">
                            <asp:ListItem Value="Y">正常</asp:ListItem>
                            <asp:ListItem Value="N">停止</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>备注：</td>
                    <td><input type="text" id="m18" /></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input type="button"  value="提交" id="m19" /></td>
                </tr>
            </table>
        </div>
        <script type="text/javascript">
            var mm = 3;
            function Userbianji(name) {
                mm = 4;
                $("#m1").textbox({
                    readonly:true
                });
                $("#you").css("display", "none");
                $("#ku3").css("display", "block");
                $("#zheid").css("display", "block");
                $("#bianhao").text(name);
                $.ajax({
                    data: { "name": name },
                    type: "post",
                    dataType: "json",
                    url: "handler/UserID.ashx",
                    success: function (data) {
                        $("#m1").val(data[0]["UserName"]);
                        $("#m2").val(data[0]["Password"]);
                        $("#d1").combobox("setValue", data[0]["TypeID"]);
                        $("#d2").combobox("setValue", data[0]["SubClassID"]);
                        $("#d3").combobox("setValue", data[0]["GroupID"]);
                        $("#m4").val(data[0]["RealName"]);
                        $(".t6").val(data[0]["Sex"]);
                        $("#m6").val(data[0]["Dept"]);
                        $("#m7").val(data[0]["Tel"]);
                        $("#m8").val(data[0]["Email"]);
                        $("#m9").val(data[0]["QQ"]);
                        $("#m10").val(data[0]["WangWang"]);
                        $("#m11").val(data[0]["CompanyName"]);
                        $("#m12").val(data[0]["CompanyInfo"]);
                        $("#m13").val(data[0]["Bankname"]);
                        $("#m14").val(data[0]["BankAccount"]);
                        $("#m15").val(data[0]["LatelyLogin"]);
                        $("#m16").val(data[0]["Address"]);
                        $(".t7").val(data[0]["State"]);
                        $("#m18").val(data[0]["Description"]);
                    }
                })
            }
            function Usershanchu(name) {
                $.ajax({
                    data: { "name": name },
                    type: "post",
                    dataType: "Text",
                    url: "handler/UserDelete.ashx",
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
                $("#m19").click(function () {
                    var obj = {
                        UserName: $("#m1").val(),
                        Password: $("#m2").val(),
                        TypeID: $("#d1").combobox("getValue"),
                        SubClassID: $("#d2").combobox("getValue"),
                        GroupID: $("#d3").combobox("getValue"),
                        RealName: $("#m4").val(),
                        Sex: $(".t6").val(),
                        Dept: $("#m6").val(),
                        Tel: $("#m7").val(),
                        Email: $("#m8").val(),
                        QQ: $("#m9").val(),
                        WangWang: $("#m10").val(),
                        CompanyName: $("#m11").val(),
                        CompanyInfo: $("#m12").val(),
                        Bankname: $("#m13").val(),
                        BankAccount: $("#m14").val(),
                        LatelyLogin: $("#m15").val(),
                        Address: $("#m16").val(),
                        State: $(".t7").val(),
                        Description: $("#m18").val()
                    }
                    if (mm == 3) {
                        if ($("#m1").val() != "" && $("#m2").val("") != "" &&  $("#m4").val() != "") {
                            $.ajax({
                                data: obj,
                                type: "post",
                                dataType: "Text",
                                url: "handler/UserUpdate.ashx?name=" + "",
                                success: function (data) {
                                    if (data == "True") {
                                        $.messager.alert("提示", "添加成功！");
                                        $("#you").css("display", "block");
                                        $("#ku3").css("display", "none");
                                        $("#zheid").css("display", "none");
                                    } else {
                                        $.messager.alert("提示", "添加失败！");
                                    }
                                    $("#tab").datagrid("reload");
                                }
                            })
                        } else {
                            $.messager.alert("提示：","商品名称、品牌、类型和成本不能为空！");
                        }
                    } else if (mm == 4) {
                        if ($("#m1").val() != "" && $("#m2").val("") != ""  && $("#m4").val() != "") {
                            $.ajax({
                                data: obj,
                                type: "post",
                                dataType: "Text",
                                url: "handler/UserUpdate.ashx?name=" + $("#bianhao").text(),
                                success: function (data) {
                                    if (data == "True") {
                                        $.messager.alert("提示", "修改成功！");
                                        $("#you").css("display", "block");
                                        $("#ku3").css("display", "none");
                                        $("#zheid").css("display", "none");
                                    } else {
                                        $.messager.alert("提示", "修改失败！");
                                    }
                                    $("#tab").datagrid("reload");
                                }
                            })
                        } else {
                            $.messager.alert("提示：", "商品名称、品牌、类型和成本不能为空！");
                        }
                    }
                })
                $("#tianjia").click(function () {
                    mm = 3;
                    $("#you").css("display", "none");
                    $("#ku3").css("display", "block");
                    $("#zheid").css("display", "none");
                    $("#m1").val("");
                    $("#d1").combobox("select", 2);
                    $("#d2").combobox("select", 2);
                    $("#d3").combobox("select", 1)
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
                    $("#m15").val("");
                    $("#m16").val("");
                    $("#m18").val("");
                })
                $("#ku2").panel({
                    title: "用户列表",
                    width: 700,
                    collapsible: true
                })
                $("#ku3").css("display", "none");
                $("#zheid").css("display", "none");
                $("#d1").combobox({
                    url: 'handler/UserleiDrop.ashx',
                    valueField: 'TypeID',
                    textField: 'TypeName',
                    width: 100,
                    editable: false,
                onLoadSuccess: function () {
                    $("#d1").combobox("select", 2)
                }
                })
                $("#d2").combobox({
                    url: 'handler/UserdingleiDrop.ashx',
                    valueField: 'SubClassID',
                    textField: 'SubClassName',
                    width: 100,
                    editable: false,
                    onLoadSuccess: function () {
                        $("#d2").combobox("select", 2)
                    }
                })
                $("#d3").combobox({
                    url: 'handler/UserquanDrop.ashx',
                    valueField: 'GroupID',
                    textField: 'GroupName',
                    width: 100,
                    editable: false,
                    onLoadSuccess: function () {
                        $("#d3").combobox("select", 1)
                    }
                })
                $("#tab").datagrid({
                    url: "handler/UserALL.ashx",
                    columns: [[
                         {
                             "title": "查看", "field": "pp", width: 20, "align": "center", formatter: function (value, row, index) {
                                 return '<a href="UserList.aspx?name=' + row.UserName + '">查看</a>'
                             }
                         },
                     { "title": "账号", "field": "UserName", width: 40, "align": "center" },
                     { "title": "姓名", "field": "RealName", width: 40, "align": "center" },
                     { "title": "电话", "field": "Tel", width: 40, "align": "center" },
                     { "title": "权限组", "field": "GroupID", width: 20, "align": "center" },
                     { "title": "一级类型", "field": "TypeID", width: 20, "align": "center" },
                     { "title": "二级类型", "field": "SubClassID", width: 20, "align": "center" },
                      {
                          "title": "状态", "field": "State", width: 20, "align": "center"
                      },
                     {
                         "title": "编辑", "field": "nu3", width: 20, "align": "center", formatter: function (value, row, index) {
                             return '<a href="javascript:Userbianji(\'' + row.UserName + '\')">编辑</a>'
                         }
                     },
                     {
                         "title": "删除", "field": "num", width: 20, "align": "center", formatter: function (value, row, index) {
                             return "<a href='javascript:Usershanchu(" + row.UserName + ")'>删除</a>"
                         }
                     }
                    ]],
                    width: 700,
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
