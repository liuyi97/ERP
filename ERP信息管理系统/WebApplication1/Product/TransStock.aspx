<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransStock.aspx.cs" Inherits="WebApplication1.Product.TransStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../UI/jquery-1.8.3.min.js"></script>
    <script src="../UI/jquery.min.js"></script>
    <script src="../UI/jquery.easyui.min.js"></script>
    <link href="../UI/themes/icon.css" rel="stylesheet" />
    <link href="../UI/themes/default/easyui.css" rel="stylesheet" />
    <script src="../UI/locale/easyui-lang-zh_CN.js"></script>
<style type="text/css">
     * {
            text-decoration: none;
            list-style: none;

        }

        #big {
            width: 900px;
        }

        #Store {
            width: 900px;
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
            width: 100px;
            text-align: right;
        }

        .tiao td {
            padding-top: 20px;
        }

        .tiao td input[type="text"] {
            width: 160px;
        }

        #TabOne {
            width:900px;
            border:1px solid #4096ad;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="big">
        <div id="Store">
            <h2 style="text-align: center;">库存调拨</h2>
            <table class="tiao" id="TabOne">
                <tr>
                    <td><span>单号：</span><asp:TextBox ID="txtOrderID" runat="server" Enabled="false"></asp:TextBox></td>
                    <td><span>制单日期：</span><asp:TextBox ID="txtCreateDate" runat="server" Enabled="false"></asp:TextBox></td>
                    <td><span>经办人：</span><asp:TextBox ID="txtPeople" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><span>调出仓库分区：</span><asp:TextBox ID="txtOut" runat="server"></asp:TextBox>
                    <input type="button" id="btnOut" name="btnOut" value="引用" /></td>
                    <td><span>执行日期：</span>
                        <input id="DateTime3" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td><span>调入仓库分区：</span><asp:TextBox ID="txtInto" runat="server"></asp:TextBox>
                        <input type="button" id="btnInto" name="btnInto" value="引用" />
                    </td>
                    <td><span>票号：</span><asp:TextBox ID="txtID" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td><span>商品：</span><asp:TextBox ID="ProID" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtPro" runat="server" Style="display:none"></asp:TextBox>
                    <input type="button" id="btnUsingPro" name="btnUsingPro" value="引用" />
                        </td>
                    <td><span>数量：</span><asp:TextBox ID="txtBill" runat="server"></asp:TextBox></td>
                    <td><span>单价：</span><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td><span>备注：</span><asp:TextBox ID="txtDesc" runat="server"></asp:TextBox></td></tr>
                <tr><td style="float:left;margin-left:200px;"><asp:Button ID="btnSubmit" runat="server" Text="提交" Width="100px" OnClick="btnSubmit_Click" /></td></tr>
            </table>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#DateTime3").datebox({
                required: true,
                width: 154,
            });
            $("#btnOut").click(function () {
                window.open('UsingStore.aspx', '引用库区', 'height=500,width=400');
            });
            $("#btnInto").click(function () {
                window.open('StoreInto.aspx', '引用库区', 'height=500,width=400');
            });
            $("#btnUsingPro").click(function () {
                window.open('UsingProStock.aspx', '引用商品', 'height=550,width=600');
            })

        })
    </script>
</body>
</html>

