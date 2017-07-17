<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProIntoHouse.aspx.cs" Inherits="WebApplication1.Product.ProIntoHouse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <script src="../UI/jquery-1.8.3.min.js"></script>
    <script src="../UI/jquery.min.js"></script>
    <script src="../UI/jquery.easyui.min.js"></script>
    <link href="../UI/themes/icon.css" rel="stylesheet" />
    <link href="../UI/themes/default/easyui.css" rel="stylesheet" />
    <script src="../UI/locale/easyui-lang-zh_CN.js"></script>
    <title></title>

    <style type="text/css">
        * {
            text-decoration: none;
            list-style: none;
        }

        #big {
            width: 800px;
        }

        #IntoHouse {
            width: 800px;
            /*height: 350px;
            border: 1px solid black;*/
        }

        h2 {
            margin-top: 25px;
            margin-bottom: 15px;
            text-align: center;
        }

        .tiao {
            float: left;
        }

       .tiao span {
            display: inline-block;
            width: 80px;
            text-align: right;
        }

        .tiao td {
            padding-top: 20px;
            padding-left: 12px;
        }

        .tiao td input[type="text"] {
            width: 150px;
        }

        #DateTime {
            width: 138px;
        }

        #tabOne {
            width:800px;
            border:1px solid #4096ad;
        }
        #tabTwo {
            margin-top:10px;
            width:800px;
            border:1px solid #4096ad;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="big">
            <div id="IntoHouse">
                <h2 style="text-align: center;">商品入库</h2>
                <table class="tiao" id="tabOne">
                    <tr>
                        <td><span>订单编号：</span><asp:TextBox ID="txtOrderID" runat="server" Enabled="False"></asp:TextBox></td>
                        <td><span>制单日期：</span><asp:TextBox ID="txtMakeDate" runat="server" Enabled="False"></asp:TextBox></td>
                        <td><span>入库类型：</span><asp:DropDownList ID="DDLIntoType" runat="server" Height="20px" Width="148px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><span>库房：</span><asp:TextBox ID="txtHouse" runat="server"></asp:TextBox></td>
                        <td><span>库区：</span><asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                            <input type="button" id="btnUserHouse" name="btnUserHouse" value="引用" /></td>
                        <td><span>入库日期：</span>
                            <input id="DateTime1" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td><span>已经付款：</span><asp:TextBox ID="txtPay" runat="server"></asp:TextBox></td>
                        <td></td>
                        <td><span>备注：</span><asp:TextBox ID="txtDec" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCreate" runat="server" Text="生成入库订单" OnClick="btnCreate_Click" /></td>
                    </tr>
                   <%-- <asp:Panel ID="Panel1" runat="server" Visible="False">--%>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" Text="删除该单" OnClick="btnDelete_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnFinish" runat="server" Text="完成所有" OnClick="btnFinish_Click" />
                            </td>
                            <td></td>
                        </tr>
                        <table class="tiao" id="tabTwo">
                            <tr>
                                <td><span>商品：</span><asp:TextBox ID="txtPro" runat="server"></asp:TextBox>
                                    <input type="button" id="btnUsingPro" name="btnUsingPro" value="引用" /></td>
                                <td><span>价钱：</span><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
                                <td><span>数量：</span><asp:TextBox ID="txtCount" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td><span>供应商：</span><asp:TextBox ID="txtSupply" runat="server"></asp:TextBox>
                                    <input type="button" id="btnUsingSupply" name="btnUsingSupply" value="引用" />
                                </td>
                                <td>
                                    <asp:TextBox ID="ProID" runat="server" style="display:none;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td><span>描述：</span><asp:TextBox ID="txtDesc" runat="server" ></asp:TextBox>
                                    <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /> </td>
                            </tr>
                        </table>
                       
                            <asp:GridView ID="GridViewMessage" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="ProductsID" HeaderText="商品编号" />
                                    <asp:BoundField DataField="ProductsName" HeaderText="商品名称" />
                                    <asp:BoundField DataField="SupplierName" HeaderText="供应商" />
                                    <asp:BoundField DataField="Quantity" HeaderText="数量" />
                                    <asp:BoundField DataField="Price" HeaderText="采购额" />
                                    <asp:BoundField DataField="Total" HeaderText="总金额" />
                                </Columns>
                </asp:GridView>                     
                    <%--</asp:Panel>--%>
                </table>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        $(function () {
            $("#DateTime1").datebox({
                required: true,
                width: 140
            });
            $("#btnUserHouse").click(function () {
                window.open('UsingHouse.aspx', '引用库区', 'height=500,width=400');
            });
            $("#btnUsingPro").click(function () {
                window.open('UsingProduct.aspx', '引用商品', 'height=550,width=600');
            })
            $("#btnUsingSupply").click(function () {
                window.open('UsingSupply.aspx', '引用供应商', 'height=500,width=400');
            })

        })
        function ttt() {
            $("#test").css("display", "block");
        }
    </script>
</body>
</html>
