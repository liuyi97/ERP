<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingSupply.aspx.cs" Inherits="WebApplication1.Product.UsingSupply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCus" runat="server" Text="顾客名称："></asp:Label>
            <asp:TextBox ID="txtCus" runat="server"></asp:TextBox>
            <asp:Button ID="btnCheck" runat="server" Text="查询" OnClick="btnCheck_Click" />
            <asp:DataList ID="DLSupply" runat="server">
                <ItemTemplate>
                    <tr>
                        <td> <%#Eval("SupplierID") %></td>
                        <td><%#Eval("SupplierName") %></td>
                        <td> <%#Eval("Area") %></td>
                        <td>
                            <input type="button" data-id="<%#Eval("SupplierName") %>" onclick="supply(this)" value="选择" /></td> 
                    </tr>        
                </ItemTemplate>
            </asp:DataList>
        </div>

    </form>
    <script src="../Script/jquery.min.js"></script>
    <script type="text/javascript">
        function supply(i) {
            var val = i.getAttribute("data-id");
            window.opener.document.getElementById("txtSupply").value = val;
            window.close();
        }
    </script>
</body>
</html>
