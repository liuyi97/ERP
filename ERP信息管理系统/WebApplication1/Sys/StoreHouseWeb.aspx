<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreHouseWeb.aspx.cs" Inherits="WebApplication1.Sys.StoreHouseWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>>库房管理</div>
            <div id="ku1">
                <table>
                    <tr>
                        <td>库房名称：</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button Text="添加" runat="server" OnClick="Unnamed1_Click" />
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
                    <tr><td>库房编号：</td>
                        <td>
                            <input type="text" class="t4" readonly="true"/></td>
                    </tr>
                    <tr>
                        <td>库房名称：</td>
                        <td>
                            <input type="text" class="t1" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <input type="button" class="t3" value="修改" />
                        </td>
                    </tr>
                    <tr>
                        <td>描述：</td>
                        <td>
                            <input type="text" class="t2" TextMode="MultiLine" width="300" height="50" /></td>
                    </tr>
                </table>
            </div>
        <script type="text/javascript">
                function StoreHousebianji(id) {
                    $("#you").css("display", "none");
                    $("#ku3").panel({
                        closed:false
                    })
                    $.ajax({
                        data: {"id":id},
                        type: "post",
                        dataType: "json",
                        url: "handler/StoreHouseID.ashx",
                        success: function (data) {
                            $(".t4").val(id);
                            $(".t1").val(data[0]["HouseName"]);
                            $(".t2").val(data[0]["Description"]);
                        }
                    })
                }
                function StoreHouseshanchu(id) {
                    $.ajax({
                        data: { "id": id },
                        type: "post",
                        dataType: "Text",
                        url: "handler/StoreHouseDelete.ashx",
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
                            houseid: $(".t4").val(),
                            housename: $(".t1").val(),
                            Description:$(".t2").val()
                        },
                        type: "post",
                        dataType: "Text",
                        url: "handler/StoreHouseUpdate.ashx",
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
                    title: "库房添加",
                    width: 600,
                    height:200
                })
                $("#ku2").panel({
                    title: "库房列表",
                    width: 600,
                    collapsible:true
                })
                $("#ku3").panel({
                    title: "库房修改",
                    width: 600,
                    height: 200,
                    collapsible: true,
                    closed:true
                })
                $("#tab").datagrid({
                    url: "handler/StoreHouseALL.ashx",
                    columns: [[
                    { "title": "名称", "field": "HouseName", width: 20, "align": "center" },
                    { "title": "描述", "field": "Description", width: 20, "align": "center" },
                    {
                        "title": "编辑", "field": "nu", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:StoreHousebianji(" + row.HouseID + ")'>编辑</a>"
                        }
                    },
                    {
                        "title": "删除", "field": "num", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:StoreHouseshanchu(" + row.HouseID + ")'>删除</a>"
                        }
                    }
                    ]],
                    width: 600,
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
