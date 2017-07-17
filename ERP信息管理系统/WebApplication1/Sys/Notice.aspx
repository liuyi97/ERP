<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="WebApplication1.Sys.Notice" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>>通知公告设置</div>
        <div>标题：&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div><br /><br />
        <div>信息类型：&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="0">通知</asp:ListItem>
            <asp:ListItem Value="1">热销</asp:ListItem>
            <asp:ListItem Value="2">内部会议</asp:ListItem>
            </asp:DropDownList></div>
        <h3>信息内容</h3>
        <div><asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="300" Height="100"></asp:TextBox></div><br />
        <asp:Button ID="Button1" runat="server" Text="发表" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
