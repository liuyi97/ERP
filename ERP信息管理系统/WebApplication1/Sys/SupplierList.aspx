<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="WebApplication1.Sys.SupplierList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table>
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>供应商编号：</td>
                            <td><%#Eval("SupplierID") %></td>
                            <td>供应商名称：</td>
                            <td><%#Eval("SupplierName") %></td>
                        </tr>
                        <tr>
                            <td>所属地区：</td>
                            <td><%#Eval("Area") %></td>
                            <td>邮政编码：</td>
                            <td><%#Eval("Postcode") %></td>
                        </tr>
                        <tr>
                            <td>通讯地址：</td>
                            <td><%#Eval("Address") %></td>
                            <td>联系人：</td>
                            <td><%#Eval("Linkman") %></td>
                        </tr>
                        <tr>
                            <td>联系电话：</td>
                            <td><%#Eval("Tel") %></td>
                            <td>企业网址：</td>
                            <td><%#Eval("WebUrl") %></td>
                        </tr>
                        <tr>
                            <td>电子邮箱：</td>
                            <td><%#Eval("Email") %></td>
                            <td>汇款银行：</td>
                            <td><%#Eval("Bankname") %></td>
                        </tr>
                        <tr>
                            <td>汇款账户：</td>
                            <td><%#Eval("BankAccount") %></td>
                            <td>纳税号：</td>
                            <td><%#Eval("TaxNum") %></td>
                        </tr>
                        <tr>
                            <td>关系建立日：</td>
                            <td><%#Eval("CreateDate") %></td>
                            <td>备注：</td>
                            <td><%#Eval("Description") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
    </div>
    </form>
</body>
</html>
