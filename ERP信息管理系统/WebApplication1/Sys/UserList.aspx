<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="WebApplication1.Sys.UserList" %>

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
                            <td>用户名：</td>
                            <td><%#Eval("UserName") %></td>
                            <td>密码：</td>
                            <td><%#Eval("Password") %></td>
                        </tr>
                        <tr>
                            <td>用户一级类型：</td>
                            <td><%#Eval("TypeName") %></td>
                            <td>用户二级类型：</td>
                            <td><%#Eval("SubClassName") %></td>
                        </tr>
                        <tr>
                            <td>用户权限：</td>
                            <td><%#Eval("GroupName") %></td>
                            <td>真实姓名：</td>
                            <td><%#Eval("RealName") %></td>
                        </tr>
                        <tr>
                            <td>性别：</td>
                            <td><%#Eval("Sex") %></td>
                            <td>用户特征：</td>
                            <td><%#Eval("Dept") %></td>
                        </tr>
                        <tr>
                            <td>联系电话：</td>
                            <td><%#Eval("Tel") %></td>
                            <td>电子邮箱：</td>
                            <td><%#Eval("Email") %></td>
                        </tr>
                        <tr>
                            <td>QQ：</td>
                            <td><%#Eval("QQ") %></td>
                            <td>淘宝（旺旺）：</td>
                            <td><%#Eval("WangWang") %></td>
                        </tr>
                        <tr>
                            <td>公司名称：</td>
                            <td><%#Eval("CompanyName") %></td>
                            <td>部门：</td>
                            <td><%#Eval("CompanyInfo") %></td>
                        </tr>
                        <tr>
                            <td>公司状况：</td>
                            <td><%#Eval("Bankname") %></td>
                            <td>开户银行：</td>
                            <td><%#Eval("BankAccount") %></td>
                        </tr>
                        <tr>
                            <td>开户账号：</td>
                            <td><%#Eval("LatelyLogin") %></td>
                            <td>通讯地址：</td>
                            <td><%#Eval("Address") %></td>
                        </tr>
                        <tr>
                            <td>状态：</td>
                            <td><%#Eval("State") %></td>
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
