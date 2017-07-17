<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreHouseDetailWeb.aspx.cs" Inherits="WebApplication1.Sys.StoreHouseDetailWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                height:60px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="you">
            <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>>仓库设置</div>
            <div id="ku1">
                <table>
                    <tr>
                        <td>库房：</td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td>库区名称：</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>描述：</td>
                        <td><asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="300" Height="50"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem>正常</asp:ListItem>
                            <asp:ListItem>停止</asp:ListItem>
                            </asp:DropDownList></td>
                        <td><asp:Button ID="Button1" Text="添加" runat="server" OnClick="Button1_Click"/></td>
                    </tr>
                </table>
            </div>
            <div id="ku2">
                <table id="tab"></table>
            </div>
            
        </div><div id="ku3">
                <table>
                    <tr><td>库区编号：</td>
                        <td>
                            <input type="text" class="t4" readonly="true"/></td>
                    </tr>
                    <tr>
                        <td>库房名称：</td>
                        <td>
                            <input class="t1" />
                        </td>
                    </tr>
                    <tr>
                        <td>库区名称：</td>
                        <td>
                            <input type="text" class="t5" />
                        </td>
                    </tr>
                    <tr>
                        <td>描述：</td>
                      <%--  <td>

                            <input type="text" class="t2" TextMode="MultiLine" width="300" height="50" /></td>--%>
                        <td><asp:TextBox ID="TextBox3" class="t2" runat="server" TextMode="MultiLine" Width="300" Height="50"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:DropDownList ID="DropDownList3" class="t6" runat="server">
                            <asp:ListItem Value="Y">正常</asp:ListItem>
                            <asp:ListItem Value="N">停止</asp:ListItem>
                            </asp:DropDownList></td>
                        <td><input type="button" class="t3" value="修改" /></td>
                    </tr>
                </table>
            </div>
        <script type="text/javascript">
            function StoreHouseDetailbianji(id) {
                $("#you").css("display", "none");
                $("#ku3").panel({
                    closed: false
                })
                $.ajax({
                    data: { "id": id },
                    type: "post",
                    dataType: "json",
                    url: "handler/StoreHouseDetailID.ashx",
                    success: function (data) {
                        $(".t4").val(id);
                        //$(".t1").val(data[0]["HouseName"]);
                        //$(".t1").("A-33库房");
                        $(".t1").combobox("setValue", data[0]["HouseID"]);
                        $(".t5").val(data[0]["SubareaName"]);
                        $(".t2").val(data[0]["Description"]);
                        $(".t6").val(data[0]["State"]);
                        //if (data[0]["State"] == "Y") {
                        //    $(".t6").text("正常");
                        //} else {
                        //    $(".t6").text("停止");
                        //}
                    }
                })
            }
            function StoreHouseDetailshanchu(id) {
                $.ajax({
                    data: { "id": id },
                    type: "post",
                    dataType: "Text",
                    url: "handler/StoreHouseDetailDelete.ashx",
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
                            id: $(".t4").val(),
                            houseid: $(".t1").combobox("getValue"),
                            Description: $(".t2").val(),
                            SubareaName: $(".t5").val(),
                            State:$(".t6").val()
                        },
                        type: "post",
                        dataType: "Text",
                        url: "handler/StoreHouseDetailUpdate.ashx",
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
                    title: "库区添加",
                    width: 600,
                    height: 300
                })
                $("#ku2").panel({
                    title: "库区列表",
                    width: 600,
                    collapsible: true
                })
                $("#ku3").panel({
                    title: "库区修改",
                    width: 600,
                    height: 200,
                    collapsible: true,
                    closed: true
                })
                $(".t1").combobox({
                    url: 'handler/StoreHouseDetailDrop.ashx',
                    valueField: 'HouseID',
                    textField: 'HouseName',
                    width:100
                })
                $("#tab").datagrid({
                    url: "handler/StoreHouseDetailALL.ashx",
                    columns: [[
                    { "title": "库房", "field": "HouseName", width: 20, "align": "center" },
                    { "title": "库区", "field": "SubareaName", width: 20, "align": "center" },
                    { "title": "状态", "field": "State", width: 20, "align": "center" },
                    {
                        "title": "编辑", "field": "nu", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:StoreHouseDetailbianji(" + row.ID + ")'>编辑</a>"
                        }
                    },
                    {
                        "title": "删除", "field": "num", width: 20, "align": "center", formatter: function (value, row, index) {
                            return "<a href='javascript:StoreHouseDetailshanchu(" + row.ID + ")'>删除</a>"
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
