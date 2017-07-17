<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="WebApplication1.Sys.ProductsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>商品编号：</td>
                            <td><%#Eval("ProductsID") %></td>
                            <td>商品名称：</td>
                            <td><%#Eval("ProductsName") %></td>
                        </tr>
                        <tr>
                            <td>品牌：</td>
                            <td><%#Eval("BrandName") %></td>
                            <td>类型：</td>
                            <td><%#Eval("TypeName") %></td>
                        </tr>
                        <tr>
                            <td>单位：</td>
                            <td><%#Eval("ProductsUints") %></td>
                            <td>颜色：</td>
                            <td><%#Eval("Color") %></td>
                        </tr>
                        <tr>
                            <td>规格：</td>
                            <td><%#Eval("Spec") %></td>
                            <td>重量：</td>
                            <td><%#Eval("Weight") %></td>
                        </tr>
                        <tr>
                            <td>材质：</td>
                            <td><%#Eval("Material") %></td>
                            <td>销售价：</td>
                            <td><%#Eval("Price") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
