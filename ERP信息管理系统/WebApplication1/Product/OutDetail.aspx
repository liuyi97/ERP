<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutDetail.aspx.cs" Inherits="WebApplication1.Product.OutDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        * {
            text-decoration: none;
            list-style: none;

        }

        #big {
            width: 800px;
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

        #tabOne {
            width: 800px;
            border: 1px solid #4096ad;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="big">
            <div id="Detail">
                <h2 style="text-align: center;">出库明细单</h2>
                <table class="tiao" id="tabOne">
                    <tr>
                        <td><span>出库单号：</span><asp:TextBox ID="txtID" runat="server"></asp:TextBox></td>
                        <td><span>制单日期：</span><asp:TextBox ID="txtCreateDate" runat="server"></asp:TextBox></td>
                        <td><span>制单人：</span><asp:TextBox ID="txtPeople" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>库房库位：</span><asp:TextBox ID="txtHouse" runat="server"></asp:TextBox></td>
                        <td><span>合计金额：</span><asp:TextBox ID="txtTotal" runat="server"></asp:TextBox></td>
                        <td><span>状态：</span><asp:Label ID="txtState" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><span>出库日期：</span><asp:TextBox ID="txtTradeDate" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>备注：</span><asp:TextBox ID="txtDesc" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:GridView ID="GridViewDetail" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="ProductsID" HeaderText="商品编号" />
                        <asp:BoundField DataField="ProductsName" HeaderText="商品名称" />
                        <asp:BoundField DataField="SupplierName" HeaderText="供应商" />
                        <asp:BoundField DataField="Quantity" HeaderText="数量" />
                        <asp:BoundField DataField="Price" HeaderText="采购额" />
                        <asp:BoundField DataField="Total" HeaderText="总金额" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
