<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsFiledWeb.aspx.cs" Inherits="WebApplication1.Sys.ProductsFiledWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="you">
        <div><a href="#">乐易拍信息系统</a>><a href="#">系统设置</a>><a href="ProductsWeb.aspx">商品资料</a>>图片上传</div>
        <br /><br /><br />
        <div>商品编号：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;上传附加图片</div>
        <br />
        <div>上传主要标志图片（每个商品只有一个）上传图片大小不超过2MB</div>
        <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button1" runat="server" Text="上传图片" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" Height="300"  Width="400" />
    </div>
    </form>
</body>
</html>
