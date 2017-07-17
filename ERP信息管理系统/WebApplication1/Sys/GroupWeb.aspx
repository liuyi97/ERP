<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupWeb.aspx.cs" Inherits="WebApplication1.Sys.GroupWeb" %>

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
    <style type="text/css">
        #you {
            margin: 0px;
            padding: 0px;
            width: 800px;
        } 
            #ku1 table tr td {
                height:60px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="you">
            <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>>管理群组</div>
            <div id="ku1">
                <table>
                    <tr>
                        <td>群组名称：</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" Text="添加" runat="server" OnClick="Button1_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td>描述：</td>
                        <td><asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="300" Height="50"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            <div id="ku2">
                <table id="tab"></table>
            </div>
            
        </div><div id="ku3">
                <table>
                    <tr><td>群组编号：</td>
                        <td>
                            <input type="text" class="t4" readonly="true"/></td>
                    </tr>
                    <tr>
                        <td>群组名称：</td>
                        <td>
                            <input type="text" class="t1" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" class="t3" value="修改" />
                        </td>
                    </tr>
                    <tr>
                        <td>描述：</td>
                        <td>
                            <%--<input type="text" class="t2" TextMode="MultiLine" width="300" height="50" />--%>
                            <asp:TextBox ID="TextBox3" class="t2" runat="server" TextMode="MultiLine" Width="300" Height="50"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table id="tab1">
                </table>
            </div>
        <script type="text/javascript">
            function xuanzhe(id) {
                if ($("#" + id).prop("checked")) {//选中增加一条
                    $.ajax({
                        data: {
                            groupid: $(".t4").val(),
                            AuthorityID:id
                        },
                        type: "post",
                        dataType: "json",
                        url: "handler/ckzeng.ashx",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "权限添加成功！");
                            } else {
                                $.messager.alert("提示", "权限添加失败！");
                            }
                        }
                    })
                }
                else {//未选中删除一条
                    $.ajax({
                        data: {
                            groupid: $(".t4").val(),
                            AuthorityID: id
                        },
                        type: "post",
                        dataType: "json",
                        url: "Handler/ckshan.ashx",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "权限删除成功！");
                            } else {
                                $.messager.alert("提示", "权限删除失败！");
                            }
                        }
                    })
                }
            }
            function Groupbianji(id) {
                $(".t4").val(id);
                $("#tab1").datagrid({
                    url: "Handler/quanALL.ashx",
                    columns: [[
                    { "title": "ID", "field": "TypeID", width: 20, "align": "center" },
                    {
                        "title": "选取", "field": "nu", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<input type='checkbox' name='chk' id='" + row.AuthorityID + "' onclick='xuanzhe(" + row.AuthorityID + ")' />"
                        }
                    },
                    { "title": "权限名称", "field": "AuthorityName", width: 40, "align": "center" },
                    { "title": "权限描述", "field": "Description", width: 100, "align": "center" }
                    ]],
                    width: 600,
                    height: 400,
                    //pagination: true,
                    fitColumns: true,
                    //pageList: [10, 20, 30],
                    //pageSize: 10,
                    onLoadSuccess: function () {
                        $.ajax({
                            data: {
                                groupid: $(".t4").val()
                            },
                            type: "post",
                            dataType: "json",
                            url: "Handler/ckxianshi.ashx",
                            success: function (data) {
                                console.info(data.length);
                                $.each(data, function (i, item) {
                                    console.info(item["AuthorityID"]);
                                    $("#" + item["AuthorityID"]).prop("checked", true);
                                })
                            }
                        })
                    }
                })
                $("#you").css("display", "none");
                $("#ku3").panel({
                    closed: false
                })
                $.ajax({
                    data: { "id": id },
                    type: "post",
                    dataType: "json",
                    url: "handler/GroupID.ashx",
                    success: function (data) {
                        $(".t1").val(data[0]["GroupName"]);
                        $(".t2").val(data[0]["Description"]);
                    }
                })
            }
            function Groupshanchu(id) {
                $.ajax({
                    data: { "id": id },
                    type: "post",
                    dataType: "Text",
                    url: "handler/GroupDelete.ashx",
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
                $(".t3").click(function () {
                    $.ajax({
                        data: {
                            groupid: $(".t4").val(),
                            groupname: $(".t1").val(),
                            Description: $(".t2").val()
                        },
                        type: "post",
                        dataType: "Text",
                        url: "handler/GroupUpdate.ashx",
                        success: function (data) {
                            if (data == "True") {
                                $.messager.alert("提示", "修改成功！");
                                $("#you").css("display", "block");
                                $("#ku3").panel({
                                    closed: true
                                })
                            } else {
                                $.messager.alert("提示", "修改失败！");
                            }
                            $("#tab").datagrid("reload");
                        }
                    })
                });

                $("#ku1").panel({
                    title: "群组添加",
                    width: 600,
                    height: 200
                })
                $("#ku2").panel({
                    title: "群组列表",
                    width: 600,
                    collapsible: true
                })
                $("#ku3").panel({
                    title: "群组修改",
                    width: 600,
                    collapsible: true,
                    closed: true
                })
                $("#tab").datagrid({
                    url: "handler/GroupALL.ashx",
                    columns: [[
                    { "title": "编号", "field": "GroupID", width: 20, "align": "center" },
                    { "title": "群名", "field": "GroupName", width: 20, "align": "center" },
                    { "title": "描述", "field": "Description", width: 20, "align": "center" },
                    {
                        "title": "编辑", "field": "nu", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:Groupbianji(" + row.GroupID + ")'>编辑</a>"
                        }
                    },
                    {
                        "title": "删除", "field": "num", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:Groupshanchu(" + row.GroupID + ")'>删除</a>"
                        }
                    }
                    ]],
                    width: 600,
                    pagination: true,
                    fitColumns: true,
                    pageList: [10, 20, 30],
                    pageSize: 10
                })
                //$("#tab1").datagrid({
                //    url: "handler/quanALL.ashx",
                //    columns: [[
                //    { "title": "ID", "field": "TypeID", width: 20, "align": "center" },
                //    {
                //        "title": "选取", "field": "nu", width: 20, "align": "center", formatter: function (value, row, index) {
                //            return "<input type='checkbox' name='chk' onclick='xuanzhe("+row.AuthorityID+")' />"
                //        }
                //    },
                //    { "title": "权限名称", "field": "AuthorityName", width: 40, "align": "center" },
                //    { "title": "权限描述", "field": "Description", width: 100, "align": "center" }
                //    ]],
                //    width: 600,
                //    height:400,
                //    //pagination: true,
                //    fitColumns: true,
                //    //pageList: [10, 20, 30],
                //    //pageSize: 10,
                //    onLoadSuccess: function () {
                //        alert('ffff');
                //        $.ajax({
                //            data: {
                //                groupid: $(".t4").val()
                //            },
                //            type: "post",
                //            dataType: "json",
                //            url: "handler/ckxianshi.ashx",
                //            success: function (data) {
                //                console.info(data);
                //            }
                //        })
                //    }
                //})
            })
        </script>
    </form>
</body>
</html>
